using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyFreeOrder
{
    public class PageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            List<ProductEntity> list = new List<ProductEntity>();

            var modelHtmlList = page.Selectable.XPath(".//div[@class='list']/ul[@class='fn-clear']/li[@class='carbox']").Nodes();

            foreach (var modelHtml in modelHtmlList)
            {

                ProductEntity entity = new ProductEntity();

                //entity.DetailUrl = modelHtml.XPath(".//a/@href").GetValue();

                //entity.CarImg = modelHtml.XPath(".//a/div[@class='carbox-carimg']/img/@src").GetValue();

                //var price = modelHtml.XPath(".//a/div[@class='carbox-info']").GetValue(DotnetSpider.Core.Selector.ValueOption.InnerText).Trim().Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty).TrimStart('¥').Split("¥");

                //entity.Title = modelHtml.XPath(".//a/div[@class='carbox-title']").GetValue();

                //entity.Tip = modelHtml.XPath(".//a/div[@class='carbox-tip']").GetValue();

                //entity.BuyNum = modelHtml.XPath(".//a/div[@class='carbox-number']/span").GetValue();

                list.Add(entity);

            }

            page.AddResultItem("CarList", list);

        }
    
    }
}
