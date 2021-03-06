using AutoMapper;
using Cadeteria.Entities;
using Cadeteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<UsuarioAltaViewModel, Usuario>().ReverseMap();
            CreateMap<UsuarioAltaViewModel, Cadete>().ReverseMap();
            CreateMap<Cliente,ClienteViewModel>().ReverseMap();
        }
    }
}
