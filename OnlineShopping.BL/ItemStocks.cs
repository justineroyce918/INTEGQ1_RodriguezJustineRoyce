using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.DL;
using OnlineShopping.BL;
using OnlineShoppingCommon;
using static OnlineShoppingCommon.Class1;

namespace OnlineShopping.BL
{
    public class ItemStocks
    {
        public Stocks GetTotalStock(int stocks)
            {
                var totalStock = DataConnection.GetItemStocks(stocks);
                return new Stocks { itemStock = stocks };
            }
    }
}
