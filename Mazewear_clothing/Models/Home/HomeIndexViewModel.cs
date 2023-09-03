using Mazewear_clothing.DAL;
using Mazewear_clothing.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mazewear_clothing.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        MazewearEntities context = new MazewearEntities();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        public HomeIndexViewModel CreateModel(string search, int pageSize, int? page)
        {

            SqlParameter[] param = new SqlParameter[] {
                   new SqlParameter("@search", search??(object)DBNull.Value)
                   };
            IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize); 
            return new HomeIndexViewModel
            {
                ListOfProducts = data
            };
        }
    }
}