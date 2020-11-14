using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDeveloperMvc.ViewComponents.EstadoPaciente
{
    [ViewComponent(Name = "EstadoEstavel")]

    public class EstadoEstavelViewComponents : ViewComponent
    {
        public EstadoEstavelViewComponents()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
