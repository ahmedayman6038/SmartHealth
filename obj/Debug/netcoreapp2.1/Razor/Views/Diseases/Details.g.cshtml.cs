#pragma checksum "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1e0e61f14fc4314b7af91876b269ef954c638be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diseases_Details), @"mvc.1.0.view", @"/Views/Diseases/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Diseases/Details.cshtml", typeof(AspNetCore.Views_Diseases_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1e0e61f14fc4314b7af91876b269ef954c638be", @"/Views/Diseases/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9543f9600ab52d0545610097c373e8191ebae5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Diseases_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SmartHealth.Models.SymptomDisease>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Diseases", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(100, 218, true);
            WriteLiteral("\r\n<!-- Content Wrapper. Contains page content -->\r\n<div class=\"content-wrapper\">\r\n    <!-- Content Header (Page header) -->\r\n    <section class=\"content-header\">\r\n        <h1>\r\n            Diseases\r\n            <small>");
            EndContext();
            BeginContext(318, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ef8eecefcf943b5b75969944c113413", async() => {
                BeginContext(366, 9, true);
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
            BeginContext(379, 168, true);
            WriteLiteral("</small>\r\n        </h1>\r\n        <ol class=\"breadcrumb\">\r\n            <li><a href=\"#\"><i class=\"fa fa-dashboard\"></i> Diseases</a></li>\r\n            <li class=\"active\">");
            EndContext();
            BeginContext(548, 17, false);
#line 17 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(565, 698, true);
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

                        <h3 class=""box-title"">Details Of Disease</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class=""box-body"">
                        <dl class=""dl-horizontal"">
                            <dt>Disease Name</dt>
                            <dd>");
            EndContext();
            BeginContext(1264, 26, false);
#line 37 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
                           Write(Model.First().Disease.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1290, 93, true);
            WriteLiteral("</dd>\r\n                            <dt>Disease Details</dt>\r\n                            <dd>");
            EndContext();
            BeginContext(1384, 29, false);
#line 39 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
                           Write(Model.First().Disease.Details);

#line default
#line hidden
            EndContext();
            BeginContext(1413, 90, true);
            WriteLiteral("</dd>\r\n                            <dt>Disease Type</dt>\r\n                            <dd>");
            EndContext();
            BeginContext(1504, 36, false);
#line 41 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
                           Write(Model.First().Disease.Specialty.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1540, 134, true);
            WriteLiteral("</dd>\r\n                            <dt>Disease Symptoms</dt>\r\n                            <dd>\r\n                                <ul>\r\n");
            EndContext();
#line 45 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
            BeginContext(1779, 44, true);
            WriteLiteral("                                        <li>");
            EndContext();
            BeginContext(1824, 17, false);
#line 47 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
                                       Write(item.Symptom.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1841, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 48 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Details.cshtml"
                                    }

#line default
#line hidden
            BeginContext(1887, 401, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SmartHealth.Models.SymptomDisease>> Html { get; private set; }
    }
}
#pragma warning restore 1591
