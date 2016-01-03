using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{
    public interface IContactRepository
    {
        void Update(SiteIletisim iletisim);
        SiteIletisim Get();
    }
}
