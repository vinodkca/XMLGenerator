using System.Collections.Generic;
using XMLMYYP.UI.Model;

namespace XMLMYYP.UI.Interface
{
    public interface ICategoryRepository
    {
       List<Category> GetAllCategory();
       List<Category> GetAllCategoryBookCode(string strBookCode);
    }
}