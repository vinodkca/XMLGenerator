using System;
using System.Collections.Generic;
using XMLMYYP.UI.DAL;
using XMLMYYP.UI.Model;

namespace XMLMYYP.UI.BAL
{
    public class ProfileService
    {                
        ProfileRepository profileRepo;
        DIADRepository diadRepo;
        public ProfileService()
        {
            profileRepo = new ProfileRepository(AppSetting.connPRODPROFILESQL);
            diadRepo = new DIADRepository(AppSetting.connDIADSQL);
        }
   
        public void GenerateProfileXML(string strBookCode)
        {
            string strProfilePath = $"SiteMap\\SM_Profile_{strBookCode}.xml";
            SiteMapGenerator gen = new SiteMapGenerator(strProfilePath);
            gen.WriteStartDocument();
            List<Profile> lstProfile = null;
            if(strBookCode == "XSEO")
            {
                lstProfile = GetAllProfileBookCodeByCities(strBookCode);
            }
            else{
                lstProfile = GetAllProfileBookCode(strBookCode);
            }
            foreach (var profile in lstProfile)
            {
                //string strLink = $"{AppSetting.myypUrl}/{profile.CityState}/{profile.CompanyName}/profile/{profile.ProfileID}";
                string strLink = $"{AppSetting.myypUrl}/{profile.CityState}/{profile.CompanyName}/profile";
                gen.WriteItem(strLink, DateTime.Now, "1.0");
            }
            gen.WriteEndDocument();
            gen.Close();
        }

        private List<Profile> GetAllProfileBookCode(string strBookCode)
        {
            return profileRepo.GetAllProfileBookCode(strBookCode);
        }

        private List<Profile> GetAllProfileBookCodeByCities(string strBookCode)
        {
            return diadRepo.GetAllProfileBookCode(strBookCode);
        }
    }
}
