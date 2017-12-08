using CapaAD;
using CapaEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class ConstanciaEducativaLN
    {

        public DataTable AgregarConstancia(ConstanciaEducativa constancia)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD();
            var dt = constanciaAD.NuevaConstancia(constancia);
            return dt;
        }

        public DataTable EliminarArchivo(ConstanciaEducativa constancia)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD();
            var dt = constanciaAD.EliminarConstanciaEducativa(constancia.id_constancia);
            return dt;
        }

        public DataTable ConsultarConstanciaParaEmpleado(int idEmpleado)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD(); ArchivoAD archivoAd = new ArchivoAD();
            var dt = constanciaAD.GetConstanciasEducativas(idEmpleado);
            return dt;
        }

    }
}
