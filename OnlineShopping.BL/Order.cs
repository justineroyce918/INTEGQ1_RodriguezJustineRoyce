using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineShopping.BL
{
    public class Order
    {
        public Store Store { get; set; }

        public DateTime OrderedDate { get; set; }
        public string OrderID { get; set; }

    }
}
