#pragma checksum "D:\Program Files(VS)\Web Programs\Web_task_4\Views\Home\show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff72f8020da14a80d49bc205cd7b2f15b5fee37f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_show), @"mvc.1.0.view", @"/Views/Home/show.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\_ViewImports.cshtml"
using Web_task_4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\_ViewImports.cshtml"
using Web_task_4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff72f8020da14a80d49bc205cd7b2f15b5fee37f", @"/Views/Home/show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbb6bb25324bde5c6a63d01d97f02d78b7a180a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Web_task_4.Models.Car>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\Home\show.cshtml"
  
    ViewData["Title"] = "About Perfume";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h3>Information</h3>
<table class=""table-condensed"" cellpadding=""15"" cellspacing=""15"">
    <tr>
        <td>Car</td>
        <td>Brand</td>
        <td>Price</td>
        <td>Engine power</td>
        <td>Number</td>
    </tr>


    <tr>
        <td>");
#nullable restore
#line 17 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\Home\show.cshtml"
       Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 18 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\Home\show.cshtml"
       Write(ViewBag.BrandName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 19 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\Home\show.cshtml"
       Write(ViewBag.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 20 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\Home\show.cshtml"
       Write(ViewBag.EnginePower);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 21 "D:\Program Files(VS)\Web Programs\Web_task_4\Views\Home\show.cshtml"
       Write(ViewBag.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Web_task_4.Models.Car>> Html { get; private set; }
    }
}
#pragma warning restore 1591
