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
    public class LogeoLN
    {

        LogeoAD mtsLogeoAD;


        public int BloquearAcceso(string usuario, string webForm)
        {
            mtsLogeoAD = new LogeoAD();
            return mtsLogeoAD.BloquearAcceso(usuario, webForm).Rows.Count;
        }


        public int Logearse(string usuario, string pass)
        {
            mtsLogeoAD = new LogeoAD();
            return mtsLogeoAD.Logearse(usuario, pass).Rows.Count;
        }


        public void LlenarMenu(Menu menu, string usuario)
        {//inicia el metodo 
            mtsLogeoAD = new LogeoAD();
            DataTable dtMenuItems = new DataTable();

            dtMenuItems = mtsLogeoAD.LlenarDoctosUsuarios(usuario);

            foreach (DataRow drMenuItem in dtMenuItems.Rows)
            {

                if (drMenuItem["IdMenu"].Equals(drMenuItem["PadreId"]))
                {

                    MenuItem mnuMenuItem = new MenuItem();

                    mnuMenuItem.Value = drMenuItem["IdMenu"].ToString();
                    mnuMenuItem.Text = drMenuItem["descripcion"].ToString();
                    mnuMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                    mnuMenuItem.NavigateUrl = drMenuItem["Url"].ToString();

                    menu.Items.Add(mnuMenuItem);
                    agregarMenuItem(mnuMenuItem, dtMenuItems);

                }

            }

        }


        public void agregarMenuItem(MenuItem mnuMenuItem, DataTable dtMenuItems)
        {

            foreach (DataRow drMenuItem in dtMenuItems.Rows)
            {
                if ((drMenuItem["PadreId"].ToString().Equals(mnuMenuItem.Value)) && !(drMenuItem["IdMenu"].Equals(drMenuItem["PadreId"])))
                {
                    MenuItem mnuNewMenuItem = new MenuItem();

                    mnuNewMenuItem.Value = drMenuItem["IdMenu"].ToString();
                    mnuNewMenuItem.Text = drMenuItem["descripcion"].ToString();
                    mnuNewMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                    mnuNewMenuItem.NavigateUrl = drMenuItem["Url"].ToString();
                    mnuMenuItem.ChildItems.Add(mnuNewMenuItem);
                    agregarMenuItem(mnuNewMenuItem, dtMenuItems);

                }
            }

        }



    }
}
