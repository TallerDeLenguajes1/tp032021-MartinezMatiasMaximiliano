using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioCadete
    {
        void BorrarCadete(int Id);
        void DesactivarCadete(int Id);
        void EditarCadete(Cadete Cadete);
        List<Cadete> GetAllCadetes();
        Cadete GetCadeteByID(int ID);
        void SaveCadete(Cadete Cadete);
    }
}
