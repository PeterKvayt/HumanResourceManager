#pragma checksum "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7eab906c96601576dc8b51653bec9d038ebac478"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CreateUpdateLayout), @"mvc.1.0.view", @"/Views/Shared/_CreateUpdateLayout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_CreateUpdateLayout.cshtml", typeof(AspNetCore.Views_Shared__CreateUpdateLayout))]
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
#line 1 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\_ViewImports.cshtml"
using PresentationLayer;

#line default
#line hidden
#line 2 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\_ViewImports.cshtml"
using PresentationLayer.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7eab906c96601576dc8b51653bec9d038ebac478", @"/Views/Shared/_CreateUpdateLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30be6e8d357e7570361a44c6f59cbfc77c09d358", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CreateUpdateLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
  
    Layout = "_Layout";
    ViewBag.PageTitle = ViewBag.Title;

#line default
#line hidden
            BeginContext(74, 140, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-3 col-md-3 col-sm-1\"></div>\r\n    <div class=\"col-lg-6 col-md-6 col-sm-10\">\r\n        <h5><strong>");
            EndContext();
            BeginContext(215, 24, false);
#line 10 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
               Write(ViewBag.LayoutActionName);

#line default
#line hidden
            EndContext();
            BeginContext(239, 10, true);
            WriteLiteral("</strong> ");
            EndContext();
            BeginContext(250, 22, false);
#line 10 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
                                                  Write(ViewBag.LayoutItemName);

#line default
#line hidden
            EndContext();
            BeginContext(272, 15, true);
            WriteLiteral("</h5>\r\n        ");
            EndContext();
            BeginContext(287, 285, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7eab906c96601576dc8b51653bec9d038ebac4785875", async() => {
                BeginContext(391, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(406, 12, false);
#line 12 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
       Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(418, 147, true);
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <input id=\"submit-btn\" type=\"submit\" style=\"display:none;\" />\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#line 11 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
                                WriteLiteral(ViewBag.LayoutAspController);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 11 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
                                                                          WriteLiteral(ViewBag.LayoutAspAction);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(572, 54, true);
            WriteLiteral("\r\n        <button id=\"ok-btn\" class=\"btn btn-primary\">");
            EndContext();
            BeginContext(627, 30, false);
#line 17 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
                                               Write(ViewBag.LayoutAcceptButtonName);

#line default
#line hidden
            EndContext();
            BeginContext(657, 19, true);
            WriteLiteral("</button>\r\n        ");
            EndContext();
            BeginContext(676, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7eab906c96601576dc8b51653bec9d038ebac4789972", async() => {
                BeginContext(767, 6, true);
                WriteLiteral("Отмена");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#line 18 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
               WriteLiteral(ViewBag.LayoutAspController);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(777, 320, true);
            WriteLiteral(@"
        <br />
        <br />
        <div id=""warning-alert"" class=""alert alert-warning .alert-dismissible"" role=""alert"" style=""display: none;"">
            <button id=""close-warning"" type=""button"" class=""close"">
                <span aria-hidden=""true"">&times;</span>
            </button>
            <strong>");
            EndContext();
            BeginContext(1098, 26, false);
#line 25 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
               Write(ViewBag.LayoutAlertMessage);

#line default
#line hidden
            EndContext();
            BeginContext(1124, 49, true);
            WriteLiteral("</strong>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1190, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 31 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
     foreach (var item in @ViewBag.LayoutScripts)
    {

#line default
#line hidden
                BeginContext(1250, 15, true);
                WriteLiteral("        <script");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1265, "\"", 1276, 1);
#line 33 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
WriteAttributeValue("", 1271, item, 1271, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1277, 12, true);
                WriteLiteral("></script>\r\n");
                EndContext();
#line 34 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Shared\_CreateUpdateLayout.cshtml"
    }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591