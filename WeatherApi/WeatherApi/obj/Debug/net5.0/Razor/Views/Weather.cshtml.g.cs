#pragma checksum "D:\new\WeatherApi\WeatherApi\Views\Weather.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8a27db809620bda641dc0dae435b2603d031439"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Weather), @"mvc.1.0.view", @"/Views/Weather.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8a27db809620bda641dc0dae435b2603d031439", @"/Views/Weather.cshtml")]
    public class Views_Weather : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeatherApi.Models.Weather>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"container\">\r\n        <div class=\"form-group col-md-offset-3 col-md-5\">\r\n            <h2>Weather Forecast for the selected city</h2>\r\n\r\n            <label asp-for=\"Name\"></label>\r\n            <span class=\"badge\">");
#nullable restore
#line 9 "D:\new\WeatherApi\WeatherApi\Views\Weather.cshtml"
                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <br />\r\n\r\n            <label asp-for=\"Temp\"></label>\r\n            <span class=\"basge\">");
#nullable restore
#line 13 "D:\new\WeatherApi\WeatherApi\Views\Weather.cshtml"
                           Write(Model.Temp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <br />\r\n\r\n            <label asp-for=\"Humidity\"></label>\r\n            <span class=\"badge\">");
#nullable restore
#line 17 "D:\new\WeatherApi\WeatherApi\Views\Weather.cshtml"
                           Write(Model.Humidity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <br />\r\n\r\n            <label asp-for=\"Pressure\"></label>\r\n            <span class=\"basge\">");
#nullable restore
#line 21 "D:\new\WeatherApi\WeatherApi\Views\Weather.cshtml"
                           Write(Model.Pressure);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n            <br />\r\n\r\n            <label asp-for=\"Wind\"></label>\r\n            <span class=\"badge\">");
#nullable restore
#line 25 "D:\new\WeatherApi\WeatherApi\Views\Weather.cshtml"
                           Write(Model.Wind);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <br />\r\n\r\n            <label asp-for=\"Weater\"></label>\r\n            <span class=\"basge\">");
#nullable restore
#line 29 "D:\new\WeatherApi\WeatherApi\Views\Weather.cshtml"
                           Write(Model.Weater);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            <br />
        </div>
    </div>

    <div class=""container"">
        <div class=""form-group"" col-md-offset-3 col-md-5>
            <form method=""get"">
                <button asp-controller=""WeatherApi"" asp-action=""Search"" class=""btn btn-success"">Return</button>
            </form>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeatherApi.Models.Weather> Html { get; private set; }
    }
}
#pragma warning restore 1591
