#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc640d79a85214585365d51d2a75207cd659d30f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ExtendAdvertisement_List), @"mvc.1.0.view", @"/Views/ExtendAdvertisement/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ExtendAdvertisement/List.cshtml", typeof(AspNetCore.Views_ExtendAdvertisement_List))]
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
#line 4 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
using CTMS.Common.Enum;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc640d79a85214585365d51d2a75207cd659d30f", @"/Views/ExtendAdvertisement/List.cshtml")]
    public class Views_ExtendAdvertisement_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Extend_Advertisement>>
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
#line 6 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(234, 652, true);
            WriteLiteral(@"

<nav class=""breadcrumb"">
    <i class=""Hui-iconfont"">&#xe67f;</i> 首页 <span class=""c-gray en"">&gt;</span> 扩展管理 <span class=""c-gray en"">&gt;</span> 广告管理 <span class=""c-gray en"">&gt;</span> 列表
    <a id=""btn_refresh"" class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a>
</nav>
<div class=""page-container"">
    <div class=""text-c"">
        日期范围：
        <input type=""text"" onfocus=""WdatePicker({ maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}' })"" id=""datemin"" name=""datemin"" class=""input-text Wdate"" style=""width:120px;""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 886, "\"", 914, 1);
#line 19 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 894, ViewData["datemin"], 894, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(915, 196, true);
            WriteLiteral(" />\r\n        -\r\n        <input type=\"text\" onfocus=\"WdatePicker({ minDate:\'#F{$dp.$D(\\\'datemin\\\')}\',maxDate:\'%y-%M-%d\' })\" id=\"datemax\" name=\"datemax\" class=\"input-text Wdate\" style=\"width:120px;\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1111, "\"", 1139, 1);
#line 21 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 1119, ViewData["datemax"], 1119, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1140, 193, true);
            WriteLiteral(" />\r\n        <select id=\"state\" name=\"state\" class=\"select\" style=\"width:100px; height:31px;vertical-align: middle;\">\r\n            <option value=\"\">选择状态</option>\r\n            <option value=\"0\" ");
            EndContext();
            BeginContext(1335, 53, false);
#line 24 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                          Write(ViewData["State"].ToString() == "0" ? "selected" : "");

#line default
#line hidden
            EndContext();
            BeginContext(1389, 45, true);
            WriteLiteral(">待审核</option>\r\n            <option value=\"1\" ");
            EndContext();
            BeginContext(1436, 53, false);
#line 25 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                          Write(ViewData["State"].ToString() == "1" ? "selected" : "");

#line default
#line hidden
            EndContext();
            BeginContext(1490, 149, true);
            WriteLiteral(">已审核</option>\r\n        </select>\r\n        <input type=\"text\" class=\"input-text\" style=\"width:350px\" placeholder=\"请输入广告名称\" id=\"keyword\" name=\"keyword\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1639, "\"", 1667, 1);
#line 27 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 1647, ViewData["keyword"], 1647, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1668, 423, true);
            WriteLiteral(@" />
        <button type=""submit"" class=""btn btn-success radius"" id=""driversearch"" name=""driversearch"" onclick=""$.mainu.search()""><i class=""Hui-iconfont"">&#xe665;</i> 查找</button>
    </div>
    <div class=""cl pd-5 bg-1 bk-gray mt-20"">
        <span class=""l"">
            <a href=""javascript:;"" onclick=""$.mainu.deleteBatch()"" class=""btn btn-danger radius""><i class=""Hui-iconfont"">&#xe6e2;</i> 批量删除</a>
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2091, "\"", 2117, 1);
#line 33 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 2098, Url.Action("list"), 2098, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2118, 144, true);
            WriteLiteral(" class=\"btn btn-primary radius\"><i class=\"Hui-iconfont\">&#xe667;</i> 广告列表</a>\r\n            <a href=\"javascript:;\" class=\"btn btn-primary radius\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2262, "\"", 2312, 3);
            WriteAttributeValue("", 2272, "$.mainu.add(\'新增广告\',\'", 2272, 20, true);
#line 34 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 2292, Url.Action("add"), 2292, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 2310, "\')", 2310, 2, true);
            EndWriteAttribute();
            BeginContext(2313, 102, true);
            WriteLiteral("><i class=\"Hui-iconfont\">&#xe600;</i> 新增广告</a>\r\n        </span>\r\n        <span class=\"r\">共有数据：<strong>");
            EndContext();
            BeginContext(2416, 17, false);
#line 36 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                                Write(ViewData["Count"]);

#line default
#line hidden
            EndContext();
            BeginContext(2433, 665, true);
            WriteLiteral(@"</strong> 条</span>
    </div>
    <div class=""mt-20"">
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width=""25""><input type=""checkbox"" name="""" value=""""></th>
                    <th width=""90"">编号</th>
                    <th width=""180"">名称</th>
                    <th width="""">注备</th>
                    <th width=""80"">排序</th>
                    <th width=""80"">状态</th>
                    <th width=""120"">加入时间</th>
                    <th width=""120"">操作</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 53 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                 if (Model != null)
                {
                    foreach (var m in Model)
                    {

#line default
#line hidden
            BeginContext(3223, 109, true);
            WriteLiteral("                        <tr class=\"text-c\">\r\n                            <td><input type=\"checkbox\" name=\"id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3332, "\"", 3358, 1);
#line 58 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 3340, m.AdvertisementID, 3340, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3359, 40, true);
            WriteLiteral("></td>\r\n                            <td>");
            EndContext();
            BeginContext(3400, 17, false);
#line 59 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                           Write(m.AdvertisementID);

#line default
#line hidden
            EndContext();
            BeginContext(3417, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3458, 67, false);
#line 60 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                            Write(Html.Raw(Utility.Highlight(m.Name, ViewData["keyword"].ToString())));

#line default
#line hidden
            EndContext();
            BeginContext(3526, 54, true);
            WriteLiteral("</td>\r\n                            <td class=\"text-l\">");
            EndContext();
            BeginContext(3582, 69, false);
#line 61 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                                           Write(Html.Raw(Utility.Highlight(m.Remark, ViewData["keyword"].ToString())));

#line default
#line hidden
            EndContext();
            BeginContext(3652, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3692, 14, false);
#line 62 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                           Write(m.Sort.ToInt());

#line default
#line hidden
            EndContext();
            BeginContext(3706, 57, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-status\">");
            EndContext();
            BeginContext(3765, 148, false);
#line 63 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                                              Write(m.State.ToBool() ? Html.Raw("<span class='label label-success radius'>已启用</span>") : Html.Raw("<span class='label label-defaunt radius'>已停用</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(3914, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3955, 77, false);
#line 64 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                            Write(m.CreateDate.HasValue ? m.CreateDate.Value.ToString("yyyy-MM-dd HH:mm") : "-");

#line default
#line hidden
            EndContext();
            BeginContext(4033, 59, true);
            WriteLiteral("</td>\r\n                            <td class=\"td-manage\">\r\n");
            EndContext();
#line 66 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                                 if (m.State.ToBool())
                                {

#line default
#line hidden
            BeginContext(4183, 111, true);
            WriteLiteral("                                    <a title=\"停用\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 4294, "\"", 4343, 3);
            WriteAttributeValue("", 4304, "$.mainu.stop(this,\'", 4304, 19, true);
#line 68 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 4323, m.AdvertisementID, 4323, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 4341, "\')", 4341, 2, true);
            EndWriteAttribute();
            BeginContext(4344, 9, true);
            WriteLiteral(">停用</a>\r\n");
            EndContext();
#line 69 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(4461, 111, true);
            WriteLiteral("                                    <a title=\"启用\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onClick", " onClick=\"", 4572, "\"", 4622, 3);
            WriteAttributeValue("", 4582, "$.mainu.start(this,\'", 4582, 20, true);
#line 72 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 4602, m.AdvertisementID, 4602, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 4620, "\')", 4620, 2, true);
            EndWriteAttribute();
            BeginContext(4623, 9, true);
            WriteLiteral(">启用</a>\r\n");
            EndContext();
#line 73 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                                }

#line default
#line hidden
            BeginContext(4667, 107, true);
            WriteLiteral("                                <a title=\"编辑\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4774, "\"", 4873, 3);
            WriteAttributeValue("", 4784, "$.mainu.add(\'编辑\',\'", 4784, 18, true);
#line 74 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 4802, Url.Action("add", new { AdvertisementID = m.AdvertisementID }), 4802, 63, false);

#line default
#line hidden
            WriteAttributeValue("", 4865, "\',\'\',\'\')", 4865, 8, true);
            EndWriteAttribute();
            BeginContext(4874, 116, true);
            WriteLiteral(">编辑</a>\r\n                                <a title=\"删除\" href=\"javascript:;\" class=\"ml-5\" style=\"text-decoration:none\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4990, "\"", 5041, 3);
            WriteAttributeValue("", 5000, "$.mainu.delete(this,\'", 5000, 21, true);
#line 75 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
WriteAttributeValue("", 5021, m.AdvertisementID, 5021, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 5039, "\')", 5039, 2, true);
            EndWriteAttribute();
            BeginContext(5042, 75, true);
            WriteLiteral(">删除</a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 78 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(5159, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5298, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(5332, 101, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66f7f96ca14d4b57aa4543cbda47b36c", async() => {
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
                BeginContext(5433, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5439, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca98d79818bc44edb36bb4de3eea1b29", async() => {
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
                BeginContext(5531, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5537, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c7b2310a5814d858d3aaf463e3ae1bc", async() => {
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
                BeginContext(5618, 1906, true);
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
                    $state = $(""select[name='state']"").val();
                    $keyword = $(""input[name='keyword']"").val();
                    if ($keyword == """") {
                        if ($dateMin == """" || $dateMax=="""") {
                            layer.alert('日期范围不能空', { icon: 5 });
                            return;
                        }
    ");
                WriteLiteral(@"                }
                    var param = {
                        datemin: $dateMin,
                        datemax: $dateMax,
                        state: $state,
                        keyword: $keyword
                    };
                    var url = ""?"" + urlEncodes(param);
                    window.location.href = url;
                },
                add: function (title, url) {
                    var index = layer.open({
                        type: 2,
                        title: title,
                        content: url
                    });
                    layer.full(index);
                },
                stop: function (obj, id) {
                    layer.confirm('确认要停用吗？', function (index) {
                        $.ajax({
                            type: 'POST',
                            url: '");
                EndContext();
                BeginContext(7525, 25, false);
#line 138 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                             Write(Url.Action("UpdateState"));

#line default
#line hidden
                EndContext();
                BeginContext(7550, 1481, true);
                WriteLiteral(@"',
                            data: { advertisementId: id, state: false },
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
                WriteLiteral(@"                 },
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
                BeginContext(9032, 25, false);
#line 163 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                             Write(Url.Action("UpdateState"));

#line default
#line hidden
                EndContext();
                BeginContext(9057, 1480, true);
                WriteLiteral(@"',
                            data: { advertisementId: id, state: true },
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
                WriteLiteral(@"               },
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
                BeginContext(10538, 20, false);
#line 188 "E:\Projects\CTMS\CTMS.Web\Views\ExtendAdvertisement\List.cshtml"
                             Write(Url.Action("delete"));

#line default
#line hidden
                EndContext();
                BeginContext(10558, 1171, true);
                WriteLiteral(@"',
                            data: { advertisementId: id },
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
                    layer.msg(""不支持批量删除操作！"", { icon: 5, time: 3000 });
   ");
                WriteLiteral("             }\r\n            };\r\n            $(function () {\r\n                $.mainu.init();\r\n            });\r\n        })(jQuery);\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(11732, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Extend_Advertisement>> Html { get; private set; }
    }
}
#pragma warning restore 1591
