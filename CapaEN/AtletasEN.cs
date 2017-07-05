using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class AtletasEN
    {
        public int idAtleta { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        //public int idTipoSangre { get; set; }
        public int genero { get; set; }
        public int idEtnia { get; set; }
        public int idFederacion { get; set; }
        public string fechaNacimiento { get; set; }
        public string usuario { get; set; }
        public int idUnidadMedica { get; set; }
        public int idTipoAtleta { get; set; }

        public int idPersonal { get; set; }
        public int idAtencionAtleta { get; set; }
        public int idTipoAtencion { get; set; }
        public int idTipoTratamiento { get; set; }
        public string observacion { get; set; }



    }
}
