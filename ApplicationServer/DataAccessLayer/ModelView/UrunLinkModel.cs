using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer.ModelView
{
    public class UrunLinkModel
    {

        public int KatId { get; set; }
        public int AnaId { get; set; }
        public int Sira { get; set; }
        public int UrunLink { get; set; }

        public int IcBaslikId { get; set; }
        public string IcBaslik { get; set; }
        public string Dil { get; set; }
        public string Link { get; set; }
        public string Serial { get; set; }
    }
}
