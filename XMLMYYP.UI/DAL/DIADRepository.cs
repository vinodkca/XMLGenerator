using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XMLMYYP.UI.Interface;
using XMLMYYP.UI.Model;
using Dapper;


namespace XMLMYYP.UI.DAL
{
    public class DIADRepository: IProfileRepository
    {
       private static IDbConnection db = null;

       public DIADRepository(string strConn)
       {
            db = new SqlConnection(strConn);
        } 
        public List<Profile> GetAllProfile()
        {
           List<Profile> resProfile = db.Query<Profile>(sql:"dbo.spSelXMLProfileByCity", commandType: CommandType.StoredProcedure ) as List<Profile>;
           return resProfile;
        }

        public List<Profile> GetAllProfileBookCode(string strBookCode)
        {
           DynamicParameters dp = new DynamicParameters();
           dp.Add("BookCode", strBookCode);
           List<Profile> resProfile = db.Query<Profile>(sql:"dbo.spSelXMLProfileByCity", param: dp, commandType: CommandType.StoredProcedure ) as List<Profile>;
           return resProfile;
        }
    }
}
