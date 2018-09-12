using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XMLMYYP.UI.Interface;
using XMLMYYP.UI.Model;
using Dapper;


namespace XMLMYYP.UI.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private static IDbConnection db = null;

       public CategoryRepository(string strConn)
       {
            db = new SqlConnection(strConn);
        } 
        public List<Category> GetAllCategory()
        {
           List<Category> resCategory = db.Query<Category>(sql:"dbo.spSelXMLCategory", commandType: CommandType.StoredProcedure ) as List<Category>;
           return resCategory;  
        }

        public List<Category> GetAllCategoryBookCode(string strBookCode)
        {
           DynamicParameters dp = new DynamicParameters();
           dp.Add("BookCode", strBookCode);
           List<Category> resCategory = db.Query<Category>(sql:"dbo.spSelXMLCategory", param: dp, commandType: CommandType.StoredProcedure ) as List<Category>;
           return resCategory;
        }

        public List<string> GetAllBook()
        {
           List<string> resBook = db.Query<string>(sql:"dbo.spSelXMLBookAll", commandType: CommandType.StoredProcedure ) as List<string>;
           return resBook;
        }        
    }
}
