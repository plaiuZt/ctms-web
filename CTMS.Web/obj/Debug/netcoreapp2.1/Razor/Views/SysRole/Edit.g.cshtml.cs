#pragma checksum "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14afca280ed8f5708bab9395dcdc1c0ce14c672c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SysRole_Edit), @"mvc.1.0.view", @"/Views/SysRole/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SysRole/Edit.cshtml", typeof(AspNetCore.Views_SysRole_Edit))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
#line 1 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
using System.Linq;

#line default
#line hidden
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
using CTMS.DbStoredProcedure;

#line default
#line hidden
#line 3 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
using CTMS.Common.Utility;

#line default
#line hidden
#line 4 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
using CTMS.Common.Extension;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14afca280ed8f5708bab9395dcdc1c0ce14c672c", @"/Views/SysRole/Edit.cshtml")]
    public class Views_SysRole_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SP_Get_Sys_RoleFunctionSelect>>
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
#line 6 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(248, 47, true);
            WriteLiteral("\r\n\r\n<article class=\"page-container\">\r\n    <form");
            EndContext();
            BeginWriteAttribute("action", " action=\"", 295, "\"", 361, 1);
#line 13 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
WriteAttributeValue("", 304, Url.Action("Update",new { roleId = ViewData["RoleID"] }), 304, 57, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(362, 300, true);
            WriteLiteral(@" method=""post"" class=""form form-horizontal"" id=""form-add"">
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>角色编号：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 662, "\"", 689, 1);
#line 17 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
WriteAttributeValue("", 670, ViewData["RoleID"], 670, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(690, 331, true);
            WriteLiteral(@" placeholder="""" id=""fRoleId"" name=""fRoleId"" disabled>
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>角色名称：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1021, "\"", 1050, 1);
#line 23 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
WriteAttributeValue("", 1029, ViewData["RoleName"], 1029, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1051, 296, true);
            WriteLiteral(@" placeholder="""" id=""fRoleName"" name=""fRoleName"">
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2"">备注：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1347, "\"", 1374, 1);
#line 29 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
WriteAttributeValue("", 1355, ViewData["Remark"], 1355, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1375, 243, true);
            WriteLiteral(" placeholder=\"\" id=\"fRemark\" name=\"fRemark\">\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row cl\">\r\n            <label class=\"form-label col-xs-4 col-sm-2\">角色功能：</label>\r\n            <div class=\"formControls col-xs-8 col-sm-9\">\r\n");
            EndContext();
#line 36 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                 foreach (var m in Model)
                {
                    if (m.RankID == 1 && m.FunctionID != "000000")
                    {

#line default
#line hidden
            BeginContext(1771, 149, true);
            WriteLiteral("                        <dl class=\"permission-list\">\r\n                            <dt>\r\n                                <label><input type=\"checkbox\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1920, "\"", 1941, 1);
#line 42 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
WriteAttributeValue("", 1928, m.FunctionID, 1928, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1942, 16, true);
            WriteLiteral(" name=\"fFuncId\" ");
            EndContext();
            BeginContext(1960, 32, false);
#line 42 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                                                                               Write(m.Selected.ToBool()?"checked":"");

#line default
#line hidden
            EndContext();
            BeginContext(1993, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1995, 14, false);
#line 42 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                                                                                                                  Write(m.FunctionName);

#line default
#line hidden
            EndContext();
            BeginContext(2009, 79, true);
            WriteLiteral("</label>\r\n                            </dt>\r\n                            <dd>\r\n");
            EndContext();
#line 45 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                 foreach (var m1 in Model.Where(w => w.ParentID == m.FunctionID))
                                {

#line default
#line hidden
            BeginContext(2222, 198, true);
            WriteLiteral("                                    <dl class=\"cl permission-list2\">\r\n                                        <dt>\r\n                                            <label class=\"\"><input type=\"checkbox\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2420, "\"", 2442, 1);
#line 49 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
WriteAttributeValue("", 2428, m1.FunctionID, 2428, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2443, 16, true);
            WriteLiteral(" name=\"fFuncId\" ");
            EndContext();
            BeginContext(2461, 33, false);
#line 49 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                                                                                                     Write(m1.Selected.ToBool()?"checked":"");

#line default
#line hidden
            EndContext();
            BeginContext(2495, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2497, 15, false);
#line 49 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                                                                                                                                         Write(m1.FunctionName);

#line default
#line hidden
            EndContext();
            BeginContext(2512, 103, true);
            WriteLiteral("</label>\r\n                                        </dt>\r\n                                        <dd>\r\n");
            EndContext();
#line 52 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                             foreach (var m2 in Model.Where(w => w.ParentID == m1.FunctionID))
                                            {

#line default
#line hidden
            BeginContext(2774, 86, true);
            WriteLiteral("                                                <label class=\"\"><input type=\"checkbox\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2860, "\"", 2882, 1);
#line 54 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
WriteAttributeValue("", 2868, m2.FunctionID, 2868, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2883, 16, true);
            WriteLiteral(" name=\"fFuncId\" ");
            EndContext();
            BeginContext(2901, 33, false);
#line 54 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                                                                                                         Write(m2.Selected.ToBool()?"checked":"");

#line default
#line hidden
            EndContext();
            BeginContext(2935, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2937, 15, false);
#line 54 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                                                                                                                                             Write(m2.FunctionName);

#line default
#line hidden
            EndContext();
            BeginContext(2952, 10, true);
            WriteLiteral("</label>\r\n");
            EndContext();
#line 55 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                            }

#line default
#line hidden
            BeginContext(3009, 90, true);
            WriteLiteral("                                        </dd>\r\n                                    </dl>\r\n");
            EndContext();
#line 58 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                }

#line default
#line hidden
            BeginContext(3134, 66, true);
            WriteLiteral("                            </dd>\r\n                        </dl>\r\n");
            EndContext();
#line 61 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(3242, 326, true);
            WriteLiteral(@"            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2"">审核：</label>
            <div class=""formControls col-xs-8 col-sm-9 skin-minimal"">
                <div class=""check-box"">
                    <input type=""checkbox"" id=""fState"" name=""fState"" value=""1"" ");
            EndContext();
            BeginContext(3570, 39, false);
#line 69 "E:\Projects\CTMS\CTMS.Web\Views\SysRole\Edit.cshtml"
                                                                           Write(ViewData["State"].ToBool()?"checked":"");

#line default
#line hidden
            EndContext();
            BeginContext(3610, 445, true);
            WriteLiteral(@" />
                    <label for=""checkbox-1"">&nbsp;</label>
                </div>
            </div>
        </div>
        <div class=""row cl"">
            <div class=""col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-2"">
                <button type=""submit"" class=""btn btn-success radius"" id=""admin-role-save"" name=""admin-role-save""><i class=""icon-ok""></i> 确定</button>
            </div>
        </div>
    </form>
</article>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4134, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(4168, 102, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19fd34f7427a4f7683a85057d0d3e2ee", async() => {
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
                BeginContext(4270, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4276, 103, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2cac1b8d9dc347319e3e380d1e84a74b", async() => {
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
                BeginContext(4379, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4385, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f804bd626a74a058cc20e4473e86a5e", async() => {
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
                BeginContext(4483, 4136, true);
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
                    $("".permission-list dt input:checkbox"").click(function () {
                        $(this).closest(""dl"").find(""dd input:checkbox"").prop(""checked"", $(this).prop(""checked""));
                    });
                    $("".permission-list2 dd input:checkbox"").click(function () {
                        var l = $(this).parent().parent().find(""input:checked"").length;
                        var l2 = $(this).parents("".permission-list"").find("".permission-list2 dd"").find(""input:checked"").length;
                        if ($(this).prop(""checked"")) {
                            $(this).closest(""dl"").find(""dt input:checkbox"").prop(""chec");
                WriteLiteral(@"ked"", true);
                            $(this).parents("".permission-list"").find(""dt"").first().find(""input:checkbox"").prop(""checked"", true);
                        }
                        else {
                            if (l == 0) {
                                $(this).closest(""dl"").find(""dt input:checkbox"").prop(""checked"", false);
                            }
                            if (l2 == 0) {
                                $(this).parents("".permission-list"").find(""dt"").first().find(""input:checkbox"").prop(""checked"", false);
                            }
                        }
                    });
                },
                formSubmit: function () {
                    $(""#form-add"").validate({
                        rules: {
                            fRoleId: {
                                required: true,
                                minlength: 3,
                                maxlength: 4
                            },
                      ");
                WriteLiteral(@"      fRoleName: {
                                required: true,
                                minlength: 2,
                                maxlength: 20
                            }
                        },
                        onkeyup: false,
                        focusCleanup: true,
                        success: ""valid"",
                        submitHandler: function (form) {
                            var fState = $(""input[name='fState']"").is(':checked');
                            $(form).ajaxSubmit({
                                type: ""POST"",
                                cache: false,
                                data: { fState: fState },
                                dataType: ""json"",
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    if (XMLHttpRequest.status != 200) {
                                        layer.alert(""POST[FAIL]"", { icon: 5 });
                              ");
                WriteLiteral(@"      }
                                },
                                success: function (result) {
                                    var state = result.state;          //错误代码
                                    var message = result.message;        //错误说明
                                    if (state == ""success"") {
                                        var index = parent.layer.getFrameIndex(window.name);
                                        parent.location.reload();
                                        parent.layer.close(index);
                                    } else {
                                        layer.alert(message, { icon: 5 });
                                    }
                                }
                            });
                        }
                    });
                }
            };
            $(function () {
                $.mainu.init();
                $.mainu.formSubmit();
            });

        })(jQuery);
    </sc");
                WriteLiteral("ript>\r\n    <!--/请在上方写此页面业务相关的脚本-->\r\n\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(8622, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SP_Get_Sys_RoleFunctionSelect>> Html { get; private set; }
    }
}
#pragma warning restore 1591