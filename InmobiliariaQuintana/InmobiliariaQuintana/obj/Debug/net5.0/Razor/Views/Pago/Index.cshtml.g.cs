#pragma checksum "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81edfb7c7d07d19b7cc19fdc10d858eeb17aa104"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pago_Index), @"mvc.1.0.view", @"/Views/Pago/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81edfb7c7d07d19b7cc19fdc10d858eeb17aa104", @"/Views/Pago/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6741b137c68282f08820d746ca13cc4305978e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Pago_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InmobiliariaQuintana.Models.Pago>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int numeroPago = Model.Count() + 1;
    int idContrato = ViewBag.idContratoR;
    var hoy = DateTime.Now.Date.ToString();
    var contrato = ViewBag.contrato;
    var saldo = ViewBag.contrato.Precio;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    \r\n    ");
#nullable restore
#line 17 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
Write(Html.ActionLink("Crear Pago", "Create", new { id = idContrato }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NumeroPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 36 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ContratoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 39 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaUpdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 45 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumeroPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaPago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Monto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ContratoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaUpdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 67 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 68 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 69 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Pago\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InmobiliariaQuintana.Models.Pago>> Html { get; private set; }
    }
}
#pragma warning restore 1591