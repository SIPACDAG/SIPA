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
    public class GeneroLN
    {
        /// <summary>
        /// Obtiene listado de generos
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerGeneros()
        {
            GeneroAD generoAD = new GeneroAD();
            return generoAD.ListadoGeneros();
        }

        /// <summary>
        /// Crea un nuevo género
        /// </summary>
        /// <param name="genero">Descripción del nuevo género</param>
        /// <returns></returns>
        public DataTable CrearGenero(String genero)
        {
            GeneroAD generoAD = new GeneroAD();
            return generoAD.CrearGenero(genero);
        }

        /// <summary>
        /// Edita un género
        /// </summary>
        /// <param name="id">Id del género a editar</param>
        /// <param name="genero">Descripción modificada</param>
        /// <returns></returns>
        public DataTable EditarGenero (int id, string genero)
        {
            GeneroAD generoAD = new GeneroAD();
            return generoAD.EditarGenero(id, genero);
        }

        /// <summary>
        /// Eliminar un género
        /// </summary>
        /// <param name="id">Id del género a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarGenero(int id)
        {
            GeneroAD generoAD = new GeneroAD();
            return generoAD.EliminarGenero(id);
        }

        /// <summary>
        /// Obtiene un género
        /// </summary>
        /// <param name="id">Id del género a obtener</param>
        /// <returns></returns>
        public DataTable GetGenero(int id)
        {
            GeneroAD generoAD = new GeneroAD();
            return generoAD.GetGenero(id);
        }
    }
}
