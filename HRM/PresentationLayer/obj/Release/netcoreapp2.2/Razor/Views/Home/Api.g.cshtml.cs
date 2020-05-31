#pragma checksum "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Home\Api.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02f092a5554df21e0538821dcd9180891b554cd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Api), @"mvc.1.0.view", @"/Views/Home/Api.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Api.cshtml", typeof(AspNetCore.Views_Home_Api))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02f092a5554df21e0538821dcd9180891b554cd6", @"/Views/Home/Api.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30be6e8d357e7570361a44c6f59cbfc77c09d358", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Api : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\MyDirectory\GitRepositories\HumanResourceManager\HRM\PresentationLayer\Views\Home\Api.cshtml"
  
    ViewData["Title"] = "API Документация";

#line default
#line hidden
            BeginContext(52, 4134, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""jumbotron"">
            <h1>Работа с видами деятельности</h1>
            <p>
                GET api/ActivityTypes : возвращает все виды деятельности
            </p>
            <p>
                GET api/ActivityTypes/id : возвращает конкретный вид деятельности по параметру id
            </p>
            <p>
                POST api/ActivityTypes/model : запрос на создание нового вида деятельности с параметром model
            </p>
            <p>
                PUT api/ActivityTypes/model : запрос на обновление вида деятельности с параметром model
            </p>
            <p>
                DELETE api/ActivityTypes/id : запрос на удаление вида деятельности по параметру id
            </p>
        </div>
    </div>
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""jumbotron"">
            <h1>Работа с компаниями</h1>
            <p>
                GET api/Companies : в");
            WriteLiteral(@"озвращает все компании
            </p>
            <p>
                GET api/Companies/id : возвращает конкретную компанию по параметру id
            </p>
            <p>
                POST api/Companies/model : запрос на создание новой компании с параметром model
            </p>
            <p>
                PUT api/Companies/model : запрос на обновление компании с параметром model
            </p>
            <p>
                DELETE api/Companies/id : запрос на удаление компании по параметру id
            </p>
        </div>
    </div>
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""jumbotron"">
            <h1>Работа с должностями сотрудников</h1>
            <p>
                GET api/Positions : возвращает все должности
            </p>
            <p>
                GET api/Positions/id : возвращает конкретную должность по параметру id
            </p>
            <p>
                POST api/Positions/model : запрос на создание новой должности");
            WriteLiteral(@" с параметром model
            </p>
            <p>
                PUT api/Positions/model : запрос на обновление должности с параметром model
            </p>
            <p>
                DELETE api/Positions/id : запрос на удаление должности по параметру id
            </p>
        </div>
    </div>
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""jumbotron"">
            <h1>Работа с организационно-правовыми формами</h1>
            <p>
                GET api/LegalForms : возвращает все организационно-правовые формы деятельности компаний
            </p>
            <p>
                GET api/LegalForms/id : возвращает конкретную организационно-правовую форму деятельности компании по параметру id
            </p>
            <p>
                POST api/LegalForms/model : запрос на создание новой организационно-правовой формы деятельности компаний с параметром model
            </p>
            <p>
                PUT api/LegalForms/model : запрос на обновлен");
            WriteLiteral(@"ие организационно-правовой формы деятельности компаний с параметром model
            </p>
            <p>
                DELETE api/LegalForms/id : запрос на удаление организационно-правовой формы деятельности компаний по параметру id
            </p>
        </div>
    </div>
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""jumbotron"">
            <h1>Работа с сотрудниками</h1>
            <p>
                GET api/Employees : возвращает всех сотрудников
            </p>
            <p>
                GET api/Employees/id : возвращает конкретного сотрудника по параметру id
            </p>
            <p>
                POST api/Employees/model : запрос на создание нового сотрудника с параметром model
            </p>
            <p>
                PUT api/Employees/model : запрос на обновление сотрудника с параметром model
            </p>
            <p>
                DELETE api/Employees/id : запрос на удаление сотрудника по параметру id
            </p>");
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
