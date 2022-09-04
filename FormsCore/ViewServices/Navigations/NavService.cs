using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.TreeEditor.Services.Shared.Navigations
{
    public class NavService
    {
        private readonly NavigationManager _navigationManager;

        public NavService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        
    }
}
