using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class PresupuestoEN
    {
        public int idPresupuestoUnidad { get; set; }
        public int idUnidad { get; set; }
        public int idDependencia { get; set; }
        public int idPlan { get; set; }
        public double monto { get; set; }
        public int anio { get; set; }
        public string usuario { get; set; }
        
        public string id_modificacion { get; set; }
        public string id_poa { get; set; }
        public string id_unidad { get; set; }
        public string anio_solicitud { get; set; }
        public string techo_aprobado { get; set; }
        public string techo_actual { get; set; }
        public string ppto_codificado { get; set; }
        public string ppto_pendiente_codificar { get; set; }
        public string nuevo_techo { get; set; }
        public string sobreescribe_techo_aprobado { get; set; }
        public string justificacion { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public string usuario_solicitud { get; set; }
        public string fecha_solicitud { get; set; }
        public string usuario_dge { get; set; }
        public string fecha_dge { get; set; }
        public string aprobacion_dge { get; set; }
        public string usuario_sdi { get; set; }
        public string fecha_sdi { get; set; }
        public string aprobacion_sdi { get; set; }
        public string usuario_ing { get; set; }
        public string fecha_ing { get; set; }
        public string usuario_act { get; set; }
        public string fecha_act { get; set; }

        public string monto_global { get; set; }
    }
}
