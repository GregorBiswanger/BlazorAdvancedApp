using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using BlazorAdvancedApp;
using BlazorAdvancedApp.Shared;
using BlazorAdvancedApp.Pages.Index.Services;

namespace BlazorAdvancedApp.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IChucknorrisService ChucknorrisService { get; set; }

        public void ReloadJokeInvoke()
        {
            ChucknorrisService.ReloadJoke.OnNext(true);
        }
    }
}