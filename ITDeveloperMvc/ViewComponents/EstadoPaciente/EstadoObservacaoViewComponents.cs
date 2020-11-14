using ITDeveloperMvc.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDeveloperMvc.ViewComponents.EstadoPaciente
{
    public class EstadoObservacaoViewComponents : ViewComponent
    {
        public EstadoObservacaoViewComponents()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalGeral = Util.TotReg();
            decimal totalEstado = Util.GetNumRegEstado();

            decimal progress = totalEstado * 100 / totalGeral;
            var prct = progress.ToString("F1");

            var model = new ContadorEstadoPaciente()
            {
                Titulo = "Paciente em Observação",
                Parcial = (int)totalEstado,
                Percentual = prct,
                ClassContainer = "panel panel-default tile panelClose panelRefresh",
                IconeLg = "l-banknote",
                IconeSm = "fa fa-arrow-circle-o-down s20 mr5 pull-left",
                Progress = progress
            };

            return View(model);
        }
    }
}
