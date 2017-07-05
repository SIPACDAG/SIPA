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
    public class PacLN
    {
        PacAD pacAD;


        public DataTable datosPoa(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.datosPoa(pacEN);
        }

        public void dropAccionesPoa(DropDownList drop, PacEN pacEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Accion >>");
            drop.Items[0].Value = "0";
            pacAD = new PacAD();
            drop.DataSource = pacAD.dropAccionPoa(pacEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropNoPac(DropDownList drop, PacEN pacEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Pac >>");
            drop.Items[0].Value = "0";
            pacAD = new PacAD();
            drop.DataSource = pacAD.dropNoPac(pacEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropUsuarioUnidad(DropDownList drop, PacEN pacEN)
        {
            pacAD = new PacAD();
            drop.DataSource = pacAD.dropUnidadesUsuario(pacEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void gridDetalleAccion(GridView grid, PacEN pacEN)
        {
            pacAD = new PacAD();
            grid.DataSource =pacAD.datosDetalleAccion(pacEN);
            grid.DataBind();

        }
        public void gridIdDetalleAccion(GridView grid, PacEN pacEN)
        {
            pacAD = new PacAD();
            grid.DataSource = pacAD.datosIdDetalleAccion(pacEN);
            grid.DataBind();

        }
        public void gridPacListado(GridView grid, PacEN pacEN)
        {
            pacAD = new PacAD();
            grid.DataSource = pacAD.PacListado(pacEN);
            grid.DataBind();

        }
        public double saldoPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.saldoPac(pacEN);
        }
        public double montoActualPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.montoActualPac(pacEN);
        }
        public double saldoPacPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.saldoPacPac(pacEN);
        }
        public double codificadoPacPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.codificadoPacPac(pacEN);
        }
       public void dropModalidad(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Modalidad  >>");
            drop.Items[0].Value = "0";
            pacAD = new PacAD();
            drop.DataSource = pacAD.dropModalidad();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropExcepcion(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Excepcion >>");
            drop.Items[0].Value = "0";
            pacAD = new PacAD();
            drop.DataSource = pacAD.dropExcepcion();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public int InsertarPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.InsertarPac(pacEN);

        }
        public int maxidPac()
        {
            pacAD = new PacAD();
            return pacAD.maxidPac();
        }
        public int InsertarPacDetalle(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.InsertarPacDetalle(pacEN);

        }
        public int EliminarPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.EliminarPac(pacEN);

        }
        public DataTable datosPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.datosPac(pacEN);
        }
        public DataTable datosPacDetalle(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.datosPacDetalle(pacEN);
        }

        public int ModificarPac(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.ModificarPac(pacEN);
        }
        public int ModificarPacDetalle(PacEN pacEN)
        {
            pacAD = new PacAD();
            return pacAD.ModificarPacDetalle(pacEN);
        }
    }
}
