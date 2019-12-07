﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jinx.J003.UpdateDoubanSubject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MovieWarehouseEntities : DbContext
    {
        public MovieWarehouseEntities()
            : base("name=MovieWarehouseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Douban_Celeb_UpdateLog> Douban_Celeb_UpdateLog { get; set; }
        public virtual DbSet<Douban_Celebrity_ID> Douban_Celebrity_ID { get; set; }
        public virtual DbSet<Douban_Celebrity_Info> Douban_Celebrity_Info { get; set; }
        public virtual DbSet<Douban_Movie_Country> Douban_Movie_Country { get; set; }
        public virtual DbSet<Douban_Movie_Genre> Douban_Movie_Genre { get; set; }
        public virtual DbSet<Douban_Movie_ID> Douban_Movie_ID { get; set; }
        public virtual DbSet<Douban_Movie_Info> Douban_Movie_Info { get; set; }
        public virtual DbSet<Douban_Movie_Popular> Douban_Movie_Popular { get; set; }
        public virtual DbSet<Douban_Movie_UpdateLog> Douban_Movie_UpdateLog { get; set; }
        public virtual DbSet<Douban_People_Contact> Douban_People_Contact { get; set; }
        public virtual DbSet<Douban_People_ID> Douban_People_ID { get; set; }
        public virtual DbSet<Douban_Search_Celeb> Douban_Search_Celeb { get; set; }
        public virtual DbSet<Movie_Mine> Movie_Mine { get; set; }
        public virtual DbSet<Movie_Store> Movie_Store { get; set; }
    
        public virtual int P_SplitPagesQuery(string tablesName, string pK, string strSort, Nullable<int> sortType, string strWhere, string fields, Nullable<int> pageCurrent, Nullable<int> pageSize, ObjectParameter pageCount, ObjectParameter recordCount)
        {
            var tablesNameParameter = tablesName != null ?
                new ObjectParameter("TablesName", tablesName) :
                new ObjectParameter("TablesName", typeof(string));
    
            var pKParameter = pK != null ?
                new ObjectParameter("PK", pK) :
                new ObjectParameter("PK", typeof(string));
    
            var strSortParameter = strSort != null ?
                new ObjectParameter("StrSort", strSort) :
                new ObjectParameter("StrSort", typeof(string));
    
            var sortTypeParameter = sortType.HasValue ?
                new ObjectParameter("SortType", sortType) :
                new ObjectParameter("SortType", typeof(int));
    
            var strWhereParameter = strWhere != null ?
                new ObjectParameter("StrWhere", strWhere) :
                new ObjectParameter("StrWhere", typeof(string));
    
            var fieldsParameter = fields != null ?
                new ObjectParameter("Fields", fields) :
                new ObjectParameter("Fields", typeof(string));
    
            var pageCurrentParameter = pageCurrent.HasValue ?
                new ObjectParameter("PageCurrent", pageCurrent) :
                new ObjectParameter("PageCurrent", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_SplitPagesQuery", tablesNameParameter, pKParameter, strSortParameter, sortTypeParameter, strWhereParameter, fieldsParameter, pageCurrentParameter, pageSizeParameter, pageCount, recordCount);
        }
    
        public virtual int PROC_Douban_Movie_Pager(string strWhere, string strSort, Nullable<int> sortType, string fields, Nullable<int> pageCurrent, Nullable<int> pageSize, ObjectParameter pageCount, ObjectParameter recordCount)
        {
            var strWhereParameter = strWhere != null ?
                new ObjectParameter("StrWhere", strWhere) :
                new ObjectParameter("StrWhere", typeof(string));
    
            var strSortParameter = strSort != null ?
                new ObjectParameter("StrSort", strSort) :
                new ObjectParameter("StrSort", typeof(string));
    
            var sortTypeParameter = sortType.HasValue ?
                new ObjectParameter("SortType", sortType) :
                new ObjectParameter("SortType", typeof(int));
    
            var fieldsParameter = fields != null ?
                new ObjectParameter("Fields", fields) :
                new ObjectParameter("Fields", typeof(string));
    
            var pageCurrentParameter = pageCurrent.HasValue ?
                new ObjectParameter("PageCurrent", pageCurrent) :
                new ObjectParameter("PageCurrent", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PROC_Douban_Movie_Pager", strWhereParameter, strSortParameter, sortTypeParameter, fieldsParameter, pageCurrentParameter, pageSizeParameter, pageCount, recordCount);
        }
    
        public virtual int PROC_Mine_Movie_Pager(string strWhere, string strSort, Nullable<int> sortType, string fields, Nullable<int> pageCurrent, Nullable<int> pageSize, ObjectParameter pageCount, ObjectParameter recordCount)
        {
            var strWhereParameter = strWhere != null ?
                new ObjectParameter("StrWhere", strWhere) :
                new ObjectParameter("StrWhere", typeof(string));
    
            var strSortParameter = strSort != null ?
                new ObjectParameter("StrSort", strSort) :
                new ObjectParameter("StrSort", typeof(string));
    
            var sortTypeParameter = sortType.HasValue ?
                new ObjectParameter("SortType", sortType) :
                new ObjectParameter("SortType", typeof(int));
    
            var fieldsParameter = fields != null ?
                new ObjectParameter("Fields", fields) :
                new ObjectParameter("Fields", typeof(string));
    
            var pageCurrentParameter = pageCurrent.HasValue ?
                new ObjectParameter("PageCurrent", pageCurrent) :
                new ObjectParameter("PageCurrent", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PROC_Mine_Movie_Pager", strWhereParameter, strSortParameter, sortTypeParameter, fieldsParameter, pageCurrentParameter, pageSizeParameter, pageCount, recordCount);
        }
    }
}
