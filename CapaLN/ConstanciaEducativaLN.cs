using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;

namespace CapaLN
{
    /// <summary>
    /// Clase Constancia educativa 
    /// </summary>
    public class ConstanciaEducativaLN
    {
        #region Nuevo codigo

        /// <summary>
        /// Agrega nueva constancia
        /// </summary>
        /// <param name="constancia">objeto constancia</param>
        /// <returns></returns>
        public DataTable AgregarConstancia(ConstanciaEducativa constancia)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD();
            var dt = new DataTable();
            if (constancia.id_constancia > 0)
            {
                dt = constanciaAD.ModificarConstancia(constancia);
            }
            else
            {
                dt = constanciaAD.NuevaConstancia(constancia);
            }
            return dt;
        }

        /// <summary>
        /// Modificar constancia
        /// </summary>
        /// <param name="constancia">objeto constancia</param>
        /// <returns></returns>
        public DataTable ModificarConstancia(ConstanciaEducativa constancia)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD();
            var dt = constanciaAD.ModificarConstancia(constancia);
            return dt;
        }

        /// <summary>
        /// Eliminar constancia 
        /// </summary>
        /// <param name="constancia"></param>
        /// <returns></returns>
        public DataTable EliminarConstancia(ConstanciaEducativa constancia)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD();
            var dt = constanciaAD.EliminarConstanciaEducativa(constancia.id_constancia);
            return dt;
        }


        /// <summary>
        /// Consulta de constancia 
        /// </summary>
        /// <param name="idEmpleado">identificador de empleado</param>
        /// <returns></returns>
        public DataTable ConsultarConstanciaParaEmpleado(int idEmpleado)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD();
            var dt = constanciaAD.GetConstanciasEducativas(idEmpleado);
            return dt;
        }


        public DataTable ConsultarConstancia(int idConstancia)
        {
            ConstanciasEducativasAD constanciaAD = new ConstanciasEducativasAD();
            var dt = constanciaAD.GetConstanciaEducativa(idConstancia);
            return dt;
        }

        #endregion
    }
}
