#pragma checksum "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c173c13fbc159b937355d8e09ccb19fe4494632"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerHistory), @"mvc.1.0.view", @"/Views/Customer/CustomerHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c173c13fbc159b937355d8e09ccb19fe4494632", @"/Views/Customer/CustomerHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0b7d1a745096d44a7db9fa27b60361e187e3828", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HelperlandWebsite.ViewModels.CustomerHistoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("modal-closer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-dismiss", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CustomerHistory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
  
    ViewData["Title"] = "CustomerHistory";
    ViewData["userName"] = @ViewBag.name;
    Layout = "~/Views/Shared/_LayoutCustomer.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>CustomerHistory</h3>\r\n\r\n<div class=\"col-md-9\" id=\"bgclrset\">\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 16 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.ServiceRequestId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 19 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.StartingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 22 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.ServiceHours));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 25 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.Payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 28 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.ServiceProviderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 31 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayFor(modelItem => item.ServiceRequestId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayFor(modelItem => item.ServiceHours));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayFor(modelItem => item.Payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 53 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
               Write(Html.DisplayFor(modelItem => item.ServiceProviderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 56 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                     if (item.Status == 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button class=\"btn btn-primary btncustDash\" disabled>Completed</button>\r\n");
#nullable restore
#line 59 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button class=\"btn btn-danger btncustDash\" disabled>Cancelled</button>\r\n");
#nullable restore
#line 63 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 66 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                     if (item.Status == 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2329, "\"", 2372, 3);
            WriteAttributeValue("", 2339, "btnRateSP(", 2339, 10, true);
#nullable restore
#line 68 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
WriteAttributeValue("", 2349, item.ServiceRequestId, 2349, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2371, ")", 2371, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Rate SP</button>\r\n");
#nullable restore
#line 69 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button class=\"btn btn-primary\" disabled>Rate SP</button>\r\n");
#nullable restore
#line 73 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            WriteLiteral(@"            <div id=""SPRste"" class=""reschedule"">
                <div class=""modal-dialog vertical-align-center modal-sm"">
                    <div class=""modal-content"">
                        <div class=""modal-body formclass"">
                            <p>
                                <strong>
                                    ");
#nullable restore
#line 83 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 84 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                               Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </strong>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c173c13fbc159b937355d8e09ccb19fe449463213334", async() => {
                WriteLiteral("\r\n                                    Close\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </p>
                            <p class=""rateSP""><span class=""stars""></span></p>
                            
                            <h2 class=""modal-title"">Rate your service provider</h2>
                            <hr />
                            <label>
                                On time arrival
                                <input type=""text"" class=""form-control rateSP"" id=""inptstar1"" />
                                <p class=""rateSP""><span class=""stars1""></span></p>
                            </label>
                            <label>
                                Friendly
                                <input type=""text"" class=""form-control rateSP"" id=""inptstar2"" />
                                <p class=""rateSP""><span class=""stars2""></span></p>
                            </label>
                            <label>
                                Quality of Service
                                <input type=""text"" class=""form-c");
            WriteLiteral(@"ontrol rateSP"" id=""inptstar3"" />
                                <p class=""rateSP""><span class=""stars3""></span></p>
                            </label>
                            <label>
                                Feedback on service provider
                                <textarea class=""btncustDash"" id=""cmnt""></textarea>
                            </label>
                            <button type=""button"" class=""btn btn-primary"" name=""stars"" onclick=""starsnew()"">
                                stars
                            </button>
                            <button onclick=""saveRatings()"" class=""btn btn-primary"">Done</button>
                            <p class=""text-info fornonedisplay"" id=""updationmsg"">Schedule is updated.</p>
                        </div>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 122 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<script>

    var starWidth = 40;
    var ratingData = {};
    var ServiceRequestId;
    var val;
    var val1;
    var val2;
    var val3;

    $.fn.stars = function () {
        return $(this).each(function () {
            var star1 = $(""#inptstar1"").val();
            var star2 = $(""#inptstar2"").val();
            var star3 = $(""#inptstar3"").val();
            //var val;
            val = (parseFloat(star1) + parseFloat(star2) + parseFloat(star3)) / 3;
            var size = Math.max(0, (Math.min(5, val))) * starWidth;
            var $span = $('<span />').width(size);
            $(this).html($span);
        });
    }
    $.fn.stars1 = function () {
        return $(this).each(function () {
            var val1 = $(""#inptstar1"").val();
            var size = Math.max(0, (Math.min(5, val1))) * starWidth;
            var $span = $('<span />').width(size);
            $(this).html($span);
        });
    }
    $.fn.stars2 = function () ");
            WriteLiteral(@"{
        return $(this).each(function () {
            var val2 = $(""#inptstar2"").val();
            var size = Math.max(0, (Math.min(5, val2))) * starWidth;
            var $span = $('<span />').width(size);
            $(this).html($span);
        });
    }
    $.fn.stars3 = function () {
        return $(this).each(function () {
            var val3 = $(""#inptstar3"").val();
            var size = Math.max(0, (Math.min(5, val3))) * starWidth;
            var $span = $('<span />').width(size);
            $(this).html($span);
        });
    }
    function btnRateSP(x) {
        ServiceRequestId = x;
        $(""#SPRste"").show();
        $(""body"").addClass(""bgclrset"");
        $(""table"").addClass(""bgclrset"");
    }

    function starsnew() {
        $('span.stars').stars();
        $('span.stars1').stars1();
        $('span.stars2').stars2();
        $('span.stars3').stars3(); 
    }
    function saveRatings() {
        ratingData.OnTimeArrival = $(""#inptstar1"").val();
        ");
            WriteLiteral(@"ratingData.Friendly = $(""#inptstar2"").val();
        ratingData.QualityOfService = $(""#inptstar3"").val();
        ratingData.Ratings = val;
        ratingData.Comments = $(""#cmnt"").text();
        ratingData.ServiceRequestId = ServiceRequestId;
            //alert(ratingData.ServiceRequestId);

            $.ajax({
                url: '");
#nullable restore
#line 197 "C:\Users\Aanal Trivedi\source\repos\HelperlandWebsite\HelperlandWebsite\Views\Customer\CustomerHistory.cshtml"
                 Write(Url.Action("CustomerHistory"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'post',
                data: ratingData,
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
                    $(""#errormsg"").html(""Something went wrong"")
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HelperlandWebsite.ViewModels.CustomerHistoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591