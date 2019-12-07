using Jinx.J001.ColorStatistics.Helper;
using Noesis.Drawing.Imaging.WebP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Jinx.J001.ColorStatistics.Controllers
{
    public class ImageColor
    {
        public string Color { get; set; }
        public int Amount { get; set; }
        public double Percent { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public static Color IntToColor(int color)
        {
            int R = color & 255;
            int G = (color & 65280) / 256;
            int B = (color & 16711680) / 65536;
            return Color.FromArgb(255, R, G, B);
        }

        /// <summary>
        /// 获取图片中各个颜色值的像素点个数
        /// </summary>
        /// <returns></returns>
        public ActionResult ColorStatistics()
        {
            string filePath = "https://img3.doubanio.com/view/photo/s_ratio_poster/public/p2507227732.webp";
            ViewBag.FilePath = "https://img3.doubanio.com/view/photo/s_ratio_poster/public/p2507227732.webp";
            
            //Bitmap bitmap = new Bitmap(filePath);//非webp图片
            //Bitmap bitmap = WebPFormat.LoadFromStream(new FileStream(filePath, FileMode.Open, FileAccess.Read));//本地webp图片

            //远程webp图片
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(filePath);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            Bitmap bitmap = WebPFormat.LoadFromStream(sr.BaseStream);
            resp.Close();
            sr.Close();
            List<Statistics.MajorColor> majorColor = Statistics.PrincipalColorAnalysis(bitmap, 10);
            List<ImageColor> result = new List<ImageColor>();
            int sum = 0;
            for (int i = 0; i < majorColor.Count; i++)
            {
                sum += majorColor[i].Amount;
                Color clr = IntToColor(majorColor[i].Color);
                result.Add(new ImageColor() { Color = clr.R.ToString("X2") + clr.G.ToString("X2") + clr.B.ToString("X2"), Amount = majorColor[i].Amount });
            }
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Percent = (double)result[i].Amount / sum;
            }
            return View(result);
        }


        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = true)]
        private static extern void CopyMemory(IntPtr Dest, IntPtr src, int Length); //  Marshal.Copy 居然没有从一个内存地址直接复制到另外一个内存的重载函数
        private IntPtr ImageCopyPointer, ImagePointer;
        private int DataLength;
        /// <summary>
        /// 图片添加高斯模糊效果
        /// </summary>
        /// <returns></returns>
        public ActionResult GaussianBlur()
        {
            ViewBag.FilePath = "LadyBird2017.png";
            ViewBag.GaussianBlur30 = "LadyBird2017Gaussian30.png";
            ViewBag.GaussianBlur40 = "LadyBird2017Gaussian40.png";
            ViewBag.GaussianBlur50 = "LadyBird2017Gaussian50.png";

            Bitmap bitmap = new Bitmap(Server.MapPath("../LadyBird2017.png"));

            //BitmapData BmpData = new BitmapData();
            //bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat, BmpData);  //  用原始格式LockBits,得到图像在内存中真正地址，这个地址在图像的大小，色深等未发生变化时，每次Lock返回的Scan0值都是相同的。
            //ImagePointer = BmpData.Scan0;                         //  记录图像在内存中的真正地址
            //DataLength = BmpData.Stride * BmpData.Height;         //  记录整幅图像占用的内存大小
            //ImageCopyPointer = Marshal.AllocHGlobal(DataLength);  //  直接用内存数据来做备份，AllocHGlobal在内部调用的是LocalAlloc函数
            //bitmap.UnlockBits(BmpData);

            CopyMemory(ImagePointer, ImageCopyPointer, DataLength); //  这里当然也可以用Bitmap的Clone方式来处理，但是我总认为直接处理内存数据比用对象的方式速度快。
            Rectangle Rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            bitmap.GaussianBlur(ref Rect, 30, false);
            bitmap.Save(Server.MapPath("../LadyBird2017Gaussian30.png"));
            bitmap = new Bitmap(Server.MapPath("../LadyBird2017.png"));
            bitmap.GaussianBlur(ref Rect, 40, false);
            bitmap.Save(Server.MapPath("../LadyBird2017Gaussian40.png"));
            bitmap = new Bitmap(Server.MapPath("../LadyBird2017.png"));
            bitmap.GaussianBlur(ref Rect, 50, false);
            bitmap.Save(Server.MapPath("../LadyBird2017Gaussian50.png"));
            return View();
        }
    }
}