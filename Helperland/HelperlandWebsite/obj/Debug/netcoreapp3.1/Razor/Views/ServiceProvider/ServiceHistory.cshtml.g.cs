#pragma checksum "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87071ef46c3fa77fd1c567c7686d66fda4d23ead"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_ServiceHistory), @"mvc.1.0.view", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
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
#line 1 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\_ViewImports.cshtml"
using HelperlandWebsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\_ViewImports.cshtml"
using HelperlandWebsite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87071ef46c3fa77fd1c567c7686d66fda4d23ead", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0b7d1a745096d44a7db9fa27b60361e187e3828", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_ServiceHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HelperlandWebsite.ViewModels.SPServiceHistoryViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
  
    ViewData["Title"] = "ServiceHistory";
    Layout = "~/Views/Shared/_LayoutSP.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>ServiceHistory</h3>\r\n\r\n<div class=\"col-md-9\">\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 15 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.ServiceRequestId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 18 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.StartingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Customer Details\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 31 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ServiceRequestId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
                   Write(Html.DisplayFor(modelItem => item.StartingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 35 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ServiceHours));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 38 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AddressLine1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 39 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AddressLine2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 40 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
                   Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 41 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\ServiceHistory.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HelperlandWebsite.ViewModels.SPServiceHistoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
