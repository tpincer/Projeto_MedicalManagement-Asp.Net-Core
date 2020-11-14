using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDeveloperMvc.ViewComponents.EstadoPaciente
{
    [ViewComponent(Name = "EstadoGrave")]

    public class EstadoGraveViewComponents : ViewComponent
    {
        public EstadoGraveViewComponents()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
