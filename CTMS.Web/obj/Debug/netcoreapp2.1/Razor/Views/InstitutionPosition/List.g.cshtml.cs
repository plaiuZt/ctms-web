#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0a18b5c10829e910aa2cf3a22d9ef1789449439"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InstitutionPosition_List), @"mvc.1.0.view", @"/Views/InstitutionPosition/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/InstitutionPosition/List.cshtml", typeof(AspNetCore.Views_InstitutionPosition_List))]
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0a18b5c10829e910aa2cf3a22d9ef1789449439", @"/Views/InstitutionPosition/List.cshtml")]
    public class Views_InstitutionPosition_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Institution_Position>>
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
#line 5 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(209, 600, true);
            WriteLiteral(@"

<nav class=""breadcrumb""><i class=""Hui-iconfont"">&#xe67f;</i> 首页 <span class=""c-gray en"">&gt;</span> 公司管理 <span class=""c-gray en"">&gt;</span> 职位管理 <a id=""btn_refresh"" class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a></nav>
<div class=""page-container"">
    <div class=""text-c"">
        日期范围：
        <input type=""text"" onfocus=""WdatePicker({ maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}' })"" id=""datemin"" name=""datemin"" class=""input-text Wdate"" style=""width:120px;""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 809, "\"", 833, 1);
#line 15 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 817, ViewBag.datemin, 817, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(834, 196, true);
            WriteLiteral(" />\r\n        -\r\n        <input type=\"text\" onfocus=\"WdatePicker({ minDate:\'#F{$dp.$D(\\\'datemin\\\')}\',maxDate:\'%y-%M-%d\' })\" id=\"datemax\" name=\"datemax\" class=\"input-text Wdate\" style=\"width:120px;\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1030, "\"", 1054, 1);
#line 17 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 1038, ViewBag.datemax, 1038, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1055, 122, true);
            WriteLiteral(" />\r\n        <input type=\"text\" class=\"input-text\" style=\"width:350px\" placeholder=\"输入职位编号、名称\" id=\"keyword\" name=\"keyword\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1177, "\"", 1201, 1);
#line 18 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 1185, ViewBag.keyword, 1185, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1202, 420, true);
            WriteLiteral(@" />
        <button type=""submit"" class=""btn btn-success radius"" id=""driversearch"" name=""driversearch"" onclick=""$.mainu.search()""><i class=""Hui-iconfont"">&#xe665;</i> 查找</button>
    </div>
    <div class=""cl pd-5 bg-1 bk-gray mt-20"">
        <span class=""l"">
            <a href=""javascript:;"" onclick=""$.mainu.delBatch()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 批量删除</a>
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1622, "\"", 1648, 1);
#line 24 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 1629, Url.Action("list"), 1629, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1649, 144, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 职位列表</a>\r\n            <a href=\"javascript:;\" class=\"btn btn-primary radius\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1793, "\"", 1849, 3);
            WriteAttributeValue("", 1803, "$.mainu.add(\'新增职位\',\'", 1803, 20, true);
#line 25 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 1823, Url.Action("add"), 1823, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 1841, "\',\'\',\'\')", 1841, 8, true);
            EndWriteAttribute();
            BeginContext(1850, 102, true);
            WriteLiteral("><i class=\"Hui-iconfont\">&#xe600;</i> 新增职位</a>\r\n        </span>\r\n        <span class=\"r\">共有数据：<strong>");
            EndContext();
            BeginContext(1953, 13, false);
#line 27 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                                Write(ViewBag.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1966, 669, true);
            WriteLiteral(@"</strong> 条</span>
    </div>
    <div class=""mt-20"">
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""80"">职位编号</th>
                    <th width=""120"">职位名称</th>
                    <th width="""">描述</th>
                    <th width=""80"">排序</th>
                    <th width=""80"">状态</th>
                    <th width=""120"">加入时间</th>
                    <th width=""120"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 44 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(2760, 109, true);
            WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td><input type=\"checkbox\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2869, "\"", 2890, 1);
#line 49 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 2877, m.PositionID, 2877, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2891, 40, true);
            WriteLiteral("></td>\r\n                            <td>");
            EndContext();
            BeginContext(2933, 58, false);
#line 50 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.PositionID, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(2992, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3033, 60, false);
#line 51 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.PositionName, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3094, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(3149, 13, false);
#line 52 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                                          Write(m.Description);

#line default
#line hidden
            EndContext();
            BeginContext(3162, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3202, 14, false);
#line 53 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                           Write(m.Sort.ToInt());

#line default
#line hidden
            EndContext();
            BeginContext(3216, 57, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-status\">");
            EndContext();
            BeginContext(3275, 148, false);
#line 54 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                                              Write(m.State.ToBool() ? Html.Raw("<span class='label label-success radius'>已启用</span>") : Html.Raw("<span class='label label-defaunt radius'>已停用</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(3424, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3465, 77, false);
#line 55 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                            Write(m.CreateDate.HasValue ? m.CreateDate.Value.ToString("yyyy-MM-dd HH:mm") : "-");

#line default
#line hidden
            EndContext();
            BeginContext(3543, 59, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-manage\">\r\n");
            EndContext();
#line 57 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                                 if (m.State.ToBool())
                                {

#line default
#line hidden
            BeginContext(3693, 111, true);
            WriteLiteral("                                    <a title=\"停用\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 3804, "\"", 3848, 3);
            WriteAttributeValue("", 3814, "$.mainu.stop(this,\'", 3814, 19, true);
#line 59 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 3833, m.PositionID, 3833, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 3846, "\')", 3846, 2, true);
            EndWriteAttribute();
            BeginContext(3849, 9, true);
            WriteLiteral(">停用</a>\r\n");
            EndContext();
#line 60 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(3966, 111, true);
            WriteLiteral("                                    <a title=\"启用\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 4077, "\"", 4122, 3);
            WriteAttributeValue("", 4087, "$.mainu.start(this,\'", 4087, 20, true);
#line 63 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 4107, m.PositionID, 4107, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 4120, "\')", 4120, 2, true);
            EndWriteAttribute();
            BeginContext(4123, 9, true);
            WriteLiteral(">启用</a>\r\n");
            EndContext();
#line 64 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                                }

#line default
#line hidden
            BeginContext(4167, 107, true);
            WriteLiteral("                                <a title=\"编辑\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4274, "\"", 4364, 3);
            WriteAttributeValue("", 4284, "$.mainu.edit(\'编辑\',\'", 4284, 19, true);
#line 65 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 4303, Url.Action("add", new { positionid = m.PositionID }), 4303, 53, false);

#line default
#line hidden
            WriteAttributeValue("", 4356, "\',\'\',\'\')", 4356, 8, true);
            EndWriteAttribute();
            BeginContext(4365, 116, true);
            WriteLiteral(">编辑</a>\r\n                                <a title=\"删除\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4481, "\"", 4524, 3);
            WriteAttributeValue("", 4491, "$.mainu.del(this,\'", 4491, 18, true);
#line 66 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
WriteAttributeValue("", 4509, m.PositionID, 4509, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 4522, "\')", 4522, 2, true);
            EndWriteAttribute();
            BeginContext(4525, 75, true);
            WriteLiteral(">删除</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 69 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(4642, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4781, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(4815, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5167a9f06f844b448165b0308b34c34b", async() => {
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
                BeginContext(4907, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4913, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcf418cafc9a4a37a4853bc5448108e7", async() => {
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
                BeginContext(5014, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5020, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a6719b82481469d8512bbbaff1c196f", async() => {
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
                BeginContext(5101, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5107, 96, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f74b76811f44da8837daa4562a326f0", async() => {
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
                BeginContext(5203, 1626, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        (function ($) {
            $.mainu = {
                init: function () {
                    $('.table-sort').dataTable({
                        ""aaSorting"": [[6, ""desc""]],//默认第几个排序
                        ""bStateSave"": true,//状态保存
                        ""aoColumnDefs"": [
                          { ""orderable"": false, ""aTargets"": [0,7] }// 制定列不参与排序
                        ]
                    });
                },
                search: function () {
                    $dateMin = $(""input[name='datemin']"").val();
                    $dateMax = $(""input[name='datemax']"").val();
                    $keyword = $(""input[name='keyword']"").val();
                    if ($keyword == """") {
                        if ($dateMin == """" || $dateMax=="""") {
                            layer.alert('日期范围不能空', { icon: 5 });
                            return;
                        }
                    }
                    var url = ""?datemin="" + ");
                WriteLiteral(@"$dateMin + ""&datemax="" + $dateMax + ""&keyword="" + $keyword + """";
                    window.location.href = url;
                },
                add: function (title, url, w, h) {
                    layer_show(title, url, w, h);
                },
                edit: function (title, url, w, h) {
                    layer_show(title, url, w, h);
                },
                stop: function (obj, id) {
                    layer.confirm('确认要停用吗？', function (index) {
                        $.ajax({
                            type: 'POST',
                            url: '");
                EndContext();
                BeginContext(6830, 25, false);
#line 121 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                             Write(Url.Action("UpdateState"));

#line default
#line hidden
                EndContext();
                BeginContext(6855, 1476, true);
                WriteLiteral(@"',
                            data: { positionid: id, state: false },
                            dataType: 'json',
                            success: function (result) {
                                var state = result.state;
                                var message = result.message;
                                if (state == ""success"") {
                                    $(obj).parents(""tr"").find("".td-manage"").prepend('<a title=""启用"" href=""javascript:;"" class=""ml-5"" style=""text-decoration:none"" onClick=""$.mainu.start(this,\'' + id + '\')"">启用</a>');
                                    $(obj).parents(""tr"").find("".td-status"").html('<span class=""label label-defaunt radius"">已停用</span>');
                                    $(obj).remove();
                                    layer.msg('已停用！', { icon: 5, time: 3000 });
                                } else {
                                    layer.msg(message, { icon: 5, time: 3000 });
                                }
                ");
                WriteLiteral(@"            },
                            error: function (data) {
                                console.log(data.msg);
                            }
                        });
                    });
                },
                start: function (obj, id) {
                    layer.confirm('确认要启用吗？', function (index) {
                        $.ajax({
                            type: 'POST',
                            url: '");
                EndContext();
                BeginContext(8332, 25, false);
#line 146 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                             Write(Url.Action("UpdateState"));

#line default
#line hidden
                EndContext();
                BeginContext(8357, 1472, true);
                WriteLiteral(@"',
                            data: { positionid: id, state: true },
                            dataType: 'json',
                            success: function (result) {
                                var state = result.state;
                                var message = result.message;
                                if (state == ""success"") {
                                    $(obj).parents(""tr"").find("".td-manage"").prepend('<a title=""停用"" href=""javascript:;"" class=""ml-5"" style=""text-decoration:none"" onClick=""$.mainu.stop(this,\'' + id + '\')"">停用</a>');
                                    $(obj).parents(""tr"").find("".td-status"").html('<span class=""label label-success radius"">已启用</span>');
                                    $(obj).remove();
                                    layer.msg('已启用！', { icon: 6, time: 3000 });
                                } else {
                                    layer.msg(message, { icon: 5, time: 3000 });
                                }
                  ");
                WriteLiteral(@"          },
                            error: function (data) {
                                console.log(data.msg);
                            }
                        });
                    });
                },
                del: function (obj, id) {
                    layer.confirm('确认要删除吗？', function (index) {
                        $.ajax({
                            type: 'POST',
                            url: '");
                EndContext();
                BeginContext(9830, 20, false);
#line 171 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                             Write(Url.Action("delete"));

#line default
#line hidden
                EndContext();
                BeginContext(9850, 1520, true);
                WriteLiteral(@"',
                            data: { positionid: id },
                            dataType: 'json',
                            success: function (result) {
                                var state = result.state;
                                var message = result.message;
                                if (state == ""success"") {
                                    $(obj).parents(""tr"").remove();
                                    layer.msg('已删除！', { icon: 1, time: 2000 });
                                } else {
                                    layer.msg(message, { icon: 5, time: 3000 });
                                }
                            },
                            error: function (data) {
                                console.log(data.msg);
                            },
                        });
                    });
                },
                delBatch: function () {
                    layer.confirm('确认要删除吗？', function (index) {
                 ");
                WriteLiteral(@"       var arrId = [];
                        $(""input:checkbox[name='id']:checked"").each(function () {
                            arrId.push($(this).val());
                        });
                        if (arrId.length == 0) {
                            layer.msg('请选择要删除的数据！', { icon: 5, time: 2000 });
                            return;
                        }
                        $.ajax({
                            type: 'POST',
                            url: '");
                EndContext();
                BeginContext(11371, 25, false);
#line 202 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionPosition\List.cshtml"
                             Write(Url.Action("deletebatch"));

#line default
#line hidden
                EndContext();
                BeginContext(11396, 957, true);
                WriteLiteral(@"',
                            data: { arrid: arrId },
                            dataType: 'json',
                            success: function (result) {
                                var state = result.state;
                                var message = result.message;
                                if (state == ""success"") {
                                    window.location.replace(location.href);
                                } else {
                                    layer.msg(message, { icon: 5, time: 1000 });
                                }
                            },
                            error: function (data) {
                                console.log(data.msg);
                            },
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
            BeginContext(12356, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Institution_Position>> Html { get; private set; }
    }
}
#pragma warning restore 1591
