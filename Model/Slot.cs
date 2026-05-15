using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Enums;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Model
{
    public class Slot
    {
        public DateTime Data { get; set; }
        public Periodo Periodo { get; set; }
        public TimeOnly Horario { get; set; }

        public Slot(){}

        public Slot(DateTime data, Periodo periodo, TimeOnly horario)
        {
            Data = data.Date;
            Periodo = periodo;
            Horario = horario;
        }
    }
}