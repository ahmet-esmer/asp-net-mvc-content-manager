using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{
    public interface ILanguageRepository
    {
        void Insert(SiteDil siteDil);
        IEnumerable<SiteDil> FindAll();
        IEnumerable<SiteDil> FindDropDownList();
        void Delete(int id);
        void State(int id, Boolean durum);
    }
}
