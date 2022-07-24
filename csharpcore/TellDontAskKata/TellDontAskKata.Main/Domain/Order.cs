using System.Collections.Generic;
using System.Linq;
using TellDontAskKata.Main.UseCase;

namespace TellDontAskKata.Main.Domain
{
    public class Order
    {
        public decimal Total => this.Items.Sum(x => x.TaxedAmount);
        public string Currency { get; private set; } = "EUR";
        public IList<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public decimal Tax => this.Items.Sum(x => x.Tax);
        public OrderStatus Status { get; private set; } = OrderStatus.Created;
        public int Id { get; private set; }

        public Order()
        {
        }

        public Order(int id, OrderStatus status)
        {
            this.Id = id;
            this.Status = status;
        }

        public void Approve(bool approved)
        {
            if (this.CanApprove(approved))
            {
                this.Status = approved ? OrderStatus.Approved : OrderStatus.Rejected;
            }
        }

        public void Ship()
        {
            if (this.CanShip())
            {
                this.Status = OrderStatus.Shipped;
            }
        }

        private bool CanApprove(bool approved)
        {
            if (this.Status == OrderStatus.Shipped)
            {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (approved && this.Status == OrderStatus.Rejected)
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            if (!approved && this.Status == OrderStatus.Approved)
            {
                throw new ApprovedOrderCannotBeRejectedException();
            }

            return true;
        }

        private bool CanShip()
        {
            if (this.Status == OrderStatus.Created || this.Status == OrderStatus.Rejected)
            {
                throw new OrderCannotBeShippedException();
            }

            if (this.Status == OrderStatus.Shipped)
            {
                throw new OrderCannotBeShippedTwiceException();
            }

            return true;
        }
    }
}
