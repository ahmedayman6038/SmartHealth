#pragma checksum "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76c0247cb0c668dce0f43da23ab3bd40e1fd2e18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Feedbacks_Index), @"mvc.1.0.view", @"/Views/Feedbacks/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Feedbacks/Index.cshtml", typeof(AspNetCore.Views_Feedbacks_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76c0247cb0c668dce0f43da23ab3bd40e1fd2e18", @"/Views/Feedbacks/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9543f9600ab52d0545610097c373e8191ebae5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Feedbacks_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SmartHealth.Models.Feedback>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Feedbacks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-social-icon btn-bitbucket"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #3c8dbc"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Reply", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(92, 219, true);
            WriteLiteral("\r\n<!-- Content Wrapper. Contains page content -->\r\n<div class=\"content-wrapper\">\r\n    <!-- Content Header (Page header) -->\r\n    <section class=\"content-header\">\r\n        <h1>\r\n            Feedbacks\r\n            <small>");
            EndContext();
            BeginContext(311, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afac324b274742d692921302582eb995", async() => {
                BeginContext(361, 8, true);
                WriteLiteral("Send New");
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
            BeginContext(373, 167, true);
            WriteLiteral("</small>\r\n        </h1>\r\n        <ol class=\"breadcrumb\">\r\n            <li><a href=\"#\"><i class=\"fa fa-comment\"></i> Feedbacks</a></li>\r\n            <li class=\"active\">");
            EndContext();
            BeginContext(541, 17, false);
#line 17 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(558, 649, true);
            WriteLiteral(@"</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class=""content container-fluid"">


        <div class=""row"">
            <div class=""col-xs-12"">
                <div class=""box"">
                    <div class=""box-header"">
                        <h3 class=""box-title"">All Feedbacks</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class=""box-body"">
                        <table id=""example1"" class=""table table-bordered table-striped"">
                            <thead>
                                <tr>
                                    <th>");
            EndContext();
            BeginContext(1208, 41, false);
#line 36 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1249, 47, true);
            WriteLiteral("</th>\r\n                                    <th>");
            EndContext();
            BeginContext(1297, 49, false);
#line 37 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Patient.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1346, 47, true);
            WriteLiteral("</th>\r\n                                    <th>");
            EndContext();
            BeginContext(1394, 44, false);
#line 38 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.SendDate));

#line default
#line hidden
            EndContext();
            BeginContext(1438, 178, true);
            WriteLiteral("</th>\r\n                                    <th>Operations</th>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
            EndContext();
#line 43 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(1713, 39, true);
            WriteLiteral("                                    <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1752, "\"", 1765, 1);
#line 45 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
WriteAttributeValue("", 1757, item.ID, 1757, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1766, 47, true);
            WriteLiteral(">\r\n                                        <td>");
            EndContext();
            BeginContext(1814, 40, false);
#line 46 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1854, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1906, 48, false);
#line 47 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Patient.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1954, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(2006, 43, false);
#line 48 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.SendDate));

#line default
#line hidden
            EndContext();
            BeginContext(2049, 97, true);
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2146, 188, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfcf596f96724e9da2c91296fe43bc15", async() => {
                BeginContext(2297, 33, true);
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
#line 50 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
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
            BeginContext(2334, 46, true);
            WriteLiteral("\r\n                                            ");
            EndContext();
            BeginContext(2380, 188, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f77fc1a41b744b0fb7c6dbbd3bc07b17", async() => {
                BeginContext(2535, 29, true);
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
#line 51 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                                                                               WriteLiteral(item.Patient.ID);

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
            BeginContext(2568, 53, true);
            WriteLiteral("\r\n                                            <button");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2621, "\"", 2634, 1);
#line 52 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
WriteAttributeValue("", 2626, item.ID, 2626, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2635, 211, true);
            WriteLiteral(" class=\"btn btn-social-icon btn-facebook delete\" style=\"background-color: #dd4b39\"><i class=\"fa fa-trash\"></i></button>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 55 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Feedbacks\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(2881, 2129, true);
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
                BeginContext(5028, 466, true);
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
                deleteFeedback(id,table);
                $('#modal-warning').modal('hide');
            })
        })
    </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SmartHealth.Models.Feedback>> Html { get; private set; }
    }
}
#pragma warning restore 1591
