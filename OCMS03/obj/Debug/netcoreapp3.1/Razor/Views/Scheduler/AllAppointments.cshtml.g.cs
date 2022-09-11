#pragma checksum "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2809513330df9e3328936ba8a894a0cf40db02fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Scheduler_AllAppointments), @"mvc.1.0.view", @"/Views/Scheduler/AllAppointments.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2809513330df9e3328936ba8a894a0cf40db02fb", @"/Views/Scheduler/AllAppointments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"672e7970f59b7a3a0f8fb5fd52e21e2082f3ae1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Scheduler_AllAppointments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OCMS03.Models.ViewModels.PatientViewModel.PatientAppointmentsListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CancelAppointment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
  
    ViewData["Title"] = "Appointments";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
  
    var trClass = "bg-active";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-sm-4 col-3"">
        <h4 class=""page-title"">All Appointment</h4>
    </div>
</div>
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""table-responsive"">
            <table class=""table table-border table-striped custom-table datatable mb-0"">
                <thead>
");
#nullable restore
#line 23 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                     if (Model.Count() == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\" colspan=\"6\" class=\"text-center\">No Appointments</th>\r\n                        </tr>\r\n");
#nullable restore
#line 28 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <tr>
                            <th>Patient</th>
                            <th>Date</th>
                            <th>From</th>
                            <th>Status</th>
                            <th>Clinic</th>
                            <th>Hospital</th>
                            <th>Doctor</th>
                            <th>Nurse</th>
                            <th>Description</th>
                            <th>Action</th>
                        </tr>
");
#nullable restore
#line 43 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 46 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                     foreach (var appointment in Model)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("class", " class=\"", 1564, "\"", 1580, 1);
#nullable restore
#line 49 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
WriteAttributeValue("", 1572, trClass, 1572, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <th scope=\"row\">");
#nullable restore
#line 50 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                       Write(appointment.PatientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 51 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                           Write(appointment.AppointmentDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 52 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                           Write(appointment.StartTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n");
#nullable restore
#line 54 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                 if (appointment.IsConfirmed == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"text-success\">Confirmed</span>\r\n");
#nullable restore
#line 57 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"text-warning\">Pending</span>\r\n");
#nullable restore
#line 61 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 64 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                 if (appointment.ClinicName != null)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                               Write(appointment.ClinicName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                                           
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"text-warning\">N/A</span>\r\n");
#nullable restore
#line 71 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 74 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                 if (appointment.HospitalName != null)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                               Write(appointment.HospitalName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                                             
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span");
            BeginWriteAttribute("class", " class=\"", 3091, "\"", 3099, 0);
            EndWriteAttribute();
            WriteLiteral(">N/A</span>\r\n");
#nullable restore
#line 81 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 84 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                 if (appointment.DoctorName != null)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                               Write(appointment.DoctorName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                                           
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span");
            BeginWriteAttribute("class", " class=\"", 3532, "\"", 3540, 0);
            EndWriteAttribute();
            WriteLiteral(">Not Assigned</span>\r\n");
#nullable restore
#line 91 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 94 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                 if (appointment.NurseName != null)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                               Write(appointment.NurseName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                                          
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span");
            BeginWriteAttribute("class", " class=\"", 3980, "\"", 3988, 0);
            EndWriteAttribute();
            WriteLiteral(">Not Assigned</span>\r\n");
#nullable restore
#line 101 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>");
#nullable restore
#line 103 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                           Write(appointment.AppointmentDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td class=""text-right"">
                                <div class=""dropdown dropdown-action"">
                                    <a class=""action-icon dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false""><i class=""fa fa-ellipsis-v""></i></a>
                                    <div class=""dropdown-menu dropdown-menu-right"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2809513330df9e3328936ba8a894a0cf40db02fb15250", async() => {
                WriteLiteral("<i class=\"fa fa-trash-o m-r-5\"></i> Cancel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 108 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
                                                                                                  WriteLiteral(appointment.AppointmentId);

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
#line 113 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Scheduler\AllAppointments.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OCMS03.Models.ViewModels.PatientViewModel.PatientAppointmentsListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
