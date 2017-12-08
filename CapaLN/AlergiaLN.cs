using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class AlergiaLN
    {
        /// <summary>
        /// Obtiene el listado de alergias
        /// </summary>
        /// <returns>Listado de alergias</returns>
        public DataTable ObtenerAlergia()
        {
            AlergiaAD alergiaAD = new AlergiaAD();
            return alergiaAD.ListadoAlergia();
        }

        /// <summary>
        /// Agrega una alergia nueva 
        /// </summary>
        /// <param name="alergia"></param>
        /// <returns>Listado de alergias</returns>
        public DataTable CrearAlergia(String alergia)
        {
            AlergiaAD alergiaAD = new AlergiaAD();
            return alergiaAD.CrearAlergia(alergia);
        }

        /// <summary>
        /// Edita la descripción de la alergia
        /// </summary>
        /// <param name="id">Id de la alergía a editar</param>
        /// <param name="alergia">Descripción de la alergia</param>
        /// <returns></returns>
        public DataTable EditarAlergia(int id, string alergia)
        {
            AlergiaAD alergiaAD = new AlergiaAD();
            return alergiaAD.EditarAlergia(id, alergia);
        }

        /// <summary>
        /// Elimina una alergia
        /// </summary>
        /// <param name="id">Id de la alergia a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarAlergia(int id)
        {
            AlergiaAD alergiaAD = new AlergiaAD();
            return alergiaAD.EliminarAlergia(id);
        }

        /// <summary>
        /// Obtiene los datos de una alergia
        /// </summary>
        /// <param name="id">Id de la alergia a obtener</param>
        /// <returns>Tabla con datos de la alergi</returns>
        public DataTable GetAlergia(int id)
        {
            AlergiaAD alergiaAD = new AlergiaAD();
            return alergiaAD.GetAlergia(id);
        }
    }
}
