using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Sample.Models;
using Kendo.Mvc.Extensions;

namespace Sample.Controllers
{
    public class GridController : Controller
    {
        public static List<OrderViewModel> orders = new List<OrderViewModel>();
        /// <summary>
        /// Create mocked up data
        /// </summary>
        public GridController()
        {
            if (orders.Count == 0)
            {
                for (int index = 1; index < 50; index++)
                {
                    orders.Add(new OrderViewModel()
                    {
                        OrderID = index,
                        Freight = index * 10,
                        OrderDate = new DateTime(DateTime.Now.Year, 9, 15).AddDays(index % 7),
                        ShipName = "ShipName " + index,
                        ShipCity = "ShipCity " + index
                    });
                }
            }
        }
        public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request)
        {
            var dsResult = orders.ToDataSourceResult(request);
            return Json(dsResult);
        }

        public ActionResult Orders_Update([DataSourceRequest]DataSourceRequest request, OrderViewModel order)
        {
            var dsResult = new[] { order}.ToDataSourceResult(request);
            return Json(dsResult);
        }
        public ActionResult Orders_Create([DataSourceRequest]DataSourceRequest request, OrderViewModel order)
        {
            order.OrderID = orders.Count + 1;
            var dsResult = new[] { order }.ToDataSourceResult(request);
            return Json(dsResult);
        }

    }
}
