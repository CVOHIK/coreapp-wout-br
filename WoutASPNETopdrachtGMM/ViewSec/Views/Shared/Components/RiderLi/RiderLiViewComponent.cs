using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewSec.Views.Shared.Components.RiderLi
{
    public class RiderLiModel
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    /// <summary>Print a list item with the given rider item and the given value of the item</summary>
    /// <see cref="https://www.telerik.com/blogs/why-you-should-use-view-components-not-partial-views-aspnet-core"/>
    /// <seealso href="https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-2.2"/>
    public class RiderLiViewComponent : ViewComponent
    {
        public RiderLiViewComponent() { }
        public IViewComponentResult Invoke(string name, object value)
        {
            return View("Default", new RiderLiModel {
                Name = name,
                Value = value
            });
        }
    }
}
