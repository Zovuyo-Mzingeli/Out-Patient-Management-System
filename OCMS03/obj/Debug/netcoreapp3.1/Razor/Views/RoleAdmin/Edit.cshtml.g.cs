#pragma checksum "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f12e7672ef9b027a897b75efe31c224488852665"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoleAdmin_Edit), @"mvc.1.0.view", @"/Views/RoleAdmin/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f12e7672ef9b027a897b75efe31c224488852665", @"/Views/RoleAdmin/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"672e7970f59b7a3a0f8fb5fd52e21e2082f3ae1e", @"/Views/_ViewImports.cshtml")]
    public class Views_RoleAdmin_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OCMS03.Models.ViewModels.RoleEditModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal fade"" id=""addPopUp"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-dark text-light"">
                <h5 class=""modal-title text-white"">Edit Role</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body mx-3"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f12e7672ef9b027a897b75efe31c2244888526655366", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 18 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f12e7672ef9b027a897b75efe31c2244888526656985", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"roleName\"");
                BeginWriteAttribute("value", " value=\"", 877, "\"", 901, 1);
#nullable restore
#line 21 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
WriteAttributeValue("", 885, Model.Role.Name, 885, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"roleId\"");
                BeginWriteAttribute("value", " value=\"", 969, "\"", 991, 1);
#nullable restore
#line 22 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
WriteAttributeValue("", 977, Model.Role.Id, 977, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <h6 class=\"bg-info p-1 text-white\">Add To ");
#nullable restore
#line 23 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                                                 Write(Model.Role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n\r\n                            <table class=\"table table-bordered table-sm\">\r\n");
#nullable restore
#line 26 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                 if (Model.NonMembers.Count() == 0)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr><td colspan=\"2\">All Users Are Members</td></tr>\r\n");
#nullable restore
#line 29 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                     foreach (ApplicationUser user in Model.NonMembers)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 35 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                           Write(user.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 35 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                                           Write(user.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                            <td><input type=\"checkbox\" name=\"IdsToAdd\"");
                BeginWriteAttribute("value", " value=\"", 1813, "\"", 1829, 1);
#nullable restore
#line 36 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
WriteAttributeValue("", 1821, user.Id, 1821, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></td>\r\n                                        </tr>\r\n");
#nullable restore
#line 38 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </table>\r\n                            <h6 class=\"bg-info p-1 text-white\">Remove From ");
#nullable restore
#line 41 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                                                      Write(Model.Role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n\r\n                            <table class=\"table table-bordered table-sm\">\r\n");
#nullable restore
#line 44 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                 if (Model.Members.Count() == 0)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr><td colspan=\"2\">No Users Are Members</td></tr>\r\n");
#nullable restore
#line 47 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"

                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                     foreach (ApplicationUser user in Model.Members)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 54 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                           Write(user.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 54 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                                           Write(user.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                            <td>\r\n                                                <input type=\"checkbox\" name=\"IdsToDelete\"");
                BeginWriteAttribute("value", " value=\"", 2866, "\"", 2882, 1);
#nullable restore
#line 56 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
WriteAttributeValue("", 2874, user.Id, 2874, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 59 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\RoleAdmin\Edit.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </table>\r\n");
                WriteLiteral("                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary btn-lg btn-block"" data-save=""modal"">Submit</button>
            </div>
        </div>
    </div>
</div>

<hr />
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OCMS03.Models.ViewModels.RoleEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
