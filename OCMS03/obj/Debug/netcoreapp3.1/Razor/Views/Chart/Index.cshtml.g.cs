#pragma checksum "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3de3265c24057702885ff7ee2c2e2d2f484c903"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chart_Index), @"mvc.1.0.view", @"/Views/Chart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3de3265c24057702885ff7ee2c2e2d2f484c903", @"/Views/Chart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"672e7970f59b7a3a0f8fb5fd52e21e2082f3ae1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Chart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OCMS03.Models.Helper>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-md-6"">
            <h4 style=""margin-left:200px""> 2021 Appointments</h4>
            <div id=""chart1""></div>
        </div>
        <div class=""col-md-6"">
            <h4 style=""margin-left:200px""> 2021 Appointment Details</h4>
            <div id=""chart2""></div>
        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

    <script>
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            // Pie Chart with Data Array:

            var myArray = [['Months', 'Stats'],
            ['January', { v: ");
#nullable restore
#line 26 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                        Write(Model.Data()[0]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 26 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                              Write(Model.Data()[0]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'February\', { v: ");
#nullable restore
#line 27 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                         Write(Model.Data()[1]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 27 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                               Write(Model.Data()[1]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'March\', { v: ");
#nullable restore
#line 28 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                      Write(Model.Data()[2]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 28 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                            Write(Model.Data()[2]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'April\', { v: ");
#nullable restore
#line 29 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                      Write(Model.Data()[3]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 29 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                            Write(Model.Data()[3]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'May\', { v: ");
#nullable restore
#line 30 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                    Write(Model.Data()[4]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 30 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                          Write(Model.Data()[4]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'June\', { v: ");
#nullable restore
#line 31 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                     Write(Model.Data()[5]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 31 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                           Write(Model.Data()[5]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'July\', { v: ");
#nullable restore
#line 32 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                     Write(Model.Data()[6]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 32 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                           Write(Model.Data()[6]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'August\', { v: ");
#nullable restore
#line 33 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                       Write(Model.Data()[7]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 33 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                             Write(Model.Data()[7]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'September\', { v: ");
#nullable restore
#line 34 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                          Write(Model.Data()[8]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 34 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                                Write(Model.Data()[8]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'October\', { v: ");
#nullable restore
#line 35 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                        Write(Model.Data()[9]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 35 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                              Write(Model.Data()[9]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'November\', { v: ");
#nullable restore
#line 36 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                         Write(Model.Data()[10]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 36 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                                Write(Model.Data()[10]);

#line default
#line hidden
#nullable disable
                WriteLiteral("%\' }],\r\n            [\'December\', { v: ");
#nullable restore
#line 37 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                         Write(Model.Data()[11]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", f: \'");
#nullable restore
#line 37 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                                Write(Model.Data()[11]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"%' }],
            ];

            var data = google.visualization.arrayToDataTable(myArray, false);
            var option = {
                title: 'Appointment Stats',
                width: 600,
                height: 500
            };
            var chart = new google.visualization.PieChart(document.getElementById('chart1'));
            chart.draw(data, option);

            // Line Chart with Datas Array and Dat Array:

            var data = google.visualization.arrayToDataTable([
                ['Genre','Approved Appointments', 'Cancelled Appointments'],
                ['January', ");
#nullable restore
#line 53 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                       Write(Model.Datas()[0]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 53 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                          Write(Model.Dat()[0]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'February\', ");
#nullable restore
#line 54 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                        Write(Model.Datas()[1]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 54 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                           Write(Model.Dat()[1]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'March\', ");
#nullable restore
#line 55 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                     Write(Model.Datas()[2]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 55 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                        Write(Model.Dat()[2]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'April\', ");
#nullable restore
#line 56 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                     Write(Model.Datas()[3]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 56 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                        Write(Model.Dat()[3]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'May\', ");
#nullable restore
#line 57 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                   Write(Model.Datas()[4]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 57 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                      Write(Model.Dat()[4]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'June\', ");
#nullable restore
#line 58 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                    Write(Model.Datas()[5]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 58 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                       Write(Model.Dat()[5]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ],\r\n                [\'July\', ");
#nullable restore
#line 59 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                    Write(Model.Datas()[6]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 59 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                       Write(Model.Dat()[6]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'August\', ");
#nullable restore
#line 60 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                      Write(Model.Datas()[7]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 60 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                         Write(Model.Dat()[7]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'September\', ");
#nullable restore
#line 61 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                         Write(Model.Datas()[8]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 61 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                            Write(Model.Dat()[8]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'October\', ");
#nullable restore
#line 62 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                       Write(Model.Datas()[9]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 62 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                          Write(Model.Dat()[9]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'November\', ");
#nullable restore
#line 63 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                        Write(Model.Datas()[10]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 63 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                            Write(Model.Dat()[10]);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'December\', ");
#nullable restore
#line 64 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                        Write(Model.Datas()[11]);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 64 "E:\bhala doco\OCMS03_TheCollective\OCMS03\Views\Chart\Index.cshtml"
                                            Write(Model.Dat()[11]);

#line default
#line hidden
#nullable disable
                WriteLiteral("]\r\n            ]);\r\n\r\n            chart = new google.visualization.LineChart(document.getElementById(\'chart2\'));\r\n            chart.draw(data, option);\r\n        }\r\n\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OCMS03.Models.Helper> Html { get; private set; }
    }
}
#pragma warning restore 1591
