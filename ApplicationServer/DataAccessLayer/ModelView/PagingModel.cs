using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer.ModelView
{
    public class PagingModel
    {
        public int TotolItem { get; set; }
        public int ViewItems { get; set; }
        
        public string Culture { get; set; }
        public string SearchKey { get; set; }


        private int curentPage;

        public int CurentPage
        {
            get {

                return curentPage; 
            }
            set {

                curentPage = value;

                if (this.ViewItems == 0)
                    this.ViewItems = 9;
             

                this.StartItem = (curentPage * this.ViewItems) +1;
                this.EndItem = this.StartItem + this.ViewItems - 1;
                
            }
        }

        public int StartItem { get; set; }
        public int EndItem { get; set; }

        public int IcBaslikId { get; set; }
     
    }
}
