#pragma checksum "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71147e4af9f5123b8429c973c860890d2c9a2e15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_Index), @"mvc.1.0.view", @"/Views/Administration/Index.cshtml")]
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
#line 1 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\_ViewImports.cshtml"
using OCMS03.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\_ViewImports.cshtml"
using OCMS03.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71147e4af9f5123b8429c973c860890d2c9a2e15", @"/Views/Administration/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"672e7970f59b7a3a0f8fb5fd52e21e2082f3ae1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RoleViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("28"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("28"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle m-r-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""d-sm-flex align-items-center justify-content-between mb-4"">
    <h1 class=""h3 mb-0 text-gray-800"">General reports</h1>
    <a href=""#"" class=""d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"">
        <i class=""fas fa-info fa-sm text-white""></i>
    </a>
</div>


<div class=""row"">
    <div class=""col-md-6 col-sm-6 col-lg-6 col-xl-3"">
        <div class=""dash-widget"">
            <span class=""dash-widget-bg1""><i class=""fa fa-stethoscope"" aria-hidden=""true""></i></span>
            <div class=""dash-widget-info text-right"">
                <h3>");
#nullable restore
#line 22 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
               Write(ViewBag.NurseCounter);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                <span class=""widget-title1"">Nurses <i class=""fa fa-check"" aria-hidden=""true""></i></span>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-sm-6 col-lg-6 col-xl-3"">
        <div class=""dash-widget"">
            <span class=""dash-widget-bg2""><i class=""fa fa-users""></i></span>
            <div class=""dash-widget-info text-right"">
                <h3>");
#nullable restore
#line 31 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
               Write(ViewBag.PatCounter);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                <span class=""widget-title2"">Patients <i class=""fa fa-check"" aria-hidden=""true""></i></span>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-sm-6 col-lg-6 col-xl-3"">
        <div class=""dash-widget"">
            <span class=""dash-widget-bg3""><i class=""fa fa-calendar"" aria-hidden=""true""></i></span>
            <div class=""dash-widget-info text-right"">
                <h3>");
#nullable restore
#line 40 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
               Write(ViewBag.apptCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                <span class=""widget-title3"">Appointment <i class=""fa fa-check"" aria-hidden=""true""></i></span>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-sm-6 col-lg-6 col-xl-3"">
        <div class=""dash-widget"">
            <span class=""dash-widget-bg4""><i class=""fa fa-calendar-alt"" aria-hidden=""true""></i></span>
            <div class=""dash-widget-info text-right"">
                <h3>");
#nullable restore
#line 49 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
               Write(ViewBag.CountPendingAppts);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                <span class=""widget-title4"">Pending Appts<i class=""fa fa-check"" aria-hidden=""true""></i></span>
            </div>
        </div>
    </div>
</div>


<div class=""row"">
    <div class=""col-12 col-md-6 col-lg-6 col-xl-6"">
        <div class=""hospital-barchart"">
            <h4 class=""card-title d-inline-block"">Hospital Management</h4>
        </div>
        <div class=""bar-chart"">
            <div class=""legend"">
                <div class=""item"">
                    <h4>Level1</h4>
                </div>

                <div class=""item"">
                    <h4>Level2</h4>
                </div>
                <div class=""item text-right"">
                    <h4>Level3</h4>
                </div>
                <div class=""item text-right"">
                    <h4>Level4</h4>
                </div>
            </div>
            <div class=""chart clearfix"">
                <div class=""item"">
                    <div class=""bar"">
                        ");
            WriteLiteral(@"<span class=""percent"">16%</span>
                        <div class=""item-progress"" data-percent=""16"">
                            <span class=""title"">OPD Patient</span>
                        </div>
                    </div>
                </div>
                <div class=""item"">
                    <div class=""bar"">
                        <span class=""percent"">71%</span>
                        <div class=""item-progress"" data-percent=""71"">
                            <span class=""title"">New Patient</span>
                        </div>
                    </div>
                </div>
                <div class=""item"">
                    <div class=""bar"">
                        <span class=""percent"">82%</span>
                        <div class=""item-progress"" data-percent=""82"">
                            <span class=""title"">Laboratory Test</span>
                        </div>
                    </div>
                </div>
                <div class=""item"">
               ");
            WriteLiteral(@"     <div class=""bar"">
                        <span class=""percent"">67%</span>
                        <div class=""item-progress"" data-percent=""67"">
                            <span class=""title"">Treatment</span>
                        </div>
                    </div>
                </div>
                <div class=""item"">
                    <div class=""bar"">
                        <span class=""percent"">30%</span>
                        <div class=""item-progress"" data-percent=""30"">
                            <span class=""title"">Walk-Ins</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-12 col-md-6 col-lg-6 col-xl-6"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""chart-title"">
                    <h4>Patients In</h4>
                    <div class=""float-right"">
                        <ul class=""chat-user-total"">
");
            WriteLiteral(@"                            <li><i class=""fa fa-circle current-users"" aria-hidden=""true""></i> OPD</li>
                        </ul>
                    </div>
                </div>
                <canvas id=""bargraph""></canvas>
            </div>
        </div>
    </div>
</div>
 

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""table-responsive"">
            <table class=""table table-border table-striped custom-table datatable mb-0"">
                <thead>
                    <tr>
                        <th>Full Name</th>
                        <th>Address</th>
                        <th>Phone</th>
                        <th>Email</th>
                        <th class=""text-right"">Action</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 155 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                     foreach (var user in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "71147e4af9f5123b8429c973c860890d2c9a2e1513004", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6176, "~/profileImage/", 6176, 15, true);
#nullable restore
#line 158 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
AddHtmlAttributeValue("", 6191, user.ProfileImage, 6191, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 158 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                                                                                                                                    Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp; ");
#nullable restore
#line 158 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                                                                                                                                                           Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 159 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                           Write(user.Address1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp; ");
#nullable restore
#line 159 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                                                 Write(user.Address2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 160 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                           Write(user.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 161 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td class=""text-right"">
                                <div class=""dropdown dropdown-action"">
                                    <a href=""#"" class=""action-icon dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false""><i class=""fa fa-ellipsis-v""></i></a>
                                    <div class=""dropdown-menu dropdown-menu-right"">
");
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71147e4af9f5123b8429c973c860890d2c9a2e1517126", async() => {
                WriteLiteral("<i class=\"fa fa-trash-o m-r-5\"></i> Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 167 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                                                                                           WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 172 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Administration\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RoleViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
