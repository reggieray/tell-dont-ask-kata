using System.Collections.Generic;

namespace TellDontAskKata.Main.Requests
{
    public class SellItemsRequest
    {
        public IList<SellItemRequest> Requests { get; set; }
    }
}
