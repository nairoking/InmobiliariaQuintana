#pragma checksum "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0bfbbeece6b1d70dc864df0f279e56afddfcd0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contrato_Index), @"mvc.1.0.view", @"/Views/Contrato/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0bfbbeece6b1d70dc864df0f279e56afddfcd0b", @"/Views/Contrato/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6741b137c68282f08820d746ca13cc4305978e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Contrato_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InmobiliariaQuintana.Models.Contrato>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pago", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Pagos"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Contratos</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0bfbbeece6b1d70dc864df0f279e56afddfcd0b5195", async() => {
                WriteLiteral("Crear nuevo contrato");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdContrato));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.InquilinoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.InmuebleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaDesde));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaHasta));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DNIGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TelefonoGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 46 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdContrato));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 53 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
                Write(item.inqui.Nombre + " " + item.inqui.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 56 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
                Write(item.InmuebleId + " - " + item.inmueble.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 59 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaDesde));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 62 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaHasta));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NombreGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DNIGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 71 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TelefonoGarante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 74 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 77 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.IdContrato }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 78 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.IdContrato }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 79 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.IdContrato }));

#line default
#line hidden
#nullable disable
            WriteLiteral("|\r\n                    \r\n\r\n                    <!-- <a class=\"btn btn-primary\" asp-action=\"Edit\" asp-controller=\"Contrato\" asp-route-id=\"");
#nullable restore
#line 82 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
                                                                                                         Write(item.IdContrato);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" title=\"Edit\"><i class=\"fas fa-pencil-alt\"></i> </a>\r\n    <a class=\"btn btn-primary\" asp-action=\"Details\" asp-controller=\"Contrato\" asp-route-id=\"");
#nullable restore
#line 83 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
                                                                                       Write(item.IdContrato);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" title=\"Details\"> </a>\r\n    <a class=\"btn btn-primary\" asp-action=\"Delete\" asp-controller=\"Contrato\" asp-route-id=\"");
#nullable restore
#line 84 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
                                                                                      Write(item.IdContrato);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" title=\"Delete\"> </a>\r\n    \r\n                        -->\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0bfbbeece6b1d70dc864df0f279e56afddfcd0b16220", async() => {
                WriteLiteral("Pagos ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
                                                                                          WriteLiteral(item.IdContrato);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n                </td>\r\n                        </tr>\r\n");
#nullable restore
#line 92 "C:\Users\Miguelon\Documents\GitHub\InmobiliariaQuintana\InmobiliariaQuintana\InmobiliariaQuintana\Views\Contrato\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InmobiliariaQuintana.Models.Contrato>> Html { get; private set; }
    }
}
#pragma warning restore 1591
