using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class TipoSangreLN
    {
        public DataTable ObtenerTipoSangre()
        {
            TipoSangreAD tiposangreAD = new TipoSangreAD();
            return tiposangreAD.ListadoTipoSangre();
        }

        public DataTable CrearTipoSangre(String tipo_sangre)
        {
            TipoSangreAD tiposangreAD = new TipoSangreAD();
            return tiposangreAD.CrearTipoSangre(tipo_sangre);
        }

        public DataTable EditarTipoSangre(int id, string tipo_sangre)
        {
            TipoSangreAD tiposangreAD = new TipoSangreAD();
            return tiposangreAD.EditarTipoSangre(id, tipo_sangre);
        }

        public DataTable EliminarTipoSangre(int id)
        {
            TipoSangreAD tiposangreAD = new TipoSangreAD();
            return tiposangreAD.EliminarTipoSangre(id);
        }

        public DataTable GetTipoSangre(int id)
        {
            TipoSangreAD tiposangreAD = new TipoSangreAD();
            return tiposangreAD.GetTipoSangre(id);
        }
    }
}
