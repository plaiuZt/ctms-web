#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b06e4a47b27d072a640ca1f35b42e7bbf30aa91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MemberRank_List), @"mvc.1.0.view", @"/Views/MemberRank/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MemberRank/List.cshtml", typeof(AspNetCore.Views_MemberRank_List))]
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b06e4a47b27d072a640ca1f35b42e7bbf30aa91", @"/Views/MemberRank/List.cshtml")]
    public class Views_MemberRank_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Member_Rank>>
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
#line 5 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(200, 598, true);
            WriteLiteral(@"
<nav class=""breadcrumb""><i class=""Hui-iconfont"">&#xe67f;</i> 首页 <span class=""c-gray en"">&gt;</span> 会员管理 <span class=""c-gray en"">&gt;</span> 等级管理 <a id=""btn_refresh"" class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a></nav>
<div class=""page-container"">
    <div class=""text-c"">
        日期范围：
        <input type=""text"" onfocus=""WdatePicker({ maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}' })"" id=""datemin"" name=""datemin"" class=""input-text Wdate"" style=""width:120px;""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 798, "\"", 822, 1);
#line 14 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 806, ViewBag.datemin, 806, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(823, 196, true);
            WriteLiteral(" />\r\n        -\r\n        <input type=\"text\" onfocus=\"WdatePicker({ minDate:\'#F{$dp.$D(\\\'datemin\\\')}\',maxDate:\'%y-%M-%d\' })\" id=\"datemax\" name=\"datemax\" class=\"input-text Wdate\" style=\"width:120px;\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1019, "\"", 1043, 1);
#line 16 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 1027, ViewBag.datemax, 1027, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1044, 122, true);
            WriteLiteral(" />\r\n        <input type=\"text\" class=\"input-text\" style=\"width:350px\" placeholder=\"输入等级编号、名称\" id=\"keyword\" name=\"keyword\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1166, "\"", 1190, 1);
#line 17 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 1174, ViewBag.keyword, 1174, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1191, 423, true);
            WriteLiteral(@" />
        <button type=""submit"" class=""btn btn-success radius"" id=""driversearch"" name=""driversearch"" onclick=""$.mainu.search()""><i class=""Hui-iconfont"">&#xe665;</i> 查找</button>
    </div>
    <div class=""cl pd-5 bg-1 bk-gray mt-20"">
        <span class=""l"">
            <a href=""javascript:;"" onclick=""$.mainu.deleteBatch()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 批量删除</a>
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1614, "\"", 1640, 1);
#line 23 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 1621, Url.Action("list"), 1621, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1641, 144, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 等级列表</a>\r\n            <a href=\"javascript:;\" class=\"btn btn-primary radius\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1785, "\"", 1841, 3);
            WriteAttributeValue("", 1795, "$.mainu.add(\'新增职位\',\'", 1795, 20, true);
#line 24 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 1815, Url.Action("add"), 1815, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 1833, "\',\'\',\'\')", 1833, 8, true);
            EndWriteAttribute();
            BeginContext(1842, 102, true);
            WriteLiteral("><i class=\"Hui-iconfont\">&#xe600;</i> 新增等级</a>\r\n        </span>\r\n        <span class=\"r\">共有数据：<strong>");
            EndContext();
            BeginContext(1945, 13, false);
#line 26 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                                Write(ViewBag.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1958, 759, true);
            WriteLiteral(@"</strong> 条</span>
    </div>
    <div class=""mt-20"">
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""60"">编号</th>
                    <th width=""120"">名称</th>
                    <th width=""100"">最小积分</th>
                    <th width=""100"">最大积分</th>
                    <th width=""80"">优惠</th>
                    <th width="""">描述</th>
                    <th width=""80"">状态</th>
                    <th width=""120"">加入时间</th>
                    <th width=""120"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 45 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(2842, 93, true);
            WriteLiteral("                <tr class=\"text-c\">\r\n                    <td><input type=\"checkbox\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2935, "\"", 2952, 1);
#line 50 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 2943, m.RankID, 2943, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2953, 32, true);
            WriteLiteral("></td>\r\n                    <td>");
            EndContext();
            BeginContext(2986, 8, false);
#line 51 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                   Write(m.RankID);

#line default
#line hidden
            EndContext();
            BeginContext(2994, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3027, 56, false);
#line 52 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                    Write(Html.Raw(Utility.Highlight(m.RankName, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3084, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3116, 19, false);
#line 53 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                   Write(m.MinPoints.ToInt());

#line default
#line hidden
            EndContext();
            BeginContext(3135, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3167, 19, false);
#line 54 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                   Write(m.MaxPoints.ToInt());

#line default
#line hidden
            EndContext();
            BeginContext(3186, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3218, 18, false);
#line 55 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                   Write(m.Discount.ToInt());

#line default
#line hidden
            EndContext();
            BeginContext(3236, 46, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-l\">");
            EndContext();
            BeginContext(3283, 8, false);
#line 56 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                                  Write(m.Remark);

#line default
#line hidden
            EndContext();
            BeginContext(3291, 49, true);
            WriteLiteral("</td>\r\n                    <td class=\"td-status\">");
            EndContext();
            BeginContext(3342, 148, false);
#line 57 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                                      Write(m.State.ToBool() ? Html.Raw("<span class='label label-success radius'>已启用</span>") : Html.Raw("<span class='label label-defaunt radius'>已停用</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(3491, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3524, 77, false);
#line 58 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                    Write(m.CreateDate.HasValue ? m.CreateDate.Value.ToString("yyyy-MM-dd HH:mm") : "-");

#line default
#line hidden
            EndContext();
            BeginContext(3602, 51, true);
            WriteLiteral("</td>\r\n                    <td class=\"td-manage\">\r\n");
            EndContext();
#line 60 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                         if (m.State.ToBool())
                        {

#line default
#line hidden
            BeginContext(3728, 103, true);
            WriteLiteral("                            <a title=\"停用\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 3831, "\"", 3871, 3);
            WriteAttributeValue("", 3841, "$.mainu.stop(this,\'", 3841, 19, true);
#line 62 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 3860, m.RankID, 3860, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 3869, "\')", 3869, 2, true);
            EndWriteAttribute();
            BeginContext(3872, 9, true);
            WriteLiteral(">停用</a>\r\n");
            EndContext();
#line 63 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(3965, 103, true);
            WriteLiteral("                            <a title=\"启用\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 4068, "\"", 4109, 3);
            WriteAttributeValue("", 4078, "$.mainu.start(this,\'", 4078, 20, true);
#line 66 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 4098, m.RankID, 4098, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 4107, "\')", 4107, 2, true);
            EndWriteAttribute();
            BeginContext(4110, 9, true);
            WriteLiteral(">启用</a>\r\n");
            EndContext();
#line 67 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                        }

#line default
#line hidden
            BeginContext(4146, 99, true);
            WriteLiteral("                        <a title=\"编辑\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4245, "\"", 4327, 3);
            WriteAttributeValue("", 4255, "$.mainu.edit(\'编辑\',\'", 4255, 19, true);
#line 68 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 4274, Url.Action("add", new { RankID = m.RankID }), 4274, 45, false);

#line default
#line hidden
            WriteAttributeValue("", 4319, "\',\'\',\'\')", 4319, 8, true);
            EndWriteAttribute();
            BeginContext(4328, 108, true);
            WriteLiteral(">编辑</a>\r\n                        <a title=\"删除\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4436, "\"", 4478, 3);
            WriteAttributeValue("", 4446, "$.mainu.delete(this,\'", 4446, 21, true);
#line 69 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
WriteAttributeValue("", 4467, m.RankID, 4467, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 4476, "\')", 4476, 2, true);
            EndWriteAttribute();
            BeginContext(4479, 59, true);
            WriteLiteral(">删除</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 72 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(4580, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4719, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(4753, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0df72e1864e947d689461a2f15e6a71b", async() => {
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
                BeginContext(4845, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4851, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31203b226d094b0eab322833dfa8c6ab", async() => {
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
                BeginContext(4952, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4958, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f34e7f76c3544d9a5fc7c66f1469342", async() => {
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
                BeginContext(5039, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5045, 96, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "989182aed9544365b28603f18964bc9c", async() => {
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
                BeginContext(5141, 1625, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        (function ($) {
            $.mainu = {
                init: function () {
                    $('.table-sort').dataTable({
                        ""aaSorting"": [[1, ""asc""]],//默认第几个排序
                        ""bStateSave"": true,//状态保存
                        ""aoColumnDefs"": [
                          { ""orderable"": false, ""aTargets"": [0,9] }// 制定列不参与排序
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
                    var url = ""?datemin="" + $");
                WriteLiteral(@"dateMin + ""&datemax="" + $dateMax + ""&keyword="" + $keyword + """";
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
                BeginContext(6767, 25, false);
#line 124 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                             Write(Url.Action("UpdateState"));

#line default
#line hidden
                EndContext();
                BeginContext(6792, 1472, true);
                WriteLiteral(@"',
                            data: { rankId: id, state: false },
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
                WriteLiteral(@"        },
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
                BeginContext(8265, 25, false);
#line 149 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                             Write(Url.Action("UpdateState"));

#line default
#line hidden
                EndContext();
                BeginContext(8290, 1471, true);
                WriteLiteral(@"',
                            data: { rankId: id, state: true },
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
                WriteLiteral(@"      },
                            error: function (data) {
                                console.log(data.msg);
                            }
                        });
                    });
                },
                delete: function (obj, id) {
                    layer.confirm('确认要删除吗？', function (index) {
                        $.ajax({
                            type: 'POST',
                            url: '");
                EndContext();
                BeginContext(9762, 20, false);
#line 174 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                             Write(Url.Action("delete"));

#line default
#line hidden
                EndContext();
                BeginContext(9782, 1519, true);
                WriteLiteral(@"',
                            data: { rankId: id },
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
                deleteBatch: function () {
                    layer.confirm('确认要删除吗？', function (index) {
                  ");
                WriteLiteral(@"      var arrId = [];
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
                BeginContext(11302, 25, false);
#line 205 "E:\Projects\CTMS\CTMS.Web\Views\MemberRank\List.cshtml"
                             Write(Url.Action("deletebatch"));

#line default
#line hidden
                EndContext();
                BeginContext(11327, 957, true);
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
            BeginContext(12287, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Member_Rank>> Html { get; private set; }
    }
}
#pragma warning restore 1591
