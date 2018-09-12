using System.Collections.Generic;
using XMLMYYP.UI.Model;

namespace XMLMYYP.UI.Interface
{
    public interface IProfileRepository
    {
       List<Profile> GetAllProfile();
       List<Profile> GetAllProfileBookCode(string strBookCode);

    }
}