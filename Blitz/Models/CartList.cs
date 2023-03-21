using System.Collections.Generic;

namespace Blitz.Models
{
    public class CartList
    {
        public static List<CartItem> cartlist = new List<CartItem>();
    }
    public class CartItem
    {
        public int iid;
        public int iqty;
    }
}
