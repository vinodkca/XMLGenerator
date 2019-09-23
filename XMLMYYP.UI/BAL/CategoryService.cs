using System;
using System.Collections.Generic;
using XMLMYYP.UI.DAL;
using XMLMYYP.UI.Model;

namespace XMLMYYP.UI.BAL
{
    public class CategoryService
    {
        // connection string to my SQL Server
        CategoryRepository catRepo = null;
        
        public CategoryService()
        {
            catRepo = new CategoryRepository(AppSetting.connPRODPROFILESQL);
        }

        public void GenerateCategoryXML(bool IsMap)
        {

            foreach (string strBookCode in catRepo.GetAllBook())
            {
                string strCategoryPath = !IsMap ? $"SiteMap\\SM_Category_{strBookCode}.xml" : $"SiteMap\\SM_Category_{strBookCode}_Map.xml";
                SiteMapGenerator gen = new SiteMapGenerator(strCategoryPath);
                //Console.WriteLine( "Book Code: {0}, City: {1},  Heading: {2}", cat.BookCode, cat.CityState, cat.HeadingName );
                gen.WriteStartDocument();
                List<Category> lstCategory = GetAllCategoryBookCode(strBookCode);
                foreach (var cat in lstCategory)
                {
                    string strLink = !IsMap ? $"{AppSetting.myypUrl}/{cat.CityState}/{cat.HeadingName}" : $"{AppSetting.myypUrl}/{cat.CityState}/{cat.HeadingName}/Map";
                    gen.WriteItem(strLink, DateTime.Now, "1.0");
                }
                gen.WriteEndDocument();
                gen.Close();
            }


            // List<Category> lstCategory =  GetAllCategory();
            // foreach(var cat in lstCategory)
            // {
            //Console.WriteLine( "Book Code: {0}, City: {1},  Heading: {2}", cat.BookCode, cat.CityState, cat.HeadingName );
            // }   
        }
        public void GenerateCategoryXML(bool IsMap, string strBookCode)
        {
            if (strBookCode == "ALL")
            {
                GenerateCategoryXML(IsMap);
                return;
            }
            else
            {
                string strCategoryPath = !IsMap ? $"SiteMap\\SM_Category_{strBookCode}.xml" : $"SiteMap\\SM_Category_{strBookCode}_Map.xml";
                SiteMapGenerator gen = new SiteMapGenerator(strCategoryPath);
                gen.WriteStartDocument();
                List<Category> lstCategory = GetAllCategoryBookCode(strBookCode);
                foreach (var cat in lstCategory)
                {
                    string strLink = !IsMap ? $"{AppSetting.myypUrl}/{cat.CityState}/{cat.HeadingName}" : $"{AppSetting.myypUrl}/{cat.CityState}/{cat.HeadingName}/Map";
                    gen.WriteItem(strLink, DateTime.Now, "1.0");
                }
                gen.WriteEndDocument();
                gen.Close();
            }
        }

        public List<Category> GetAllCategory()
        {
            return catRepo.GetAllCategory();
        }

        private List<Category> GetAllCategoryBookCode(string strBookCode)
        {
            return catRepo.GetAllCategoryBookCode(strBookCode);
        }

        public void ShowCategory()
        {
            List<Category> lstCategory = GetAllCategory();
            foreach (var cat in lstCategory)
            {
                Console.WriteLine("Book Code: {0}, City: {1},  Heading: {2}", cat.BookCode, cat.CityState, cat.HeadingName);
            }
        }


        public void ShowBooks()
        {
            foreach (string bookCode in catRepo.GetAllBook())
            {
                Console.Write($"{bookCode},");
            }
            Console.WriteLine("ALL");
        }
    }
}
