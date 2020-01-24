#pragma checksum "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5d112c47d4de11a59813ec4982bc2305bd35855"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Car_AddNewCar), @"mvc.1.0.view", @"/Views/Car/AddNewCar.cshtml")]
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
#line 1 "D:\Program Files(VS)\Web Programs\Program_5\Views\_ViewImports.cshtml"
using Program_5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Program Files(VS)\Web Programs\Program_5\Views\_ViewImports.cshtml"
using Program_5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5d112c47d4de11a59813ec4982bc2305bd35855", @"/Views/Car/AddNewCar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f440a2ba6d4ed1629af0322fcd3440a657fc517", @"/Views/_ViewImports.cshtml")]
    public class Views_Car_AddNewCar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Program_5.ViewModels.IndexViewModel>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
  
    ViewData["Title"] = "Add new car";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
 using (Html.BeginForm("AddNewCar", "Car", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h2>Добавление нового автомобиля</h2><br>\r\n        <p>\r\n            <label for=\"brand\">Выберите существующий бренд: </label>\r\n            <select name=\"BrandId\" id=\"brand\"  >\r\n");
#nullable restore
#line 14 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
                 foreach (Brand brand in Model.Brands)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5d112c47d4de11a59813ec4982bc2305bd358554038", async() => {
#nullable restore
#line 16 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
                                         Write(brand.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
                       WriteLiteral(brand.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 17 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n        </p>\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 22 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.Label("name", "Название: "));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 23 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.TextBox("name","Tesla Model S"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 27 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.Label("power", "Мошность: "));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 28 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.TextBox("power", "", new { type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 32 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.Label("price", "Цена:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 33 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.TextBox("price", "", new { type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 37 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.Label("count", "Кол-во:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 38 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
       Write(Html.TextBox("count", "", new { type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>


        <span class=""col-md-offset-2 col-md-10"">
            <button type=""submit"" value=""Submit"" name=""Submit"">Добавить</button>
            <button type=""submit"" value=""Cancel"" name=""Cancel"">Отмена</button>
        </span>
    </div>
");
#nullable restore
#line 47 "D:\Program Files(VS)\Web Programs\Program_5\Views\Car\AddNewCar.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Program_5.ViewModels.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
