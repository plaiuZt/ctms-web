#pragma checksum "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1afcec9d0bff45026ef4437ed12f26f3e13f831a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ExtendAdvertisement_Add), @"mvc.1.0.view", @"/Views/ExtendAdvertisement/Add.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ExtendAdvertisement/Add.cshtml", typeof(AspNetCore.Views_ExtendAdvertisement_Add))]
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
#line 1 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
using LdCms.EF.DbModels;

#line default
#line hidden
#line 2 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
using LdCms.Common.Extension;

#line default
#line hidden
#line 3 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
using LdCms.Common.Utility;

#line default
#line hidden
#line 4 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
using LdCms.Common.Enum;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1afcec9d0bff45026ef4437ed12f26f3e13f831a", @"/Views/ExtendAdvertisement/Add.cshtml")]
    public class Views_ExtendAdvertisement_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ld_Extend_Advertisement>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/webuploader/0.1.5/webuploader.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/validate-methods.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/jquery.validation/1.14.0/messages_zh.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/lib/webuploader/0.1.5/webuploader.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
  
    ViewData["Title"] = "Add";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(230, 47, true);
            WriteLiteral("\r\n\r\n<article class=\"page-container\">\r\n    <form");
            EndContext();
            BeginWriteAttribute("action", " action=\"", 277, "\"", 353, 1);
#line 13 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
WriteAttributeValue("", 286, Url.Action("Save",new { AdvertisementID = Model.AdvertisementID }), 286, 67, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(354, 300, true);
            WriteLiteral(@" method=""post"" class=""form form-horizontal"" id=""form-add"">
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>广告名称：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 654, "\"", 673, 1);
#line 17 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
WriteAttributeValue("", 662, Model.Name, 662, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(674, 425, true);
            WriteLiteral(@" placeholder=""请输入广告名称"" id=""fName"" name=""fName"" />
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>广告内容：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <div id=""picker"" class=""formControls"" style=""padding-left:0px;"">选择文件</div>
                <div id=""filelist"" class=""ad-image-list"">
");
            EndContext();
            BeginContext(1968, 300, true);
            WriteLiteral(@"                </div>

            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2""><span class=""c-red"">*</span>排序：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <input type=""text"" class=""input-text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2268, "\"", 2287, 1);
#line 42 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
WriteAttributeValue("", 2276, Model.Sort, 2276, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2288, 373, true);
            WriteLiteral(@" placeholder=""请输入排序号，只能为数字。越小越靠前"" id=""fSort"" name=""fSort"" />
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2"">备注：</label>
            <div class=""formControls col-xs-8 col-sm-9"">
                <textarea id=""fRemark"" name=""fRemark"" class=""textarea"" placeholder=""说点什么...100个字符以内"" dragonfly=""true"">");
            EndContext();
            BeginContext(2662, 12, false);
#line 48 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
                                                                                                                 Write(Model.Remark);

#line default
#line hidden
            EndContext();
            BeginContext(2674, 808, true);
            WriteLiteral(@"</textarea>
                <p class=""textarea-numberbar""></p>
            </div>
        </div>
        <div class=""row cl"">
            <label class=""form-label col-xs-4 col-sm-2"">审核：</label>
            <div class=""formControls col-xs-8 col-sm-9 skin-minimal"">
                <div class=""check-box"">
                    <input type=""checkbox"" id=""fState"" name=""fState"" value=""1"" checked=""checked"" />
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
            DefineSection("css", async() => {
                BeginContext(3557, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3563, 94, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ff652cae79d248be8528d1d3df37fac7", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3657, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            DefineSection("scripts", async() => {
                BeginContext(3679, 34, true);
                WriteLiteral("\r\n    <!--请在下方写此页面业务相关的脚本-->\r\n    ");
                EndContext();
                BeginContext(3713, 102, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebbabc0c6bc24ff4b3d293ac9ac1e7b7", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3815, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3821, 103, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44acd7b0fd024f1cad1ee518cad7a0e4", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3924, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3930, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ecdca0216b82400ebdce351265a92f1a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4028, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4034, 95, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f78b0e9ee3c469c85651ab8eb8d7b09", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4129, 573, true);
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
                    $(""#fRemark"").Huitextarealength({
                        minlength: 4,
                        maxlength: 200
                    });
                    $.mainu.getAdvertisementDetails(""");
                EndContext();
                BeginContext(4703, 21, false);
#line 96 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
                                                Write(Model.AdvertisementID);

#line default
#line hidden
                EndContext();
                BeginContext(4724, 114, true);
                WriteLiteral("\");\r\n                },\r\n                getAdvertisementDetails: function (id) {\r\n                    var url = \"");
                EndContext();
                BeginContext(4839, 37, false);
#line 99 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
                          Write(Url.Action("GetAdvertisementDetails"));

#line default
#line hidden
                EndContext();
                BeginContext(4876, 2355, true);
                WriteLiteral(@""";
                    $.ajaxSetup({ cache: false });
                    $.get(url, { advertisementId: id }, function (result) {
                        var state = result.state;
                        var message = result.message;
                        var strOption = '';
                        if (state == ""success"") {
                            var list = result.data;
                            for (var i = 0; i < list.length; i++) {
                                strOption += '' +
                                    '<div id=""details_' + list[i].id + '"" class=""form-content l"">' +
                                    '    <p><img src=""' + list[i].media_path + '"" /></p>' +
                                    '    <p><input type=""text"" class=""input-text"" value=""' + list[i].title + '"" placeholder=""广告描述"" id=""fDetailsTitle"" name=""fDetailsTitle"" /></p>' +
                                    '    <p><textarea id=""fDetailsUrl"" name=""fDetailsUrl"" class=""textarea"" placeholder=""广告链接网址"" dragonfly=""");
                WriteLiteral(@"true"">' + list[i].url + '</textarea></p>' +
                                    '    <p>' +
                                    '        <a href=""javascript:;"" class=""action act-left center l""><i class=""Hui-iconfont"">&#xe6d4;</i>左移</a>' +
                                    '        <a href=""javascript:;"" class=""action act-right center l"">右移<i class=""Hui-iconfont"">&#xe6d7;</i></a>' +
                                    '        <a href=""javascript:;"" class=""action act-del center l"" onClick=""$.mainu.deleteDetails(\'' + list[i].id + '\')""><i class=""Hui-iconfont"">&#xe6a6;</i>删除</a>' +
                                    '    </p>' +
                                    '    <p><input type=""text"" class=""hide"" id=""fDetailsMediaId"" name=""fDetailsMediaId"" value=""' + list[i].media_id + '""/></p>' +
                                    '    <p><input type=""text"" class=""hide"" id=""fDetailsMediaPath"" name=""fDetailsMediaPath"" value=""' + list[i].media_path + '""/></p>' +
                                    '</div>'
  ");
                WriteLiteral(@"                          }

                        }
                        $(""#filelist"").html(strOption);
                    });
                },
                deleteDetails: function (id) {
                    $.ajax({
                        type: 'POST',
                        url: '");
                EndContext();
                BeginContext(7232, 27, false);
#line 130 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
                         Write(Url.Action("DeleteDetails"));

#line default
#line hidden
                EndContext();
                BeginContext(7259, 1061, true);
                WriteLiteral(@"',
                        data: { DetailsId: id },
                        dataType: 'json',
                        success: function (result) {
                            var state = result.state;
                            var message = result.message;
                            if (state == ""success"") {
                                $(""#details_"" + id).remove();
                                layer.msg('已删除！', { icon: 1, time: 2000 });
                            } else {
                                layer.msg(message, { icon: 5, time: 3000 });
                            }
                        },
                        error: function (data) {
                            console.log(data.msg);
                        },
                    });
                },
                webUploaderInit: function () {
                    var uploader = WebUploader.create({
                        auto: true,
                        swf: '~/admin/lib/webuploader/0.1.5/Uploader.swf");
                WriteLiteral("\',\r\n                        server: \'");
                EndContext();
                BeginContext(8321, 28, false);
#line 152 "G:\蓝点管理信息系统-开源版ASP.NET CORE\LdCms\LdCms.Web\Views\ExtendAdvertisement\Add.cshtml"
                            Write(Url.Action("file", "upload"));

#line default
#line hidden
                EndContext();
                BeginContext(8349, 6220, true);
                WriteLiteral(@"',
                        pick: {
                            id: '#picker',
                            multiple: true,
                        },
                        fileNumLimit: 9,
                        resize: false,
                        accept: {
                            title: 'Images',
                            extensions: 'gif,jpg,jpeg,bmp,png',
                            mimeTypes: 'image/*'
                        }
                    });
                    uploader.on('fileQueued', function (file) {
                        console.log(file);
                        $list = $(""#filelist"")
                        var $li = $(
                            '<div id=""' + file.id + '"" class=""form-content l"">' +
                            '    <p><img src="""" /></p>' +
                            '    <p><input type=""text"" class=""input-text"" value="""" placeholder=""广告描述"" id=""fDetailsTitle"" name=""fDetailsTitle"" /></p>' +
                            '    <p><textarea id=""");
                WriteLiteral(@"fDetailsUrl"" name=""fDetailsUrl"" class=""textarea"" placeholder=""广告链接网址"" dragonfly=""true""></textarea></p>' +
                            '    <p>' +
                            '        <a href=""javascript:;"" class=""action act-left center l""><i class=""Hui-iconfont"">&#xe6d4;</i>左移</a>' +
                            '        <a href=""javascript:;"" class=""action act-right center l"">右移<i class=""Hui-iconfont"">&#xe6d7;</i></a>' +
                            '        <a href=""javascript:;"" class=""action act-del center l""><i class=""Hui-iconfont"">&#xe6a6;</i>删除</a>' +
                            '    </p>' +
                            '    <p><input type=""text"" class=""hide"" id=""fDetailsMediaId"" name=""fDetailsMediaId"" /></p>' +
                            '    <p><input type=""text"" class=""hide"" id=""fDetailsMediaPath"" name=""fDetailsMediaPath"" /></p>' +
                            '</div>'
                        );
                        var $img = $li.find('img');
                        $list.prepend($li);
");
                WriteLiteral(@"                        var thumbnailWidth = 100;
                        var thumbnailHeight = 100;
                        uploader.makeThumb(file, function (error, src) {
                            if (error) {
                                $img.replaceWith('<img width=""100"" height=""100"" src=""~/admin/lib/webuploader/0.1.5/images/bg.png"" />');
                                return;
                            }
                            $img.attr('src', src);
                        }, thumbnailWidth, thumbnailHeight);

                        $li.find("".act-del"").on(""click"", function () {
                            console.log(""a3"");
                            cancelFile(file);
                            console.log(""a5"");
                        });


                    });
                    uploader.on('uploadProgress', function (file, percentage) {

                    });
                    uploader.on('uploadSuccess', function (file, json) {
                        v");
                WriteLiteral(@"ar mediaid = json.data.file.mediaid;
                        var src = json.data.file.src;
                        $('#' + file.id).find(""#fDetailsMediaId"").val(mediaid);
                        $('#' + file.id).find(""#fDetailsMediaPath"").val(src);
                    });
                    uploader.on('uploadError', function (file, json) {
                        var message = ""上传出错！"";
                        layer.msg(message, { icon: 5 });
                    });
                    uploader.on('uploadComplete', function (file) {

                    });
                    function cancelFile(file) {
                        console.log(""aa4"");
                        uploader.cancelFile(file);
                        var $li = $('#' + file.id);
                        $li.off().find('.file-panel').off().end().remove();
                    };
                },
                formSubmit: function () {
                    $(""#form-add"").validate({
                        rules: {
   ");
                WriteLiteral(@"                         fName: {
                                required: true
                            }
                        },
                        onkeyup: false,
                        focusCleanup: true,
                        success: ""valid"",
                        submitHandler: function (form) {
                            var fState = $(""input[name='fState']"").is(':checked');
                            var fGroupName = $(""select[name='fGroupId']"").find(""option:selected"").text();
                            $(form).ajaxSubmit({
                                type: ""POST"",
                                cache: false,
                                data: { fState: fState },
                                dataType: ""json"",
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    if (XMLHttpRequest.status != 200) {
                                        layer.alert(""POST[FAIL]"", { icon: 5 });
   ");
                WriteLiteral(@"                                 }
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
                $.mainu.webUploaderInit();
                ");
                WriteLiteral("$.mainu.formSubmit();\r\n            });\r\n        })(jQuery);\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ld_Extend_Advertisement> Html { get; private set; }
    }
}
#pragma warning restore 1591