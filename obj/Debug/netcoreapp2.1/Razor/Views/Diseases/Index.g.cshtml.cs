#pragma checksum "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "879a72ccafa4bb0bf30dc2c65093e42811dae154"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diseases_Index), @"mvc.1.0.view", @"/Views/Diseases/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Diseases/Index.cshtml", typeof(AspNetCore.Views_Diseases_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"879a72ccafa4bb0bf30dc2c65093e42811dae154", @"/Views/Diseases/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9543f9600ab52d0545610097c373e8191ebae5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Diseases_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SmartHealth.Models.Disease>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Diseases", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-social-icon btn-bitbucket"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #3c8dbc"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-social-icon btn-dropbox"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #00a65a"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(91, 216, true);
            WriteLiteral("<!-- Content Wrapper. Contains page content -->\r\n<div class=\"content-wrapper\">\r\n    <!-- Content Header (Page header) -->\r\n    <section class=\"content-header\">\r\n        <h1>\r\n            Diseases\r\n            <small>");
            EndContext();
            BeginContext(307, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "043c346a4a6946f986734b82f789d44e", async() => {
                BeginContext(356, 7, true);
                WriteLiteral("Add New");
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
            BeginContext(367, 168, true);
            WriteLiteral("</small>\r\n        </h1>\r\n        <ol class=\"breadcrumb\">\r\n            <li><a href=\"#\"><i class=\"fa fa-dashboard\"></i> Diseases</a></li>\r\n            <li class=\"active\">");
            EndContext();
            BeginContext(536, 17, false);
#line 16 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(553, 648, true);
            WriteLiteral(@"</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class=""content container-fluid"">


        <div class=""row"">
            <div class=""col-xs-12"">
                <div class=""box"">
                    <div class=""box-header"">
                        <h3 class=""box-title"">All Diseases</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class=""box-body"">
                        <table id=""example1"" class=""table table-bordered table-striped"">
                            <thead>
                                <tr>
                                    <th>");
            EndContext();
            BeginContext(1202, 40, false);
#line 35 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1242, 299, true);
            WriteLiteral(@"</th>
                                    <th>Type</th>
                                    <th>Reference Symptom Count</th>
                                    <th>Operations</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 42 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(1638, 39, true);
            WriteLiteral("                                    <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1677, "\"", 1690, 1);
#line 44 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
WriteAttributeValue("", 1682, item.ID, 1682, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1691, 47, true);
            WriteLiteral(">\r\n                                        <td>");
            EndContext();
            BeginContext(1739, 39, false);
#line 45 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1778, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1830, 49, false);
#line 46 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Specialty.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1879, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1931, 56, false);
#line 47 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.SymptomDiseases.Count));

#line default
#line hidden
            EndContext();
            BeginContext(1987, 97, true);
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2084, 187, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebaf46827ef34be4b3ee88305d5bb398", async() => {
                BeginContext(2234, 33, true);
                WriteLiteral("<i class=\"fa fa-info-circle\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                                                                                WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2271, 46, true);
            WriteLiteral("\r\n                                            ");
            EndContext();
            BeginContext(2317, 178, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88dedb56cf2b435e8d1bed1bdc030821", async() => {
                BeginContext(2462, 29, true);
                WriteLiteral("<i class=\"fa fa-refresh\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 50 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                                                                             WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2495, 53, true);
            WriteLiteral("\r\n                                            <button");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2548, "\"", 2561, 1);
#line 51 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
WriteAttributeValue("", 2553, item.ID, 2553, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2562, 211, true);
            WriteLiteral(" class=\"btn btn-social-icon btn-facebook delete\" style=\"background-color: #dd4b39\"><i class=\"fa fa-trash\"></i></button>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 54 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Diseases\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(2808, 2129, true);
            WriteLiteral(@"
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->

<div class=""modal modal-warning fade"" id=""modal-warning"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h4 class=""modal-title"">Warning</h4>
            </div>
            <div class=""modal-body"">
                <p>Are you sure you want delete this item?</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-outline pull-left""");
            WriteLiteral(@" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-outline"" id=""confirmDelete"">Delete</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->

<div class=""modal modal-danger fade"" id=""modal-danger"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h4 class=""modal-title"">Error</h4>
            </div>
            <div class=""modal-body"">
                <p>Something goes wrong on the server, Please try again!</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-outline "" data-dismiss=""modal"">Ok</button>
            </div>
        </div>
        <!-- /.modal");
            WriteLiteral("-content -->\r\n    </div>\r\n    <!-- /.modal-dialog -->\r\n</div>\r\n<!-- /.modal -->\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4955, 465, true);
                WriteLiteral(@"
    <script>
        $(function () {
            var table = $('#example1').DataTable();
            var id = 0;
            $('.delete').click(function () {
                $('#modal-warning').modal('show');
                id = $(this).attr('id');
            })
            $('#confirmDelete').click(function () {
                deleteDisease(id,table);
                $('#modal-warning').modal('hide');
            })
        })
    </script>
");
                EndContext();
            }
            );
            BeginContext(5423, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SmartHealth.Models.Disease>> Html { get; private set; }
    }
}
#pragma warning restore 1591
