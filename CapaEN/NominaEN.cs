using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class NominaEN
    {
        public int IDNomina { get; set; }
        public int Anio { get; set; }
        public string Fecha { get; set; }
        public int IDTIpo { get; set; }
        public string Renglon { get; set; }
        public int IDProyecto { get; set; }
        public string Descripcion { get; set; }
        public string Periodo { get; set; }
        public int Estado { get; set; }
        public bool Concejo { get; set; }
        public string usuario { get; set; }
        // Detalle Nomina
        public int IDEmpleado { get; set; }
        public string Nombre { get; set; }
        public string fIngreso { get; set; }
        public string Cuenta { get; set; }
        public string RenglonD { get; set; }
        public int Departamento { get; set; }
        public int Dereccion { get; set; }
        public int Dias { get; set; }
        public double SueldoBase { get; set; }
        public double Bonificacion { get; set; }
        public double IGSS { get; set; }
        public double Prestaciones { get; set; }
        public double Fianza { get; set; }
        public double ISR { get; set; }
        public double Bantrab { get; set; }
        public double OtrasBonificaciones { get; set; }
        public double OtrasDeducciones { get; set; }
        public int Status { get; set; }
        public int NotaStatus { get; set; }
        public double BanSeguro { get; set; }

    }
}
