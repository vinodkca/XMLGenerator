using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XMLMYYP.UI.Interface;
using XMLMYYP.UI.Model;
using Dapper;


namespace XMLMYYP.UI.DAL
{
    public class ProfileRepository: IProfileRepository
    {
       private static IDbConnection db = null;

       public ProfileRepository(string strConn)
       {
            db = new SqlConnection(strConn);
        } 
        public List<Profile> GetAllProfile()
        {
           List<Profile> resProfile = db.Query<Profile>(sql:"dbo.spSelXMLProfile", commandType: CommandType.StoredProcedure ) as List<Profile>;
           return resProfile;
        }

        public List<Profile> GetAllProfileBookCode(string strBookCode)
        {
           DynamicParameters dp = new DynamicParameters();
           dp.Add("BookCode", strBookCode);
           List<Profile> resProfile = db.Query<Profile>(sql:"dbo.spSelXMLProfile", param: dp, commandType: CommandType.StoredProcedure ) as List<Profile>;
           return resProfile;
        }

    }
}
