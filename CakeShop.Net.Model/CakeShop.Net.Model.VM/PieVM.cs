using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Net.Model.VM
{
    public class PieVM
    {
        public Guid Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        public string ShortDescription
        {
            get;
            set;
        }
        public string LongDescription
        {
            get;
            set;
        }
        public string AllergyInformation
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public string ImageUrl
        {
            get;
            set;
        }
        public string ImageThumbnailUrl
        {
            get;
            set;
        }
        public bool IsPieOfTheWeek
        {
            get;
            set;
        }
        public bool InStock
        {
            get;
            set;
        }
    }
}
