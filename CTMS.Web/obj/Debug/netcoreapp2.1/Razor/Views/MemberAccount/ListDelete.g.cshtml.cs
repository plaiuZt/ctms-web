#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92a30901cfbbb7830e8203d6ecfee1bf22f79590"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MemberAccount_ListDelete), @"mvc.1.0.view", @"/Views/MemberAccount/ListDelete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MemberAccount/ListDelete.cshtml", typeof(AspNetCore.Views_MemberAccount_ListDelete))]
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
#line 4 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
using CTMS.Common.Enum;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a30901cfbbb7830e8203d6ecfee1bf22f79590", @"/Views/MemberAccount/ListDelete.cshtml")]
    public class Views_MemberAccount_ListDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Member_Account>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/datatables/1.10.0/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/My97DatePicker/4.8/WdatePicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
  
    ViewData["Title"] = "ListDelete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(234, 601, true);
            WriteLiteral(@"

<nav class=""breadcrumb""><i class=""Hui-iconfont"">&#xe67f;</i> 首页 <span class=""c-gray en"">&gt;</span> 会员管理 <span class=""c-gray en"">&gt;</span> 删除的会员 <a id=""btn_refresh"" class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a></nav>
<div class=""page-container"">
    <div class=""text-c"">
        日期范围：
        <input type=""text"" onfocus=""WdatePicker({ maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}' })"" id=""datemin"" name=""datemin"" class=""input-text Wdate"" style=""width:120px;""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 835, "\"", 859, 1);
#line 16 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
WriteAttributeValue("", 843, ViewBag.datemin, 843, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(860, 196, true);
            WriteLiteral(" />\r\n        -\r\n        <input type=\"text\" onfocus=\"WdatePicker({ minDate:\'#F{$dp.$D(\\\'datemin\\\')}\',maxDate:\'%y-%M-%d\' })\" id=\"datemax\" name=\"datemax\" class=\"input-text Wdate\" style=\"width:120px;\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1056, "\"", 1080, 1);
#line 18 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
WriteAttributeValue("", 1064, ViewBag.datemax, 1064, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1081, 304, true);
            WriteLiteral(@" />
        <select id=""rankId"" name=""rankId"" class=""select"" style=""width:100px; height:31px;vertical-align: middle;"">
            <option value="""">选择等级</option>
        </select>
        <input type=""text"" class=""input-text"" style=""width:350px"" placeholder=""输入会员编号、手机、邮箱"" id=""keyword"" name=""keyword""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1385, "\"", 1409, 1);
#line 22 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
WriteAttributeValue("", 1393, ViewBag.keyword, 1393, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1410, 423, true);
            WriteLiteral(@" />
        <button type=""submit"" class=""btn btn-success radius"" id=""driversearch"" name=""driversearch"" onclick=""$.mainu.search()""><i class=""Hui-iconfont"">&#xe665;</i> 查找</button>
    </div>
    <div class=""cl pd-5 bg-1 bk-gray mt-20"">
        <span class=""l"">
            <a href=""javascript:;"" onclick=""$.mainu.deleteBatch()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 批量删除</a>
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1833, "\"", 1865, 1);
#line 28 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
WriteAttributeValue("", 1840, Url.Action("ListDelete"), 1840, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1866, 136, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 删除的会员列表</a>\r\n        </span>\r\n        <span class=\"r\">共有数据：<strong>");
            EndContext();
            BeginContext(2003, 13, false);
#line 30 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                                Write(ViewBag.Count);

#line default
#line hidden
            EndContext();
            BeginContext(2016, 848, true);
            WriteLiteral(@"</strong> 条</span>
    </div>
    <div class=""mt-20"">
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""120"">会员ID</th>
                    <th width=""80"">等级</th>
                    <th width=""80"">姓名</th>
                    <th width=""80"">性别</th>
                    <th width=""120"">手机</th>
                    <th width=""100"">总积分</th>
                    <th width=""100"">总金额</th>
                    <th width="""">地址</th>
                    <th width=""80"">状态</th>
                    <th width=""120"">加入时间</th>
                    <th width=""100"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 51 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(2989, 109, true);
            WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td><input type=\"checkbox\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3098, "\"", 3117, 1);
#line 56 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
WriteAttributeValue("", 3106, m.MemberID, 3106, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3118, 40, true);
            WriteLiteral("></td>\r\n                            <td>");
            EndContext();
            BeginContext(3160, 56, false);
#line 57 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.MemberID, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3217, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3258, 56, false);
#line 58 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.RankName, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3315, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3356, 52, false);
#line 59 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.Name, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3409, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3450, 48, false);
#line 60 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                            Write(EnumHelper.GetName<ParamEnum.Sex>(m.Sex.ToInt()));

#line default
#line hidden
            EndContext();
            BeginContext(3499, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3539, 7, false);
#line 61 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                           Write(m.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(3546, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3586, 21, false);
#line 62 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                           Write(m.TotalPoints.ToInt());

#line default
#line hidden
            EndContext();
            BeginContext(3607, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3647, 21, false);
#line 63 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                           Write(m.TotalAmount.ToInt());

#line default
#line hidden
            EndContext();
            BeginContext(3668, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(3723, 9, false);
#line 64 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                                          Write(m.Address);

#line default
#line hidden
            EndContext();
            BeginContext(3732, 57, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-status\">");
            EndContext();
            BeginContext(3791, 146, false);
#line 65 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                                              Write(m.IsDel.ToBool() ? Html.Raw("<span class='label label-danger radius'>已删除</span>") : Html.Raw("<span class='label label-defaunt radius'>正常</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(3938, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3979, 77, false);
#line 66 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                            Write(m.CreateDate.HasValue ? m.CreateDate.Value.ToString("yyyy-MM-dd HH:mm") : "-");

#line default
#line hidden
            EndContext();
            BeginContext(4057, 166, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-manage\">\r\n                                <a title=\"还原\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4223, "\"", 4273, 3);
            WriteAttributeValue("", 4233, "$.mainu.updateDelete(this,\'", 4233, 27, true);
#line 68 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
WriteAttributeValue("", 4260, m.MemberID, 4260, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 4271, "\')", 4271, 2, true);
            EndWriteAttribute();
            BeginContext(4274, 116, true);
            WriteLiteral(">还原</a>\r\n                                <a title=\"删除\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4390, "\"", 4434, 3);
            WriteAttributeValue("", 4400, "$.mainu.delete(this,\'", 4400, 21, true);
#line 69 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
WriteAttributeValue("", 4421, m.MemberID, 4421, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 4432, "\')", 4432, 2, true);
            EndWriteAttribute();
            BeginContext(4435, 75, true);
            WriteLiteral(">删除</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 72 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(4552, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4691, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(4725, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7b25ea79dd1416fa2d1d76a81f891fd", async() => {
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
                BeginContext(4826, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4832, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "faac1a8394f841dfa64399c1aeb80524", async() => {
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
                BeginContext(4924, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4930, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e95185759cf446639bf5f9d826fe9ed2", async() => {
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
                BeginContext(5011, 509, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        (function ($) {
            $.mainu = {
                init: function () {
                    $('.table-sort').dataTable({
                        ""aaSorting"": [[10, ""desc""]],//默认第几个排序
                        ""bStateSave"": true,//状态保存
                        ""aoColumnDefs"": [
                          { ""orderable"": false, ""aTargets"": [0,11] }// 制定列不参与排序
                        ]
                    });
                    $.mainu.getMemberRank(""");
                EndContext();
                BeginContext(5521, 14, false);
#line 99 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                                      Write(ViewBag.RankID);

#line default
#line hidden
                EndContext();
                BeginContext(5535, 1026, true);
                WriteLiteral(@""");
                },
                search: function () {
                    $dateMin = $(""input[name='datemin']"").val();
                    $dateMax = $(""input[name='datemax']"").val();
                    $rankId = $(""select[name='rankId']"").val();
                    $keyword = $(""input[name='keyword']"").val();
                    if ($keyword == """") {
                        if ($dateMin == """" || $dateMax=="""") {
                            layer.alert('日期范围不能空', { icon: 5 });
                            return;
                        }
                    }
                    var param = {
                        datemin: $dateMin,
                        datemax: $dateMax,
                        rankId: $rankId,
                        keyword: $keyword
                    };
                    var url = ""?"" + urlEncodes(param);
                    window.location.href = url;
                },
                getMemberRank: function (rankId) {
                    var url =");
                WriteLiteral(" \"");
                EndContext();
                BeginContext(6562, 27, false);
#line 122 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                          Write(Url.Action("rank-list-get"));

#line default
#line hidden
                EndContext();
                BeginContext(6589, 1207, true);
                WriteLiteral(@""";
                    $.ajaxSetup({ cache: false });
                    $.get(url, { state: true }, function (result) {
                        var state = result.state;
                        var message = result.message;
                        var strOption = '<option value="""">选择等级</option>';
                        if (state == ""success"") {
                            var list = result.data;
                            for (var i = 0; i < list.length; i++) {
                                if (rankId == list[i].id)
                                    strOption += '<option value=""' + list[i].id + '"" selected>' + list[i].name + '</option>';
                                else
                                    strOption += '<option value=""' + list[i].id + '"">' + list[i].name + '</option>';
                            }
                        }
                        $(""#rankId"").html(strOption);
                    });
                },
                updateDelete: function (obj, ");
                WriteLiteral("id) {\r\n                    layer.confirm(\'确认要删除吗？\', function (index) {\r\n                        $.ajax({\r\n                            type: \'POST\',\r\n                            url: \'");
                EndContext();
                BeginContext(7797, 26, false);
#line 144 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                             Write(Url.Action("UpdateDelete"));

#line default
#line hidden
                EndContext();
                BeginContext(7823, 1136, true);
                WriteLiteral(@"',
                            data: { delete: false, memberId: id },
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
                delete: function (obj, id) {
                    layer.confirm('确认要删除吗？', function (index) {");
                WriteLiteral("\n                        $.ajax({\r\n                            type: \'POST\',\r\n                            url: \'");
                EndContext();
                BeginContext(8960, 20, false);
#line 167 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                             Write(Url.Action("delete"));

#line default
#line hidden
                EndContext();
                BeginContext(8980, 1535, true);
                WriteLiteral(@"',
                            data: { delete: true, memberId: id },
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
                WriteLiteral(@"                      var arrId = [];
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
                BeginContext(10516, 25, false);
#line 198 "E:\Projects\CTMS\CTMS.Web\Views\MemberAccount\ListDelete.cshtml"
                             Write(Url.Action("deletebatch"));

#line default
#line hidden
                EndContext();
                BeginContext(10541, 971, true);
                WriteLiteral(@"',
                            data: { delete: true, arrid: arrId },
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
            BeginContext(11515, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Member_Account>> Html { get; private set; }
    }
}
#pragma warning restore 1591
