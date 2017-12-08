using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class DepartamentoLN
    {
        /// <summary>
        /// Obtiene listado de departamentos
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerDepartamento()
        {
            DepartamentoAD departamentoAD = new DepartamentoAD();
            return departamentoAD.ListadoDepartamento();
        }

        /// <summary>
        /// Crea un departamento nuevo 
        /// </summary>
        /// <param name="departamento">Descripción del departamento</param>
        /// <returns></returns>
        public DataTable CrearDepartamento(String departamento)
        {
            DepartamentoAD departamentoAD = new DepartamentoAD();
            return departamentoAD.CrearDepartamento(departamento);
        }

        /// <summary>
        /// Editar la descripción de un departamento
        /// </summary>
        /// <param name="id">Id del departamento a editar</param>
        /// <param name="departamento">Descripción del departamento</param>
        /// <returns></returns>
        public DataTable EditarDepartamento(int id, string departamento)
        {
            DepartamentoAD departamentoAD = new DepartamentoAD();
            return departamentoAD.EditarDepartamento(id, departamento);
        }

        /// <summary>
        /// Departamento a eliminar
        /// </summary>
        /// <param name="id">Id del departamento a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarDepartamento(int id)
        {
            DepartamentoAD departamentoAD = new DepartamentoAD();
            return departamentoAD.EliminarDepartamento(id);
        }


        /// <summary>
        /// Obtiene datos de un departamento en especifico
        /// </summary>
        /// <param name="id">Id del departamento ue se quiere obtener</param>
        /// <returns></returns>
        public DataTable GetDepartamento(int id)
        {
            DepartamentoAD departamentoAD = new DepartamentoAD();
            return departamentoAD.GetDepartamento(id);
        }
    }
}
