#pragma checksum "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ccd5027baf2759b7054b489985fe586de754ff2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceMessageBoard_Show), @"mvc.1.0.view", @"/Views/ServiceMessageBoard/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ServiceMessageBoard/Show.cshtml", typeof(AspNetCore.Views_ServiceMessageBoard_Show))]
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
#line 1 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
using LdCms.EF.DbModels;

#line default
#line hidden
#line 2 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
using LdCms.Common.Utility;

#line default
#line hidden
#line 3 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
using LdCms.Common.Extension;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ccd5027baf2759b7054b489985fe586de754ff2", @"/Views/ServiceMessageBoard/Show.cshtml")]
    public class Views_ServiceMessageBoard_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ld_Service_MessageBoard>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/validate-methods.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/messages_zh.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
  
    ViewData["Title"] = "Show";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(205, 402, true);
            WriteLiteral(@"
<article class=""page-container"">
    <div>
        <div style=""height:32px;line-height:32px;"">基本信息：</div>
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <tbody>
                <tr>
                    <td class=""text-r"" style=""background-color:#f5fafe;"" width=""200"">留言ID：</td>
                    <td class=""text-l"" width="""" colspan=""3"">");
            EndContext();
            BeginContext(608, 15, false);
#line 17 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.MessageID);

#line default
#line hidden
            EndContext();
            BeginContext(623, 200, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">公司名称：</td>\r\n                    <td class=\"text-l\" width=\"35%\">");
            EndContext();
            BeginContext(824, 17, false);
#line 21 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                              Write(Model.CompanyName);

#line default
#line hidden
            EndContext();
            BeginContext(841, 151, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">联系人：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(993, 10, false);
#line 23 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1003, 197, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">联系电话：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1201, 9, false);
#line 27 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Tel);

#line default
#line hidden
            EndContext();
            BeginContext(1210, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">联系手机：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1363, 11, false);
#line 29 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(1374, 197, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">邮箱地址：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1572, 11, false);
#line 33 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1583, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">IP地址：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1736, 15, false);
#line 35 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.IpAddress);

#line default
#line hidden
            EndContext();
            BeginContext(1751, 197, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">审阅状态：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1949, 11, false);
#line 39 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.State);

#line default
#line hidden
            EndContext();
            BeginContext(1960, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">置顶状态：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(2113, 11, false);
#line 41 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.IsTop);

#line default
#line hidden
            EndContext();
            BeginContext(2124, 209, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">留言内容：</td>\r\n                    <td class=\"text-l\" width=\"\" colspan=\"3\">");
            EndContext();
            BeginContext(2334, 13, false);
#line 45 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.Content);

#line default
#line hidden
            EndContext();
            BeginContext(2347, 209, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">留言时间：</td>\r\n                    <td class=\"text-l\" width=\"\" colspan=\"3\">");
            EndContext();
            BeginContext(2557, 16, false);
#line 49 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.CreateDate);

#line default
#line hidden
            EndContext();
            BeginContext(2573, 425, true);
            WriteLiteral(@"</td>
                </tr>
            </tbody>
        </table>
        <div style=""height:32px;line-height:32px;"">回复信息：</div>
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <tbody>
                <tr>
                    <td class=""text-r"" style=""background-color:#f5fafe;"" width=""200"">回复内容：</td>
                    <td class=""text-l"" width="""" colspan=""3"">");
            EndContext();
            BeginContext(2999, 11, false);
#line 58 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.Reply);

#line default
#line hidden
            EndContext();
            BeginContext(3010, 200, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">员工工号：</td>\r\n                    <td class=\"text-l\" width=\"35%\">");
            EndContext();
            BeginContext(3211, 18, false);
#line 62 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                              Write(Model.ReplyStaffId);

#line default
#line hidden
            EndContext();
            BeginContext(3229, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">员工姓名：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(3382, 20, false);
#line 64 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.ReplyStaffName);

#line default
#line hidden
            EndContext();
            BeginContext(3402, 209, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">回复时间：</td>\r\n                    <td class=\"text-l\" width=\"\" colspan=\"3\">");
            EndContext();
            BeginContext(3612, 15, false);
#line 68 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.ReplyTime);

#line default
#line hidden
            EndContext();
            BeginContext(3627, 1001, true);
            WriteLiteral(@"</td>
                </tr>
            </tbody>
        </table>
        <div style=""height:32px;line-height:32px;"">操作信息：</div>
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <tbody>
                <tr>
                    <td class=""text-r"" style=""background-color:#f5fafe;"" width=""200"">回复：</td>
                    <td class=""text-l"" width="""">
                        <textarea id=""fReply"" name=""fReply"" class=""textarea"" placeholder=""说点什么...100个字符以内"" dragonfly=""true""></textarea>
                        <p class=""textarea-numberbar""><em class=""textarea-length"">0</em>/100</p>
                    </td>
                </tr>
                <tr>
                    <td class=""text-r"" style=""background-color:#f5fafe;"" width=""200"">审阅：</td>
                    <td class=""text-l"" width="""">
                        <div class=""check-box"">
                            <input type=""checkbox"" id=""fState"" name=""fState"" value=""1"" ");
            EndContext();
            BeginContext(4630, 37, false);
#line 86 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                                                   Write(Model.State.ToBool() ? "checked" : "");

#line default
#line hidden
            EndContext();
            BeginContext(4668, 599, true);
            WriteLiteral(@" />
                            <label for=""checkbox-1"">&nbsp;</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class=""text-r"" style=""background-color:#f5fafe;"" width=""200""></td>
                    <td class=""text-l"" width="""">
                        <a class=""btn btn-primary radius"" onclick=""$.mainu.updateReply()"">提交</a>
                    </td>
                </tr>
            </tbody>
        </table>


    </div>
    <div class=""pt-30"" style=""width:100%; height:60px;""></div>
</article>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5346, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(5380, 102, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c80e6e833d9b42ecbd0259193fbbd1f0", async() => {
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
                BeginContext(5482, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5488, 103, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd1d2a28a9dd4df4b9a7771ea8a2556f", async() => {
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
                BeginContext(5591, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5597, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f8e733f6c3545ea99a8e1300e26e4f2", async() => {
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
                BeginContext(5695, 924, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        (function ($) {
            $.mainu = {
                init: function () {
                    $('.check-box input').iCheck({
                        checkboxClass: 'icheckbox-blue',
                        radioClass: 'iradio-blue',
                        increaseArea: '20%'
                    });
                    $(""#fReply"").Huitextarealength({
                        minlength: 4,
                        maxlength: 100
                    });
                },
                updateReply: function () {
                    var fReply = $(""textarea[name='fReply']"").val();
                    var fState = $(""input[name='fState']"").is(':checked');
                    if (fReply.length <= 1) {
                        layer.alert(""回复内容不能为空！"", { icon: 5 });
                        return;
                    }
                    var url = """);
                EndContext();
                BeginContext(6620, 62, false);
#line 135 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ServiceMessageBoard\Show.cshtml"
                          Write(Url.Action("UpdateReply", new { MessageID = Model.MessageID }));

#line default
#line hidden
                EndContext();
                BeginContext(6682, 937, true);
                WriteLiteral(@""";
                    var data = {
                        fReply: fReply,
                        fState: fState
                    };
                    $.ajax({
                        url: url,
                        type: ""POST"",
                        cache: false,
                        data: data,
                        success: function (result) {
                            var state = result.state;
                            var message = result.message;
                            if (state == ""success"") {
                                location.reload();
                            } else {
                                layer.alert(message, { icon: 5 });
                            }
                        }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ld_Service_MessageBoard> Html { get; private set; }
    }
}
#pragma warning restore 1591
