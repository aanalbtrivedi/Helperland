#pragma checksum "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cd6733f98519cfeea9eb1057d5b2fe96db73e2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_NewServiceRequests), @"mvc.1.0.view", @"/Views/ServiceProvider/NewServiceRequests.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cd6733f98519cfeea9eb1057d5b2fe96db73e2b", @"/Views/ServiceProvider/NewServiceRequests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0b7d1a745096d44a7db9fa27b60361e187e3828", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_NewServiceRequests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HelperlandWebsite.ViewModels.NewServiceRequestsViewModels>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
  
    ViewData["Title"] = "NewServiceRequests";
    Layout = "~/Views/Shared/_LayoutSP.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>NewServiceRequests</h3>\r\n\r\n<div class=\"col-md-9\">\r\n\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 16 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayNameFor(model => model.ServiceRequestId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 19 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayNameFor(model => model.StartingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Customer Details\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 25 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayNameFor(model => model.Payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.ServiceRequestId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 39 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.ServiceHours));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.AddressLine1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 43 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.AddressLine2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 44 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 45 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.PostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
               Write(Html.DisplayFor(modelItem => item.Payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1693, "\"", 1739, 3);
            WriteAttributeValue("", 1703, "btnAcceptReq(", 1703, 13, true);
#nullable restore
#line 51 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
WriteAttributeValue("", 1716, item.ServiceRequestId, 1716, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1738, ")", 1738, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Accept</button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 54 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>
<script>
    function btnAcceptReq(x) {
        var dataAccept = {};
        var Id = x;
        dataAccept.ServiceRequestId = Id;
        alert(dataAccept.ServiceRequestId);

        $.ajax({
                url: '");
#nullable restore
#line 66 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\ServiceProvider\NewServiceRequests.cshtml"
                 Write(Url.Action("NewServiceRequests"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'post',
                data: dataAccept,
                success: function (response) {

                    if (response) {
                        location.reload();
                    }
                },
                failure: function (response) {
                    alert(""failure"");
                },
                error: function (response) {
                    location.reload();
                    $(""#errorMsg"").html(""Something wrong"");
                }
            })
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HelperlandWebsite.ViewModels.NewServiceRequestsViewModels>> Html { get; private set; }
    }
}
#pragma warning restore 1591
