using TellDontAskKata.Main.Util;

namespace TellDontAskKata.Main.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public decimal UnitaryTax => DecimalHelper.Round((this.Price / 100m) * this.Category.TaxPercentage);

        public decimal UnitaryTaxedAmount => DecimalHelper.Round(this.Price + UnitaryTax);
    }
}