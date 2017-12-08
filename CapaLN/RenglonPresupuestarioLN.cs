using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class RenglonPresupuestarioLN
    {
        public DataTable ObtenerRenglonPresupuestario()
        {
            RenglonPresupuestarioAD renglonpresupuestarioAD = new RenglonPresupuestarioAD();
            return renglonpresupuestarioAD.ListadoRenglonPresupuestario();
        }

        public DataTable CrearRenglonPresupuestario(String renglon_presupuestario)
        {
            RenglonPresupuestarioAD renglonpresupuestarioAD = new RenglonPresupuestarioAD();
            return renglonpresupuestarioAD.CrearRenglonPresupuestario(renglon_presupuestario);
        }

        public DataTable EditarRenglonPresupuestario(int id, string renglon_presupuestario)
        {
            RenglonPresupuestarioAD renglonpresupuestarioAD = new RenglonPresupuestarioAD();
            return renglonpresupuestarioAD.EditarRenglonPresupuestario(id, renglon_presupuestario);
        }

        public DataTable EliminarRenglonPresupuestario(int id)
        {
            RenglonPresupuestarioAD renglonpresupuestarioAD = new RenglonPresupuestarioAD();
            return renglonpresupuestarioAD.EliminarRenglonPresupuestario(id);
        }

        public DataTable GetRenglonPresupuestario(int id)
        {
            RenglonPresupuestarioAD renglonpresupuestarioAD = new RenglonPresupuestarioAD();
            return renglonpresupuestarioAD.GetRenglonPresupuestario(id);
        }
    }
}
