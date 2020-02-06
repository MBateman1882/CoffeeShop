#pragma checksum "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34dffc2614d7cb420bd35e4723688144a8e4b8de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Shop), @"mvc.1.0.view", @"/Views/Home/Shop.cshtml")]
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
#line 1 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\_ViewImports.cshtml"
using CoffeeShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\_ViewImports.cshtml"
using CoffeeShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34dffc2614d7cb420bd35e4723688144a8e4b8de", @"/Views/Home/Shop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0280a23aa28fddc99a39f5869bf0f0a5a4076c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Shop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopDBContext>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
  
    ViewData["Title"] = "Shop";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<h1>Welcome to the Shop</h1>\r\n\r\n<table>\r\n    <tr>\r\n        <th>Name</th>\r\n        <th>Description</th>\r\n        <th>Quantity</th>\r\n        <th>Price</th>\r\n        <th>Purchase</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 22 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
     foreach (Items item in Model.Items)
    {



#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 29 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
           Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>$");
#nullable restore
#line 30 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
            Write(Math.Round(item.Price, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n");
#nullable restore
#line 33 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
             if (Convert.ToBoolean(Context.Session.GetString("Registered")) == true)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td><button");
            BeginWriteAttribute("onclick", " onclick=\"", 705, "\"", 791, 4);
            WriteAttributeValue("", 715, "location.href=", 715, 14, true);
            WriteAttributeValue(" ", 729, "\'", 730, 2, true);
#nullable restore
#line 35 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
WriteAttributeValue("", 731, Url.Action("Purchase", "Home", new { price = item.Price }), 731, 59, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 790, "\'", 790, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Buy</button></td>\r\n");
#nullable restore
#line 36 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 38 "C:\Users\mbate\source\repos\CoffeeShop\CoffeeShop\Views\Home\Shop.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopDBContext> Html { get; private set; }
    }
}
#pragma warning restore 1591
