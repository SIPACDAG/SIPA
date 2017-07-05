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
    public class PoaLN
    {
        PoaAD poaAD;
        public DataTable datosPoa(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.datosPoa(poaEN); 
        }
        public DataTable rptPoa(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.rptPoa(poaEN); 
        }
        public void gridPoas(GridView grid, PoaEN poaEN,int op)
        {
            poaAD = new PoaAD();
            grid.DataSource = poaAD.datosPoas(poaEN,op);
            grid.DataBind();
        }
        public DataTable datosAccion(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.datosAccion(poaEN);
        }
        public DataTable datosMontoReglon(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.datosMontoReglon(poaEN);
        
        }
        public void gridAccionesPoa(GridView grid, PoaEN poaEN)
        {
            poaAD = new PoaAD();
            grid.DataSource = poaAD.datosAccionesPoa(poaEN);
            grid.DataBind();
        }
        public void gridDetalleAccion(GridView grid, PoaEN poaEN)
        {
            poaAD = new PoaAD();
            grid.DataSource = poaAD.datosDetalleAccion(poaEN);
            grid.DataBind();
        }
        public void gridSaldoAccion(GridView grid, PoaEN poaEN)
        {
            poaAD = new PoaAD();
            grid.DataSource = poaAD.gridSaldoAccion(poaEN);
            grid.DataBind();
        }
        
        public void gridDatosBeneficiariosAccion(GridView grid, PoaEN poaEN)
        {
            poaAD = new PoaAD();
            grid.DataSource = poaAD.datosBeneficiariosAccion(poaEN);
            grid.DataBind();

        }
        public int valReglon(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.valReglon(poaEN);
        }
        public int valBeneficiario(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.valBeneficiario(poaEN);
        }
        public void dropBeneficiarios(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Beneficiario >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.dropBeneficiario();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropReglones(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Reglon >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.reglones();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropFinanciamiento(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("< Eliga >");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.financiamiento();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropProducto(DropDownList drop, PoaEN poaEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Objetivo Operativo >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.dropProducto(poaEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropAccionesPoa(DropDownList drop, PoaEN poaEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Accion >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.dropAccionPoa(poaEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropUsuarioUnidad(DropDownList drop,PoaEN poaEN)
        {
            poaAD = new PoaAD();
            drop.DataSource = poaAD.dropUnidadesUsuario(poaEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropUnidadesAdmin(DropDownList drop, PoaEN poaEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Seleccione Unidad >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.datosPoas(poaEN,1);
            drop.DataTextField = "Unidad";
            drop.DataValueField = "idUnidad";
            drop.DataBind();
            
        }
        public void dropPoas(DropDownList drop, PoaEN poaEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Seleccione Unidad >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.datosPoas(poaEN, 1);
            drop.DataTextField = "Unidad";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        public void dropDependencias(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Seleccione Dependencia a Trasladar >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            drop.DataSource = poaAD.dropDependencias();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
            
        }
        public void dropDependencia(DropDownList drop, PoaEN poaEN)
        {
            poaAD = new PoaAD();
            drop.DataSource = poaAD.dropDependencia(poaEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public double saldoPresUnidad(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.saldoPoa(poaEN);
        }
        public double saldoPoaDep(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.saldoPoaDep(poaEN);
        }
        public double saldoDetalleAccion(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.saldoDetalleAccion(poaEN);
        }
        public int InsertarAccion(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.InsertarAccion(poaEN);
        }
        public int ModificarAccion(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.ModificarAccion(poaEN);
        }
        public int MaxidAccion()
        { 
            poaAD = new PoaAD();
            return poaAD.MaxidAccion();
        }
        public int InsertarBeneficiario(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.InsertarBeneficiario(poaEN);
        }
        public int InsertarReglon(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.InsertarReglon(poaEN);
        }
        public int EliminarBeneficiario(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.EliminarBeneficiario(poaEN);
        }
        public int EliminarAccion(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.EliminarAccion(poaEN);
        }
        public int EliminarReglon(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.EliminarReglon(poaEN);
        }
        public int ModificarCostoReglon(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.ModificarCostoReglon(poaEN);
        }
        public int ModificarEstadoPoa(PoaEN poaEN)
        {
            poaAD = new PoaAD();
            return poaAD.ModificarEstadoPoa(poaEN);
        }
        public int TransferirMonto(PoaEN poaEN, int idDepTras)
        {
            poaAD = new PoaAD();
            return poaAD.TransferirMonto(poaEN, idDepTras);
        }

    }
}
