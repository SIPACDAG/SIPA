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
    public class ArchivoLN
    {
        #region Nuevo codigo

        public Archivo NuevoArchivo(Archivo archivo)
        {
            ArchivoAD archivoAd = new ArchivoAD();
            var dt = archivoAd.GuardarArchivo(archivo);
            if (dt != null && !dt.HasErrors && dt.Rows.Count > 0)
            {
                archivo.id_archivo = Convert.ToInt32(dt.Rows[0][0]);
            }
            return archivo;
        }

        public DataTable GetEmpleado(int id_empleado)
        {
            EmpleadosAD empleadoAD = new EmpleadosAD();
            return empleadoAD.GetEmpleado(id_empleado);
        }

        public Archivo ModificarArchivo(Archivo archivo)
        {
            ArchivoAD archivoAd = new ArchivoAD();
            var dt = archivoAd.ModificarArchivo(archivo);
            if (dt != null && !dt.HasErrors && dt.Rows.Count > 0)
            {
                throw new Exception("Ocurrió un error al modificar el archivo.");
            }
            return archivo;
        }

        #endregion
    }
}
