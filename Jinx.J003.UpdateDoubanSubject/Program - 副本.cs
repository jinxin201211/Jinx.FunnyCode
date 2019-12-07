using HtmlAgilityPack;
using Newtonsoft.Json;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDoubanSubject
{
    class Program
    {
        public static string TaskName = "";
        static void Main(string[] args)
        {
            #region 过期

            //UpdateAllMovie();
            //GetDoubanIDFromTags();

            //ResetMovieIDRead();
            //GetAllMovie();

            //MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //foreach (var item in _db.Douban_Celebrity_ID)
            //{
            //    if (string.IsNullOrWhiteSpace(item.Movie))
            //        item.Read = false;
            //    else
            //        item.Read = true;
            //}
            //_db.SaveChanges();
            //GetCelebIDsMovieID();

            //GetMovieIDsFromCelebID();
            //GetCelebIdsFromMovie();

            //DecodeMovieCelebsID();


            //using (MovieWarehouseEntities _db = new MovieWarehouseEntities())
            //{
            //    foreach (var item in _db.Douban_Celebrity_ID)
            //    {
            //        string id = item.ID.ToString();
            //        if (_db.Douban_Celebrity_Info.Where(p => p.ID == id).Count() == 0)
            //            item.Read = false;
            //        else
            //            item.Read = true;
            //    }
            //    _db.SaveChanges();
            //}
            //Console.WriteLine("xxxxxxxx");
            //GetAllCeleb();

            //Celeb_ID 的 Name Name_Original
            //using (MovieWarehouseEntities model = new MovieWarehouseEntities())
            //{
            //    foreach (var item in model.Douban_Celebrity_ID)
            //    {
            //        string id = item.ID.ToString();
            //        MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //        var celeb = _db.Douban_Celebrity_Info.FirstOrDefault(p => p.ID == id);
            //        if (celeb != null)
            //        {
            //            var celebid = _db.Douban_Celebrity_ID.FirstOrDefault(p => p.ID == item.ID);
            //            celebid.Name = celeb.Name;
            //            celebid.Name_Original = celeb.Name_Original;
            //        }
            //        //Console.WriteLine(id);
            //        _db.SaveChanges();
            //    }
            //}

            //GetMoviesCelebID();

            #region 从电影中获取所有search
            //using (MovieWarehouseEntities model = new MovieWarehouseEntities())
            //{
            //    Parallel.ForEach(model.Douban_Movie_Info.Where(p => p.Directors.Contains("search")),
            //        item =>
            //        {
            //            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //            var ids = item.Directors.Split('/');
            //            for (int i = 0; i < ids.Length; i++)
            //            {
            //                if (ids[i].Contains("search"))
            //                {
            //                    string id = ids[i];
            //                    if (_db.Douban_Search_Celeb.Where(p => p.Keyword == id).Count() == 0)
            //                    {
            //                        _db.Douban_Search_Celeb.Add(new Douban_Search_Celeb { Keyword = ids[i].Replace("search", "") });
            //                    }
            //                }
            //            }
            //            _db.SaveChanges();
            //        });
            //    Parallel.ForEach(model.Douban_Movie_Info.Where(p => p.Writers.Contains("search")),
            //        item =>
            //        {
            //            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //            var ids = item.Writers.Split('/');
            //            for (int i = 0; i < ids.Length; i++)
            //            {
            //                if (ids[i].Contains("search"))
            //                {
            //                    string id = ids[i];
            //                    if (_db.Douban_Search_Celeb.Where(p => p.Keyword == id).Count() == 0)
            //                    {
            //                        _db.Douban_Search_Celeb.Add(new Douban_Search_Celeb { Keyword = ids[i].Replace("search", "") });
            //                    }
            //                }
            //            }
            //            _db.SaveChanges();
            //        });
            //    Parallel.ForEach(model.Douban_Movie_Info.Where(p => p.Casts.Contains("search")),
            //        item =>
            //        {
            //            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //            var ids = item.Casts.Split('/');
            //            for (int i = 0; i < ids.Length; i++)
            //            {
            //                if (ids[i].Contains("search"))
            //                {
            //                    string id = ids[i];
            //                    if (_db.Douban_Search_Celeb.Where(p => p.Keyword == id).Count() == 0)
            //                    {
            //                        _db.Douban_Search_Celeb.Add(new Douban_Search_Celeb { Keyword = ids[i].Replace("search", "") });
            //                    }
            //                }
            //            }
            //            _db.SaveChanges();
            //        });
            //}
            #endregion

            #region 获取Douban_Search_Celeb的豆瓣编号
            //using (MovieWarehouseEntities model = new MovieWarehouseEntities())
            //{
            //    foreach (var item in model.Douban_Search_Celeb.Where(p => !(bool)p.Read))
            //    {
            //        MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //        var search = _db.Douban_Search_Celeb.FirstOrDefault(p => p.ID == item.ID);
            //        #region 搜索影人
            //        string strCode = DownloadHtmlCode("https://movie.douban.com/celebrities/search?search_text=" + item.Keyword);
            //        HtmlDocument doc = new HtmlDocument();
            //        doc.LoadHtml(strCode);

            //        var resultItem = doc.DocumentNode.CssSelect("div.result").FirstOrDefault();
            //        if (resultItem != null)
            //        {
            //            var pic = resultItem.CssSelect("div.pic").FirstOrDefault();
            //            var nbg = pic.CssSelect("a.nbg").FirstOrDefault();
            //            string name_original = nbg.Attributes["title"].Value.Trim();
            //            string id = nbg.Attributes["href"].Value.Replace("https://movie.douban.com/celebrity/", "").Replace("/", "").Trim();
            //            var img = nbg.CssSelect("img").FirstOrDefault();
            //            string name = img.Attributes["alt"].Value;
            //            if (!string.IsNullOrWhiteSpace(name_original))
            //                name = name.Replace(name_original, "").Trim();
            //            if (name == search.Keyword || name_original == search.Keyword)
            //            {
            //                search.Douban = id;
            //                Console.WriteLine(search.Keyword + ":" + id);
            //            }
            //        }
            //        #endregion
            //        search.Read = true;
            //        _db.SaveChanges();
            //    }
            //}
            #endregion
            //GetMoviesCelebIDFromWeb();
            #endregion

            #region 一般更新电影流程 
            Console.WriteLine("Mission Satrt");
            //ResetMovieIDRatingCount();
            //Console.WriteLine("GetAllMovie Begin");
            //GetAllMovie();
            //Console.WriteLine("GetAllCelebrity Begin");
            //GetAllCeleb();
            //GetMovieCelebToJson();
            //GetMovieCelebToJsonParallel();
            //GetCelebIdsFromMovie();
            //Console.WriteLine("Start ResetCelebIDRead Mission");
            //ResetCelebIDRead();
            TaskName = "GetCelebIDsMovieID";
            GetCelebIDsMovieID();
            TaskName = "GetMovieIDsFromCelebID";
            GetMovieIDsFromCelebID();
            TaskName = "ResetMovieIDRead";
            ResetMovieIDRead();
            TaskName = "GetAllMovie";
            GetAllMovie();
            TaskName = "GetCelebIdsFromMovie";
            GetCelebIdsFromMovie();
            TaskName = "GetAllCeleb";
            GetAllCeleb();
            //Console.WriteLine(GetCelebrityMoviesNew("1274242"));
            Console.WriteLine("Mission Complete");
            Console.Read();
            #endregion
        }

        class MovieCelebItem
        {
            public string ID { get; set; } = "";
            public string Name { get; set; } = "";
        }

        #region 一次性
        private static void GetMovieCelebToJson()
        {
            string sssss = System.Web.HttpUtility.UrlDecode("subject_search?search_text=Quentin%20Tarantino/subject_search?search_text=Smashing%20Pumpkins");
            string[] asdasdas = sssss.Split('/');
            for (int i = 0; i < asdasdas.Length; i++)
            {
                Console.WriteLine(asdasdas[i].Substring(27));
            }

            using (MovieWarehouseEntities _db = new MovieWarehouseEntities())
            {
                //var listMovieID = _db.Douban_Movie_ID.Where(p => p.Read == false && p.ID == 1303764).OrderBy(p => p.ID).ToList();
                var listMovieID = _db.Douban_Movie_ID.Where(p => p.Read == false).OrderBy(p => p.ID).ToList();
                //Parallel.For(0, listMovieID.Count, i =>
                //{
                for (int i = 0; i < listMovieID.Count; i++)
                {
                    try
                    {
                        string id = listMovieID[i].ID.ToString();
                        var movie = _db.Douban_Movie_Info.Where(p => p.ID == id).FirstOrDefault();
                        if (movie != null)
                        {
                            {
                                List<MovieCelebItem> ListMovieDir = new List<MovieCelebItem>();
                                string dirs = movie.Directors;
                                if (!string.IsNullOrEmpty(dirs) && dirs.StartsWith("["))
                                {
                                    //Console.WriteLine(i + ":" + listMovieID[i].ID);
                                    //listMovieID[i].Read = true;
                                    //_db.SaveChanges();
                                    //continue;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(dirs))
                                    {
                                        string[] listDir = System.Web.HttpUtility.UrlDecode(dirs).Split('/');
                                        for (int j = 0; j < listDir.Length; j++)
                                        {
                                            int cid;
                                            MovieCelebItem movieCelebItem = new MovieCelebItem();
                                            if (int.TryParse(listDir[j], out cid))
                                            {
                                                var celeb = _db.Douban_Celebrity_Info.Where(p => p.ID == cid.ToString()).FirstOrDefault();
                                                if (celeb == null)
                                                {
                                                    movieCelebItem.ID = listDir[j];
                                                }
                                                else
                                                {
                                                    movieCelebItem.ID = listDir[j];
                                                    movieCelebItem.Name = celeb.Name;
                                                }
                                            }
                                            else
                                            {
                                                movieCelebItem.Name = listDir[j].Replace("subject_search?search_text=", "").Replace("search", "");
                                            }
                                            ListMovieDir.Add(movieCelebItem);
                                        }
                                        movie.Directors = JsonConvert.SerializeObject(ListMovieDir);
                                    }
                                }
                            }
                            {
                                List<MovieCelebItem> ListMovieWriter = new List<MovieCelebItem>();
                                string writers = movie.Writers;
                                if (!string.IsNullOrEmpty(writers) && writers.StartsWith("["))
                                {
                                    //Console.WriteLine(i + ":" + listMovieID[i].ID);
                                    //listMovieID[i].Read = true;
                                    //_db.SaveChanges();
                                    //continue;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(writers))
                                    {
                                        string[] listWriter = System.Web.HttpUtility.UrlDecode(writers).Split('/');
                                        for (int j = 0; j < listWriter.Length; j++)
                                        {
                                            int cid;
                                            MovieCelebItem movieCelebItem = new MovieCelebItem();
                                            if (int.TryParse(listWriter[j], out cid))
                                            {
                                                var celeb = _db.Douban_Celebrity_Info.Where(p => p.ID == cid.ToString()).FirstOrDefault();
                                                if (celeb == null)
                                                {
                                                    movieCelebItem.ID = listWriter[j];
                                                }
                                                else
                                                {
                                                    movieCelebItem.ID = celeb.ID;
                                                    movieCelebItem.Name = celeb.Name;
                                                }
                                            }
                                            else
                                            {
                                                movieCelebItem.Name = listWriter[j].Replace("subject_search?search_text=", "").Replace("search", "");
                                            }
                                            ListMovieWriter.Add(movieCelebItem);
                                        }
                                        movie.Writers = JsonConvert.SerializeObject(ListMovieWriter);
                                    }
                                }
                            }
                            {
                                List<MovieCelebItem> ListMovieCast = new List<MovieCelebItem>();
                                string casts = movie.Casts;
                                if (!string.IsNullOrEmpty(casts) && casts.StartsWith("["))
                                {
                                    //Console.WriteLine(i + ":" + listMovieID[i].ID);
                                    //listMovieID[i].Read = true;
                                    //_db.SaveChanges();
                                    //continue;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(casts))
                                    {
                                        string[] listCast = System.Web.HttpUtility.UrlDecode(casts).Split('/');
                                        for (int j = 0; j < listCast.Length; j++)
                                        {
                                            int cid;
                                            MovieCelebItem movieCelebItem = new MovieCelebItem();
                                            if (int.TryParse(listCast[j], out cid))
                                            {
                                                var celeb = _db.Douban_Celebrity_Info.Where(p => p.ID == cid.ToString()).FirstOrDefault();
                                                if (celeb == null)
                                                {
                                                    movieCelebItem.ID = listCast[j];
                                                }
                                                else
                                                {
                                                    movieCelebItem.ID = celeb.ID;
                                                    movieCelebItem.Name = celeb.Name;
                                                }
                                            }
                                            else
                                            {
                                                movieCelebItem.Name = listCast[j].Replace("subject_search?search_text=", "").Replace("search", "");
                                            }
                                            ListMovieCast.Add(movieCelebItem);
                                        }
                                        movie.Casts = JsonConvert.SerializeObject(ListMovieCast);
                                    }
                                }
                            }
                        }

                        listMovieID[i].Read = true;
                        _db.SaveChanges();
                        //Console.WriteLine(i + ":" + listMovieID[i].ID);
                        //System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(listMovieID[i].ID + ":" + e.Message);
                    }
                }
                //});
            }
        }

        private static void GetMovieCelebToJsonParallel()
        {
            using (MovieWarehouseEntities _db = new MovieWarehouseEntities())
            {
                var listMovie = _db.Douban_Movie_Info.Where(p => (!p.Directors.Contains("[") || (string.IsNullOrEmpty(p.Directors)) && (!p.Writers.Contains("[") || string.IsNullOrEmpty(p.Writers)) && (!p.Casts.Contains("[") || string.IsNullOrEmpty(p.Casts)))).OrderBy(p => p.ID).ToList();
                Console.WriteLine(listMovie.Count);
                //Parallel.For(0, listMovie.Count, i =>
                //{
                for (int i = 0; i < listMovie.Count; i++)
                {
                    try
                    {
                        {
                            List<MovieCelebItem> ListMovieDir = new List<MovieCelebItem>();
                            string dirs = listMovie[i].Directors;
                            if (!string.IsNullOrEmpty(dirs) && dirs.StartsWith("["))
                            {
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(dirs))
                                {
                                    string[] listDir = System.Web.HttpUtility.UrlDecode(dirs).Split('/');
                                    for (int j = 0; j < listDir.Length; j++)
                                    {
                                        int cid;
                                        MovieCelebItem movieCelebItem = new MovieCelebItem();
                                        if (int.TryParse(listDir[j], out cid))
                                        {
                                            var celeb = _db.Douban_Celebrity_Info.Where(p => p.ID == cid.ToString()).FirstOrDefault();
                                            if (celeb == null)
                                            {
                                                movieCelebItem.ID = listDir[j];
                                            }
                                            else
                                            {
                                                movieCelebItem.ID = listDir[j];
                                                movieCelebItem.Name = celeb.Name;
                                            }
                                        }
                                        else
                                        {
                                            movieCelebItem.Name = listDir[j].Replace("subject_search?search_text=", "").Replace("search", "");
                                        }
                                        ListMovieDir.Add(movieCelebItem);
                                    }
                                    listMovie[i].Directors = JsonConvert.SerializeObject(ListMovieDir);
                                }
                            }
                        }
                        {
                            List<MovieCelebItem> ListMovieWriter = new List<MovieCelebItem>();
                            string writers = listMovie[i].Writers;
                            if (!string.IsNullOrEmpty(writers) && writers.StartsWith("["))
                            {
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(writers))
                                {
                                    string[] listWriter = System.Web.HttpUtility.UrlDecode(writers).Split('/');
                                    for (int j = 0; j < listWriter.Length; j++)
                                    {
                                        int cid;
                                        MovieCelebItem movieCelebItem = new MovieCelebItem();
                                        if (int.TryParse(listWriter[j], out cid))
                                        {
                                            var celeb = _db.Douban_Celebrity_Info.Where(p => p.ID == cid.ToString()).FirstOrDefault();
                                            if (celeb == null)
                                            {
                                                movieCelebItem.ID = listWriter[j];
                                            }
                                            else
                                            {
                                                movieCelebItem.ID = celeb.ID;
                                                movieCelebItem.Name = celeb.Name;
                                            }
                                        }
                                        else
                                        {
                                            movieCelebItem.Name = listWriter[j].Replace("subject_search?search_text=", "").Replace("search", "");
                                        }
                                        ListMovieWriter.Add(movieCelebItem);
                                    }
                                    listMovie[i].Writers = JsonConvert.SerializeObject(ListMovieWriter);
                                }
                            }
                        }
                        {
                            List<MovieCelebItem> ListMovieCast = new List<MovieCelebItem>();
                            string casts = listMovie[i].Casts;
                            if (!string.IsNullOrEmpty(casts) && casts.StartsWith("["))
                            {
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(casts))
                                {
                                    string[] listCast = System.Web.HttpUtility.UrlDecode(casts).Split('/');
                                    for (int j = 0; j < listCast.Length; j++)
                                    {
                                        int cid;
                                        MovieCelebItem movieCelebItem = new MovieCelebItem();
                                        if (int.TryParse(listCast[j], out cid))
                                        {
                                            var celeb = _db.Douban_Celebrity_Info.Where(p => p.ID == cid.ToString()).FirstOrDefault();
                                            if (celeb == null)
                                            {
                                                movieCelebItem.ID = listCast[j];
                                            }
                                            else
                                            {
                                                movieCelebItem.ID = celeb.ID;
                                                movieCelebItem.Name = celeb.Name;
                                            }
                                        }
                                        else
                                        {
                                            movieCelebItem.Name = listCast[j].Replace("subject_search?search_text=", "").Replace("search", "");
                                        }
                                        ListMovieCast.Add(movieCelebItem);
                                    }
                                    listMovie[i].Casts = JsonConvert.SerializeObject(ListMovieCast);
                                }
                            }
                        }
                        if (i % 1000 == 0 || i == listMovie.Count - 1)
                        {
                            _db.SaveChanges();
                            Console.WriteLine("1000 达成");
                        }
                        Console.WriteLine(i + ":" + listMovie[i].ID);
                        //System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(listMovie[i].ID + ":" + e.Message);
                    }
                }
                //});
            }
        }

        //电影条目中没有ID的影人，在数据库中匹配出ID
        private static void GetMoviesCelebID()
        {
            //导演
            using (MovieWarehouseEntities _db = new MovieWarehouseEntities())
            {
                Parallel.ForEach(_db.Douban_Movie_Info.Where(p => p.Directors.Contains("search")), item =>
                {
                    MovieWarehouseEntities tempdb = new MovieWarehouseEntities();
                    var movie = tempdb.Douban_Movie_Info.FirstOrDefault(p => p.ID == item.ID);
                    string[] ids = movie.Directors.Split('/');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        if (ids[i].Contains("search"))
                        {
                            string keyword = ids[i].Replace("search", "");
                            var celeb = tempdb.Douban_Celebrity_ID.Where(p => p.Name == keyword || p.Name_Original == keyword);
                            if (celeb.Count() != 0)
                            {
                                ids[i] = celeb.FirstOrDefault().ID.ToString();
                            }
                        }
                    }
                    movie.Directors = string.Join("/", ids);
                    tempdb.SaveChanges();
                });
                Parallel.ForEach(_db.Douban_Movie_Info.Where(p => p.Writers.Contains("search")), item =>
                {
                    MovieWarehouseEntities tempdb = new MovieWarehouseEntities();
                    var movie = tempdb.Douban_Movie_Info.FirstOrDefault(p => p.ID == item.ID);
                    string[] ids = movie.Writers.Split('/');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        if (ids[i].Contains("search"))
                        {
                            string keyword = ids[i].Replace("search", "");
                            var celeb = tempdb.Douban_Celebrity_ID.Where(p => p.Name == keyword || p.Name_Original == keyword);
                            if (celeb.Count() != 0)
                            {
                                ids[i] = celeb.FirstOrDefault().ID.ToString();
                            }
                        }
                    }
                    movie.Writers = string.Join("/", ids);
                    tempdb.SaveChanges();
                });
                Parallel.ForEach(_db.Douban_Movie_Info.Where(p => p.Casts.Contains("search")), item =>
                {
                    MovieWarehouseEntities tempdb = new MovieWarehouseEntities();
                    var movie = tempdb.Douban_Movie_Info.FirstOrDefault(p => p.ID == item.ID);
                    string[] ids = movie.Casts.Split('/');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        if (ids[i].Contains("search"))
                        {
                            string keyword = ids[i].Replace("search", "");
                            var celeb = tempdb.Douban_Celebrity_ID.Where(p => p.Name == keyword || p.Name_Original == keyword);
                            if (celeb.Count() != 0)
                            {
                                ids[i] = celeb.FirstOrDefault().ID.ToString();
                            }
                        }
                    }
                    movie.Casts = string.Join("/", ids);
                    tempdb.SaveChanges();
                });
                //foreach (var item in _db.Douban_Movie_Info.Where(p => p.Directors.Contains("search")))
                //{
                //    MovieWarehouseEntities tempdb = new MovieWarehouseEntities();
                //    var movie = tempdb.Douban_Movie_Info.FirstOrDefault(p => p.ID == item.ID);
                //    string[] ids = movie.Directors.Split('/');
                //    for (int i = 0; i < ids.Length; i++)
                //    {
                //        if (ids[i].Contains("search"))
                //        {
                //            string keyword = ids[i].Replace("search", "");
                //            var celeb = tempdb.Douban_Celebrity_ID.Where(p => p.Name == keyword || p.Name_Original == keyword);
                //            if (celeb.Count() != 0)
                //            {
                //                ids[i] = celeb.FirstOrDefault().ID.ToString();
                //            }
                //        }
                //    }
                //    movie.Directors = string.Join("/", ids);
                //    tempdb.SaveChanges();
                //}
            }
        }

        //电影条目中没有ID的影人在豆瓣中查询匹配
        private static void GetMoviesCelebIDFromWeb()
        {
            using (MovieWarehouseEntities _db = new MovieWarehouseEntities())
            {
                foreach (var item in _db.Douban_Movie_Info.Where(p => p.Directors.Contains("search")))
                {
                    using (MovieWarehouseEntities tempdb = new MovieWarehouseEntities())
                    {
                        var movie = tempdb.Douban_Movie_Info.FirstOrDefault(p => p.ID == item.ID);
                        string[] ids = movie.Directors.Split('/');
                        bool hasChange = false;
                        for (int i = 0; i < ids.Length; i++)
                        {
                            if (ids[i].Contains("search"))
                            {
                                string keyword = ids[i].Replace("search", "");
                                ids[i] = keyword;
                                hasChange = true;

                                #region 搜索影人
                                string strCode = DownloadHtmlCode("https://movie.douban.com/celebrities/search?search_text=" + keyword);
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(strCode);

                                var resultItem = doc.DocumentNode.CssSelect("div.result").FirstOrDefault();
                                if (resultItem != null)
                                {
                                    var pic = resultItem.CssSelect("div.pic").FirstOrDefault();
                                    var nbg = pic.CssSelect("a.nbg").FirstOrDefault();
                                    string name_original = nbg.Attributes["title"].Value.Trim();
                                    string id = nbg.Attributes["href"].Value.Replace("https://movie.douban.com/celebrity/", "").Replace("/", "").Trim();
                                    var img = nbg.CssSelect("img").FirstOrDefault();
                                    string name = img.Attributes["alt"].Value;
                                    if (!string.IsNullOrWhiteSpace(name_original))
                                        name = name.Replace(name_original, "").Trim();
                                    if (name == keyword || name_original == keyword)
                                    {
                                        ids[i] = id;
                                        Console.WriteLine(movie.ID + ":" + keyword + ":" + id);
                                    }
                                }
                                #endregion

                                //var celeb = tempdb.Douban_Celebrity_ID.Where(p => p.Name == keyword || p.Name_Original == keyword);
                                //if (celeb.Count() != 0)
                                //{
                                //    ids[i] = celeb.FirstOrDefault().ID.ToString();
                                //}
                            }
                        }
                        movie.Directors = string.Join("/", ids);
                        if (hasChange)
                        {
                            tempdb.SaveChanges();
                        }

                    }
                }
            }
        }

        private static void DecodeMovieCelebsID()
        {
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            foreach (var item in _db.Douban_Movie_Info)
            {
                item.Directors = System.Web.HttpUtility.UrlDecode(item.Directors);
                item.Writers = System.Web.HttpUtility.UrlDecode(item.Writers);
                item.Casts = System.Web.HttpUtility.UrlDecode(item.Casts);
                //Console.WriteLine($"{item.Directors}   {item.Writers}  {item.Casts}");
            }
            _db.SaveChanges();
            Console.WriteLine("System.Web.HttpUtility.UrlDecode");
        }
        #endregion

        //获取所有影人的作品ID
        private static void GetCelebIDsMovieID()
        {
            using (MovieWarehouseEntities _db = new MovieWarehouseEntities())
            {
                //foreach (var item in _db.Douban_Celebrity_ID)
                //{
                //    item.Read = false;
                //    item.FZF = false;
                //}
                //_db.SaveChanges();
                foreach (var item in _db.Douban_Celebrity_ID.Where(p => p.Read == false))
                {
                    MovieWarehouseEntities _db2 = new MovieWarehouseEntities();
                    var celebid = _db2.Douban_Celebrity_ID.FirstOrDefault(p => p.ID == item.ID);
                    try
                    {
                        celebid.Movie = GetCelebrityMoviesNew(celebid.ID.ToString());
                        celebid.Read = true;
                        celebid.FZF = false;
                        Console.WriteLine("Complete:" + celebid.ID + "---" + celebid.Movie);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failed:" + celebid.ID);
                        celebid.Read = true;
                        celebid.FZF = true;
                    }
                    _db2.SaveChanges();
                }
            }
        }

        //从全部影人ID中获取所有电影ID
        private static void GetMovieIDsFromCelebID()
        {
            using (MovieWarehouseEntities _db = new MovieWarehouseEntities())
            {
                foreach (var item in _db.Douban_Celebrity_ID.Where(p => p.Read == false))
                {
                    if (string.IsNullOrWhiteSpace(item.Movie))
                        continue;
                    List<string> movies = item.Movie.Split('/').ToList();
                    MovieWarehouseEntities _db2 = new MovieWarehouseEntities();
                    foreach (var id in movies)
                    {
                        int sid = int.Parse(id);
                        if (_db2.Douban_Movie_ID.Where(p => p.ID == sid).Count() == 0)
                        {
                            _db2.Douban_Movie_ID.Add(new Douban_Movie_ID { ID = sid, Read = false, FZF = false });
                            Console.WriteLine("Add ID: " + id);
                        }
                    }
                    _db2.Douban_Celebrity_ID.FirstOrDefault(p => p.ID == item.ID).Read = true;
                    _db2.SaveChanges();
                }
            }
        }

        //重置电影读取状态
        private static void ResetMovieToNotRead()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            foreach (var item in _db.Douban_Movie_ID)
            {
                //Console.WriteLine(item.ID);
                item.FZF = false;
                item.Read = false;
            }
            _db.SaveChanges();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }

        //重置电影读取进度
        private static void ResetMovieIDRead()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            foreach (var item in _db.Douban_Movie_ID)
            {
                string id = item.ID.ToString();
                if (_db.Douban_Movie_Info.Where(p => p.ID == id).Count() == 0)
                {
                    item.Read = false;
                    item.FZF = false;
                }
                else
                {
                    item.Read = true;
                    item.FZF = false;
                }
            }
            _db.SaveChanges();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }

        private static void ResetMovieIDRatingCount()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            foreach (var item in _db.Douban_Movie_ID)
            {
                var movie = _db.Douban_Movie_Info.SingleOrDefault(p => p.ID == item.ID.ToString());
                if (movie != null)
                {
                    item.Rating_Count = movie.Rating_Count;
                }
            }
            _db.SaveChanges();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }

        //获取所有没有读取过的影人信息
        public static void GetAllCeleb()
        {
            bool EnableRead = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableRead"].ToString());
            bool EnableFZF = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableFZF"].ToString());
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //RemoteMovieWarehouseEntities _db = new RemoteMovieWarehouseEntities();
            var allCelebIds = _db.Douban_Celebrity_ID.Where(p => p.Read == EnableRead && p.FZF == EnableFZF).OrderBy(p => p.ID);
            foreach (var item in allCelebIds)
            {
                bool FZF = false;
                MovieWarehouseEntities _db2 = new MovieWarehouseEntities();
                //RemoteMovieWarehouseEntities _db2 = new RemoteMovieWarehouseEntities();
                Douban_Celebrity_Info celeb;
                try
                {
                    celeb = GetCelebrityInfo("https://movie.douban.com/celebrity/" + item.ID);
                }
                catch (Exception e)
                {
                    if (e.Message == "404")
                    {
                        FZF = true;
                    }
                    celeb = null;
                }

                if (celeb != null)
                {
                    celeb.ID = item.ID.ToString();
                    var doubanid = _db2.Douban_Celebrity_ID.FirstOrDefault(p => p.ID == item.ID);
                    doubanid.Read = true;
                    _db2.Configuration.ValidateOnSaveEnabled = false;
                    var hasCeleb = _db2.Douban_Celebrity_Info.FirstOrDefault(p => p.ID == celeb.ID);
                    if (hasCeleb == null)
                    {
                        _db2.Douban_Celebrity_Info.Add(celeb);
                    }
                    else
                    {
                        hasCeleb.Born_Place = celeb.Born_Place;
                        hasCeleb.Constellation = celeb.Constellation;
                        hasCeleb.Day_Birth = celeb.Day_Birth;
                        hasCeleb.Day_Death = celeb.Day_Death;
                        hasCeleb.Family_Member = celeb.Family_Member;
                        hasCeleb.Gender = celeb.Gender;
                        hasCeleb.ID = celeb.ID;
                        hasCeleb.Image = celeb.Image;
                        hasCeleb.IMDb = celeb.IMDb;
                        hasCeleb.Name = celeb.Name;
                        hasCeleb.Name_Aka = celeb.Name_Aka;
                        hasCeleb.Name_Aka_Original = celeb.Name_Aka_Original;
                        hasCeleb.Name_Original = celeb.Name_Original;
                        hasCeleb.Profession = celeb.Profession;
                        hasCeleb.Summary = celeb.Summary;
                        hasCeleb.Website = celeb.Website;
                    }
                    _db2.Configuration.ValidateOnSaveEnabled = false;
                    _db2.SaveChanges();
                    Console.WriteLine(item.ID);
                }
                else
                {
                    var doubanid = _db2.Douban_Celebrity_ID.FirstOrDefault(p => p.ID == item.ID);
                    doubanid.FZF = FZF;
                    _db2.SaveChanges();
                    Console.WriteLine("失败：" + item.ID);
                }
            }
        }

        //从所有电影中获取全部的影人ID
        public static void GetCelebIdsFromMovie()
        {
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            //List<Douban_Movie_Info> allmovie = _db.Douban_Movie_Info.Where(p => !string.IsNullOrEmpty(p.Directors) || !string.IsNullOrEmpty(p.Writers) || !string.IsNullOrEmpty(p.Casts)).ToList();
            List<Douban_Movie_Info> allmovie = _db.Douban_Movie_Info.Where(p => p.ID == "1303749").ToList();
            Console.WriteLine("总共电影" + allmovie.Count + "部");
            //Parallel.ForEach(allmovie, (item) =>
            //{
            int count = 0;
            foreach (var item in allmovie)
            {
                string[] listMovieCelebStr = new string[] { item.Directors, item.Writers, item.Casts };
                int number = 0;
                for (int i = 0; i < listMovieCelebStr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(listMovieCelebStr[i]))
                    {
                        List<MovieCelebItem> listCeleb = JsonConvert.DeserializeObject<List<MovieCelebItem>>(listMovieCelebStr[i]);
                        for (int j = 0; j < listCeleb.Count; j++)
                        {
                            if (!string.IsNullOrEmpty(listCeleb[j].ID))
                            {
                                number = int.Parse(listCeleb[j].ID);
                                if (_db.Douban_Celebrity_ID.Where(p => p.ID == number).Count() == 0)
                                {
                                    Douban_Celebrity_ID model = new Douban_Celebrity_ID();
                                    model.ID = number;
                                    model.Read = false;
                                    model.FZF = false;
                                    _db.Douban_Celebrity_ID.Add(model);
                                    _db.SaveChanges();
                                    SWLog.WriteLine($"[INFO][MESSAGE][{DateTime.Now}][{TaskName}][New Movie ID:{model.ID}]");
                                    SWLog.Flush();
                                    Console.WriteLine("Add:" + model.ID);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine((count++) + "\tMovie:" + item.ID + "\tFinish");
            }
            //});
            //for (int k = 0; k < allmovie.Count; k++)
            //{
            //}
            //foreach (var item in allmovie)
            //{
            #region OLD
            //MovieWarehouseEntities _db2 = new MovieWarehouseEntities();
            //string itemid = item.Directors;
            //int number = 0;
            //if (!string.IsNullOrEmpty(itemid))
            //{
            //    List<MovieCelebItem> listCeleb = JsonConvert.DeserializeObject<List<MovieCelebItem>>(itemid);
            //    for (int i = 0; i < listCeleb.Count; i++)
            //    {
            //        if (!string.IsNullOrEmpty(listCeleb[i].ID))
            //        {
            //            number = int.Parse(listCeleb[i].ID);
            //            if (_db.Douban_Celebrity_ID.Where(p => p.ID == number).Count() == 0)
            //            {
            //                Douban_Celebrity_ID model = new Douban_Celebrity_ID();
            //                model.ID = number;
            //                model.Read = false;
            //                model.FZF = false;
            //                _db.Douban_Celebrity_ID.Add(model);
            //                Console.WriteLine("Add:" + model.ID);
            //            }
            //        }
            //    }
            //    //foreach (var id in itemid.Split('/'))
            //    //{
            //    //    if (int.TryParse(id, out number) && _db2.Douban_Celebrity_ID.Where(p => p.ID == number).Count() == 0)
            //    //    {
            //    //        Douban_Celebrity_ID model = new Douban_Celebrity_ID();
            //    //        model.ID = int.Parse(id);
            //    //        model.Read = false;
            //    //        model.FZF = false;
            //    //        _db2.Douban_Celebrity_ID.Add(model);
            //    //        Console.WriteLine(model.ID);
            //    //        _db2.SaveChanges();
            //    //    }
            //    //}
            //}
            //itemid = item.Writers;
            //if (!string.IsNullOrEmpty(itemid))
            //{
            //    List<MovieCelebItem> listCeleb = JsonConvert.DeserializeObject<List<MovieCelebItem>>(itemid);
            //    for (int i = 0; i < listCeleb.Count; i++)
            //    {
            //        if (!string.IsNullOrEmpty(listCeleb[i].ID))
            //        {
            //            number = int.Parse(listCeleb[i].ID);
            //            if (_db.Douban_Celebrity_ID.Where(p => p.ID == number).Count() == 0)
            //            {
            //                Douban_Celebrity_ID model = new Douban_Celebrity_ID();
            //                model.ID = number;
            //                model.Read = false;
            //                model.FZF = false;
            //                _db.Douban_Celebrity_ID.Add(model);
            //                Console.WriteLine("Add:" + model.ID);
            //            }
            //        }
            //    }
            //    foreach (var id in itemid.Split('/'))
            //    {
            //        if (int.TryParse(id, out number) && _db2.Douban_Celebrity_ID.Where(p => p.ID == number).Count() == 0)
            //        {
            //            Douban_Celebrity_ID model = new Douban_Celebrity_ID();
            //            model.ID = int.Parse(id);
            //            model.Read = false;
            //            model.FZF = false;
            //            _db2.Douban_Celebrity_ID.Add(model);
            //            Console.WriteLine(model.ID);
            //            _db2.SaveChanges();
            //        }
            //    }
            //}
            //itemid = item.Casts;
            //if (!string.IsNullOrEmpty(itemid))
            //{
            //    foreach (var id in itemid.Split('/'))
            //    {
            //        if (int.TryParse(id, out number) && _db2.Douban_Celebrity_ID.Where(p => p.ID == number).Count() == 0)
            //        {
            //            Douban_Celebrity_ID model = new Douban_Celebrity_ID();
            //            model.ID = int.Parse(id);
            //            model.Read = false;
            //            model.FZF = false;
            //            _db2.Douban_Celebrity_ID.Add(model);
            //            Console.WriteLine(model.ID);
            //            _db2.SaveChanges();
            //        }
            //    }
            //}
            //_db2.SaveChanges();
            #endregion
            //    if (k % 1000 == 0 || k == allmovie.Count - 1)
            //    {
            //        _db.SaveChanges();
            //        Console.WriteLine("Save Changes");
            //    }
            //    Console.WriteLine(k + "\tMovie:" + allmovie[k].ID + "\tFinish");
            //}
        }

        //重置影人读取进度
        private static void ResetCelebIDRead()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            foreach (var item in _db.Douban_Celebrity_ID)
            {
                string id = item.ID.ToString();
                if (_db.Douban_Celebrity_Info.Where(p => p.ID == id).Count() == 0)
                {
                    item.Read = false;
                    item.FZF = false;
                }
                else
                {
                    item.Read = true;
                    item.FZF = false;
                }
            }
            _db.SaveChanges();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }

        //获取单个影人信息
        public static Douban_Celebrity_Info GetCelebrityInfo(string url)
        {
            string htmlCode = DownloadHtmlCode(url);
            if (string.IsNullOrWhiteSpace(htmlCode))
            {
                throw new Exception("404");
            }
            //StreamReader sr = new StreamReader("D://C1053623.html");
            //string htmlCode = sr.ReadToEnd();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlCode);
            Douban_Celebrity_Info celeb = new Douban_Celebrity_Info();
            celeb.Name = doc.DocumentNode.CssSelect("title").FirstOrDefault().InnerText.Replace("(豆瓣)", "").Trim();
            HtmlNode headlineNode = doc.DocumentNode.CssSelect("div#headline").FirstOrDefault();
            celeb.Name_Original = headlineNode.CssSelect("img").FirstOrDefault().Attributes["alt"].Value.Replace(celeb.Name, "").Trim();
            celeb.Image = headlineNode.CssSelect("img").FirstOrDefault().Attributes["src"].Value;

            HtmlNode infoNode = headlineNode.CssSelect("ul").FirstOrDefault();

            foreach (var item in infoNode.CssSelect("li"))
            {
                if (item.InnerHtml.Contains(">性别"))
                {
                    celeb.Gender = item.InnerText.Replace("性别:", "").Trim();
                }
                else if (item.InnerHtml.Contains(">星座"))
                {
                    celeb.Constellation = item.InnerText.Replace("星座:", "").Trim();
                }
                else if (item.InnerHtml.Contains(">出生日期"))
                {
                    celeb.Day_Birth = item.InnerText.Replace("出生日期:", "").Trim();
                }
                else if (item.InnerHtml.Contains(">生卒日期"))
                {
                    string str = item.InnerText.Replace("生卒日期:", "").Trim();
                    celeb.Day_Birth = str.Substring(0, str.IndexOf('至')).Trim();
                    celeb.Day_Death = str.Substring(str.IndexOf('至') + 1, str.Length - str.IndexOf('至') - 1).Trim();
                }
                else if (item.InnerHtml.Contains(">出生地"))
                {
                    celeb.Born_Place = item.InnerText.Replace("出生地:", "").Trim();
                }
                else if (item.InnerHtml.Contains(">职业"))
                {
                    string[] strs = item.InnerText.Replace("职业:", "").Trim().Split('/');
                    foreach (var str in strs)
                    {
                        celeb.Profession += str.Trim() + "/";
                    }
                    celeb.Profession = celeb.Profession.TrimEnd('/');
                }
                else if (item.InnerHtml.Contains(">更多外文名"))
                {
                    string[] strs = item.InnerText.Replace("更多外文名:", "").Trim().Split('/');
                    foreach (var str in strs)
                    {
                        celeb.Name_Aka_Original += str.Trim() + "/";
                    }
                    celeb.Name_Aka_Original = celeb.Name_Aka_Original.TrimEnd('/');
                }
                else if (item.InnerHtml.Contains(">更多中文名"))
                {
                    string[] strs = item.InnerText.Replace("更多中文名:", "").Trim().Split('/');
                    foreach (var str in strs)
                    {
                        celeb.Name_Aka += str.Trim() + "/";
                    }
                    celeb.Name_Aka = celeb.Name_Aka.TrimEnd('/');
                }
                else if (item.InnerHtml.Contains(">家庭成员"))
                {
                    string[] strs = item.InnerText.Replace("家庭成员:", "").Trim().Split('/');
                    foreach (var str in strs)
                    {
                        celeb.Family_Member += str.Trim() + "/";
                    }
                    celeb.Family_Member = celeb.Family_Member.TrimEnd('/');
                }
                else if (item.InnerHtml.Contains(">imdb编号"))
                {
                    celeb.IMDb = item.InnerText.Replace("imdb编号:", "").Trim();
                }
                else if (item.InnerHtml.Contains(">官方网站"))
                {
                    celeb.Website = item.InnerText.Replace("官方网站:", "").Trim();
                }
            }

            HtmlNode summaryNode = doc.DocumentNode.CssSelect("div#intro").FirstOrDefault().CssSelect("div.bd").FirstOrDefault();
            if (summaryNode.CssSelect("span.all").Count() != 0)
            {
                summaryNode = summaryNode.CssSelect("span.all").FirstOrDefault();
            }
            List<string> sums = new List<string>();
            foreach (var item in summaryNode.InnerHtml.Replace("<br>", "&").Replace("<br >", "&").Replace("<br />", "&").Split('&'))
            {
                sums.Add(item.Trim());
            }
            celeb.Summary = string.Join("\n", sums);

            return celeb;
        }

        //获取单个影人的作品
        public static string GetCelebrityMovies(string celeb)
        {
            string urlHead = "https://movie.douban.com/celebrity/" + celeb + "/movies";
            string url = urlHead + "?sortby=time";

            //MovieWarehouseEntities _db = new MovieWarehouseEntities();
            List<string> movieIds = new List<string>();
            while (!string.IsNullOrEmpty(url))
            {
                string htmlCode = DownloadHtmlCode(url);
                if (string.IsNullOrWhiteSpace(htmlCode))
                {
                    return string.Empty;
                }

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlCode);

                HtmlNode gridviewNode = doc.DocumentNode.CssSelect("div.grid_view").FirstOrDefault();

                var linkNodes = gridviewNode.CssSelect("a.nbg");
                foreach (var item in linkNodes)
                {
                    movieIds.Add(item.Attributes["href"].Value.Replace("https://movie.douban.com/subject/", "").Replace("/", ""));
                    //int id = int.Parse(item.Attributes["href"].Value.Replace("https://movie.douban.com/subject/", "").Replace("/", ""));
                    //if (_db.Douban_Movie_ID.Where(p => p.ID == id).Count() == 0)
                    //{
                    //    _db.Douban_Movie_ID.Add(new Douban_Movie_ID { ID = id, Read = false, FZF = false });
                    //    Console.WriteLine("Add Movie:" + id);
                    //}
                }

                HtmlNode paginatorNode = doc.DocumentNode.CssSelect("div.paginator").FirstOrDefault();
                if (paginatorNode != null && paginatorNode.CssSelect("span.next").FirstOrDefault().InnerHtml.Contains(">后页"))
                {
                    url = urlHead + paginatorNode.CssSelect("span.next").FirstOrDefault().CssSelect("link").FirstOrDefault().Attributes["href"].Value;
                }
                else
                {
                    url = string.Empty;
                }
            }
            //_db.SaveChanges();
            return string.Join("/", movieIds);
        }


        public static string GetCelebrityMoviesNew(string celeb)
        {
            string urlHead = "https://movie.douban.com/celebrity/" + celeb + "/movies";
            string url = urlHead + "?sortby=time&format=text&";

            List<string> movieIds = new List<string>();
            while (!string.IsNullOrEmpty(url))
            {
                string htmlCode = DownloadHtmlCode(url);
                if (string.IsNullOrWhiteSpace(htmlCode))
                {
                    return string.Empty;
                }

                HtmlDocument doc = new HtmlDocument();
                //doc.Load(@"D:\CUIT\C#.NET\GC_GatherCode\UpdateDoubanSubject\1274242.html");
                doc.LoadHtml(htmlCode);

                HtmlNode gridviewNode = doc.DocumentNode.CssSelect("div.list_view>table>tbody").FirstOrDefault();

                var linkNodes = gridviewNode.CssSelect("tr");
                //var linkNodes = gridviewNode.CssSelect("td[headers=m_name]");
                int year = 2018;
                foreach (var item in linkNodes)
                {
                    var m_name = item.CssSelect("td[headers=m_name]").FirstOrDefault();
                    if (m_name != null)
                    {
                        movieIds.Add(m_name.CssSelect("a").FirstOrDefault().Attributes["href"].Value.Replace("https://movie.douban.com/subject/", "").Replace("/", ""));
                    }
                    var mc_date = item.CssSelect("td[headers=mc_date]").FirstOrDefault();
                    if (mc_date != null)
                    {
                        year = int.Parse(mc_date.InnerText);
                    }
                }

                HtmlNode paginatorNode = doc.DocumentNode.CssSelect("div.paginator").FirstOrDefault();
                if (paginatorNode != null && paginatorNode.CssSelect("span.next").FirstOrDefault().InnerHtml.Contains(">后页"))
                {
                    url = urlHead + paginatorNode.CssSelect("span.next").FirstOrDefault().CssSelect("link").FirstOrDefault().Attributes["href"].Value;
                }
                else
                {
                    url = string.Empty;
                }
                if (year < 2016)
                {
                    break;
                }
                //break;
            }
            return string.Join("/", movieIds);
        }

        //获取所有没有读取过的电影信息
        public static void GetAllMovie()
        {
            bool EnableRead = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableRead"].ToString());
            bool EnableFZF = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableFZF"].ToString());
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            var allMovieIds = _db.Douban_Movie_ID.Where(p => p.Read == EnableRead && p.FZF == EnableFZF).OrderByDescending(p => p.Rating_Count);
            foreach (var item in allMovieIds)
            {
                bool FZF = false;
                MovieWarehouseEntities _db2 = new MovieWarehouseEntities();
                Douban_Movie_Info movie;
                try
                {
                    movie = GetMovieInfo("https://movie.douban.com/subject/" + item.ID);
                }
                catch (Exception e)
                {
                    if (e.Message == "404")
                    {
                        FZF = true;
                    }
                    movie = null;
                }

                if (movie != null)
                {
                    movie.ID = item.ID.ToString();
                    var doubanid = _db2.Douban_Movie_ID.FirstOrDefault(p => p.ID == item.ID);
                    doubanid.Read = true;
                    var doubaninfo = _db2.Douban_Movie_Info.FirstOrDefault(p => p.ID == movie.ID);
                    if (doubaninfo == null)
                    {
                        _db2.Douban_Movie_Info.Add(movie);
                    }
                    else
                    {
                        //doubaninfo.Title_Original = "@@@@@@@";
                        //doubaninfo = movie;
                        doubaninfo.Casts = movie.Casts;
                        doubaninfo.Countries = movie.Countries;
                        doubaninfo.Current_Season = movie.Current_Season;
                        doubaninfo.Directors = movie.Directors;
                        doubaninfo.Durations = movie.Durations;
                        doubaninfo.Episodes_Count = movie.Episodes_Count;
                        doubaninfo.Genres = movie.Genres;
                        doubaninfo.ID = movie.ID;
                        doubaninfo.Image = movie.Image;
                        doubaninfo.IMDb = movie.IMDb;
                        doubaninfo.Languages = movie.Languages;
                        doubaninfo.Pubdates = movie.Pubdates;
                        doubaninfo.Rating = movie.Rating;
                        doubaninfo.Rating_Count = movie.Rating_Count;
                        doubaninfo.Seasons_Count = movie.Seasons_Count;
                        doubaninfo.Star_1 = movie.Star_1;
                        doubaninfo.Star_2 = movie.Star_2;
                        doubaninfo.Star_3 = movie.Star_3;
                        doubaninfo.Star_4 = movie.Star_4;
                        doubaninfo.Star_5 = movie.Star_5;
                        doubaninfo.Summary = movie.Summary;
                        doubaninfo.Title = movie.Title;
                        doubaninfo.Title_Aka = movie.Title_Aka;
                        doubaninfo.Title_Original = movie.Title_Original;
                        doubaninfo.Website = movie.Website;
                        doubaninfo.Writers = movie.Writers;
                        doubaninfo.Year = movie.Year;
                    }
                    _db2.Configuration.ValidateOnSaveEnabled = false;
                    _db2.SaveChanges();
                    Console.WriteLine(item.ID);
                }
                else
                {
                    var doubanid = _db2.Douban_Movie_ID.FirstOrDefault(p => p.ID == item.ID);
                    doubanid.FZF = FZF;
                    _db2.SaveChanges();
                    Console.WriteLine("失败：" + item.ID);
                }
            }
        }

        //更新所有没有读取过的电影信息
        public static void UpdateAllMovie()
        {
            MovieWarehouseEntities _db = new MovieWarehouseEntities();
            var allMovieIds = _db.Douban_Movie_ID.Where(p => p.Read == false && p.FZF == false).Take(10);
            foreach (var item in allMovieIds)
            {
                bool FZF = false;
                MovieWarehouseEntities _db2 = new MovieWarehouseEntities();
                Douban_Movie_Info movie;
                try
                {
                    movie = GetMovieInfo("https://movie.douban.com/subject/" + item.ID);
                }
                catch (Exception e)
                {
                    if (e.Message == "404")
                    {
                        FZF = true;
                    }
                    movie = null;
                }

                if (movie != null)
                {
                    movie.ID = item.ID.ToString();
                    var doubanid = _db2.Douban_Movie_ID.FirstOrDefault(p => p.ID == item.ID);
                    doubanid.Read = true;
                    var moviechange = _db2.Douban_Movie_Info.FirstOrDefault(p => p.ID == movie.ID);
                    moviechange = movie;
                    _db2.Configuration.ValidateOnSaveEnabled = false;
                    _db2.SaveChanges();
                    Console.WriteLine(item.ID);
                }
                else
                {
                    var doubanid = _db2.Douban_Movie_ID.FirstOrDefault(p => p.ID == item.ID);
                    doubanid.FZF = FZF;
                    _db2.SaveChanges();
                    Console.WriteLine("失败：" + item.ID);
                }
            }
        }

        //获取单个电影信息
        public static Douban_Movie_Info GetMovieInfo(string url)
        {
            var htmlCode = DownloadHtmlCode(url);
            if (string.IsNullOrWhiteSpace(htmlCode))
            {
                throw new Exception("404");
            }
            //StreamReader sr = new StreamReader("D://M6560058.html");
            //string htmlCode = sr.ReadToEnd();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlCode);

            Douban_Movie_Info movie = new Douban_Movie_Info();
            movie.Title = doc.DocumentNode.CssSelect("title").FirstOrDefault().InnerText.Replace("(豆瓣)", "").Trim();
            if (movie.Title == "条目不存在")
            {
                throw new Exception("404");
            }

            HtmlNode nodeMainpic = doc.DocumentNode.CssSelect("div#mainpic").FirstOrDefault();
            movie.Image = nodeMainpic.CssSelect("img").FirstOrDefault().Attributes["src"].Value;

            HtmlNode nodeContent = doc.DocumentNode.CssSelect("div#content").FirstOrDefault();
            movie.Title_Original = nodeContent.CssSelect("span[property='v:itemreviewed']").FirstOrDefault().InnerText.Replace(movie.Title, "").Trim();
            if (nodeContent.CssSelect("span.year").Count() != 0)
            {
                movie.Year = nodeContent.CssSelect("span.year").FirstOrDefault().InnerText.Replace("(", "").Replace(")", "");
            }

            HtmlNode nodeRatingSelf = doc.DocumentNode.CssSelect("div.rating_self").FirstOrDefault();
            if (nodeRatingSelf != null)
            {
                movie.Rating = nodeRatingSelf.CssSelect("strong").FirstOrDefault().InnerText;
                if (nodeRatingSelf.CssSelect("span[property='v:votes']").Count() != 0)
                {
                    movie.Rating_Count = int.Parse(nodeRatingSelf.CssSelect("span[property='v:votes']").FirstOrDefault().InnerText);
                }
                if (doc.DocumentNode.CssSelect("div.ratings-on-weight").Count() != 0)
                {
                    var nodeRatingWeight = doc.DocumentNode.CssSelect("div.ratings-on-weight").FirstOrDefault().CssSelect("div.item").ToArray();
                    if (nodeRatingWeight.Count() != 0)
                    {
                        movie.Star_5 = nodeRatingWeight[0].CssSelect("span.rating_per").FirstOrDefault().InnerText;
                        movie.Star_4 = nodeRatingWeight[1].CssSelect("span.rating_per").FirstOrDefault().InnerText;
                        movie.Star_3 = nodeRatingWeight[2].CssSelect("span.rating_per").FirstOrDefault().InnerText;
                        movie.Star_2 = nodeRatingWeight[3].CssSelect("span.rating_per").FirstOrDefault().InnerText;
                        movie.Star_1 = nodeRatingWeight[4].CssSelect("span.rating_per").FirstOrDefault().InnerText;
                    }
                }
            }

            HtmlNode nodeRelatedInfo = doc.DocumentNode.CssSelect("div.related-info").FirstOrDefault();
            if (nodeRelatedInfo.CssSelect("span").Count() != 0)
            {
                HtmlNode nodeSummary;
                if (nodeRelatedInfo.CssSelect("span.all").Count() != 0)
                {
                    nodeSummary = doc.DocumentNode.CssSelect("span.all").FirstOrDefault();
                }
                else
                {
                    nodeSummary = doc.DocumentNode.CssSelect("span[property='v:summary']").FirstOrDefault();
                }
                List<string> sums = new List<string>();
                foreach (var item in nodeSummary.InnerHtml.Replace("<br>", "&").Replace("<br >", "&").Replace("<br />", "&").Split('&'))
                {
                    sums.Add(item.Trim());
                }
                movie.Summary = string.Join("\n", sums);
            }

            HtmlNode nodeInfo = doc.DocumentNode.CssSelect("div#info").FirstOrDefault();
            foreach (var item in nodeInfo.InnerHtml.Split('\n'))
            {
                if (item.Contains(">导演"))
                {
                    HtmlDocument docInfo = new HtmlDocument();
                    docInfo.LoadHtml(item);
                    List<MovieCelebItem> dirs = new List<MovieCelebItem>();
                    foreach (var itemdir in docInfo.DocumentNode.CssSelect("a"))
                    {
                        string hrefVal = itemdir.Attributes["href"].Value;
                        if (hrefVal.Contains("celebrity"))
                        {
                            dirs.Add(new MovieCelebItem() { Name = itemdir.InnerText.Trim(), ID = itemdir.Attributes["href"].Value.Replace("celebrity", "").Replace("/", "") });
                        }
                        else
                        {
                            dirs.Add(new MovieCelebItem() { Name = itemdir.InnerText.Trim(), ID = "" });
                        }
                    }
                    movie.Directors = JsonConvert.SerializeObject(dirs); //string.Join("/", dirs);
                }
                else if (item.Contains(">编剧"))
                {
                    HtmlDocument docInfo = new HtmlDocument();
                    docInfo.LoadHtml(item);
                    List<MovieCelebItem> writers = new List<MovieCelebItem>();
                    foreach (var itemwriter in docInfo.DocumentNode.CssSelect("a"))
                    {
                        string hrefVal = itemwriter.Attributes["href"].Value;
                        if (hrefVal.Contains("celebrity"))
                        {
                            writers.Add(new MovieCelebItem() { Name = itemwriter.InnerText.Trim(), ID = itemwriter.Attributes["href"].Value.Replace("celebrity", "").Replace("/", "") });
                        }
                        else
                        {
                            writers.Add(new MovieCelebItem() { Name = itemwriter.InnerText.Trim(), ID = "" });
                        }
                    }
                    movie.Writers = JsonConvert.SerializeObject(writers); //string.Join("/", writers);
                }
                else if (item.Contains(">主演"))
                {
                    HtmlDocument docInfo = new HtmlDocument();
                    docInfo.LoadHtml(item);
                    List<MovieCelebItem> casts = new List<MovieCelebItem>();
                    foreach (var itemcast in docInfo.DocumentNode.CssSelect("a"))
                    {
                        string hrefVal = itemcast.Attributes["href"].Value;
                        if (hrefVal.Contains("celebrity"))
                        {
                            casts.Add(new MovieCelebItem() { Name = itemcast.InnerText.Trim(), ID = hrefVal.Replace("celebrity", "").Replace("/", "") });
                        }
                        else
                        {
                            casts.Add(new MovieCelebItem() { Name = itemcast.InnerText.Trim(), ID = "" });
                        }
                    }
                    movie.Casts = JsonConvert.SerializeObject(casts); //string.Join("/", casts);
                }
                else if (item.Contains(">季数"))
                {
                    HtmlDocument docInfo = new HtmlDocument();
                    docInfo.LoadHtml(item);
                    List<string> seasons = new List<string>();
                    int seasoncount = 0;
                    if (docInfo.DocumentNode.CssSelect("option").Count() != 0)
                    {
                        movie.Seasons_Count = docInfo.DocumentNode.CssSelect("option").Count().ToString();
                        foreach (var itemseason in docInfo.DocumentNode.CssSelect("option"))
                        {
                            seasoncount++;
                            if (itemseason.Attributes["selected"] != null)
                            {
                                movie.Current_Season = seasoncount.ToString();
                            }
                        }
                    }
                    else
                    {
                        movie.Current_Season = docInfo.DocumentNode.InnerText.Replace("季数:", "").Trim();
                    }
                }
                else if (item.Contains(">官方网站"))
                {
                    HtmlDocument docInfo = new HtmlDocument();
                    docInfo.LoadHtml(item);
                    movie.Website = docInfo.DocumentNode.CssSelect("a").FirstOrDefault().Attributes["href"].Value;
                }
            }
            foreach (var item in nodeInfo.InnerText.Split('\n'))
            {
                if (item.Trim().Length == 0)
                    continue;
                else if (item.Contains("类型:"))
                {
                    List<string> genres = new List<string>();
                    foreach (var itemgenre in item.Replace("类型:", "").Split('/'))
                    {
                        genres.Add(itemgenre.Trim());
                    }
                    movie.Genres = string.Join("/", genres);
                }
                else if (item.Contains("制片国家/地区:"))
                {
                    List<string> genres = new List<string>();
                    foreach (var itemgenre in item.Replace("制片国家/地区:", "").Split('/'))
                    {
                        genres.Add(itemgenre.Trim());
                    }
                    movie.Countries = string.Join("/", genres);
                }
                else if (item.Contains("语言:"))
                {
                    List<string> genres = new List<string>();
                    foreach (var itemgenre in item.Replace("语言:", "").Split('/'))
                    {
                        genres.Add(itemgenre.Trim());
                    }
                    movie.Languages = string.Join("/", genres);
                }
                else if (item.Contains("首播:") || item.Contains("上映日期:"))
                {
                    List<string> genres = new List<string>();
                    foreach (var itemgenre in item.Replace("首播:", "").Replace("上映日期:", "").Split('/'))
                    {
                        genres.Add(itemgenre.Trim());
                    }
                    movie.Pubdates = string.Join("/", genres);
                }
                else if (item.Contains("单集片长:"))
                {
                    movie.Durations = item.Replace("单集片长:", "").Trim();
                    continue;
                }
                else if (item.Contains("片长:"))
                {
                    List<string> genres = new List<string>();
                    foreach (var itemgenre in item.Replace("片长:", "").Split('/'))
                    {
                        genres.Add(itemgenre.Trim());
                    }
                    movie.Durations = string.Join("/", genres);
                }
                else if (item.Contains("集数:"))
                {
                    movie.Episodes_Count = item.Replace("集数:", "").Trim();
                }
                else if (item.Contains("又名:"))
                {
                    movie.Title_Aka = item.Replace("又名:", "").Trim();
                }
                else if (item.Contains("IMDb链接:"))
                {
                    movie.IMDb = item.Replace("IMDb链接:", "").Trim();
                }
            }

            return movie;
        }

        public static void GetDoubanIDFromTags()
        {
            List<string> tags = new List<string>() { "戏剧" };

            foreach (var tag in tags)
            {
                string url = "https://movie.douban.com/tag/" + tag;

                if (tag == "纪录片")
                {
                    url = "https://movie.douban.com/tag/%E7%BA%AA%E5%BD%95%E7%89%87?start=3620&type=T";
                }

                int i = 0;
                while (!string.IsNullOrEmpty(url))
                {
                    var result = DownloadHtmlCode(url);

                    if (result.Contains("豆瓣上暂时还没有人给电影标注"))
                    {
                        break;
                    }
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(result);

                    HtmlNode root = doc.DocumentNode.CssSelect("div.article").FirstOrDefault().CssSelect("div").ToList()[2];

                    MovieWarehouseEntities _db = new MovieWarehouseEntities();
                    foreach (var item in root.CssSelect("table"))
                    {
                        HtmlNode movie = item.CssSelect("a").FirstOrDefault();
                        int doubanID = int.Parse(movie.Attributes["href"].Value.Replace("https://movie.douban.com/subject/", "").Replace("/", "").Trim());
                        if (_db.Douban_Movie_ID.Where(p => p.ID == doubanID).Count() == 0)
                        {
                            Console.WriteLine(doubanID);
                            _db.Douban_Movie_ID.Add(new Douban_Movie_ID() { ID = doubanID, Read = false });
                        }
                    }
                    _db.SaveChanges();

                    HtmlNode paginator = doc.DocumentNode.CssSelect("div.paginator").SingleOrDefault();
                    if (paginator != null && paginator.CssSelect("span.next").SingleOrDefault().InnerHtml.Contains("href"))
                    {
                        url = paginator.CssSelect("span.next").SingleOrDefault().CssSelect("a").SingleOrDefault().Attributes["href"].Value.Trim();
                    }
                    else
                    {
                        url = "";
                    }
                    Console.WriteLine("Page {0} Completed", ++i);
                }
                Console.WriteLine(tag + " Mission Complete");
            }
        }

        #region 网页
        public static string DoubanCookie = System.Configuration.ConfigurationManager.AppSettings["DoubanCookie"].ToString();
        public static int MaxRequestInterval = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxRequestInterval"].ToString());
        public static int MinRequestInterval = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MinRequestInterval"].ToString());
        public static bool EnableRandomCookie = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableRandomCookie"].ToString());
        public static int SleepTimeFor403 = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SleepTimeFor403"].ToString());
        public static string[] DoubanCookies = new string[] { };
        public static string First_403 = string.Empty;
        public static int ErrorCount = 0;
        public static StreamWriter SWLog = new StreamWriter(System.Environment.CurrentDirectory + "\\Log.txt", true);
        public static string DownloadHtmlCode(string url)
        {
            string ID = url.Replace("https://movie.douban.com/celebrity/", "").Replace("/movies?sortby=time&format=text&", "");
            try
            {
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
                myHttpWebRequest.Headers.Remove("Cookie");
                myHttpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                //myHttpWebRequest.Referer = "https://movie.douban.com/";
                myHttpWebRequest.ContentType = "text/html; charset=utf-8";

                var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (property != null)
                {
                    var collection = property.GetValue(myHttpWebRequest.Headers, null) as System.Collections.Specialized.NameValueCollection;
                    //collection["Cookie"] = DoubanCookies[new Random(Guid.NewGuid().GetHashCode()).Next(0, DoubanCookies.Length - 1)];
                    if (EnableRandomCookie)
                    {
                        collection["Cookie"] = string.Format("ll=\"{0}\"; bid=\"{1}\"; path=/; domain=.douban.com; expires=Sun, 10-Mar-2019 13:43:57 GMT", new Random(Guid.NewGuid().GetHashCode()).Next(100000, 200000), GetRandomString(11, true, true, true, false, ""));
                    }
                    else
                    {
                        collection["Cookie"] = DoubanCookie;
                    }
                }

                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    int interval = new Random(Guid.NewGuid().GetHashCode()).Next(MinRequestInterval, MaxRequestInterval);
                    System.Threading.Thread.Sleep(interval);
                    DownloadHtmlCode(url);
                }
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string fullhtml = System.Web.HttpUtility.HtmlDecode(sr.ReadToEnd());
                response.Close();
                sr.Close();
                return fullhtml;
            }
            catch (Exception e)
            {
                //SWLog.WriteLine(string.Format("[ERROR][EXCEPTION][{0}][{1}][{2}][{3}]", DateTime.Now, TaskName, ID, e.Message));
                SWLog.WriteLine($"[ERROR][EXCEPTION][{DateTime.Now}][{TaskName}][{ID}][{e.Message}]");
                Console.WriteLine(url + e.Message);
                if (e.Message == "远程服务器返回错误: (403) 已禁止。")
                {
                    if (string.IsNullOrWhiteSpace(First_403) || First_403.Trim().Length == 0)
                    {
                        First_403 = url;
                    }
                    Console.WriteLine("总共：" + ErrorCount);
                    Console.WriteLine("首个403的ID：" + First_403 + "," + DateTime.Now);
                    //SWLog.WriteLine(string.Format("[ERROR][403][{0}][{1}][本轮总共：{1}]", DateTime.Now, ErrorCount));
                    //SWLog.WriteLine(string.Format("[ERROR][403][{0}][{1}][首个403的ID：{1}]", DateTime.Now, First_403));
                    SWLog.WriteLine($"[ERROR][403][{DateTime.Now}][{TaskName}][本轮总共：{ErrorCount}]");
                    SWLog.WriteLine($"[ERROR][403][{DateTime.Now}][{TaskName}][首个403的ID：{First_403}]");
                    SWLog.Flush();
                    ErrorCount = 0;
                    System.Threading.Thread.Sleep(SleepTimeFor403);
                    //Console.Read();
                    return DownloadHtmlCode(url);
                }
                else
                {
                    //SWLog.WriteLine(string.Format("[ERROR][404][{0}][{1}]", DateTime.Now, ID));
                    SWLog.WriteLine($"[ERROR][404][{DateTime.Now}][{TaskName}][{ID}]");
                    SWLog.Flush();
                    return "";
                }
            }
            finally
            {
                ErrorCount++;
                int interval = new Random(Guid.NewGuid().GetHashCode()).Next(MinRequestInterval, MaxRequestInterval);
                //SWLog.WriteLine(string.Format("[INFO][SUCCESS][{0}][ErrorCount:{1}][{2}][等待：{3}]", DateTime.Now, ErrorCount, ID, interval));
                SWLog.WriteLine($"[INFO][SUCCESS][{ DateTime.Now}][{TaskName}][ErrorCount:{ErrorCount}][{ID}][等待：{interval}]");
                SWLog.Flush();
                System.Threading.Thread.Sleep(interval);
            }
        }

        #region 5.0 生成随机字符串 + static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        ///<summary>
        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
        #endregion
        #endregion
    }
}
