#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c96f266fddd715ac42fec188c1a37c391aea41f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LogLoginRecord_List), @"mvc.1.0.view", @"/Views/LogLoginRecord/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/LogLoginRecord/List.cshtml", typeof(AspNetCore.Views_LogLoginRecord_List))]
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c96f266fddd715ac42fec188c1a37c391aea41f", @"/Views/LogLoginRecord/List.cshtml")]
    public class Views_LogLoginRecord_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Log_LoginRecord>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/My97DatePicker/4.8/WdatePicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/datatables/1.10.0/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/laypage/1.2/laypage.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/static/h-ui.admin/js/H-ui.admin.common.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(204, 648, true);
            WriteLiteral(@"<nav class=""breadcrumb"">
    <i class=""Hui-iconfont"">&#xe67f;</i> 首页 <span class=""c-gray en"">&gt;</span> 系统管理 <span class=""c-gray en"">&gt;</span> 系统日志 <span class=""c-gray en"">&gt;</span> 列表
    <a id=""btn_refresh"" class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a>
</nav>
<div class=""page-container"">
    <div class=""text-c"">
        日期范围：
        <input type=""text"" onfocus=""WdatePicker({ maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}' })"" id=""datemin"" name=""datemin"" class=""input-text Wdate"" style=""width:120px;""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 852, "\"", 876, 1);
#line 16 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
WriteAttributeValue("", 860, ViewBag.datemin, 860, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(877, 196, true);
            WriteLiteral(" />\r\n        -\r\n        <input type=\"text\" onfocus=\"WdatePicker({ minDate:\'#F{$dp.$D(\\\'datemin\\\')}\',maxDate:\'%y-%M-%d\' })\" id=\"datemax\" name=\"datemax\" class=\"input-text Wdate\" style=\"width:120px;\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1073, "\"", 1097, 1);
#line 18 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
WriteAttributeValue("", 1081, ViewBag.datemax, 1081, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1098, 199, true);
            WriteLiteral(" />\r\n        <select id=\"clientId\" name=\"clientId\" class=\"select\" style=\"width:100px; height:31px;vertical-align: middle;\">\r\n            <option value=\"\">全部状态</option>\r\n            <option value=\"1\" ");
            EndContext();
            BeginContext(1299, 41, false);
#line 21 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                          Write(ViewBag.ClientID == "1" ? "selected" : "");

#line default
#line hidden
            EndContext();
            BeginContext(1341, 45, true);
            WriteLiteral(">Web</option>\r\n            <option value=\"2\" ");
            EndContext();
            BeginContext(1388, 41, false);
#line 22 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                          Write(ViewBag.ClientID == "2" ? "selected" : "");

#line default
#line hidden
            EndContext();
            BeginContext(1430, 43, true);
            WriteLiteral(">M</option>\r\n            <option value=\"3\" ");
            EndContext();
            BeginContext(1475, 41, false);
#line 23 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                          Write(ViewBag.ClientID == "3" ? "selected" : "");

#line default
#line hidden
            EndContext();
            BeginContext(1517, 44, true);
            WriteLiteral(">WX</option>\r\n            <option value=\"4\" ");
            EndContext();
            BeginContext(1563, 41, false);
#line 24 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                          Write(ViewBag.ClientID == "4" ? "selected" : "");

#line default
#line hidden
            EndContext();
            BeginContext(1605, 152, true);
            WriteLiteral(">App</option>\r\n        </select>\r\n        <input type=\"text\" class=\"input-text\" style=\"width:350px\" placeholder=\"帐号、姓名、IP地址\" id=\"keyword\" name=\"keyword\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1757, "\"", 1781, 1);
#line 26 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
WriteAttributeValue("", 1765, ViewBag.keyword, 1765, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1782, 554, true);
            WriteLiteral(@" />
        <button type=""submit"" class=""btn btn-success radius"" id=""search"" name=""search"" onclick=""$.mainu.search()""><i class=""Hui-iconfont"">&#xe665;</i> 搜日志</button>
    </div>
    <div class=""cl pd-5 bg-1 bk-gray mt-20"">
        <span class=""l"">
            <a href=""javascript:;"" onclick=""$.mainu.deleteBatch()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 批量删除</a>
            <a href=""javascript:;"" onclick=""$.mainu.deleteAll()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 清空日志</a>
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2336, "\"", 2362, 1);
#line 33 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
WriteAttributeValue("", 2343, Url.Action("list"), 2343, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2363, 133, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 日志列表</a>\r\n        </span>\r\n        <span class=\"r\">共有数据：<strong>");
            EndContext();
            BeginContext(2497, 13, false);
#line 35 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                                Write(ViewBag.Count);

#line default
#line hidden
            EndContext();
            BeginContext(2510, 755, true);
            WriteLiteral(@"</strong> 条</span>
    </div>
    <div class=""mt-20"">
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""60"">序号</th>
                    <th width=""80"">工号</th>
                    <th width=""80"">姓名</th>
                    <th width=""80"">客户端</th>
                    <th width=""120"">IP地址</th>
                    <th width="""">描述</th>
                    <th width=""70"">结果</th>
                    <th width=""120"">操作时间</th>
                    <th width=""80"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 54 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(3390, 109, true);
            WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td><input type=\"checkbox\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3499, "\"", 3512, 1);
#line 59 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
WriteAttributeValue("", 3507, m.ID, 3507, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3513, 40, true);
            WriteLiteral("></td>\r\n                            <td>");
            EndContext();
            BeginContext(3554, 4, false);
#line 60 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                           Write(m.ID);

#line default
#line hidden
            EndContext();
            BeginContext(3558, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3599, 55, false);
#line 61 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.Account, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3655, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3696, 56, false);
#line 62 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.NickName, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3753, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3793, 12, false);
#line 63 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                           Write(m.ClientName);

#line default
#line hidden
            EndContext();
            BeginContext(3805, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3845, 11, false);
#line 64 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                           Write(m.IpAddress);

#line default
#line hidden
            EndContext();
            BeginContext(3856, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(3911, 13, false);
#line 65 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                                          Write(m.Description);

#line default
#line hidden
            EndContext();
            BeginContext(3924, 57, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-status\">");
            EndContext();
            BeginContext(3983, 149, false);
#line 66 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                                              Write(m.IsResult.ToBool() ? Html.Raw("<span class='label label-success radius'>成功</span>") : Html.Raw("<span class='label label-defaunt radius'>失败</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(4133, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4174, 77, false);
#line 67 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                            Write(m.CreateDate.HasValue ? m.CreateDate.Value.ToString("yyyy-MM-dd HH:mm") : "-");

#line default
#line hidden
            EndContext();
            BeginContext(4252, 124, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-manage\">\r\n                                <a title=\"删除\" href=\"javascript:;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4376, "\"", 4414, 3);
            WriteAttributeValue("", 4386, "$.mainu.delete(this,\'", 4386, 21, true);
#line 69 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
WriteAttributeValue("", 4407, m.ID, 4407, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 4412, "\')", 4412, 2, true);
            EndWriteAttribute();
            BeginContext(4415, 117, true);
            WriteLiteral(" class=\"ml-5\" style=\"text-decoration:none\">删除</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 72 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(4574, 120, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n<div class=\"pt-30\" style=\"width:100%; height:60px;\"></div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4773, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(4807, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6915b8f6d8a44fbebc6f705c78b08bee", async() => {
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
                BeginContext(4899, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4905, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "194b03596bb843c18cc69d6d852e65fa", async() => {
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
                BeginContext(5006, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5012, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d85d804e8f549369fba028764d00df8", async() => {
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
                BeginContext(5093, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5099, 96, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcc97183545a441d96084ac49b98d1c2", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5195, 1849, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
            (function ($) {
                $.mainu = {
                    init: function () {
                        $('.table-sort').dataTable({
                            ""aaSorting"": [[1, ""desc""]],//默认第几个排序
                            ""bStateSave"": true,//状态保存
                            ""aoColumnDefs"": [
                              { ""orderable"": false, ""aTargets"": [0, 9] }// 制定列不参与排序
                            ],
                            ""aLengthMenu"": [10, 25, 50, 100]
                        });
                    },
                    search: function () {
                        var dateMin = $(""input[name='datemin']"").val();
                        var dateMax = $(""input[name='datemax']"").val();
                        var clientId = $(""select[name='clientId']"").val();
                        var keyword = $(""input[name='keyword']"").val();
                        if (keyword == """") {
                            if (dateMin == """" ||");
                WriteLiteral(@" dateMax == """") {
                                layer.alert('日期范围不能空', { icon: 5 });
                                return;
                            }
                        }
                        var params = {
                            dateMin: dateMin,
                            dateMax: dateMax,
                            clientId: clientId,
                            keyword: keyword
                        };
                        var url = ""?"" + urlEncodes(params);
                        window.location.href = url;
                    },
                    delete: function (obj, id) {
                        layer.confirm('确认要删除吗？', function (index) {
                            $.ajax({
                                type: 'POST',
                                url: '");
                EndContext();
                BeginContext(7045, 20, false);
#line 127 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                                 Write(Url.Action("Delete"));

#line default
#line hidden
                EndContext();
                BeginContext(7065, 1858, true);
                WriteLiteral(@"',
                                data: { id: id },
                                dataType: 'json',
                                success: function (result) {
                                    var state = result.state;
                                    var message = result.message;
                                    if (state == ""success"") {
                                        $(obj).parents(""tr"").remove();
                                        layer.msg('已删除!', { icon: 1, time: 1000 });
                                    } else {
                                        layer.msg(message, { icon: 5, time: 1000 });
                                    }
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    if (XMLHttpRequest.status != 200) {
                                        layer.alert(""系统错误！"", { icon: 5 });
                                    }
                  ");
                WriteLiteral(@"              }
                            });
                        });
                    },
                    deleteBatch: function () {
                        layer.confirm('确认要删除吗？', function (index) {
                            var arrId = [];
                            $(""input:checkbox[name='id']:checked"").each(function () {
                                //alert($(this).val());
                                arrId.push($(this).val());
                            });
                            if (arrId.length == 0) {
                                layer.msg('请选择需要删除日志！', { icon: 5, time: 2000 });
                                return;
                            }
                            $.ajax({
                                type: 'POST',
                                url: '");
                EndContext();
                BeginContext(8924, 25, false);
#line 161 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                                 Write(Url.Action("DeleteBatch"));

#line default
#line hidden
                EndContext();
                BeginContext(8949, 1338, true);
                WriteLiteral(@"',
                                data: { arrid: arrId },
                                dataType: 'json',
                                success: function (result) {
                                    var state = result.state;          //错误代码
                                    var message = result.message;        //错误说明
                                    if (state == ""success"") {
                                        window.location.replace(location.href);
                                    } else {
                                        layer.msg(message, { icon: 5, time: 1000 });
                                    }
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    if (XMLHttpRequest.status != 200) {
                                        layer.alert(""系统错误！"", { icon: 5 });
                                    }
                                }
                       ");
                WriteLiteral(@"     });
                        });
                    },
                    deleteAll: function () {
                        layer.confirm('确认要清空系统日志吗？保留最近三天日志。', function (index) {
                            $.ajax({
                                type: 'POST',
                                url: '");
                EndContext();
                BeginContext(10288, 23, false);
#line 185 "E:\Projects\CTMS\CTMS.Web\Views\LogLoginRecord\List.cshtml"
                                 Write(Url.Action("DeleteAll"));

#line default
#line hidden
                EndContext();
                BeginContext(10311, 1230, true);
                WriteLiteral(@"',
                                data: { id: 0 },
                                dataType: 'json',
                                success: function (result) {
                                    var state = result.state;          //错误代码
                                    var message = result.message;        //错误说明
                                    if (state == ""success"") {
                                        window.location.replace(location.href);
                                    } else {
                                        layer.msg(message, { icon: 5, time: 1000 });
                                    }
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    if (XMLHttpRequest.status != 200) {
                                        layer.alert(""系统错误！"", { icon: 5 });
                                    }
                                }
                            })");
                WriteLiteral(";\r\n                        });\r\n                    }\r\n                };\r\n                $(function () {\r\n                    $.mainu.init();\r\n                });\r\n            })(jQuery);\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(11544, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Log_LoginRecord>> Html { get; private set; }
    }
}
#pragma warning restore 1591
