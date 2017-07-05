using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaEN
{
    public class GESFOR2EN
    {
        public DataSet armarDsGESFOR2()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable("ENC"));
            ds.Tables["ENC"].Columns.Add("ID_SOLICITUD", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_FORMULARIO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_POA", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("NO_SOLICITUD", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ANIO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_UNIDAD", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_DEPENDENCIA", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("FECHA", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("TIPO_SOLICITUD", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_ACCION", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ID_ESTADO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("TRANSFERENCIA", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("DEBITO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("CREDITO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("DESTINO_DEBITO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("ORIGEN_CREDITO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("SOLICITUD_PRINCIPAL", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("MONTO", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("JUSTIFICACION", Type.GetType("System.String"));
            ds.Tables["ENC"].Columns.Add("USUARIO", Type.GetType("System.String"));
            

            ds.Tables.Add(new DataTable("DET"));
            ds.Tables["DET"].Columns.Add("ID_CAMPO", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("ID_FORMULARIO", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("NOMBRE_TABLA", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("NOMBRE_CAMPO", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("TIPO_DATO", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("ACTIVO", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("VALOR", Type.GetType("System.String"));
            ds.Tables["DET"].Columns.Add("VACIO", Type.GetType("System.String"));

            /*ds.Tables["DET"].Rows.Add("1", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_OBJETIVO_OPERATIVO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("2", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_OBJETIVO_ESTRATEGICO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("3", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_META_ESTRATEGICA", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("4", "1", "SIPA_OBJETIVOS_OPERATIVOS", "CODIGO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("5", "1", "SIPA_OBJETIVOS_OPERATIVOS", "NOMBRE", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("6", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ANIO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("7", "1", "SIPA_OBJETIVOS_OPERATIVOS", "ID_UNIDAD", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("8", "1", "SIPA_OBJETIVOS_OPERATIVOS", "USUARIO", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("9", "1", "SIPA_KPI_OPERATIVOS", "ID_KPI_OPERATIVO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("10", "1", "SIPA_KPI_OPERATIVOS", "ID_OBJETIVO_OPERATIVO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("11", "1", "SIPA_KPI_OPERATIVOS", "ID_META_ESTRATEGICA", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("12", "1", "SIPA_KPI_OPERATIVOS", "NOMBRE", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("13", "1", "SIPA_KPI_OPERATIVOS", "ANIO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("14", "1", "SIPA_KPI_OPERATIVOS", "FORMULA", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("15", "1", "SIPA_KPI_OPERATIVOS", "USUARIO", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("16", "1", "SIPA_METAS_OPERATIVAS", "ID_META_OPERATIVA", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("17", "1", "SIPA_METAS_OPERATIVAS", "ID_KPI_OPERATIVO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("18", "1", "SIPA_METAS_OPERATIVAS", "ANIO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("19", "1", "SIPA_METAS_OPERATIVAS", "NOMBRE", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("20", "1", "SIPA_METAS_OPERATIVAS", "USUARIO", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("21", "1", "SIPA_ACCIONES", "ID_ACCION", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("22", "1", "SIPA_ACCIONES", "ID_POA", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("23", "1", "SIPA_ACCIONES", "ID_DEPENDENCIA", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("24", "1", "SIPA_ACCIONES", "ID_OBJETIVO_OPERATIVO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("25", "1", "SIPA_ACCIONES", "ID_META_OPERATIVA", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("26", "1", "SIPA_ACCIONES", "CODIGO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("27", "1", "SIPA_ACCIONES", "ACCION", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("28", "1", "SIPA_ACCIONES", "META_GENERAL", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("29", "1", "SIPA_ACCIONES", "META_1", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("30", "1", "SIPA_ACCIONES", "META_2", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("31", "1", "SIPA_ACCIONES", "META_3", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("32", "1", "SIPA_ACCIONES", "PONDERACION", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("33", "1", "SIPA_ACCIONES", "PRESUPUESTO", "DECIMAL", "1", "", "S");
            ds.Tables["DET"].Rows.Add("34", "1", "SIPA_ACCIONES", "NO_ACTIVIDADES", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("35", "1", "SIPA_ACCIONES", "ENE", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("36", "1", "SIPA_ACCIONES", "FEB", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("37", "1", "SIPA_ACCIONES", "MAR", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("38", "1", "SIPA_ACCIONES", "ABR", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("39", "1", "SIPA_ACCIONES", "MAY", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("40", "1", "SIPA_ACCIONES", "JUN", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("41", "1", "SIPA_ACCIONES", "JUL", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("42", "1", "SIPA_ACCIONES", "AGO", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("43", "1", "SIPA_ACCIONES", "SEP", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("44", "1", "SIPA_ACCIONES", "OCT", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("45", "1", "SIPA_ACCIONES", "NOV", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("46", "1", "SIPA_ACCIONES", "DIC", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("47", "1", "SIPA_ACCIONES", "ANIO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("48", "1", "SIPA_ACCIONES", "USUARIO", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("49", "1", "SIPA_ACCIONES", "ID_UNIDAD", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("50", "1", "SIPA_METAS_ACCION", "ID_META_ACCION", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("51", "1", "SIPA_METAS_ACCION", "ID_ACCION", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("52", "1", "SIPA_METAS_ACCION", "ID_META_OPERATIVA", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("53", "1", "SIPA_METAS_ACCION", "META_GENERAL", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("54", "1", "SIPA_METAS_ACCION", "META_1", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("55", "1", "SIPA_METAS_ACCION", "META_2", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("56", "1", "SIPA_METAS_ACCION", "META_3", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("57", "1", "SIPA_METAS_ACCION", "PONDERACION1", "DECIMAL", "1", "", "S");
            ds.Tables["DET"].Rows.Add("58", "1", "SIPA_METAS_ACCION", "PONDERACION2", "DECIMAL", "1", "", "S");
            ds.Tables["DET"].Rows.Add("59", "1", "SIPA_METAS_ACCION", "PONDERACION3", "DECIMAL", "1", "", "S");
            ds.Tables["DET"].Rows.Add("60", "1", "SIPA_METAS_ACCION", "PONDERACION", "DECIMAL", "1", "", "S");
            ds.Tables["DET"].Rows.Add("61", "1", "SIPA_METAS_ACCION", "PRESUPUESTO", "DECIMAL", "1", "", "S");
            ds.Tables["DET"].Rows.Add("62", "1", "SIPA_METAS_ACCION", "NO_ACTIVIDADES", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("63", "1", "SIPA_METAS_ACCION", "RESPONSABLE", "VARCHAR", "1", "", "S");
            ds.Tables["DET"].Rows.Add("64", "1", "SIPA_METAS_ACCION", "ENE", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("65", "1", "SIPA_METAS_ACCION", "FEB", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("66", "1", "SIPA_METAS_ACCION", "MAR", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("67", "1", "SIPA_METAS_ACCION", "ABR", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("68", "1", "SIPA_METAS_ACCION", "MAY", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("69", "1", "SIPA_METAS_ACCION", "JUN", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("70", "1", "SIPA_METAS_ACCION", "JUL", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("71", "1", "SIPA_METAS_ACCION", "AGO", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("72", "1", "SIPA_METAS_ACCION", "SEP", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("73", "1", "SIPA_METAS_ACCION", "OCT", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("74", "1", "SIPA_METAS_ACCION", "NOV", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("75", "1", "SIPA_METAS_ACCION", "DIC", "BIT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("76", "1", "SIPA_METAS_ACCION", "ANIO", "INT", "1", "", "S");
            ds.Tables["DET"].Rows.Add("77", "1", "SIPA_METAS_ACCION", "USUARIO", "VARCHAR", "1", "", "S");
            */
            
            //dr = ds.Tables["DET"].NewRow().ItemArray = new Item;
            //dr.ItemArray


            return ds;
        }
             
            

    }
}
