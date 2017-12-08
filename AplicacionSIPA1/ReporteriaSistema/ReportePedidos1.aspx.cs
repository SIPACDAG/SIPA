using CapaLN;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class ReportePedidos1 : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        public string thisConnectionString = ConfigurationManager.ConnectionStrings[ "dbcdagsipaConnectionString1"].ConnectionString;

        /*I used the following statement to show if you have multiple 
          input parameters, declare the parameter with the number 
          of parameters in your application, ex. New SqlParameter[4]; */

        public MySqlParameter[] SearchValue = new MySqlParameter[1];
        public MySqlParameter[] SearchValue2 = new MySqlParameter[2];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //string script = string.Format("document.getElementById('{0}_Toolbar').style.display = 'none';", ReportViewer1.ClientID);
                    //ClientScript.RegisterStartupScript(this.GetType(), "_Toolbar", script, true);
                    pEstrategicoLN = new PlanEstrategicoLN();
                    pOperativoLN = new PlanOperativoLN();
                    pAccionLN = new PlanAccionLN();
                    pAnualLN = new PlanAnualLN();
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
                    int idPoa = 0;
                    int.TryParse(lblIdPoa.Text, out idPoa);
                    obtenerPresupuesto(idPoa, 0);
                    pAccionLN = new PlanAccionLN();
                    pAccionLN.DdlAcciones(ddlAcciones, 0, 0, "", 3);
                    ddlAcciones.Items[0].Text = "<< TODAS >>";
                    MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
                    System.Data.DataSet thisDataSet = new System.Data.DataSet();
                   
                    /* Put the stored procedure result into a dataset */
                    thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, busqueda(3));

                    ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    if (thisDataSet.Tables[0].Rows.Count == 0)
                    {

                    }

                    ReportViewer1.LocalReport.Refresh();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void btnBusquedaAccion_Click(object sender, EventArgs e)
        {
           
            
        }

        public string busqueda(int opcion)
        {
            string valor = "";
            if (opcion==1)
            {
                valor = "SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad," +
               "id_accion, id_tipo_documento, id_estado_pedido, Solicitante FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, " +
               "a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido " +
               "INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 1) " +
               "UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido," +
               " c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a " +
               " INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado " +
               "= a.id_solicitante WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real" +
               ", d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion " +
               " INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = " +
               "c.id_tipo_viatico WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida " +
               "AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' " +
               "AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON " +
               "a.id_pedido = c.id_viatico INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico WHERE (a.id_tipo_documento = 4))" +
               " t WHERE (1 > 0) AND (id_estado_pedido IN (8, 10, 12)) and id_unidad = @Unidad   ORDER BY id_unidad";
            }
            if (opcion == 2)
            {
                valor = "SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad," +
               "id_accion, id_tipo_documento, id_estado_pedido, Solicitante FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, " +
               "a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido " +
               "INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 1) " +
               "UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido," +
               " c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a " +
               " INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado " +
               "= a.id_solicitante WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real" +
               ", d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion " +
               " INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = " +
               "c.id_tipo_viatico WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida " +
               "AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' " +
               "AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON " +
               "a.id_pedido = c.id_viatico INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico WHERE (a.id_tipo_documento = 4))" +
               " t WHERE (1 > 0) AND (id_estado_pedido IN (8, 10, 12)) and id_unidad = @Unidad and id_accion =@accion  ORDER BY id_unidad";
            }
            if (opcion == 3)
            {
                valor = "SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad," +
               "id_accion, id_tipo_documento, id_estado_pedido, Solicitante FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, " +
               "a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido " +
               "INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 1) " +
               "UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido," +
               " c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a " +
               " INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado " +
               "= a.id_solicitante WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real" +
               ", d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion " +
               " INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = " +
               "c.id_tipo_viatico WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida " +
               "AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' " +
               "AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON " +
               "a.id_pedido = c.id_viatico INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico WHERE (a.id_tipo_documento = 4))" +
               " t WHERE (1 > 0) AND (id_estado_pedido IN (8, 10, 12))   ORDER BY id_unidad";
            }

            return valor;
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
                lblIdPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text =  "Error: " + ex.Message;
            }
            return poaValido;
        }



        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlUnidades.SelectedValue), 2017);
            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            obtenerPresupuesto(idPoa, 0);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            SearchValue[0] = new MySqlParameter("@Unidad", ddlUnidades.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, busqueda(1),
                SearchValue);

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected void obtenerPresupuesto(int idPoa, int idDependencia)
        {
            try
            {
                pAccionLN = new PlanAccionLN();
                DataSet dsPpto = pAccionLN.PptoPoa(idPoa, 0);
                int unidads = 0;
                int.TryParse(ddlUnidades.SelectedValue, out unidads);
                decimal pptoPoaUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_UNIDAD"].ToString());
                
                
                if (unidads>0)
                {
                    dsPpto = pAccionLN.CostoEstimado(unidads);
                    decimal pptoPoaDependencia = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["Gasto"].ToString());
                    decimal disponible = pptoPoaUnidad - pptoPoaDependencia;
                    lblTechoU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoPoaUnidad);
                    lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoPoaDependencia);
                    lblSaldoU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", disponible);
                }
              


            }
            catch (Exception ex)
            {
                throw new Exception("obtenerPresupuesto(). " + ex.Message);
            }
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            SearchValue2[0] = new MySqlParameter("@Unidad", ddlUnidades.SelectedValue);
            SearchValue2[1] = new MySqlParameter("@Accion", ddlAcciones.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, busqueda(2),SearchValue2);

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