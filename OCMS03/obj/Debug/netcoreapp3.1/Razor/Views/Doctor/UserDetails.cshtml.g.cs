#pragma checksum "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce33e34f754f3994d5f315105b66c7bb027bebac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_UserDetails), @"mvc.1.0.view", @"/Views/Doctor/UserDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce33e34f754f3994d5f315105b66c7bb027bebac", @"/Views/Doctor/UserDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"672e7970f59b7a3a0f8fb5fd52e21e2082f3ae1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_UserDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OCMS03.Models.ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Doctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
  
    ViewData["Title"] = "UserDetails";
    Layout = "~/Views/Shared/_StafLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""header bg-white pb-1"">
        <div class=""container-fluid"">
            <div class=""header-body"">
                <div class=""row align-items-center py-4"">
                    <div class=""col-lg-6 col-7"">
                        <h5 class=""text-black-50 font-italic font-weight-bold d-inline-block mb-0""></h5>
                        <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                            <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                                <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce33e34f754f3994d5f315105b66c7bb027bebac5076", async() => {
                WriteLiteral("<i class=\"ni ni-single-02 text-yellow\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce33e34f754f3994d5f315105b66c7bb027bebac6543", async() => {
                WriteLiteral("Profile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">Details</li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""col-xl-12 order-xl-1"">
        <div class=""card"">
            <div class=""card-header"">
                <div class=""row align-items-center"">
                    <div class=""col-8"">
                        <h3 class=""mb-0""> </h3>
                    </div>
                </div>
            </div>
            <div class=""card-body"">
                    <div class=""panel-body bio-graph-info"">
                        <h1 class=""text-center"">Bio Graph</h1>
                        <hr class=""my-4"" />
                        <dl class=""row text-right"">
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">First Name:</label>
                            </d");
            WriteLiteral("t>\r\n                            <dd class=\"col-sm-5 text-center\">\r\n                                <span class=\"form-control-static\"> ");
#nullable restore
#line 44 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                              Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Surname:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""form-control-static"">  ");
#nullable restore
#line 50 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                               Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Email Address:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""form-control-static""> ");
#nullable restore
#line 56 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                              Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Title:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""col-sm-8 form-control-static"">  ");
#nullable restore
#line 62 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                                        Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Date Of Birth:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""col-sm-8 form-control-static""> ");
#nullable restore
#line 68 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Dob));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">ID Number:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""col-sm-8 form-control-static""> ");
#nullable restore
#line 74 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Idnumber));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Gender:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""col-sm-8 form-control-static""> ");
#nullable restore
#line 80 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Occupation:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""col-sm-8 form-control-static""> ");
#nullable restore
#line 86 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Occupation));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Specialisation:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""form-control-static"">");
#nullable restore
#line 92 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                             Write(Html.DisplayFor(model => model.Specialization));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </dd>
                            <dt class=""col-sm-4"">
                                <label class=""control-label"">Address Line 1:</label>
                            </dt>
                            <dd class=""col-sm-5 text-center"">
                                <span class=""form-control-static"">");
#nullable restore
#line 98 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Doctor\UserDetails.cshtml"
                                                             Write(Html.DisplayFor(model => model.AddressLine1));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </dd>\r\n                        </dl>\r\n                    </div>\r\n            </div>\r\n        </div>\r\n    </div>    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OCMS03.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
