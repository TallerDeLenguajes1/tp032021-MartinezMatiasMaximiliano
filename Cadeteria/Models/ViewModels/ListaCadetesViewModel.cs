using Cadeteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.ViewModels
{
    public class ListaCadetesViewModel
    {
        public List<Cadete> listacadetes { get; set; }
        public ListaCadetesViewModel(List<Cadete> listacadetes) { this.listacadetes = listacadetes; }
    }
}
