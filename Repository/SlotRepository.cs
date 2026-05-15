using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Model;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Repository
{
    public class SlotRepository
    {
        private readonly List<Slot> _listaSlots = new List<Slot>();

        public List<Slot> ListarSlots()
        {
            return _listaSlots.ToList();
        }

        public Slot? BuscarPorDisponibilidade(DateTime data, Enums.Periodo periodo)
        {
            if (data == default)    
                return null;

            return _listaSlots.FirstOrDefault(x => x.Data.Date == data.Date && x.Periodo == periodo);
        }
    }
}