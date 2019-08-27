#pragma checksum "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c8c935666e53ff83f8bca5e4a7fa483c6b3b1d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ExtendSearchKeyword_ListCount), @"mvc.1.0.view", @"/Views/ExtendSearchKeyword/ListCount.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ExtendSearchKeyword/ListCount.cshtml", typeof(AspNetCore.Views_ExtendSearchKeyword_ListCount))]
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
#line 1 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
using LdCms.Model.Extend;

#line default
#line hidden
#line 2 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
using LdCms.Common.Extension;

#line default
#line hidden
#line 3 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
using LdCms.Common.Utility;

#line default
#line hidden
#line 4 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
using LdCms.Common.Enum;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c8c935666e53ff83f8bca5e4a7fa483c6b3b1d2", @"/Views/ExtendSearchKeyword/ListCount.cshtml")]
    public class Views_ExtendSearchKeyword_ListCount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CountSearchKeywordByKeywordResult>>
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
#line 6 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
  
    ViewData["Title"] = "ListCount";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(260, 652, true);
            WriteLiteral(@"

<nav class=""breadcrumb"">
    <i class=""Hui-iconfont"">&#xe67f;</i> 首页 <span class=""c-gray en"">&gt;</span> 扩展管理 <span class=""c-gray en"">&gt;</span> 搜索管理 <span class=""c-gray en"">&gt;</span> 统计
    <a id=""btn_refresh"" class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a>
</nav>
<div class=""page-container"">
    <div class=""text-c"">
        日期范围：
        <input type=""text"" onfocus=""WdatePicker({ maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}' })"" id=""datemin"" name=""datemin"" class=""input-text Wdate"" style=""width:120px;""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 912, "\"", 940, 1);
#line 19 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
WriteAttributeValue("", 920, ViewData["DateMin"], 920, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(941, 196, true);
            WriteLiteral(" />\r\n        -\r\n        <input type=\"text\" onfocus=\"WdatePicker({ minDate:\'#F{$dp.$D(\\\'datemin\\\')}\',maxDate:\'%y-%M-%d\' })\" id=\"datemax\" name=\"datemax\" class=\"input-text Wdate\" style=\"width:120px;\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1137, "\"", 1165, 1);
#line 21 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
WriteAttributeValue("", 1145, ViewData["DateMax"], 1145, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1166, 118, true);
            WriteLiteral(" />\r\n        <input type=\"text\" class=\"input-text\" style=\"width:350px\" placeholder=\"输入关键字\" id=\"keyword\" name=\"keyword\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1284, "\"", 1312, 1);
#line 22 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
WriteAttributeValue("", 1292, ViewData["Keyword"], 1292, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1313, 423, true);
            WriteLiteral(@" />
        <button type=""submit"" class=""btn btn-success radius"" id=""driversearch"" name=""driversearch"" onclick=""$.mainu.search()""><i class=""Hui-iconfont"">&#xe665;</i> 查找</button>
    </div>
    <div class=""cl pd-5 bg-1 bk-gray mt-20"">
        <span class=""l"">
            <a href=""javascript:;"" onclick=""$.mainu.deleteBatch()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 批量删除</a>
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1736, "\"", 1762, 1);
#line 28 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
WriteAttributeValue("", 1743, Url.Action("list"), 1743, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1763, 93, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 搜索列表</a>\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1856, "\"", 1887, 1);
#line 29 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
WriteAttributeValue("", 1863, Url.Action("listCount"), 1863, 24, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1888, 134, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 关键字统计</a>\r\n        </span>\r\n        <span class=\"r\">共有数据：<strong>");
            EndContext();
            BeginContext(2023, 17, false);
#line 31 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                                Write(ViewData["Count"]);

#line default
#line hidden
            EndContext();
            BeginContext(2040, 627, true);
            WriteLiteral(@"</strong> 条</span>
    </div>
    <div class=""mt-20"">
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""80"">编号</th>
                    <th width="""">关键字</th>
                    <th width=""110"">总搜索量</th>
                    <th width=""120"">最早时间</th>
                    <th width=""120"">最新时间</th>
                    <th width=""100"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 47 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(2792, 109, true);
            WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td><input type=\"checkbox\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2901, "\"", 2914, 1);
#line 52 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
WriteAttributeValue("", 2909, m.ID, 2909, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2915, 40, true);
            WriteLiteral("></td>\r\n                            <td>");
            EndContext();
            BeginContext(2956, 4, false);
#line 53 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                           Write(m.ID);

#line default
#line hidden
            EndContext();
            BeginContext(2960, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(3016, 70, false);
#line 54 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                                           Write(Html.Raw(Utility.Highlight(m.Keyword, ViewData["keyword"].ToString())));

#line default
#line hidden
            EndContext();
            BeginContext(3087, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3127, 7, false);
#line 55 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                           Write(m.Total);

#line default
#line hidden
            EndContext();
            BeginContext(3134, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3174, 38, false);
#line 56 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                           Write(m.MinDate.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
            EndContext();
            BeginContext(3212, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3252, 38, false);
#line 57 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                           Write(m.MaxDate.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
            EndContext();
            BeginContext(3290, 166, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-manage\">\r\n                                <a title=\"查看\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3456, "\"", 3525, 3);
            WriteAttributeValue("", 3466, "$.mainu.show(\'编辑\',\'", 3466, 19, true);
#line 59 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
WriteAttributeValue("", 3485, Url.Action("Show", new { ID = m.ID }), 3485, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 3523, "\')", 3523, 2, true);
            EndWriteAttribute();
            BeginContext(3526, 75, true);
            WriteLiteral(">查看</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 62 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendSearchKeyword\ListCount.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(3643, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3782, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(3816, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "326199e3f29340cdb43c8e0f4dce5b81", async() => {
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
                BeginContext(3917, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3923, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb1845c02d4c47229d710584cd84057d", async() => {
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
                BeginContext(4015, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4021, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b933a477fc314263ba9a64543b0bd868", async() => {
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
                BeginContext(4102, 1846, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        (function ($) {
            $.mainu = {
                init: function () {
                    $('.table-sort').dataTable({
                        ""aaSorting"": [[3, ""desc""]],//默认第几个排序
                        ""bStateSave"": true,//状态保存
                        ""aoColumnDefs"": [
                          { ""orderable"": false, ""aTargets"": [0,6] }// 制定列不参与排序
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
                    var param = {
         ");
                WriteLiteral(@"               datemin: $dateMin,
                        datemax: $dateMax,
                        keyword: $keyword
                    };
                    var url = ""?"" + urlEncodes(param);
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
                deleteBatch: function () {
                    layer.msg(""不可操作删除！"", { icon: 5, time: 2000 });
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
            BeginContext(5951, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CountSearchKeywordByKeywordResult>> Html { get; private set; }
    }
}
#pragma warning restore 1591