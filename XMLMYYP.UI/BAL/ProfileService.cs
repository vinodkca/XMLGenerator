using System;
using System.Collections.Generic;
using XMLMYYP.UI.DAL;
using XMLMYYP.UI.Model;

namespace XMLMYYP.UI.BAL
{
    public class ProfileService
    {                
        ProfileRepository profileRepo;
        public ProfileService()
        {
            profileRepo = new ProfileRepository(AppSetting.connDIADSQL);
        }
   
        public void GenerateProfileXML(string strBookCode)
        {
            string strProfilePath = $"SiteMap\\SM_Profile_{strBookCode}.xml";
            SiteMapGenerator gen = new SiteMapGenerator(strProfilePath);
            gen.WriteStartDocument();
            List<Profile> lstProfile = GetAllProfileBookCode(strBookCode);
            foreach (var profile in lstProfile)
            {
                string strLink = $"{AppSetting.myypUrl}/{profile.CityState}/{profile.CompanyName}/profile/{profile.ProfileID}";
                gen.WriteItem(strLink, DateTime.Now, "1.0");
            }
            gen.WriteEndDocument();
            gen.Close();
        }

        private List<Profile> GetAllProfileBookCode(string strBookCode)
        {
            return profileRepo.GetAllProfileBookCode(strBookCode);
        }
    }
}
