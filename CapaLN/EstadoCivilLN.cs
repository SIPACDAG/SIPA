using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class EstadoCivilLN
    {
        /// <summary>
        /// Obtiene listado de Estados civiles
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerEstadoCivil()
        {
            EstadoCivilAD estadocivilAD = new EstadoCivilAD();
            return estadocivilAD.ListadoEstadoCivil();
        }

        /// <summary>
        /// Crea un estado civil nuevo
        /// </summary>
        /// <param name="estado_civil">Descripción del estado civil</param>
        /// <returns></returns>
        public DataTable CrearEstadoCivil(String estado_civil)
        {
            EstadoCivilAD estadocivilAD = new EstadoCivilAD();
            return estadocivilAD.CrearEstadoCivil(estado_civil);
        }

        /// <summary>
        /// Editar un estado civil
        /// </summary>
        /// <param name="id">Id del estado civil a editar</param>
        /// <param name="estado_civil">Descripción modificada</param>
        /// <returns></returns>
        public DataTable EditarEstadoCivil(int id, string estado_civil)
        {
            EstadoCivilAD estadocivilAD = new EstadoCivilAD();
            return estadocivilAD.EditarEstadoCivil(id, estado_civil);
        }

        /// <summary>
        /// Elimina un estado civil
        /// </summary>
        /// <param name="id">Id del estado civil a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarEstadoCivil(int id)
        {
            EstadoCivilAD estadocivilAD = new EstadoCivilAD();
            return estadocivilAD.EliminarEstadoCivil(id);
        }

        /// <summary>
        /// Obtiene un estado civil en especifico
        /// </summary>
        /// <param name="id">Id del estado civil a obtener</param>
        /// <returns></returns>
        public DataTable GetEstadoCivil(int id)
        {
            EstadoCivilAD estadocivilAD = new EstadoCivilAD();
            return estadocivilAD.GetEstadoCivil(id);
        }
    }
}
