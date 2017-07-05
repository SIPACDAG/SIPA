using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaEN
{
    public class PlanAnualEN
    {
        public DataSet armarDsPac()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable("ENC"));
            ds.Tables["ENC"].Columns.Add("ID_PAC", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_POA", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_DETALLE", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("NO_RENGLON", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_INSUMO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_MODALIDAD", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_CATEGORIA", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_EXCEPCION", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("DESCRIPCION", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ANIO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("USUARIO", Type.GetType("System.String"));
            /*DataRow dr = ds.Tables["ENC"].NewRow();
            ds.Tables["ENC"].Rows.Add(dr);*/

            ds.Tables.Add(new DataTable("DET"));
            ds.Tables["DET"].Columns.Add("ID_DETALLE", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("ID_PAC", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("MES", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("MONTO", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("USUARIO", Type.GetType("System.String"));

            return ds;
        }
             
            

    }
}
