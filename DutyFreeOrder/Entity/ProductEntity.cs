using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyFreeOrder
{
    public class ProductEntity
    {
        public string Brand { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string ProductNum { get; set; }

        public string PriceKr { get; set; }

        public string PriceUS { get; set; }

        public string BuyStatusName { get; set; }

        public string BuaStatus {
            set {
                if (BuyStatusName == "판매중")
                {
                    value = "sale";
                }
                else if (BuyStatusName == "일시품절")
                {
                    value = "saleout";
                }
                else
                {
                    value = "";
                }

            }
        }
    }
}
