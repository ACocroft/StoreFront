using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Models
{
    public class CartItemViewModel
    {
        public int Qty { get; set; }

        public Wares Wares { get; set; }

        public CartItemViewModel(int qty, Wares wares)
        {
            Qty = qty;
            Wares = wares;
        }
    }
}
