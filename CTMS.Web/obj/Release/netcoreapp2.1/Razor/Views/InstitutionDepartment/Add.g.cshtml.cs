#pragma checksum "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "783faaca6b2c9db1a6f6d47b93f58bafcc364d2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_InstitutionDepartment_Add), @"mvc.1.0.view", @"/Views/InstitutionDepartment/Add.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/InstitutionDepartment/Add.cshtml", typeof(AspNetCore.Views_InstitutionDepartment_Add))]
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
#line 1 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
using LdCms.EF.DbModels;

#line default
#line hidden
#line 2 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
using LdCms.Common.Extension;

#line default
#line hidden
#line 3 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
using LdCms.Common.Utility;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"783faaca6b2c9db1a6f6d47b93f58bafcc364d2b", @"/Views/InstitutionDepartment/Add.cshtml")]
    public class Views_InstitutionDepartment_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ld_Institution_Department>
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
#line 5 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
  
    ViewData["Title"] = "Add";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(206, 49, true);
            WriteLiteral("\r\n\r\n<article class=\"page-container\">\r\n\r\n    <form");
            EndContext();
            BeginWriteAttribute("action", " action=\"", 255, "\"", 325, 1);
#line 13 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
WriteAttributeValue("", 264, Url.Action("Save",new { DepartmentId = Model.DepartmentID }), 264, 61, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(326, 412, true);
            WriteLiteral(@" method=""post"" class=""form form-horizontal"" id=""form-add"">
        <div class=""row cl"">
            <div class=""admin-add-top-tips"">提示：所属部门不可变更类别。</div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>部门编号：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 738, "\"", 765, 1);
#line 20 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
WriteAttributeValue("", 746, Model.DepartmentID, 746, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(766, 56, true);
            WriteLiteral(" placeholder=\"\" id=\"fDepartmentId\" name=\"fDepartmentId\" ");
            EndContext();
            BeginContext(824, 58, false);
#line 20 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
                                                                                                                                     Write(string.IsNullOrEmpty(Model.DepartmentID) ? "" : "disabled");

#line default
#line hidden
            EndContext();
            BeginContext(883, 281, true);
            WriteLiteral(@" />
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>部门名称：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1164, "\"", 1193, 1);
#line 26 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
WriteAttributeValue("", 1172, Model.DepartmentName, 1172, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1194, 414, true);
            WriteLiteral(@" placeholder="""" id=""fDepartmentName"" name=""fDepartmentName"" />
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>所属部门：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <span class=""select-box"">
                    <select class=""select"" size=""1"" id=""fParentId"" name=""fParentId"" ");
            EndContext();
            BeginContext(1610, 58, false);
#line 33 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
                                                                                Write(string.IsNullOrEmpty(Model.DepartmentID) ? "" : "disabled");

#line default
#line hidden
            EndContext();
            BeginContext(1669, 358, true);
            WriteLiteral(@"></select>
                </span>
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2"">备注：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <textarea id=""fDescription"" name=""fDescription"" class=""textarea"" placeholder=""说点什么...100个字符以内"" dragonfly=""true"">");
            EndContext();
            BeginContext(2028, 27, false);
#line 40 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
                                                                                                                           Write(Html.Raw(Model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(2055, 429, true);
            WriteLiteral(@"</textarea>
                <p class=""textarea-numberbar""><em class=""textarea-length"">0</em>/100</p>
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2"">审核：</label>
            <div class=""formControls col-xs-8 col-sm-9 skin-minimal"">
                <div class=""check-box"">
                    <input type=""checkbox"" id=""fState"" name=""fState"" value=""1"" ");
            EndContext();
            BeginContext(2486, 37, false);
#line 48 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
                                                                           Write(Model.State.ToBool() ? "checked" : "");

#line default
#line hidden
            EndContext();
            BeginContext(2524, 400, true);
            WriteLiteral(@" />
                    <label for=""checkbox-1"">&nbsp;</label>
                </div>
            </div>
        </div>
        <div class=""row cl"">
            <div class=""col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-2"">
                <input class=""btn btn-primary radius"" type=""submit"" value=""&nbsp;&nbsp;提交&nbsp;&nbsp;"">
            </div>
        </div>
    </form>
</article>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3003, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(3037, 102, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f849e83cdaea4f3195c908500fb54cb9", async() => {
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
                BeginContext(3139, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3145, 103, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05b627d88d024290be673ddc6c949622", async() => {
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
                BeginContext(3248, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3254, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f3f358b79944580b7513c0eeed68e71", async() => {
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
                BeginContext(3352, 570, true);
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

                    $.mainu.getDepartment('");
                EndContext();
                BeginContext(3923, 14, false);
#line 85 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
                                      Write(Model.ParentID);

#line default
#line hidden
                EndContext();
                BeginContext(3937, 110, true);
                WriteLiteral("\');\r\n                },\r\n                getDepartment: function (parentId) {\r\n                    var url = \"");
                EndContext();
                BeginContext(4048, 33, false);
#line 88 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\InstitutionDepartment\Add.cshtml"
                          Write(Url.Action("list-byparentid-get"));

#line default
#line hidden
                EndContext();
                BeginContext(4081, 3413, true);
                WriteLiteral(@""";
                    $.ajaxSetup({ cache: false });
                    $.get(url, { id: 0 }, function (result) {
                        var state = result.state;
                        var message = result.message;
                        var strOption = '<option value="""" selected>作为一级部门</option>';
                        if (state == ""success"") {
                            var list = result.data;
                            for (var i = 0; i < list.length; i++) {
                                if (parentId == list[i].department_id)
                                    strOption += '<option value=""' + list[i].department_id + '"" selected>' + list[i].department_name + '</option>';
                                else
                                    strOption += '<option value=""' + list[i].department_id + '"">' + list[i].department_name + '</option>';
                            }
                        }
                        $(""#fParentId"").html(strOption);
                    });
");
                WriteLiteral(@"                },
                formSubmit: function () {
                    $(""#form-add"").validate({
                        rules: {
                            fDepartmentId: {
                                required: true
                            },
                            fDepartmentName: {
                                required: true
                            }
                        },
                        onkeyup: false,
                        focusCleanup: true,
                        success: ""valid"",
                        submitHandler: function (form) {
                            var strDepartmentId = $(""input[name='department_id']"").val();
                            var blnState = $(""input[name='state']"").is(':checked');
                            $(form).ajaxSubmit({
                                type: ""POST"",
                                cache: false,
                                data: { str_department_id: strDepartmentId, bln_state: blnSt");
                WriteLiteral(@"ate },
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
                                        var index = parent.layer.getFrameIndex(window.name);
                                        parent.location.reload();
                                        parent.layer.close(index);
                                    } else {
                                        layer.alert(message, { icon: 5 });
       ");
                WriteLiteral(@"                             }
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
    </script>
");
                EndContext();
            }
            );
            BeginContext(7497, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ld_Institution_Department> Html { get; private set; }
    }
}
#pragma warning restore 1591
