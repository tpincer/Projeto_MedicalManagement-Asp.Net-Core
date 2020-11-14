using ITDeveloperMvc.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDeveloperMvc.ViewComponents.EstadoPaciente
{
    [ViewComponent(Name = "EstadoCritico")]
    public class EstadoCriticoViewComponents : ViewComponent
    {
        public EstadoCriticoViewComponents()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalGeral = Util.TotReg();
            var totalEstado = Util.GetNumRegEstado();

            decimal progress = totalEstado * 100 / totalGeral;
            var prct = progress.ToString("F1");

            var model = new ContadorEstadoPaciente()
            {
                Titulo = "Paciente Critico",
                Parcial = (int)totalEstado,
                Percentual = prct,
                ClassContainer = "panel panel-success tile panelClose panelRefresh",
                IconeLg = "l-basic-geolocalize-05",
                IconeSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left",
                Progress = progress
            };

            return View(model);
        }
    }
}
