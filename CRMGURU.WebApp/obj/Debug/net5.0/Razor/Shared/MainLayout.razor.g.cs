#pragma checksum "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be5caf9b343f76ff151063e911502be3060fffec"
// <auto-generated/>
#pragma warning disable 1591
namespace CRMGURU.WebApp.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using CRMGURU.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using CRMGURU.WebApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using CRMGURU.Api.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MudBlazor.MudThemeProvider>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\r\n");
            __builder.OpenComponent<MudBlazor.MudDialogProvider>(2);
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n");
            __builder.OpenComponent<MudBlazor.MudSnackbarProvider>(4);
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenComponent<MudBlazor.MudLayout>(6);
            __builder.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudMainContent>(8);
                __builder2.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(10, 
#nullable restore
#line 9 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
