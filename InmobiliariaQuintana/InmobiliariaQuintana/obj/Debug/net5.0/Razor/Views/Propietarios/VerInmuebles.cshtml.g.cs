#pragma checksum "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23e4627c5d78444a82ee2c7b257279c8e9700f1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Propietarios_VerInmuebles), @"mvc.1.0.view", @"/Views/Propietarios/VerInmuebles.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\_ViewImports.cshtml"
using InmobiliariaQuintana;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\_ViewImports.cshtml"
using InmobiliariaQuintana.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23e4627c5d78444a82ee2c7b257279c8e9700f1b", @"/Views/Propietarios/VerInmuebles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6741b137c68282f08820d746ca13cc4305978e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Propietarios_VerInmuebles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InmobiliariaQuintana.Models.Inmueble>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
  
    ViewData["Title"] = "VerInmuebles";
    var propietario = ViewBag.Nombre;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Inmuebles</h1>\r\n<h2>Propietario ");
#nullable restore
#line 9 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(propietario);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            \r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Superficie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Latitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayNameFor(model => model.Longitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 36 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Superficie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Latitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
           Write(Html.DisplayFor(modelItem => item.Longitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n           \r\n        </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Propietarios\VerInmuebles.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InmobiliariaQuintana.Models.Inmueble>> Html { get; private set; }
    }
}
#pragma warning restore 1591
