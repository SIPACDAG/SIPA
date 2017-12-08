using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;

namespace CapaLN
{
    public class VacacionesLN
    {
        VacacionesAD ObjAD;

        public DataSet ObtenerContratoEmpleado(string criterio)
        {
            DataSet ds = new DataSet();
            ObjAD = new VacacionesAD();
            ds = ObjAD.ObtenerContratoEmpleado(criterio);
            return ds;
        }

        public DataSet ObtenerDiasVacaciones(int id)
        {
            DataSet ds = new DataSet();
            ObjAD = new VacacionesAD();
            ds = ObjAD.ObtenerDiasVacaciones(id);
            return ds;
        }

        public DataSet ListadoVacaciones(int id_vacacion)
        {
            DataSet ds = new DataSet();
            ObjAD = new VacacionesAD();
            ds = ObjAD.ListadoVacaciones(id_vacacion);
            return ds;
        }

        public int InserVacaciones(int id, string fehca, string dias_disponibles, string dias_tomados, string dias, string id_empleado)
        {
            ObjAD = new VacacionesAD();
            string[] valores = fehca.Split('/');
            string temp = valores[2].Substring(0, 4) + "-" + valores[0] + "-" + valores[1];
            int result = ObjAD.InserVacaciones(id, temp,dias_disponibles,dias_tomados,dias,id_empleado);
            return result;
        }
        public int InsertVacacionesDetalle(int id_vaciones, string dias, string fechaI, string fechaF)
        {
            ObjAD = new VacacionesAD();
            int result = ObjAD.InsertVacacionesDetalle(id_vaciones,dias,fechaI,fechaF);
            return result;
        }

        public int EliminarVacacion(int id, int cantidad, string dias_disponibles, string idVacacion)
        {
            ObjAD = new VacacionesAD();
            return ObjAD.EliminarVacacion(id,cantidad,dias_disponibles,idVacacion);
        }
    }
}
