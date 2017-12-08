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
    public class ParentescoLN
    {
        /// <summary>
        /// Obtiene lista de parentescos
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerParentescos()
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.ListadoParentescos();
        }

        /// <summary>
        /// Crea un nuevo parentesco
        /// </summary>
        /// <param name="parentesco">Descripción del parentesco</param>
        /// <returns></returns>
        public DataTable CrearParentesco(String parentesco)
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.CrearParentesco(parentesco);
        }

        /// <summary>
        /// Edita un parentesco
        /// </summary>
        /// <param name="id">Id del parentesco a editar</param>
        /// <param name="parentesco">Descripción editada</param>
        /// <returns></returns>
        public DataTable EditarParentesco (int id, string parentesco)
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.EditarParentesco(id, parentesco);
        }

        /// <summary>
        /// Eliminar un parentesco
        /// </summary>
        /// <param name="id">Id del parentesco a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarParentesco(int id)
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.EliminarParentesco(id);
        }

        /// <summary>
        /// Obtiene un parentesco especifico
        /// </summary>
        /// <param name="id">Id del parentesco a obtener</param>
        /// <returns>Datos del parentesco</returns>
        public DataTable GetParentesco(int id)
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.GetParentesco(id);
        }

        /// <summary>
        /// Agrega un nuevo familiar al empleado
        /// </summary>
        /// <param name="id_empleado">Id del empleado al que se le agrega el familiar</param>
        /// <param name="nombre">Nombre del familiar</param>
        /// <param name="fecha_nacimiento">Fecha de nacimiento del familiar</param>
        /// <param name="contacto_emergencia">Indica si el familiar es contacto de emergenci</param>
        /// <param name="telefono">Número de telefono del familiar</param>
        /// <param name="id_parentesco">Id del tipo de parentesco del familiar</param>
        /// <returns></returns>
        public int InsertarFamiliar(string id_empleado, string nombre, string fecha_nacimiento, string contacto_emergencia, string telefono, string id_parentesco)
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.IngresarFamiliar(id_empleado, nombre, fecha_nacimiento, contacto_emergencia, telefono, id_parentesco);
        }

        /// <summary>
        /// Obtiene los familiares almacenados para un empleado
        /// </summary>
        /// <param name="id">Id del empleado a obtener familiares</param>
        /// <returns>Tabla con los datos de los familiares</returns>
        public DataSet ListadoFamiliares(int id)
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.listadoFamiliares(id);
        }

        public int Eliminar_Familiar(int id)
        {
            ParentescoAD parentescoAD = new ParentescoAD();
            return parentescoAD.ElliminarFamiliar(id);
        }
    }
}
