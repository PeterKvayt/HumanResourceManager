#pragma checksum "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "332e43010626bfde3bac81320405575f2c85a60b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LegalForms_Index), @"mvc.1.0.view", @"/Views/LegalForms/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/LegalForms/Index.cshtml", typeof(AspNetCore.Views_LegalForms_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"332e43010626bfde3bac81320405575f2c85a60b", @"/Views/LegalForms/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30be6e8d357e7570361a44c6f59cbfc77c09d358", @"/Views/_ViewImports.cshtml")]
    public class Views_LegalForms_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PresentationLayer.ViewModels.LegalFormViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:none;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
  
    Layout = "_IndexLayout";
    ViewBag.Title = "Организационно-правовые формы";
    ViewBag.Controller = "LegalForms";
    ViewBag.CreateButtonName = "Создать организационно-правовую форму";
    ViewBag.DeleteAlert = "При удалении организационно-правовой формы удаляются связанные с этой организационно-правовой формой компании и сотрудники, работающие в компании!";
    ViewBag.Scripts = new string[] { "/lib/js/deletion.js" };

#line default
#line hidden
            BeginContext(502, 121, true);
            WriteLiteral("\r\n<tr class=\"bg-info\">\r\n    <td>\r\n        <strong style=\"color:#fff\">Название</strong>\r\n    </td>\r\n    <td></td>\r\n</tr>\r\n");
            EndContext();
#line 18 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
 foreach (var legalFormItem in Model.LegalFormCollection)
{

#line default
#line hidden
            BeginContext(685, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(722, 18, false);
#line 22 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
       Write(legalFormItem.Name);

#line default
#line hidden
            EndContext();
            BeginContext(740, 67, true);
            WriteLiteral("\r\n        </td>\r\n        <td style=\"text-align:end;\">\r\n            ");
            EndContext();
            BeginContext(807, 133, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "332e43010626bfde3bac81320405575f2c85a60b5658", async() => {
                BeginContext(896, 40, true);
                WriteLiteral("\r\n                Изменить\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 816, "~/", 816, 2, true);
#line 25 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
AddHtmlAttributeValue("", 818, ViewBag.Controller, 818, 19, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 837, "/Update/", 837, 8, true);
#line 25 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
AddHtmlAttributeValue("", 845, legalFormItem.Id.Identifier, 845, 28, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(940, 134, true);
            WriteLiteral("\r\n\r\n            <span class=\"btn btn-danger neibor-btn\" data-toggle=\"modal\" data-target=\"#deletion-modal\">Удалить</span>\r\n            ");
            EndContext();
            BeginContext(1074, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "332e43010626bfde3bac81320405575f2c85a60b7943", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1083, "~/", 1083, 2, true);
#line 30 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
AddHtmlAttributeValue("", 1085, ViewBag.Controller, 1085, 19, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 1104, "/Delete/", 1104, 8, true);
#line 30 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
AddHtmlAttributeValue("", 1112, legalFormItem.Id.Identifier, 1112, 28, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1168, 28, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 33 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\LegalForms\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PresentationLayer.ViewModels.LegalFormViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591