using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class EstadoContratoLN
    {
        /// <summary>
        /// Obtiene listado de estados de contrato
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerEstadoContrato()
        {
            EstadoContratoAD estadocontratoAD = new EstadoContratoAD();
            return estadocontratoAD.ListadoEstadoContrato();
        }

        /// <summary>
        /// Crea un estado de contrato nuevo
        /// </summary>
        /// <param name="estado_contrato">Descripción del nuevo estado de contrato</param>
        /// <returns></returns>
        public DataTable CrearEstadoContrato(String estado_contrato)
        {
            EstadoContratoAD estadocontratoAD = new EstadoContratoAD();
            return estadocontratoAD.CrearEstadoContrato(estado_contrato);
        }

        /// <summary>
        /// Edita un estado de contrato
        /// </summary>
        /// <param name="id">Id del estado a editar</param>
        /// <param name="estado_contrato">Descripcion modificada</param>
        /// <returns></returns>
        public DataTable EditarEstadoContrato(int id, string estado_contrato)
        {
            EstadoContratoAD estadocontratoAD = new EstadoContratoAD();
            return estadocontratoAD.EditarEstadoContrato(id, estado_contrato);
        }

        /// <summary>
        /// Elimina un estado de contrato nuevo
        /// </summary>
        /// <param name="id">Id del estado de contrato</param>
        /// <returns></returns>
        public DataTable EliminarEstadoContrato(int id)
        {
            EstadoContratoAD estadocontratoAD = new EstadoContratoAD();
            return estadocontratoAD.EliminarEstadoContrato(id);
        }

        /// <summary>
        /// Obtiene datos de un estado de contrato 
        /// </summary>
        /// <param name="id">Id del estado de contrato a obtener</param>
        /// <returns></returns>
        public DataTable GetEstadoContrato(int id)
        {
            EstadoContratoAD estadocontratoAD = new EstadoContratoAD();
            return estadocontratoAD.GetEstadoContrato(id);
        }
    }
}
