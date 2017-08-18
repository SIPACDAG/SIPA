using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class ViaticosEN
    {
        //ENCABEZADO DEL VIATICO
        public int ID_VIATICO { get; set; }
        public DateTime FECHA_NOMBRAMIENTO { get; set; }
        public int ID_POA { get; set; }
        public int ID_ACCION { get; set; }
        public int ID_TIPO_VIATICO { get; set; }
        public int ID_SOLICITANTE { get; set; }
        public int ID_JEFE_DIRECTOR { get; set; }
        public int ID_SUBGERENTE { get; set; }
        public int ID_GERENTE { get; set; }
        public int ID_DIRECTOR_FINANCIERO { get; set; }
        public int ID_TIPO_PERSONA { get; set; }
        public int ID_UNIDAD { get; set; }
        public int ID_DEPENDENCIA { get; set; }
        public int ID_PUESTO { get; set; }

        public int ID_CATEGORIA_DET { get; set; }
        public int ID_GRUPO_DET { get; set; }
        public int RETORNO_AL_EXTERIOR { get; set; }

        public string NOMBRE_SOLICITANTE { get; set; }
        public string NOMBRE_UNIDAD { get; set; }
        public string NOMBRE_DEPENDENCIA { get; set; }
        public string NOMBRE_PUESTO { get; set; }

        public decimal SUELDO_BASE { get; set; }
        public decimal TASA_DE_CAMBIO { get; set; }
        public string TASA_DE_CAMBIO_DS { get; set; }
        public string FECHA_TASA_CAMBIO { get; set; }
        public decimal COSTO_VIATICOS { get; set; }
        public decimal TOTAL_DOLARES { get; set; }

        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public string NIT { get; set; }
        public string JUSTIFICACION { get; set; }
        public string DESTINO { get; set; }

        public DateTime FECHA_INI { get; set; }
        public DateTime FECHA_FIN { get; set; }

        public int VEHICULO_CDAG{ get; set; }
        public decimal KILOMETRAJE { get; set; }
        public decimal PASAJES { get; set; }
        public decimal CUOTA_DIARIA{ get; set; }
        public string OBSERVACIONES { get; set; }
        public string USUARIO { get; set; }
        
    }
}
