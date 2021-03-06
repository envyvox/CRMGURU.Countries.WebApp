// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CRMGURU.WebApp.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 92 "D:\Development\CRMGURU.WebApp\CRMGURU.WebApp\Pages\Index.razor"
 
    private bool _displayCountries;
    private bool _displayFoundedCountry;
    private CountryClient _countryClient;
    private ICollection<CountryDto> _countries;
    private CountryDto _foundedCountry;

    protected override async Task OnInitializedAsync()
    {
        _countryClient = new CountryClient(_http);
        _countries = await _countryClient.GetCountriesAsync();
    }

    private void ToggleCountries()
    {
        _displayCountries = !_displayCountries;
    }

    private async Task SearchCountry(string countryName)
    {
        if (string.IsNullOrEmpty(countryName))
        {
            _displayFoundedCountry = false;
            return;
        }

        try
        {
            _foundedCountry = await _countryClient.GetCountryByNameAsync(countryName);
            _displayFoundedCountry = true;
        }
        catch (ApiException e)
        {
            _snackbar.Add(e.Response);
        }
        catch (Exception e)
        {
            _snackbar.Add(e.Message);
        }
    }

    private async Task SaveToDatabase()
    {
        try
        {
            _foundedCountry = await _countryClient.CreateCountryAsync(new CreateCountryCommand
            {
                Name = _foundedCountry.Name,
                Code = _foundedCountry.Code,
                Area = _foundedCountry.Area,
                Population = _foundedCountry.Population,
                CapitalName = _foundedCountry.Capital.Name,
                RegionName = _foundedCountry.Region.Name
            });

            _countries.Add(_foundedCountry);

            _snackbar.Add("Country added to database.");
        }
        catch (ApiException e)
        {
            _snackbar.Add(e.Response);
        }
        catch (Exception e)
        {
            _snackbar.Add(e.Message);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISnackbar _snackbar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
