using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class EnfermedadLN
    {
        /// <summary>
        /// Obtiene Listado de enfermedades
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerEnfermedad()
        {
            EnfermedadAD enfermedadAD = new EnfermedadAD();
            return enfermedadAD.ListadoEnfermedad();
        }

        /// <summary>
        /// Agrega una nueva enfermedad
        /// </summary>
        /// <param name="enfermedad">Descripción de la nueva enfermedad</param>
        /// <returns></returns>
        public DataTable CrearEnfermedad(String enfermedad)
        {
            EnfermedadAD enfermedadAD = new EnfermedadAD();
            return enfermedadAD.CrearEnfermedad(enfermedad);
        }

        /// <summary>
        /// Edita datos de una enfermedad
        /// </summary>
        /// <param name="id">Id enfermedad a modificar</param>
        /// <param name="enfermedad">Descripción a modificar</param>
        /// <returns></returns>
        public DataTable EditarEnfermedad(int id, string enfermedad)
        {
            EnfermedadAD enfermedadAD = new EnfermedadAD();
            return enfermedadAD.EditarEnfermedad(id, enfermedad);
        }

        /// <summary>
        /// Eliminar una enfermedad
        /// </summary>
        /// <param name="id">Id de la enfermedad a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarEnfermedad(int id)
        {
            EnfermedadAD enfermedadAD = new EnfermedadAD();
            return enfermedadAD.EliminarEnfermedad(id);
        }

        /// <summary>
        /// Obtiene datos de una enfermedad
        /// </summary>
        /// <param name="id">Id enfermedad a obtener</param>
        /// <returns></returns>
        public DataTable GetEnfermedad(int id)
        {
            EnfermedadAD enfermedadAD = new EnfermedadAD();
            return enfermedadAD.GetEnfermedad(id);
        }
    }
}
