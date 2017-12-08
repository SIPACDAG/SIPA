using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Data;

namespace CapaLN
{
    public class ContratoLN
    {
        /// <summary>
        /// Obtiene Datos del contrato activo
        /// </summary>
        /// <param name="id_empleado">Id del empleado sobre el cual se traeran los datod del contrato</param>
        /// <returns>Datos del contrato</returns>
        public DataTable ObtenerContrato(int id_empleado)
        {
            ContratoAD contratoAD = new ContratoAD();
            return contratoAD.GetContrato(id_empleado);
        }

        /// <summary>
        /// Crea un contrato para un empleado
        /// </summary>
        /// <param name="p_contrato">Objeto con los datos del contrato</param>
        /// <returns></returns>
        public DataTable CrearContrato(Contratos p_contrato)
        {
            ContratoAD contratoAD = new ContratoAD();
            return contratoAD.CrearContrato(p_contrato);
        }

        /// <summary>
        /// Edita los datos de un contrato
        /// </summary>
        /// <param name="p_contrato">Objeto contrato a editar</param>
        /// <returns></returns>
        public DataTable EditarContrato (Contratos p_contrato)
        {
            ContratoAD contratoAD = new ContratoAD();
            return contratoAD.EditarContrato(p_contrato);
        }

        /// <summary>
        /// Elimina un contrato para determinado contrato
        /// </summary>
        /// <param name="p_id_contrato">Id del contrato a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarContrato(int p_id_contrato)
        {
            ContratoAD contratoAD = new ContratoAD();
            return contratoAD.EliminarContrato(p_id_contrato);
        }

        /// <summary>
        /// Obtiene los contratos del empleado
        /// </summary>
        /// <param name="p_id_empleados">Id del empleado a obtener contratos</param>
        /// <returns></returns>
        public DataTable ObtenerHistorialContrato(int p_id_empleados)
        {
            ContratoAD contratoAD = new ContratoAD();
            return contratoAD.ObtenerHistorialContrato(p_id_empleados);
        }

    }
}
