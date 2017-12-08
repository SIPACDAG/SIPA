using CapaLN;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class SaldosRenglonesDetalles2 : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["dbcdagsipaConnectionString1"].ConnectionString;
        private PedidosLN pInsumoLN;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pInsumoLN = new PedidosLN();
                pOperativoLN = new PlanOperativoLN();
                pEstrategicoLN = new PlanEstrategicoLN();
                pEstrategicoLN.DdlAniosPlan(ddlAnios, 2017, 2020);
                ddlAnios.Items.RemoveAt(0);
                pInsumoLN.ChkEstadosPedido(chkEstados);
                chkEstados.Items.RemoveAt(0);
                for (int i = 0; i < chkEstados.Items.Count; i++)
                    chkEstados.Items[i].Selected = true;
                string usuario = Session["Usuario"].ToString().ToLower();
                string criterio = "AND c.id_tipo IN(48) AND a.usuario = ''" + usuario + "''";
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, criterio, 12);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    pOperativoLN.DdlUnidades(ddlUnidades);
                else
                    pOperativoLN.DdlUnidades(ddlUnidades, usuario);
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            int idPoa = 0;
            int.TryParse(lblPoa.Text, out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());
            stringBuilder.Append(" AND id_unidad = " + ddlUnidades.SelectedValue);
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            string estadosSalida = "";
            for (int i = 0; i < chkEstados.Items.Count; i++)
                if (chkEstados.Items[i].Selected == true)
                    estadosSalida += chkEstados.Items[i].Value + ", ";

            if (estadosSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_estado_pedido IN(" + estadosSalida + "0)");
            if (!string.IsNullOrEmpty(txtFechaInicio.Text) && !string.IsNullOrEmpty(txtFechaFinal.Text))
            {
                stringBuilder.Append("and t.fecha_pedido between '" + txtFechaInicio.Text + "' and '" + txtFechaFinal.Text + "'");
            }
            stringBuilder.Append(" Order by t.no_solicitud");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);

                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {

            }
            return poaValido;
        }

        public string consulta()
        {
            string query = "";
            query = " SELECT t.*" +
                    "FROM(SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, " +
                                    "c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, da.no_renglon AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) " +
                                    "AS Solicitante, CONCAT(sep.id_empleado, ' - ', sep.nombres) AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras " +
                    "FROM      unionpedidocc a INNER JOIN " +
                                    "sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN " +
                                    "sipa_pedido_detalle c ON a.id_pedido = c.id_pedido LEFT OUTER JOIN " +
                                    "sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN " +
                                    "sipa_pac p ON p.id_pac = c.id_pac INNER JOIN " +
                                    "ccl_empleados se ON se.id_empleado = a.id_solicitante LEFT OUTER JOIN " +
                                    "ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN " +
                                    "ccl_empleados sec ON sec.id_empleado = a.id_tecnico INNER JOIN " +
                                    "sipa_detalles_accion da ON p.id_detalle = da.id_detalle " +
                      "WHERE(a.id_tipo_documento = 1) " +
                      "UNION ALL " +
                      "SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido, c.costo_estimado, " +
                                        "c.costo_real, d.no_renglon, 'N/A' AS no_pac, 'N/A' AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante, " +
                                        "CONCAT(sep.id_empleado, ' - ', sep.nombres) AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras " +
                      "FROM     unionpedidocc a INNER JOIN " +
                                        "sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN " +
                                        "sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale LEFT OUTER JOIN " +
                                        "sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN " +
                                        "ccl_empleados se ON se.id_empleado = a.id_solicitante LEFT OUTER JOIN " +
                                        "ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN " +
                                        "ccl_empleados sec ON sec.id_empleado = a.id_tecnico " +
                      "WHERE(a.id_tipo_documento = 2) " +
                      "UNION ALL " +
                      "SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida AS Estado, a.unidad_administrativa, " +
                                        "c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, " +
                                        "'N/A' AS no_pac, 'N/A' AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante, CONCAT(sep.id_empleado, ' - ', sep.nombres) " +
                                        "AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras " +
                      "FROM     unionpedidocc a INNER JOIN " +
                                        "sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN " +
                                        "sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT OUTER JOIN " +
                                        "sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN " +
                                        "ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN " +
                                        "sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico LEFT OUTER JOIN " +
                                        "ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN " +
                                        "ccl_empleados sec ON sec.id_empleado = a.id_tecnico " +
                      "WHERE(a.id_tipo_documento = 3) " +
                      "UNION ALL " +
                      " SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida AS Estado, a.unidad_administrativa," +
                                        "c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon," +
                                        "'N/A' AS no_pac, 'N/A' AS renglon_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante, CONCAT(sep.id_empleado, ' - ', sep.nombres) " +
                                        "AS AnalistaPpto, CONCAT(sec.id_empleado, ' - ', sec.nombres) AS TecnicoCompras " +
                      "FROM     unionpedidocc a INNER JOIN " +
                                        "sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN " +
                                        "sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT OUTER JOIN " +
                                        "sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN " +
                                        "ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN " +
                                        "sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico LEFT OUTER JOIN " +
                                        "ccl_empleados sep ON sep.id_empleado = a.id_direc_financiera LEFT OUTER JOIN " +
                                        "ccl_empleados sec ON sec.id_empleado = a.id_tecnico " +
                      "WHERE(a.id_tipo_documento = 4)) t " +
                "WHERE(id_estado_pedido > 0) ";
            return query;
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            int idPoa = 0;
            int.TryParse(lblPoa.Text, out idPoa);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());
            stringBuilder.Append(" AND id_unidad = " + ddlUnidades.SelectedValue);
            stringBuilder.Append(" AND id_accion = " + ddlAcciones.SelectedValue);
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            string estadosSalida = "";
            for (int i = 0; i < chkEstados.Items.Count; i++)
                if (chkEstados.Items[i].Selected == true)
                    estadosSalida += chkEstados.Items[i].Value + ", ";

            if (estadosSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_estado_pedido IN(" + estadosSalida + "0)");
            if (!string.IsNullOrEmpty(txtFechaInicio.Text) && !string.IsNullOrEmpty(txtFechaFinal.Text))
            {
                stringBuilder.Append("and t.fecha_pedido between '" + txtFechaInicio.Text + "' and '" + txtFechaFinal.Text + "'");
            }
            stringBuilder.Append(" Order by t.no_solicitud");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected void chkTiposSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());
            if (ddlUnidades.SelectedIndex > 0)
                stringBuilder.Append(" AND id_unidad = " + ddlUnidades.SelectedValue);
            if (ddlAcciones.SelectedIndex > 0)
                stringBuilder.Append(" AND id_accion = " + ddlAcciones.SelectedValue);
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            string estadosSalida = "";
            for (int i = 0; i < chkEstados.Items.Count; i++)
                if (chkEstados.Items[i].Selected == true)
                    estadosSalida += chkEstados.Items[i].Value + ", ";

            if (estadosSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_estado_pedido IN(" + estadosSalida + "0)");
            if (!string.IsNullOrEmpty(txtFechaInicio.Text) && !string.IsNullOrEmpty(txtFechaFinal.Text))
            {
                stringBuilder.Append("and t.fecha_pedido between '" + txtFechaInicio.Text + "' and '" + txtFechaFinal.Text + "'");
            }
            stringBuilder.Append(" Order by t.no_solicitud");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected void chkEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());
            if (ddlUnidades.SelectedIndex > 0)
                stringBuilder.Append(" AND id_unidad = " + ddlUnidades.SelectedValue);
            if (ddlAcciones.SelectedIndex > 0)
                stringBuilder.Append(" AND id_accion = " + ddlAcciones.SelectedValue);
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            string estadosSalida = "";
            for (int i = 0; i < chkEstados.Items.Count; i++)
                if (chkEstados.Items[i].Selected == true)
                    estadosSalida += chkEstados.Items[i].Value + ", ";

            if (estadosSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_estado_pedido IN(" + estadosSalida + "0)");
            if (!string.IsNullOrEmpty(txtFechaInicio.Text) && !string.IsNullOrEmpty(txtFechaFinal.Text))
            {
                stringBuilder.Append("and t.fecha_pedido between '" + txtFechaInicio.Text + "' and '" + txtFechaFinal.Text + "'");
            }
            stringBuilder.Append(" Order by t.no_solicitud");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected void txtFechaFinal_TextChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());
            if (ddlUnidades.SelectedIndex > 0)
                stringBuilder.Append(" AND id_unidad = " + ddlUnidades.SelectedValue);
            if (ddlAcciones.SelectedIndex > 0)
                stringBuilder.Append(" AND id_accion = " + ddlAcciones.SelectedValue);
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            string estadosSalida = "";
            for (int i = 0; i < chkEstados.Items.Count; i++)
                if (chkEstados.Items[i].Selected == true)
                    estadosSalida += chkEstados.Items[i].Value + ", ";

            if (estadosSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_estado_pedido IN(" + estadosSalida + "0)");
            if (!string.IsNullOrEmpty(txtFechaInicio.Text))
            {
                stringBuilder.Append("and t.fecha_pedido between '" + txtFechaInicio.Text + "' and '" + txtFechaFinal.Text + "'");
            }
            stringBuilder.Append(" Order by t.no_solicitud");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }
    }
}