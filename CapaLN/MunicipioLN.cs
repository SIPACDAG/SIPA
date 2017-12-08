using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLN
{
    public class MunicipioLN
    {
        /// <summary>
        /// Obtiene listado de municipios según departamento
        /// </summary>
        /// <param name="id">Id del departamento sobre el cuál se obtendran los municipios</param>
        /// <returns></returns>
        public DataTable ObtenerMunicipio(int id)
        {
            MunicipioAD municipioAD = new MunicipioAD();
            return municipioAD.ListadoMunicipio(id);
        }

        /// <summary>
        /// Obtiene todos los municipios
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerTodosMunicipios()
        {
            MunicipioAD municipioAD = new MunicipioAD();
            return municipioAD.ListadoTodosMunicipios();
        }

        /// <summary>
        /// Crea un nuevo municipio
        /// </summary>
        /// <param name="municipio">Descripción del nuevo municipio</param>
        /// <param name="codigo">Codigo del municipio</param>
        /// <param name="departamento">Id del departamento al que pertenece el municipio</param>
        /// <returns></returns>
        public DataTable CrearMunicipio(String municipio, int codigo, int departamento)
        {
            MunicipioAD municipioAD = new MunicipioAD();
            return municipioAD.CrearMunicipio(municipio, codigo, departamento);
        }

        /// <summary>
        /// Edita un municipio
        /// </summary>
        /// <param name="id">Id del departamento al que pertenece el municipio</param>
        /// <param name="municipio">Descripción del municipio a editar</param>
        /// <param name="codigo">Código del municipio</param>
        /// <returns></returns>
        public DataTable EditarMunicipio(int id, string municipio, int codigo)
        {
            MunicipioAD municipioAD = new MunicipioAD();
            return municipioAD.EditarMunicipio(id, municipio, codigo);
        }

        /// <summary>
        /// Elimina un municipio
        /// </summary>
        /// <param name="id">Id del municipio a eliminar</param>
        /// <returns></returns>
        public DataTable EliminarMunicipio(int id)
        {
            MunicipioAD municipioAD = new MunicipioAD();
            return municipioAD.EliminarMunicipio(id);
        }

        /// <summary>
        /// Obtiene datos de un municipio 
        /// </summary>
        /// <param name="id">Id del municipio a obtener</param>
        /// <returns></returns>
        public DataTable GetMunicipio(int id)
        {
            MunicipioAD municipioAD = new MunicipioAD();
            return municipioAD.GetMunicipio(id);
        }
    }
}