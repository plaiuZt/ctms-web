#pragma checksum "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81494b1441fb8c6c94b804299a6be8d82a2ad433"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SysInterfaceAccount_Show), @"mvc.1.0.view", @"/Views/SysInterfaceAccount/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SysInterfaceAccount/Show.cshtml", typeof(AspNetCore.Views_SysInterfaceAccount_Show))]
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
#line 1 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
using LdCms.EF.DbModels;

#line default
#line hidden
#line 2 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
using LdCms.EF.DbViews;

#line default
#line hidden
#line 3 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
using LdCms.Common.Utility;

#line default
#line hidden
#line 4 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
using LdCms.Common.Extension;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81494b1441fb8c6c94b804299a6be8d82a2ad433", @"/Views/SysInterfaceAccount/Show.cshtml")]
    public class Views_SysInterfaceAccount_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ld_Sys_InterfaceAccount>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/My97DatePicker/4.8/WdatePicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/validate-methods.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/messages_zh.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/static/h-ui.admin/js/H-ui.admin.common.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(143, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
  
    ViewData["Title"] = "Show";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(232, 438, true);
            WriteLiteral(@"

<nav class=""breadcrumb"">
    <i class=""Hui-iconfont"">&#xe67f;</i> 首页<span class=""c-gray en"">&gt;</span>接口管理<span class=""c-gray en"">&gt;</span>白名单设置
    <a class=""btn btn-success radius r"" style=""line-height:1.6em;margin-top:3px"" href=""javascript:location.replace(location.href);"" title=""刷新""><i class=""Hui-iconfont"">&#xe68f;</i></a>
</nav>

<article class=""page-container"">

    <div class=""l"" style=""width:60%;"">
        <form");
            EndContext();
            BeginWriteAttribute("action", " action=\"", 670, "\"", 739, 1);
#line 21 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 679, Url.Action("SaveWhiteList",new { Account = Model.Account }), 679, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(740, 288, true);
            WriteLiteral(@" method=""post"" class=""form form-horizontal"" id=""form-add"">
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2"">接口帐号：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1028, "\"", 1050, 1);
#line 25 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 1036, Model.Account, 1036, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1051, 342, true);
            WriteLiteral(@" placeholder="""" id=""fAccount"" name=""fAccount"" disabled=""disabled"" />
                </div>
            </div>
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2"">UUID：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1393, "\"", 1412, 1);
#line 31 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 1401, Model.Uuid, 1401, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1413, 337, true);
            WriteLiteral(@" placeholder="""" id=""fUUID"" name=""fUUID"" disabled=""disabled"" />
                </div>
            </div>
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2"">AppID：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1750, "\"", 1770, 1);
#line 37 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 1758, Model.AppID, 1758, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1771, 349, true);
            WriteLiteral(@" placeholder=""接口AppID"" id=""fAppID"" name=""fAppID"" disabled=""disabled""/>
                </div>
            </div>
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2"">AppSecret：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2120, "\"", 2144, 1);
#line 43 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 2128, Model.AppSecret, 2128, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2145, 190, true);
            WriteLiteral(" placeholder=\"接口AppSecret\" id=\"fAppSecret\" name=\"fAppSecret\" style=\"width:90%;\" />\r\n                    <input class=\"btn btn-primary radius\" type=\"button\" value=\"&nbsp;&nbsp;重置&nbsp;&nbsp;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2335, "\"", 2387, 3);
            WriteAttributeValue("", 2345, "$.mainu.refreshAppSecret(\'", 2345, 26, true);
#line 44 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 2371, Model.Account, 2371, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 2385, "\')", 2385, 2, true);
            EndWriteAttribute();
            BeginContext(2388, 279, true);
            WriteLiteral(@" />
                </div>
            </div>
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2"">AppKey：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2667, "\"", 2688, 1);
#line 50 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 2675, Model.AppKey, 2675, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2689, 181, true);
            WriteLiteral(" placeholder=\"接口AppKey\" id=\"fAppKey\" name=\"fAppKey\" style=\"width:90%;\" />\r\n                    <input class=\"btn btn-primary radius\" type=\"button\" value=\"&nbsp;&nbsp;重置&nbsp;&nbsp;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2870, "\"", 2919, 3);
            WriteAttributeValue("", 2880, "$.mainu.refreshAppKey(\'", 2880, 23, true);
#line 51 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
WriteAttributeValue("", 2903, Model.Account, 2903, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 2917, "\')", 2917, 2, true);
            EndWriteAttribute();
            BeginContext(2920, 350, true);
            WriteLiteral(@" />
                </div>
            </div>
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2"">备注：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <textarea id=""fDescription"" name=""fDescription"" class=""textarea"" placeholder=""说点什么...100个字符以内"" dragonfly=""true"">");
            EndContext();
            BeginContext(3271, 17, false);
#line 57 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
                                                                                                                               Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(3288, 2044, true);
            WriteLiteral(@"</textarea>
                    <p class=""textarea-numberbar""><em class=""textarea-length""></em>/100</p>
                </div>
            </div>
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>选择分类：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <span class=""select-box"" style=""width:50%;"">
                        <select class=""select"" size=""1"" id=""fClassID"" name=""fClassID"">
                            <option value=""3"">API</option>
                        </select>
                    </span>
                </div>
            </div>
            <div class=""row cl"">
                <label class=""form-label col-xs-4 col-sm-2"">接口请求IP：</label>
                <div class=""formControls col-xs-8 col-sm-9"">
                    <input type=""text"" class=""input-text"" value="""" placeholder=""填写授权IP地址"" id=""fIpAddress"" name=""fIpAddress"" />
                    <span><font color=""red"">注：</font");
            WriteLiteral(@">授权IP地址才可以请求接口，无限请用“*”。</span>
                </div>
            </div>

            <div class=""row cl"">
                <div class=""col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-2"">
                    <input class=""btn btn-primary radius"" type=""submit"" value=""&nbsp;&nbsp;提交&nbsp;&nbsp;"">
                </div>
            </div>
        </form>
    </div>
    <div class=""l"" style=""width:40%;border:0px solid #ffd800;"">
        <div style=""height:32px;line-height:32px;"">已授权请求IP地址：</div>
        <table class=""table table-border table-bordered table-hover table-bg table-sort"">
            <thead>
                <tr class=""text-c"">
                    <th width="""">授权IP地址</th>
                    <th width=""80"">分类</th>
                    <th width=""80"">状态</th>
                    <th width=""120"">时间</th>
                    <th width=""80"">操作</th>
                </tr>
            </thead>
            <tbody id=""lists""></tbody>
        </table>
    </div>



</article>



");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5411, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(5445, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f26d76ed6c04505931a39543a677d52", async() => {
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
                BeginContext(5537, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5543, 102, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "939c3f40b1024b1181a173db29fa3ec9", async() => {
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
                BeginContext(5645, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5651, 103, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03ea63882926470899db4a782d780461", async() => {
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
                BeginContext(5754, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5760, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de291979f2e14a9fa1429fc6f4dc87ec", async() => {
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
                BeginContext(5858, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5864, 96, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f86fccb069e4bb2af90f0e543fe4ea8", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5960, 677, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        (function ($) {
            $.mainu = {
                init: function () {
                    $('.skin-minimal input').iCheck({
                        checkboxClass: 'icheckbox-blue',
                        radioClass: 'iradio-blue',
                        increaseArea: '20%'
                    });
                    $(""#fDescription"").Huitextarealength({
                        minlength: 4,
                        maxlength: 100
                    });
                    $.mainu.getWhiteList();
                },
                refreshAppSecret: function (account) {
                    var url = """);
                EndContext();
                BeginContext(6638, 29, false);
#line 136 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
                          Write(Url.Action("UpdateAppSecret"));

#line default
#line hidden
                EndContext();
                BeginContext(6667, 719, true);
                WriteLiteral(@""";
                    $.ajaxSetup({ cache: false });
                    $.post(url, {
                        account: account,
                    }, function (result) {
                        var state = result.state;
                        var message = result.message;
                        if (state == ""success"") {
                            var appSecret = result.data.appsecret;
                            $(""#fAppSecret"").val(appSecret);
                        } else {
                            layer.alert(message, { icon: 5 });
                        }
                    });
                },
                refreshAppKey: function (account) {
                    var url = """);
                EndContext();
                BeginContext(7387, 26, false);
#line 152 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
                          Write(Url.Action("UpdateAppKey"));

#line default
#line hidden
                EndContext();
                BeginContext(7413, 2585, true);
                WriteLiteral(@""";
                    $.ajaxSetup({ cache: false });
                    $.post(url, {
                        account: account,
                    }, function (result) {
                        var state = result.state;
                        var message = result.message;
                        if (state == ""success"") {
                            var key = result.data.key;
                            $(""#fAppKey"").val(key);
                        } else {
                            layer.alert(message, { icon: 5 });
                        }
                    });
                },
                formSubmit: function () {
                    $(""#form-add"").validate({
                        rules: {
                            fIpAddress: {
                                required: true
                            }
                        },
                        onkeyup: false,
                        focusCleanup: true,
                        success: ""valid"",
       ");
                WriteLiteral(@"                 submitHandler: function (form) {
                            var fClassName = $('#fClassID option:selected').text();
                            $(form).ajaxSubmit({
                                type: ""POST"",
                                cache: false,
                                data: { fClassName: fClassName, fState: true },
                                dataType: ""json"",
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    if (XMLHttpRequest.status != 200) {
                                        layer.alert(""POST[FAIL]"", { icon: 5 });
                                    }
                                },
                                success: function (result) {
                                    var state = result.state;          //错误代码
                                    var message = result.message;        //错误说明
                                    if (state == ""success"") {
     ");
                WriteLiteral(@"                                   layer.msg(message, { icon: 6, time: 3000 });
                                        $.mainu.getWhiteList();
                                    } else {
                                        layer.msg(message, { icon: 5, time: 3000 });
                                    }
                                }
                            });
                        }
                    });
                },
                getWhiteList: function () {
                    var account = """);
                EndContext();
                BeginContext(9999, 13, false);
#line 204 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
                              Write(Model.Account);

#line default
#line hidden
                EndContext();
                BeginContext(10012, 35, true);
                WriteLiteral("\";\r\n                    var url = \"");
                EndContext();
                BeginContext(10048, 28, false);
#line 205 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
                          Write(Url.Action("white-list-get"));

#line default
#line hidden
                EndContext();
                BeginContext(10076, 1340, true);
                WriteLiteral(@""";
                    $.ajaxSetup({ cache: false });
                    $.get(url, { account: account}, function (result) {
                        var state = result.state;
                        var message = result.message;
                        if (state == ""success"") {
                            var sBody = """";
                            for (var i = 0; i < result.data.length; i++) {
                                sBody += '<tr class=""text-c"">';
                                sBody += '<td class=""text-c"">' + result.data[i].ip + '</td>';
                                sBody += '<td>' + result.data[i].class_name + '</td>';
                                sBody += '<td>' + result.data[i].state + '</td>';
                                sBody += '<td>' + result.data[i].create_date + '</td>';
                                sBody += '<td><a href=""###"" onclick=""$.mainu.delete(\'' + result.data[i].account + '\',\'' + result.data[i].ip + '\',\'' + result.data[i].class_id + '\')"">删除</a></td");
                WriteLiteral(@">';
                                sBody += '</tr>';
                            }
                            $(""#lists"").html(sBody);
                        }
                    }, ""json"");
                },
                delete: function (account,ipAddress,classId) {
                    var url = """);
                EndContext();
                BeginContext(11417, 29, false);
#line 226 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\SysInterfaceAccount\Show.cshtml"
                          Write(Url.Action("DeleteWhiteList"));

#line default
#line hidden
                EndContext();
                BeginContext(11446, 820, true);
                WriteLiteral(@""";
                    $.ajaxSetup({ cache: false });
                    $.post(url, {
                        account: account,
                        ipAddress: ipAddress,
                        classId: classId
                    }, function (result) {
                        var state = result.state;
                        var message = result.message;
                        if (state == ""success"") {
                            $.mainu.getWhiteList();
                        } else {
                            layer.alert(message, { icon: 5 });
                        }
                    });
                }

            };
            $(function () {
                $.mainu.init();
                $.mainu.formSubmit();
            });

        })(jQuery);
    </script>
");
                EndContext();
            }
            );
            BeginContext(12269, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ld_Sys_InterfaceAccount> Html { get; private set; }
    }
}
#pragma warning restore 1591
