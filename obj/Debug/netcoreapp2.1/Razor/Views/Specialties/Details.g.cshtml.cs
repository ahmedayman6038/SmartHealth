#pragma checksum "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e7f3f357917f9232a904b6c49409f14dd019bcf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Specialties_Details), @"mvc.1.0.view", @"/Views/Specialties/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Specialties/Details.cshtml", typeof(AspNetCore.Views_Specialties_Details))]
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
#line 1 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\_ViewImports.cshtml"
using SmartHealth;

#line default
#line hidden
#line 2 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\_ViewImports.cshtml"
using SmartHealth.Models;

#line default
#line hidden
#line 3 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\_ViewImports.cshtml"
using SmartHealth.ViewModels;

#line default
#line hidden
#line 4 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e7f3f357917f9232a904b6c49409f14dd019bcf", @"/Views/Specialties/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9543f9600ab52d0545610097c373e8191ebae5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Specialties_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SmartHealth.Models.SpecialtyDoctor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Specialties", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(101, 221, true);
            WriteLiteral("\r\n<!-- Content Wrapper. Contains page content -->\r\n<div class=\"content-wrapper\">\r\n    <!-- Content Header (Page header) -->\r\n    <section class=\"content-header\">\r\n        <h1>\r\n            Specialties\r\n            <small>");
            EndContext();
            BeginContext(322, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4537af9ca1e0480a95b9f50ccccfddac", async() => {
                BeginContext(373, 9, true);
                WriteLiteral("View List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(386, 171, true);
            WriteLiteral("</small>\r\n        </h1>\r\n        <ol class=\"breadcrumb\">\r\n            <li><a href=\"#\"><i class=\"fa fa-dashboard\"></i> Specialties</a></li>\r\n            <li class=\"active\">");
            EndContext();
            BeginContext(558, 17, false);
#line 17 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(575, 702, true);
            WriteLiteral(@"</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class=""content container-fluid"">

        <div class=""row"">
            <!-- left column -->
            <div class=""col-md-12"">
                <div class=""box box-solid"">
                    <div class=""box-header with-border"">
                        <i class=""fa fa-text-width""></i>

                        <h3 class=""box-title"">Details Of Specialty</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class=""box-body"">
                        <dl class=""dl-horizontal"">
                            <dt>Specialty Name</dt>
                            <dd>");
            EndContext();
            BeginContext(1278, 28, false);
#line 37 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml"
                           Write(Model.First().Specialty.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1306, 95, true);
            WriteLiteral("</dd>\r\n                            <dt>Specialty Details</dt>\r\n                            <dd>");
            EndContext();
            BeginContext(1402, 31, false);
#line 39 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml"
                           Write(Model.First().Specialty.Details);

#line default
#line hidden
            EndContext();
            BeginContext(1433, 138, true);
            WriteLiteral("</dd>\r\n                            <dt>Doctors Of Specialty</dt>\r\n                            <dd>\r\n                                <ul>\r\n");
            EndContext();
#line 43 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
            BeginContext(1676, 44, true);
            WriteLiteral("                                        <li>");
            EndContext();
            BeginContext(1721, 16, false);
#line 45 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml"
                                       Write(item.Doctor.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1737, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 46 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Specialties\Details.cshtml"
                                    }

#line default
#line hidden
            BeginContext(1783, 401, true);
            WriteLiteral(@"                                </ul>
                            </dd>
                        </dl>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->

            </div>
            <!--/.col (left) -->

        </div>
        <!-- /.row-->
    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SmartHealth.Models.SpecialtyDoctor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
