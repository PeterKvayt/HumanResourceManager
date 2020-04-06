#pragma checksum "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b62d555d7d18553866c95b37549f18f8b5c8d96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Companies_Index), @"mvc.1.0.view", @"/Views/Companies/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Companies/Index.cshtml", typeof(AspNetCore.Views_Companies_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b62d555d7d18553866c95b37549f18f8b5c8d96", @"/Views/Companies/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30be6e8d357e7570361a44c6f59cbfc77c09d358", @"/Views/_ViewImports.cshtml")]
    public class Views_Companies_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PresentationLayer.ViewModels.CompanyViewModel>
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
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
  
    Layout = "_IndexLayout";
    ViewBag.Title = "Компании";
    ViewBag.Controller = "Companies";
    ViewBag.CreateButtonName = "Создать компанию";
    ViewBag.DeleteAlert = "При удалении компании удаляются связанные с этой компанией сотрудники!";
    ViewBag.Scripts = new string[] { "/lib/js/deletion.js" };

#line default
#line hidden
            BeginContext(381, 404, true);
            WriteLiteral(@"
<tr class=""bg-info"">
    <td>
        <strong style=""color:#fff"">Название</strong>
    </td>
    <td>
        <strong style=""color:#fff"">Количество сотрудников</strong>
    </td>
    <td>
        <strong style=""color:#fff"">Организационно-правовая форма</strong>
    </td>
    <td>
        <strong style=""color:#fff"">Вид деятельности</strong>
    </td>
    <td></td>
    <td></td>
</tr>
");
            EndContext();
#line 28 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
 foreach (var companyItem in Model.CompanyCollection)
{

#line default
#line hidden
            BeginContext(843, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(880, 16, false);
#line 32 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
       Write(companyItem.Name);

#line default
#line hidden
            EndContext();
            BeginContext(896, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(940, 16, false);
#line 35 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
       Write(companyItem.Size);

#line default
#line hidden
            EndContext();
            BeginContext(956, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1000, 26, false);
#line 38 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
       Write(companyItem.LegalForm.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1026, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1070, 29, false);
#line 41 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
       Write(companyItem.ActivityType.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1099, 67, true);
            WriteLiteral("\r\n        </td>\r\n        <td style=\"text-align:end;\">\r\n            ");
            EndContext();
            BeginContext(1166, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b62d555d7d18553866c95b37549f18f8b5c8d967019", async() => {
                BeginContext(1253, 40, true);
                WriteLiteral("\r\n                Изменить\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1175, "~/", 1175, 2, true);
#line 44 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
AddHtmlAttributeValue("", 1177, ViewBag.Controller, 1177, 19, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 1196, "/Update/", 1196, 8, true);
#line 44 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
AddHtmlAttributeValue("", 1204, companyItem.Id.Identifier, 1204, 26, false);

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
            BeginContext(1297, 185, true);
            WriteLiteral("\r\n        </td>\r\n        <td style=\"text-align:end;\">\r\n            <span class=\"btn btn-danger neibor-btn\" data-toggle=\"modal\" data-target=\"#deletion-modal\">Удалить</span>\r\n            ");
            EndContext();
            BeginContext(1482, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b62d555d7d18553866c95b37549f18f8b5c8d969366", async() => {
                BeginContext(1570, 39, true);
                WriteLiteral("\r\n                Удалить\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1491, "~/", 1491, 2, true);
#line 50 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
AddHtmlAttributeValue("", 1493, ViewBag.Controller, 1493, 19, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 1512, "/Delete/", 1512, 8, true);
#line 50 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
AddHtmlAttributeValue("", 1520, companyItem.Id.Identifier, 1520, 26, false);

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
            BeginContext(1613, 28, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 55 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Companies\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PresentationLayer.ViewModels.CompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
