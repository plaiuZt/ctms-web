#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f7c0a5dac76df220254a483b9235aef555ac343"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LogTable_Details), @"mvc.1.0.view", @"/Views/LogTable/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/LogTable/Details.cshtml", typeof(AspNetCore.Views_LogTable_Details))]
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f7c0a5dac76df220254a483b9235aef555ac343", @"/Views/LogTable/Details.cshtml")]
    public class Views_LogTable_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Log_TableDetails>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/My97DatePicker/4.8/WdatePicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/datatables/1.10.0/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/laypage/1.2/laypage.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(180, 91, true);
            WriteLiteral("\r\n\r\n<div class=\"page-container\">\r\n    <div class=\"mt-10\">\r\n        <div class=\"mb-10\">数据表： ");
            EndContext();
            BeginContext(272, 17, false);
#line 12 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                           Write(ViewBag.TableName);

#line default
#line hidden
            EndContext();
            BeginContext(289, 544, true);
            WriteLiteral(@" 字段明细</div>
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""240"">表名</th>
                    <th width=""220"">字段名称</th>
                    <th width=""260"">字段注释</th>
                    <th width=""80"">数据类型</th>
                    <th width=""60"">主键</th>
                    <th width="""">备注</th>
                    <th width=""120"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 26 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(958, 77, true);
            WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td>");
            EndContext();
            BeginContext(1036, 17, false);
#line 31 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                           Write(ViewBag.TableName);

#line default
#line hidden
            EndContext();
            BeginContext(1053, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(1108, 12, false);
#line 32 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                          Write(m.ColumnName);

#line default
#line hidden
            EndContext();
            BeginContext(1120, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(1175, 12, false);
#line 33 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                          Write(m.ColumnText);

#line default
#line hidden
            EndContext();
            BeginContext(1187, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1227, 16, false);
#line 34 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                           Write(m.ColumnDataType);

#line default
#line hidden
            EndContext();
            BeginContext(1243, 57, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-status\">");
            EndContext();
            BeginContext(1302, 151, false);
#line 35 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                              Write(m.IsPrimaryKey.ToBool() ? Html.Raw("<span class='label label-success radius'>是</span>") : Html.Raw("<span class='label label-defaunt radius'>否</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(1454, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(1509, 8, false);
#line 36 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                          Write(m.Remark);

#line default
#line hidden
            EndContext();
            BeginContext(1517, 59, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-manage\">\r\n");
            EndContext();
#line 38 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                 if (m.IsPrimaryKey.ToBool())
                                {

#line default
#line hidden
            BeginContext(1674, 109, true);
            WriteLiteral("                                <a title=\"删除主建\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 1783, "\"", 1819, 3);
            WriteAttributeValue("", 1793, "$.mainu.stop(this,\'", 1793, 19, true);
#line 40 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
WriteAttributeValue("", 1812, m.ID, 1812, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 1817, "\')", 1817, 2, true);
            EndWriteAttribute();
            BeginContext(1820, 11, true);
            WriteLiteral(">删除主建</a>\r\n");
            EndContext();
#line 41 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(1939, 109, true);
            WriteLiteral("                                <a title=\"设为主建\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 2048, "\"", 2085, 3);
            WriteAttributeValue("", 2058, "$.mainu.start(this,\'", 2058, 20, true);
#line 44 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
WriteAttributeValue("", 2078, m.ID, 2078, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 2083, "\')", 2083, 2, true);
            EndWriteAttribute();
            BeginContext(2086, 11, true);
            WriteLiteral(">设为主建</a>\r\n");
            EndContext();
#line 45 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                }

#line default
#line hidden
            BeginContext(2132, 67, true);
            WriteLiteral("                                <a title=\"编辑注释\" href=\"javascript:;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2199, "\"", 2275, 3);
            WriteAttributeValue("", 2209, "$.mainu.edit(\'编辑\',\'", 2209, 19, true);
#line 46 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
WriteAttributeValue("", 2228, Url.Action("EditDetails", new { id = m.ID }), 2228, 45, false);

#line default
#line hidden
            WriteAttributeValue("", 2273, "\')", 2273, 2, true);
            EndWriteAttribute();
            BeginContext(2276, 117, true);
            WriteLiteral(" class=\"ml-5\" style=\"text-decoration:none\">编辑</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 49 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(2435, 120, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n<div class=\"pt-30\" style=\"width:100%; height:60px;\"></div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2634, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(2668, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d0db3fc78b3406b9fec31333b9d589e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2760, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2766, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ecdc9e7b0d264eb8a0c316687b971709", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2867, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2873, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3d70cf575504c84a5ca1ccb136c5107", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2954, 542, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
            (function ($) {
                $.mainu = {
                    init: function () {

                    },
                    edit: function (title, url, w, h) {
                        layer_show(title, url, w, h);
                    },
                    stop: function (obj, id) {
                        layer.confirm('确认要删除主建吗？', function (index) {
                            $.ajax({
                                type: 'POST',
                                url: '");
                EndContext();
                BeginContext(3497, 30, false);
#line 79 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                 Write(Url.Action("UpdatePrimaryKey"));

#line default
#line hidden
                EndContext();
                BeginContext(3527, 1574, true);
                WriteLiteral(@"',
                                data: { id: id, fState: false },
                                dataType: 'json',
                                success: function (result) {
                                    var state = result.state;
                                    var message = result.message;
                                    if (state == ""success"") {
                                        $(obj).parents(""tr"").find("".td-manage"").prepend('<a title=""设为主建"" href=""javascript:;"" class=""ml-5"" style=""text-decoration:none"" onClick=""$.mainu.start(this,\'' + id + '\')"">设为主建</a>');
                                        $(obj).parents(""tr"").find("".td-status"").html('<span class=""label label-defaunt radius"">否</span>');
                                        $(obj).remove();
                                        layer.msg('删除主建！', { icon: 5, time: 3000 });
                                    } else {
                                        layer.msg(message, { icon: 5, time: 3000 });
       ");
                WriteLiteral(@"                             }
                                },
                                error: function (data) {
                                    console.log(data.msg);
                                }
                            });
                        });
                    },
                    start: function (obj, id) {
                        layer.confirm('确认要设为主建吗？', function (index) {
                            $.ajax({
                                type: 'POST',
                                url: '");
                EndContext();
                BeginContext(5102, 30, false);
#line 104 "E:\Projects\CTMS\CTMS.Web\Views\LogTable\Details.cshtml"
                                 Write(Url.Action("UpdatePrimaryKey"));

#line default
#line hidden
                EndContext();
                BeginContext(5132, 1479, true);
                WriteLiteral(@"',
                                data: { id: id, fState: true },
                                dataType: 'json',
                                success: function (result) {
                                    var state = result.state;
                                    var message = result.message;
                                    if (state == ""success"") {
                                        $(obj).parents(""tr"").find("".td-manage"").prepend('<a title=""删除主建"" href=""javascript:;"" class=""ml-5"" style=""text-decoration:none"" onClick=""$.mainu.stop(this,\'' + id + '\')"">删除主建</a>');
                                        $(obj).parents(""tr"").find("".td-status"").html('<span class=""label label-success radius"">是</span>');
                                        $(obj).remove();
                                        layer.msg('设为主建！', { icon: 6, time: 3000 });
                                    } else {
                                        layer.msg(message, { icon: 5, time: 3000 });
         ");
                WriteLiteral(@"                           }
                                },
                                error: function (data) {
                                    console.log(data.msg);
                                }
                            });
                        });
                    }
                };
                $(function () {
                    $.mainu.init();
                });
            })(jQuery);
    </script>
");
                EndContext();
            }
            );
            BeginContext(6614, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Log_TableDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
