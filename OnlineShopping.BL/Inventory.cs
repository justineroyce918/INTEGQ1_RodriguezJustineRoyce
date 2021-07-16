using System;
using OnlineShoppingCommon;
using OnlineShopping.DL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShopping.BL.User;

namespace OnlineShopping.BL
{
    public class Inventory : Order
    {
        static public Common GetQuantities(string itemID)
        {
            var quant = DataConnection.GetItemQuantity(itemID);
            return new Common { ID = itemID,  Quantity = quant};
        }

        static public List<Common> GetAllItemQuantity()
        {
            return DataConnection.GetAllQuantity();
        }

        static public bool DecreaseQuantity(UserRole userrole, string itemID, int buyerQuantityNeeded)
        {
            var availableQuantity = GetQuantities(itemID).Quantity;

            if (availableQuantity >= buyerQuantityNeeded && userrole == UserRole.Buyer)
            {
                return DataConnection.UpdateItemQuantity(itemID, (availableQuantity - buyerQuantityNeeded)) > 0 ? true : false;   
            }
            else
            {
                return false;
            }
        }
        static public bool IfBuyerExixsts(String itemID)
        {
            var isFound = false;
            var allItemQuantity = GetAllItemQuantity();
            foreach (var quantitys in allItemQuantity)
            {
                if (quantitys.Quantity.Equals(itemID))
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }
    
    }
}
