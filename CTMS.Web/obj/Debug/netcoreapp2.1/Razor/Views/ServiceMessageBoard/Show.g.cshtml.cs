#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb4b3d98b02e47bf2ecf9f6adf1e858724a98dcd"
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
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
using CTMS.DbModels;

#line default
#line hidden
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4b3d98b02e47bf2ecf9f6adf1e858724a98dcd", @"/Views/ServiceMessageBoard/Show.cshtml")]
    public class Views_ServiceMessageBoard_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Service_MessageBoard>
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
#line 5 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
  
    ViewData["Title"] = "Show";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(196, 402, true);
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
            BeginContext(599, 15, false);
#line 17 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.MessageID);

#line default
#line hidden
            EndContext();
            BeginContext(614, 200, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">公司名称：</td>\r\n                    <td class=\"text-l\" width=\"35%\">");
            EndContext();
            BeginContext(815, 17, false);
#line 21 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                              Write(Model.CompanyName);

#line default
#line hidden
            EndContext();
            BeginContext(832, 151, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">联系人：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(984, 10, false);
#line 23 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(994, 197, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">联系电话：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1192, 9, false);
#line 27 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Tel);

#line default
#line hidden
            EndContext();
            BeginContext(1201, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">联系手机：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1354, 11, false);
#line 29 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(1365, 197, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">邮箱地址：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1563, 11, false);
#line 33 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1574, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">IP地址：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1727, 15, false);
#line 35 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.IpAddress);

#line default
#line hidden
            EndContext();
            BeginContext(1742, 197, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">审阅状态：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(1940, 11, false);
#line 39 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.State);

#line default
#line hidden
            EndContext();
            BeginContext(1951, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">置顶状态：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(2104, 11, false);
#line 41 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.IsTop);

#line default
#line hidden
            EndContext();
            BeginContext(2115, 209, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">留言内容：</td>\r\n                    <td class=\"text-l\" width=\"\" colspan=\"3\">");
            EndContext();
            BeginContext(2325, 13, false);
#line 45 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.Content);

#line default
#line hidden
            EndContext();
            BeginContext(2338, 209, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">留言时间：</td>\r\n                    <td class=\"text-l\" width=\"\" colspan=\"3\">");
            EndContext();
            BeginContext(2548, 16, false);
#line 49 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.CreateDate);

#line default
#line hidden
            EndContext();
            BeginContext(2564, 425, true);
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
            BeginContext(2990, 11, false);
#line 58 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.Reply);

#line default
#line hidden
            EndContext();
            BeginContext(3001, 200, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">员工工号：</td>\r\n                    <td class=\"text-l\" width=\"35%\">");
            EndContext();
            BeginContext(3202, 18, false);
#line 62 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                              Write(Model.ReplyStaffId);

#line default
#line hidden
            EndContext();
            BeginContext(3220, 152, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">员工姓名：</td>\r\n                    <td class=\"text-l\" width=\"\">");
            EndContext();
            BeginContext(3373, 20, false);
#line 64 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                           Write(Model.ReplyStaffName);

#line default
#line hidden
            EndContext();
            BeginContext(3393, 209, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"text-r\" style=\"background-color:#f5fafe;\" width=\"200\">回复时间：</td>\r\n                    <td class=\"text-l\" width=\"\" colspan=\"3\">");
            EndContext();
            BeginContext(3603, 15, false);
#line 68 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                       Write(Model.ReplyTime);

#line default
#line hidden
            EndContext();
            BeginContext(3618, 1001, true);
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
            BeginContext(4621, 37, false);
#line 86 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                                                                                   Write(Model.State.ToBool() ? "checked" : "");

#line default
#line hidden
            EndContext();
            BeginContext(4659, 599, true);
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
                BeginContext(5337, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(5371, 102, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03523d8620e0427c866dfc49ef5fdbd3", async() => {
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
                BeginContext(5473, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5479, 103, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42f61b0875a444e2a3a380abc52276ed", async() => {
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
                BeginContext(5582, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5588, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a566898483e94691b8fbfe94c3c92a3e", async() => {
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
                BeginContext(5686, 924, true);
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
                BeginContext(6611, 62, false);
#line 135 "E:\Projects\CTMS\CTMS.Web\Views\ServiceMessageBoard\Show.cshtml"
                          Write(Url.Action("UpdateReply", new { MessageID = Model.MessageID }));

#line default
#line hidden
                EndContext();
                BeginContext(6673, 937, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Service_MessageBoard> Html { get; private set; }
    }
}
#pragma warning restore 1591
