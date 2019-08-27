#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10b069d4af9728072c1eddb889651a3efbf44231"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InstitutionCompany_List), @"mvc.1.0.view", @"/Views/InstitutionCompany/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/InstitutionCompany/List.cshtml", typeof(AspNetCore.Views_InstitutionCompany_List))]
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10b069d4af9728072c1eddb889651a3efbf44231", @"/Views/InstitutionCompany/List.cshtml")]
    public class Views_InstitutionCompany_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Institution_Company>>
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
#line 5 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(208, 600, true);
            WriteLiteral(@"

<nav class=""breadcrumb""><i class=""Hui-iconfont"">&#xe67f;</i> 首页 <span class=""c-gray en"">&gt;</span> 公司管理 <span class=""c-gray en"">&gt;</span> 公司管理 <a id=""btn_refresh"" class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a></nav>
<div class=""page-container"">
    <div class=""text-c"">
        日期范围：
        <input type=""text"" onfocus=""WdatePicker({ maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}' })"" id=""datemin"" name=""datemin"" class=""input-text Wdate"" style=""width:120px;""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 808, "\"", 832, 1);
#line 15 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
WriteAttributeValue("", 816, ViewBag.datemin, 816, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(833, 196, true);
            WriteLiteral(" />\r\n        -\r\n        <input type=\"text\" onfocus=\"WdatePicker({ minDate:\'#F{$dp.$D(\\\'datemin\\\')}\',maxDate:\'%y-%M-%d\' })\" id=\"datemax\" name=\"datemax\" class=\"input-text Wdate\" style=\"width:120px;\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1029, "\"", 1053, 1);
#line 17 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
WriteAttributeValue("", 1037, ViewBag.datemax, 1037, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1054, 125, true);
            WriteLiteral(" />\r\n        <input type=\"text\" class=\"input-text\" style=\"width:350px\" placeholder=\"输入公司名称、手机、邮箱\" id=\"keyword\" name=\"keyword\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1179, "\"", 1203, 1);
#line 18 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
WriteAttributeValue("", 1187, ViewBag.keyword, 1187, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1204, 420, true);
            WriteLiteral(@" />
        <button type=""submit"" class=""btn btn-success radius"" id=""driversearch"" name=""driversearch"" onclick=""$.mainu.search()""><i class=""Hui-iconfont"">&#xe665;</i> 查找</button>
    </div>
    <div class=""cl pd-5 bg-1 bk-gray mt-20"">
        <span class=""l"">
            <a href=""javascript:;"" onclick=""$.mainu.delBatch()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 批量删除</a>
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1624, "\"", 1650, 1);
#line 24 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
WriteAttributeValue("", 1631, Url.Action("list"), 1631, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1651, 133, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 公司列表</a>\r\n        </span>\r\n        <span class=\"r\">共有数据：<strong>");
            EndContext();
            BeginContext(1785, 13, false);
#line 26 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                                Write(ViewBag.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1798, 758, true);
            WriteLiteral(@"</strong> 条</span>
    </div>
    <div class=""mt-20"">
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""80"">公司编号</th>
                    <th width=""200"">公司名称</th>
                    <th width=""80"">姓名</th>
                    <th width=""100"">电话</th>
                    <th width=""100"">手机</th>
                    <th width="""">地址</th>
                    <th width=""120"">加入时间</th>
                    <th width=""70"">状态</th>
                    <th width=""80"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 45 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(2681, 109, true);
            WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td><input type=\"checkbox\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2790, "\"", 2810, 1);
#line 50 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
WriteAttributeValue("", 2798, m.CompanyID, 2798, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2811, 40, true);
            WriteLiteral("></td>\r\n                            <td>");
            EndContext();
            BeginContext(2853, 57, false);
#line 51 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.CompanyID, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(2911, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2952, 59, false);
#line 52 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.CompanyName, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3012, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3052, 10, false);
#line 53 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                           Write(m.NickName);

#line default
#line hidden
            EndContext();
            BeginContext(3062, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3102, 5, false);
#line 54 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                           Write(m.Tel);

#line default
#line hidden
            EndContext();
            BeginContext(3107, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3148, 53, false);
#line 55 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.Phone, ViewBag.keyword)));

#line default
#line hidden
            EndContext();
            BeginContext(3202, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(3257, 9, false);
#line 56 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                                          Write(m.Address);

#line default
#line hidden
            EndContext();
            BeginContext(3266, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3307, 77, false);
#line 57 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                            Write(m.CreateDate.HasValue ? m.CreateDate.Value.ToString("yyyy-MM-dd HH:mm") : "-");

#line default
#line hidden
            EndContext();
            BeginContext(3385, 57, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-status\">");
            EndContext();
            BeginContext(3444, 148, false);
#line 58 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                                              Write(m.State.ToBool() ? Html.Raw("<span class='label label-success radius'>已审核</span>") : Html.Raw("<span class='label label-defaunt radius'>待审核</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(3593, 124, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-manage\">\r\n                                <a title=\"编辑\" href=\"javascript:;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3717, "\"", 3806, 3);
            WriteAttributeValue("", 3727, "$.mainu.edit(\'编辑\',\'", 3727, 19, true);
#line 60 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
WriteAttributeValue("", 3746, Url.Action("edit", new { companyid = m.CompanyID }), 3746, 52, false);

#line default
#line hidden
            WriteAttributeValue("", 3798, "\',\'\',\'\')", 3798, 8, true);
            EndWriteAttribute();
            BeginContext(3807, 117, true);
            WriteLiteral(" class=\"ml-5\" style=\"text-decoration:none\">编辑</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 63 "E:\Projects\CTMS\CTMS.Web\Views\InstitutionCompany\List.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(3966, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4105, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(4139, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ea9ae3ce9044c3ab505e257dd4e17bb", async() => {
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
                BeginContext(4231, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4237, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36824932855f47f8b22a2290729be28f", async() => {
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
                BeginContext(4338, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4344, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e673b678ac34427a3d394c74b57ddd8", async() => {
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
                BeginContext(4425, 1832, true);
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
                show: function (title, url) {
                    var index = layer.open({
                        type: 2,
                        title: title,
                        content: url
                    });
                    layer.full(index);
                },
                edit: function (title, url, w, h) {
                    layer_show(title, url, w, h);
                },
                delBatch: function () {
                    layer.msg(""不可执行删除操作！"", { icon: 5, time: 3000 });
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
            BeginContext(6260, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Institution_Company>> Html { get; private set; }
    }
}
#pragma warning restore 1591