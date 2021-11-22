using Cadeteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.ViewModels
{
    public class AltaPedidoViewModel
    {
        public int ClienteID;
        public List<CadeteViewModel> listaCadetesVM = new();
    }
}
