
namespace Store.Web.Models
{
    public class Cart
    {
       public int OrderId { get; }

        public int TotalCount { get; set; }
       
        public decimal TotalPrice { get; set; }


        public Cart(int orderid)
        {
            OrderId = orderid;
            TotalCount = 0;
            TotalPrice = 0m;
        }

    }
}
