using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PracticaProgramacionTresPrograTres.Models
{
    public class Suscripcion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Servicio { get; set; }
        public string CorreoAsociado { get; set; }
        public decimal CostoMensual { get; set; }
        public bool RenovacionAutomatica { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
