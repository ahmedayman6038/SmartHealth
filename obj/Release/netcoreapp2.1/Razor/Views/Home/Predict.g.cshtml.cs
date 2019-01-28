#pragma checksum "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Home\Predict.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92920cc4b4a01b6f7cc17a2fbc1593609945eac8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Predict), @"mvc.1.0.view", @"/Views/Home/Predict.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Predict.cshtml", typeof(AspNetCore.Views_Home_Predict))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92920cc4b4a01b6f7cc17a2fbc1593609945eac8", @"/Views/Home/Predict.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9543f9600ab52d0545610097c373e8191ebae5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Predict : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Home\Predict.cshtml"
  
    ViewData["Title"] = "Predict";

#line default
#line hidden
            BeginContext(45, 355, true);
            WriteLiteral(@"
<!-- Content Wrapper. Contains page content -->
<div class=""content-wrapper"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <h1>
            Prediction
        </h1>
        <ol class=""breadcrumb"">
            <li><a href=""#""><i class=""fa fa-dashboard""></i> Home</a></li>
            <li class=""active"">");
            EndContext();
            BeginContext(401, 17, false);
#line 15 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Home\Predict.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(418, 567, true);
            WriteLiteral(@"</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class=""content container-fluid"">

        <div class=""row"">
            <!-- left column -->
            <div class=""col-md-12"">
                <!-- general form elements -->
                <div class=""box box-primary"">
                    <div class=""box-header with-border"">
                        <h3 class=""box-title"">Predict Disease</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    ");
            EndContext();
            BeginContext(985, 833, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b215377042f24622a501d24c0a72dde7", async() => {
                BeginContext(1003, 808, true);
                WriteLiteral(@"
                        <div class=""box-body"">
                            <label for=""SName"">Enter symptom that's troubling you the most.</label>
                            <div class=""input-group input-group-sm"">

                                <input type=""text"" name=""SName"" id=""SName"" list=""results"" class=""form-control"">
                                <span class=""input-group-btn"">
                                    <button type=""submit"" class=""btn btn-info btn-flat"">Go!</button>
                                </span>
                            </div>
                            <datalist id=""results""></datalist>
                            <p id=""error"" class=""text-danger""></p>
                        </div>
                        <!-- /.box-body -->
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1818, 4227, true);
            WriteLiteral(@"
                </div>
                <!-- /.box -->

            </div>
            <!--/.col (left) -->

        </div>
        <!-- /.row-->
        <!-- <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""box box-primary"">
                        <div class=""box-header with-border"">
                            <h3 class=""box-title"">Predict Disease</h3>
                        </div>
                        <form id=""myForm2"">
                            <div class=""box-body"">
                                <div class=""form-group"">
                                    <label>Are you face any of these symptoms?</label>
                                    <div class=""radio icheck"">
                                        <label>
                                            <input type=""radio"" name=""optionsRadios"" id=""optionsRadios1"" value=""option1"">
                                            صداع
                                        </label>
");
            WriteLiteral(@"                                    </div>
                                    <div class=""radio icheck"">
                                        <label>
                                            <input type=""radio"" name=""optionsRadios"" id=""optionsRadios2"" value=""option2"">
                                            الم فى الراس
                                        </label>
                                    </div>
                                    <div class=""radio icheck"">
                                        <label>
                                            <input type=""radio"" name=""optionsRadios"" id=""optionsRadios2"" value=""option2"">
                                            الم فى الراس
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class=""box-footer"">
                                <button id=""notFound"" type=""button"" clas");
            WriteLiteral(@"s=""btn btn-success"">Don't have any of these symptoms!</button>
                                <button type=""submit"" class=""btn btn-primary"">Next</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
    -->









    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->

<div class=""modal modal-success fade"" id=""modal-success"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h4 class=""modal-title"">Success</h4>
            </div>
            <div class=""modal-body"">
                <p>Data saved successfully, Do you want add new item?</p>
            </div>
            <div class=""modal-footer"">
                <button ");
            WriteLiteral(@"type=""button"" class=""btn btn-outline pull-left"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-outline"" id=""addNew"">Add New</button>
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
                <p>This name already exist, Please add another one and try again!</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-outline "" data-dismiss=""modal"">Ok</button>
      ");
            WriteLiteral("      </div>\r\n        </div>\r\n        <!-- /.modal-content -->\r\n    </div>\r\n    <!-- /.modal-dialog -->\r\n</div>\r\n<!-- /.modal -->\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6063, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 154 "E:\DotNetProjects\SmartHealth\SmartHealth\Views\Home\Predict.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial"); 

#line default
#line hidden
                BeginContext(6134, 2687, true);
                WriteLiteral(@"    <script>
        $(function () {
            $(""#SName"").keyup(function () {
                $(""#results"").empty();
                $(""#error"").empty();
                var sname = $('#SName').val();
                $.ajax({
                    url: '/api/Prediction?Name=' + sname,
                    type: 'GET',
                    dataType: 'json',
                    error: function () {
                        $('#modal-danger').modal('show');
                    },
                    success: function (data) {
                        for (var i = 0; i < data.length; i++) {
                            $(""#results"").append(""<option>"" + data[i] + ""</option>"");
                        }
                    },
                });
            });
            $('#myForm').submit(function (e) {
                e.preventDefault();
                if ($(""#SName"").val()) {
                    var sname = $('#SName').val();
                    $.ajax({
                        url: '/ap");
                WriteLiteral(@"i/Prediction/Initialize?SName=' + sname,
                        type: 'GET',
                        dataType: 'json',
                        error: function () {
                            $('#modal-danger').modal('show');
                        },
                        success: function (data) {
                            $(""#myForm"").remove();
                            $("".box"").append('<form id=""myForm""><div class=""box-body""><div class=""form-group""><label>Are you face any of these symptoms?</label></div></div><div class=""box-footer""><button style=""margin-right: 5px;"" id=""notFound"" type=""button"" class=""btn btn-success"">Dont have any of these symptoms!</button><button type=""submit"" class=""btn btn-primary"">Next</button></div></form>');
                            for (var i = 0; i < data.length; i++) {
                                $("".form-group"").append('<div class=""radio icheck""><label><input type=""radio"" name=""Id"" value=""'+data[i].id+'"">'+data[i].name+'</label></div>');
            ");
                WriteLiteral(@"                }
                            $('input').iCheck({
                                checkboxClass: 'icheckbox_square-blue',
                                radioClass: 'iradio_square-blue margin',
                                increaseArea: '20%' /* optional */
                            });
                            $('.row').addClass('animated fadeInRight');
                        },
                    });
                } else {
                    $(""#error"").empty();
                    $(""#error"").append(""Please enter a symptom"");
                }
            })
        })
    </script>
");
                EndContext();
            }
            );
            BeginContext(8824, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
