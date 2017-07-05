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
    public class AtletasLN
    {
        AtletasAD atletasAD;
        
        public DataTable consultas(string fi, string ff,int per ,int tipo)
        {
            atletasAD = new AtletasAD();
            return atletasAD.consultas(fi, ff,per ,tipo);
        }
		 public DataTable consultasPer(string fi, string ff, int op, string usr)
        {
            atletasAD = new AtletasAD();
            return atletasAD.consultasPer(fi, ff,op, usr);
        }

        public void gridAtletas(GridView grid,AtletasEN atletasEN, int tipo)
        {
            atletasAD = new AtletasAD();
            grid.DataSource = atletasAD.gridAtletas(atletasEN, tipo);
            grid.DataBind();
        }
        public void gridAsignarAtencion(GridView grid, AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            grid.DataSource = atletasAD.gridAsignarAtencion(atletasEN);
            grid.DataBind();
        }
        public void gridAsignarPersonal(GridView grid, AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            grid.DataSource = atletasAD.gridAsignarPersonal(atletasEN);
            grid.DataBind();
        }
        public void gridVerPersonalAsignado(GridView grid, AtletasEN atletasEN, int opcion)
        {
            atletasAD = new AtletasAD();
            grid.DataSource = atletasAD.gridVerPersonalAsignado(atletasEN, opcion);
            grid.DataBind();
        }
        public string verPersonalAsignado(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.verPersonalAsignado(atletasEN);
        }
        public DataTable gridVerPersonalAsignado(AtletasEN atletasEN, int opcion)
        {
            atletasAD = new AtletasAD();
            return atletasAD.gridVerPersonalAsignado(atletasEN, opcion);
        }

        public void gridAsignarTipoAtencion(DetailsView dv, AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            dv.DataSource = atletasAD.gridAsignarTipoAtencion(atletasEN);
            dv.DataBind();
        }

        public void dropUnidades(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Unidad Medica >>");
            drop.Items[0].Value = "0";
            atletasAD = new AtletasAD();
            drop.DataSource = atletasAD.dropUnidades();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropTipoAtleta(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Tipo Atleta >>");
            drop.Items[0].Value = "0";
            atletasAD = new AtletasAD();
            drop.DataSource = atletasAD.dropTipoAtleta();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropPersonal(DropDownList drop, AtletasEN atletasEN)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Personal >>");
            drop.Items[0].Value = "0";
            atletasAD = new AtletasAD();
            drop.DataSource = atletasAD.dropPersonal(atletasEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropTipoAtencion(DropDownList drop, AtletasEN atletasEN, int idCategoria)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Opcion >>");
            drop.Items[0].Value = "0";
            drop.Items.Add("-- Agregar Nuevo --");
            drop.Items[1].Value = "-1";
            atletasAD = new AtletasAD();
            drop.DataSource = atletasAD.dropTipoAtencion(atletasEN, idCategoria);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void dropTratamiento(DropDownList drop, AtletasEN atletasEN)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Tratamiento >>");
            drop.Items[0].Value = "0";
            drop.Items.Add("--Agregar Nueva Tratamiento--");
            drop.Items[1].Value = "-1";
            atletasAD = new AtletasAD();
            drop.DataSource = atletasAD.dropTratamiento(atletasEN);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropEtnia(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Etnia >>");
            drop.Items[0].Value = "0";
            atletasAD = new AtletasAD();
            drop.DataSource = atletasAD.dropEtnia();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropFederacion(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Federacion >>");
            drop.Items[0].Value = "0";
            atletasAD = new AtletasAD();
            drop.DataSource = atletasAD.dropFederacion();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public DataTable DatosAtleta(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.clsDatosAtleta(atletasEN);
        }
        public int valAtletaUnidad(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.valAtletaUnidad(atletasEN);
        }
        public int Insertar_AsignarAtencion(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.Insertar_AsignarAtencion(atletasEN);
        }
        public int Insertar_AsignarPersonal(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.Insertar_AsignarPersonal(atletasEN);
        }
        public int Insertar_AsignarAtencionDetalle(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.Insertar_AsignarAtencionDetalle(atletasEN);
        }
        public int Insertar_Atleta(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.Insertar_Atleta(atletasEN);
        }
        public int Modificar_Atleta(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.Modificar_Atleta(atletasEN);
        }
        public int Insertar_AtencionTrar(AtletasEN atletasEN, int idcategoria)
        {
            atletasAD = new AtletasAD();
            return atletasAD.Insertar_AtencionTrar(atletasEN, idcategoria);
        }
        public int Eliminar_Atleta(AtletasEN atletasEN)
        {
            atletasAD = new AtletasAD();
            return atletasAD.Eliminar_Atleta(atletasEN);
        }
    }
}
