using System;
using System.Collections.Generic;
using XMLMYYP.UI.BAL;


namespace XMLMYYP.UI
{
    
    class Program
    {
        private static CategoryService catService; 
        private static ProfileService profileService; 
        public static void Main(string[] args)
        {  
            InitializeService();

            catService.ShowBooks();           
            Console.WriteLine("Enter four Letter BookCode or ALL to generate sitemaps");                

            string strBookCode = Console.ReadLine();
            if(strBookCode.Length == 0) return;

            strBookCode = strBookCode.ToUpper();
            Console.WriteLine("BookCode entered in UPPERCASE is:" + strBookCode);  
                        
            GenerateAllCategoryXML(strBookCode);   
            GenerateAllProfileXML(strBookCode);     
        }

        private static void InitializeService()
        {
            catService = new CategoryService(); 
            profileService = new ProfileService();
        }
 
        private static void GenerateAllCategoryXML(string strBookCode)
        {
            Console.WriteLine($"START: Generating SM_Category for {strBookCode}");
            catService.GenerateCategoryXML(false, strBookCode);            
            Console.WriteLine($"END: Generating SM_Category for {strBookCode}");

            Console.WriteLine($"START: Generating SM_Category_Map for {strBookCode}");
            catService.GenerateCategoryXML(true, strBookCode);            
            Console.WriteLine($"END: Generating SM_Category_Map for {strBookCode}");
        }

        private static void GenerateAllProfileXML(string strBookCode)
        {
            Console.WriteLine($"START: Generating SM_Profile for {strBookCode}");
            profileService.GenerateProfileXML(strBookCode);            
            Console.WriteLine($"END: Generating  SM_Profile for {strBookCode}");
        }
    }
}
