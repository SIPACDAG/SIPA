using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class TipoLicenciaLN
    {
        public DataTable ObtenerTipoLicencia()
        {
            TipoLicenciaAD tipolicenciaAD = new TipoLicenciaAD();
            return tipolicenciaAD.ListadoTipoLicencia();
        }

        public DataTable CrearTipoLicencia(String tipo_licencia)
        {
            TipoLicenciaAD tipolicenciaAD = new TipoLicenciaAD();
            return tipolicenciaAD.CrearTipoLicencia(tipo_licencia);
        }

        public DataTable EditarTipoLicencia(int id, string tipo_licencia)
        {
            TipoLicenciaAD tipolicenciaAD = new TipoLicenciaAD();
            return tipolicenciaAD.EditarTipoLicencia(id, tipo_licencia);
        }

        public DataTable EliminarTipoLicencia(int id)
        {
            TipoLicenciaAD tipolicenciaAD = new TipoLicenciaAD();
            return tipolicenciaAD.EliminarTipoLicencia(id);
        }

        public DataTable GetTipoLicencia(int id)
        {
            TipoLicenciaAD tipolicenciaAD = new TipoLicenciaAD();
            return tipolicenciaAD.GetTipoLicencia(id);
        }
    }
}
