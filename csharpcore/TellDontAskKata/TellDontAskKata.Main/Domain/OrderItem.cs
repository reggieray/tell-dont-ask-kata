using TellDontAskKata.Main.UseCase;
using TellDontAskKata.Main.Util;

namespace TellDontAskKata.Main.Domain
{
    public class OrderItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal TaxedAmount => DecimalHelper.Round(this.Product.UnitaryTaxedAmount * this.Quantity);
        public decimal Tax => DecimalHelper.Round(this.Product.UnitaryTax * this.Quantity);

        public OrderItem(Product product, int quantity)
        {
            this.Product = product ?? throw new UnknownProductException();
            this.Quantity = quantity;
        }
    }
}
