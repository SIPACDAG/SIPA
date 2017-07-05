using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaLN
{
    
    public class NominaLN
    {
        NominaAD nominaAD;
        public NominaLN()
     {
         nominaAD = new NominaAD();
     }
        public void dropUnidad(DropDownList drop)
        {
            PresupuestoAD presupuestoAD;
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Unidad >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            presupuestoAD = new PresupuestoAD();
            drop.DataSource = presupuestoAD.dropUnidad();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropReglones(DropDownList drop)
        {
            PoaAD poaAD;
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Reglon >>");
            drop.Items[0].Value = "0";
            poaAD = new PoaAD();
            //drop.DataSource = poaAD.reglones();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void dropTipoNomina(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Tipo >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            drop.DataSource = nominaAD.datosTipoNomina();
            drop.DataTextField = "Texto";
            drop.DataValueField = "id";
            drop.DataBind();

        }

       


        

        public DataTable rptNomina(int opcion, int anio, int IDNomina)
        {
            return nominaAD.rptNomina(opcion,anio,IDNomina);
        }
        public DataTable datosEmpleadoPlanilla(NominaEN nomina)
        {
            return nominaAD.datosEmpleadoPlanilla(nomina);
        }

        

        public int idNomina(int anio)
        {
            return nominaAD.idNomina(anio);
        }

        public void DatosNominaBase(GridView grid, int anio)
        {
            grid.DataSource= nominaAD.DatosNominaBase(anio);
            grid.DataBind();
        }
         


        public string IngresarNomina(NominaEN nomina)
        {
            string mensaje;
            if (nominaAD.IngresarNomina(nomina) == 0)
            {
                mensaje = "Nomina Ingresada Con Exito";
            }
            else
            {
                mensaje = "";
            }
            return mensaje;
        }

        public string IngresarNominaDetalle(NominaEN nomina)
        {
            string mensaje;
            if (nominaAD.IngresarNominaDetalle(nomina) == 0)
            {
                mensaje = "Nomina Ingresada Con Exito";
            }
            else
            {
                mensaje = "";
            }
            return mensaje;
        }

        public string ModificarNomina(NominaEN nomina)
        {
            string mensaje;
            if (nominaAD.ModificarNomina(nomina) >= 1)
            {
                mensaje = "Nomina Modificada Con Exito";
            }
            else
            {
                mensaje = "Error Al Modificar, El Registro NO fue Modificado";
            }
            return mensaje;
        }

        public string EliminarNomina(NominaEN nomina)
        {
            string mensaje;
            if (nominaAD.EliminarNomina(nomina) >= 1)
            {
                mensaje = "Nomina Eliminada Con Exito";
            }
            else
            {
                mensaje = "Error Al Eliminar, El Registro NO fue Eliminado";
            }
            return mensaje;
        }

        public DataTable crearNomina(DataTable datosEmpleado, int idTipo)
        {
            double liquido=0;
            NominaEN nomina = new NominaEN();
            nomina.IDTIpo = idTipo;
            DataTable tblNomina = new DataTable();
            tblNomina.Columns.Add("IDNomina", Type.GetType("System.String")); //0
            tblNomina.Columns.Add("IDEmpleado", Type.GetType("System.String")); //1
            tblNomina.Columns.Add("Nombre", Type.GetType("System.String")); // 2
            tblNomina.Columns.Add("Anio", Type.GetType("System.String")); // 3
            tblNomina.Columns.Add("Departamento", Type.GetType("System.String")); //4
            tblNomina.Columns.Add("fIngreso", Type.GetType("System.String"));//5
            tblNomina.Columns.Add("SueldoBase", Type.GetType("System.String"));//6
            tblNomina.Columns.Add("Bonificacion", Type.GetType("System.String"));//7
            tblNomina.Columns.Add("OtrasDeducciones", Type.GetType("System.String"));//8
            tblNomina.Columns.Add("OtrasBonificaciones", Type.GetType("System.String"));//9
            tblNomina.Columns.Add("Dias", Type.GetType("System.String")); // 10
            tblNomina.Columns.Add("IGSS", Type.GetType("System.String")); // 11
            tblNomina.Columns.Add("Prestaciones", Type.GetType("System.String")); //12
            tblNomina.Columns.Add("Fianza", Type.GetType("System.String")); //13
            tblNomina.Columns.Add("ISR", Type.GetType("System.String"));//14
            tblNomina.Columns.Add("Bantrab", Type.GetType("System.String"));//15
            tblNomina.Columns.Add("BanSeguro", Type.GetType("System.String"));//16
            tblNomina.Columns.Add("Renglon", Type.GetType("System.String"));//17
            tblNomina.Columns.Add("Liquido", Type.GetType("System.String"));//18
            
            
                
            if (nomina.IDTIpo == 3 || nomina.IDTIpo == 6 || nomina.IDTIpo == 15 || nomina.IDTIpo == 16 || nomina.IDTIpo == 17)
            { // 3 = Horas Extra , 6 = Destajo Variable , 15=Bono 14 por proyecto,  16 =Bono Vacacional por proyecto,  17 = Aguinaldo 50% por proyecto
                foreach (DataRow fila in datosEmpleado.Rows)
                {
                    nomina.IDNomina = Convert.ToInt16(fila[0]);
                    nomina.IDEmpleado = Convert.ToInt32(fila[1]);
                    nomina.Nombre = Convert.ToString(fila[2]);
                    nomina.Anio = Convert.ToInt32(fila[3]);
                    nomina.Departamento = Convert.ToInt32(fila[4]);
                    nomina.fIngreso = Convert.ToString(fila[5]);
                    nomina.SueldoBase = Math.Round(Convert.ToDouble(fila[6]), 2, MidpointRounding.ToEven);
                    nomina.Bonificacion = Math.Round(Convert.ToDouble(fila[7]), 2, MidpointRounding.ToEven);
                    nomina.OtrasDeducciones = Math.Round(Convert.ToDouble(fila[8]), 2, MidpointRounding.ToEven);
                    nomina.OtrasBonificaciones = Math.Round(Convert.ToDouble(fila[9]), 2, MidpointRounding.ToEven);
                    nomina.BanSeguro = Math.Round(Convert.ToDouble(fila[10]), 2, MidpointRounding.ToEven);
                    nomina.Renglon = Convert.ToString(fila[11]);
                    nomina.Dias = DiasTipoMes(nomina);

                    DataTable tblDescuentos;
                    tblDescuentos = nominaAD.buscarDescuentoNomina(nomina);

                    switch (nomina.IDTIpo)
                    {
                        case 6: // Destajo Variable
                            if (Convert.ToString(tblDescuentos.Rows[0][1]) == "1")
                            { nomina.IGSS = Math.Round(nomina.SueldoBase * 0.0483, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.IGSS = 0; }
                            if (Convert.ToString(tblDescuentos.Rows[0][2]) == "1")
                            { nomina.Prestaciones = Math.Round(nomina.SueldoBase * 0.07, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.Prestaciones = 0; }
                            if (Convert.ToString(tblDescuentos.Rows[0][3]) == "1")
                            { nomina.Fianza = Math.Round(nomina.SueldoBase * 0.01344, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.Fianza = 0; }
                            if (Convert.ToInt16(tblDescuentos.Rows[0][4]) == 0)
                            { nomina.Bantrab = 0; }
                            else
                            { nomina.Bantrab = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][4]), 2, MidpointRounding.ToEven); }

                            if (nomina.IDTIpo == 1 || nomina.IDTIpo == 2 || nomina.IDTIpo == 4 || nomina.IDTIpo == 5 || nomina.IDTIpo == 6)
                            {
                                nomina.ISR = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][5]), 2, MidpointRounding.ToEven);
                            }
                            else
                            {
                                nomina.ISR = 0;
                            }

                            break;
                        case 15: //Bono 14 por proyecto
                        case 17: //Aguinaldo 50% por proyecto
                        case 3: //Horas Extra
                            DateTime FechaCalculo = new DateTime(nomina.Anio, 11, 30);
                            DateTime fingreso = Convert.ToDateTime(nomina.fIngreso);
                            TimeSpan diferencia = FechaCalculo - fingreso;
                            nomina.Dias = diferencia.Days + 1;
                            if (nomina.Dias >= 365)
                            { nomina.Dias = 365; }
                            else
                            { nomina.Dias = diferencia.Days + 1; }


                            nomina.SueldoBase = Math.Round(EmpleadoBono(nomina, 1), 2, MidpointRounding.ToEven);
                            nomina.Bonificacion = 0;
                            nomina.IGSS = 0;
                            nomina.Prestaciones = 0;
                            nomina.Fianza = 0;
                            nomina.Bantrab = 0;
                            break;
                        case 16://Bono Vacacional Por Proyecto
                            DateTime FechaCalculo2 = new DateTime(nomina.Anio, 2, 28);
                            DateTime fingreso2 = Convert.ToDateTime(nomina.fIngreso);
                            TimeSpan diferencia2 = FechaCalculo2 - fingreso2;
                            nomina.Dias = diferencia2.Days + 1;
                            if (nomina.Dias >= 365)
                            { nomina.Dias = 365; }
                            else
                            { nomina.Dias = diferencia2.Days + 1; }


                            nomina.SueldoBase = Math.Round(EmpleadoBono(nomina, 2), 2, MidpointRounding.ToEven);
                            nomina.Bonificacion = 0;
                            nomina.IGSS = 0;
                            nomina.Prestaciones = 0;
                            nomina.Fianza = 0;
                            nomina.Bantrab = 0;

                            break;

                    }



                    liquido = (nomina.SueldoBase + nomina.Bonificacion + nomina.OtrasBonificaciones + nomina.Prestaciones) - (nomina.OtrasDeducciones + nomina.IGSS + nomina.Fianza + nomina.ISR + nomina.Bantrab + nomina.BanSeguro);

                    tblNomina.Rows.Add(nomina.IDNomina, nomina.IDEmpleado, nomina.Nombre, nomina.Anio, nomina.Departamento, nomina.fIngreso, nomina.SueldoBase, nomina.Bonificacion,
                        nomina.OtrasDeducciones, nomina.OtrasBonificaciones, nomina.Dias, nomina.IGSS, nomina.Prestaciones, nomina.Fianza, nomina.ISR,
                        nomina.Bantrab, nomina.BanSeguro,nomina.Renglon,liquido);


                }

            }

            else
            { // 1 Mensual (30),2 Mensual (31), 4 Mensual (28), 5 Mensual (29), 7 Bono 14, 8 Bono Vacacional,9 Aguinaldo 50%,10 Aguinaldo 100%,11 Aguinaldo Destajo 50 %
                //  12 Aguinaldo Destajo 100%,13 Mensual (31) Boleto de Ornato, 14 Destajo Variable Boleto de Ornato
                foreach (DataRow fila in datosEmpleado.Rows)
                {
                    nomina.IDNomina = Convert.ToInt16(fila[0]);
                    nomina.IDEmpleado = Convert.ToInt32(fila[1]);
                    nomina.Nombre = Convert.ToString(fila[2]);
                    nomina.Anio = Convert.ToInt32(fila[3]);
                    nomina.Departamento = Convert.ToInt32(fila[4]);
                    nomina.fIngreso = Convert.ToString(fila[5]);
                    nomina.SueldoBase = Math.Round(Convert.ToDouble(fila[6]), 2, MidpointRounding.ToEven);
                    nomina.Bonificacion = Math.Round(Convert.ToDouble(fila[7]), 2, MidpointRounding.ToEven);
                    nomina.OtrasDeducciones = Math.Round(Convert.ToDouble(fila[8]), 2, MidpointRounding.ToEven);
                    nomina.OtrasBonificaciones = Math.Round(Convert.ToDouble(fila[9]), 2, MidpointRounding.ToEven);
                    nomina.BanSeguro = Math.Round(Convert.ToDouble(fila[10]), 2, MidpointRounding.ToEven);
                    nomina.Renglon = Convert.ToString(fila[11]);
                    nomina.Dias = DiasTipoMes(nomina);

                    DataTable tblDescuentos;
                    tblDescuentos = nominaAD.buscarDescuentoNomina(nomina);

                    switch (nomina.IDTIpo)
                    {
                        case 7: // 7 Bono 14
                            DateTime FechaCalculo = new DateTime(nomina.Anio, 6, 30);
                            DateTime fingreso = Convert.ToDateTime(nomina.fIngreso);
                            TimeSpan diferencia = FechaCalculo - fingreso;
                            nomina.Dias = diferencia.Days + 1;
                            if (nomina.Dias >= 365)
                            { nomina.Dias = 365; }
                            else
                            { nomina.Dias = diferencia.Days + 1; }


                            nomina.SueldoBase = Math.Round(nomina.SueldoBase/365*nomina.Dias, 2, MidpointRounding.ToEven);
                            nomina.Bonificacion = 0;
                            nomina.IGSS = 0;
                            nomina.Prestaciones = 0;
                            nomina.Fianza = 0;
                            nomina.Bantrab = 0;
                        break;
                        case 8: // 8 Bono Vacacional
                             DateTime FechaCalculo2 = new DateTime(nomina.Anio, 2, 28);
                            DateTime fingreso2 = Convert.ToDateTime(nomina.fIngreso);
                            TimeSpan diferencia2 = FechaCalculo2 - fingreso2;
                            nomina.Dias = diferencia2.Days + 1;
                            if (nomina.Dias >= 365)
                            { nomina.Dias = 365; }
                            else
                            { nomina.Dias = diferencia2.Days + 1; }


                            nomina.SueldoBase = Math.Round(EmpleadoBono(nomina, 2), MidpointRounding.ToEven);
                            nomina.Bonificacion = 0;
                            nomina.IGSS = 0;
                            nomina.Prestaciones = 0;
                            nomina.Fianza = 0;
                            nomina.Bantrab = 0;
                        break;
                        case 9:// 9 Aguinaldo 50%
                            nomina.SueldoBase = Math.Round(EmpleadoAguinaldo(nomina)/2, MidpointRounding.ToEven);
                            nomina.Bonificacion = 0;
                            nomina.IGSS = 0;
                            nomina.Prestaciones = 0;
                            nomina.Fianza = 0;
                            nomina.Bantrab = 0;

                        break;
                        case 10: // 10 Aguinaldo 100%
                        nomina.SueldoBase = Math.Round(EmpleadoAguinaldo(nomina), MidpointRounding.ToEven);
                        nomina.Bonificacion = 0;
                        nomina.IGSS = 0;
                        nomina.Prestaciones = 0;
                        nomina.Fianza = 0;
                        nomina.Bantrab = 0;

                        break;
                        case 11: // 11 Aguinaldo Destajo 50 %
                        nomina.SueldoBase = Math.Round(EmpleadoAguinaldo(nomina) / 2, MidpointRounding.ToEven);
                        nomina.Bonificacion = 0;
                        nomina.IGSS = 0;
                        nomina.Prestaciones = 0;
                        nomina.Fianza = 0;
                        nomina.Bantrab = 0;

                        break;
                        case 12:// 12 11 Aguinaldo Destajo 100 %
                        nomina.SueldoBase = Math.Round(EmpleadoAguinaldo(nomina), MidpointRounding.ToEven);
                        nomina.Bonificacion = 0;
                        nomina.IGSS = 0;
                        nomina.Prestaciones = 0;
                        nomina.Fianza = 0;
                        nomina.Bantrab = 0;

                        break;
                        case 13: // 13 Mensual (31) Boleto de Ornato
                             if (Convert.ToString(tblDescuentos.Rows[0][1]) == "1")
                            { nomina.IGSS = Math.Round(nomina.SueldoBase * 0.0483, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.IGSS = 0; }
                            if (Convert.ToString(tblDescuentos.Rows[0][2]) == "1")
                            { nomina.Prestaciones = Math.Round(nomina.SueldoBase * 0.07, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.Prestaciones = 0; }
                            if (Convert.ToString(tblDescuentos.Rows[0][3]) == "1")
                            { nomina.Fianza = Math.Round(nomina.SueldoBase * 0.01344, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.Fianza = 0; }
                            if (Convert.ToInt16(tblDescuentos.Rows[0][4]) == 0)
                            { nomina.Bantrab = 0; }
                            else
                            { nomina.Bantrab = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][4]), 2, MidpointRounding.ToEven); }

                            
                                nomina.ISR = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][5]), 2, MidpointRounding.ToEven);
                                nomina.OtrasDeducciones = PagoBoletoOrnato( Convert.ToString(tblDescuentos.Rows[0][6]), nomina);

                        break;
                        case 14: // 14 Destajo Variable Boleto de Ornato
                        if (Convert.ToString(tblDescuentos.Rows[0][1]) == "1")
                        { nomina.IGSS = Math.Round(nomina.SueldoBase * 0.0483, 2, MidpointRounding.ToEven); }
                        else
                        { nomina.IGSS = 0; }
                        if (Convert.ToString(tblDescuentos.Rows[0][2]) == "1")
                        { nomina.Prestaciones = Math.Round(nomina.SueldoBase * 0.07, 2, MidpointRounding.ToEven); }
                        else
                        { nomina.Prestaciones = 0; }
                        if (Convert.ToString(tblDescuentos.Rows[0][3]) == "1")
                        { nomina.Fianza = Math.Round(nomina.SueldoBase * 0.01344, 2, MidpointRounding.ToEven); }
                        else
                        { nomina.Fianza = 0; }
                        if (Convert.ToInt16(tblDescuentos.Rows[0][4]) == 0)
                        { nomina.Bantrab = 0; }
                        else
                        { nomina.Bantrab = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][4]), 2, MidpointRounding.ToEven); }


                        nomina.ISR = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][5]), 2, MidpointRounding.ToEven);
                        nomina.OtrasDeducciones = PagoBoletoOrnato(Convert.ToString(tblDescuentos.Rows[0][6]), nomina);

                        break;
                        default://  1 Mensual (30),2 Mensual (31), 4 Mensual (28), 5 Mensual (29)
                            if (Convert.ToString(tblDescuentos.Rows[0][1]) == "1")
                            { nomina.IGSS = Math.Round(nomina.SueldoBase * 0.0483, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.IGSS = 0; }
                            if (Convert.ToString(tblDescuentos.Rows[0][2]) == "1")
                            { nomina.Prestaciones = Math.Round(nomina.SueldoBase * 0.07, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.Prestaciones = 0; }
                            if (Convert.ToString(tblDescuentos.Rows[0][3]) == "1")
                            { nomina.Fianza = Math.Round(nomina.SueldoBase * 0.01344, 2, MidpointRounding.ToEven); }
                            else
                            { nomina.Fianza = 0; }
                            if (Convert.ToInt16(tblDescuentos.Rows[0][4]) == 0)
                            { nomina.Bantrab = 0; }
                            else
                            { nomina.Bantrab = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][4]), 2, MidpointRounding.ToEven); }

                            if (nomina.IDTIpo == 1 || nomina.IDTIpo == 2 || nomina.IDTIpo == 4 || nomina.IDTIpo == 5 || nomina.IDTIpo == 6)
                            {
                                nomina.ISR = Math.Round(Convert.ToDouble(tblDescuentos.Rows[0][5]), 2, MidpointRounding.ToEven);
                            }
                            else
                            {
                                nomina.ISR = 0;
                            }
                            nomina.OtrasDeducciones = nomina.OtrasDeducciones;
                            
                        break;

                    }

                    liquido = (nomina.SueldoBase + nomina.Bonificacion + nomina.OtrasBonificaciones +nomina.Prestaciones) - (nomina.OtrasDeducciones + nomina.IGSS + nomina.Fianza + nomina.ISR + nomina.Bantrab + nomina.BanSeguro);
                    tblNomina.Rows.Add(nomina.IDNomina,nomina.IDEmpleado, nomina.Nombre, nomina.Anio, nomina.Departamento,nomina.fIngreso, nomina.SueldoBase, nomina.Bonificacion,
                         nomina.OtrasDeducciones, nomina.OtrasBonificaciones, nomina.Dias, nomina.IGSS, nomina.Prestaciones, nomina.Fianza, nomina.ISR,
                         nomina.Bantrab, nomina.BanSeguro, nomina.Renglon, liquido);
                }
            }

            return tblNomina;
        }

        private double PagoBoletoOrnato(string boleto,NominaEN nomina)
        {

            double BOrnato=0; 
                if (boleto== "1")
                { 
                           if (nomina.SueldoBase <= 500)
                           {BOrnato = 0;}
                           if (nomina.SueldoBase >= 500.01 && nomina.SueldoBase <= 1000) 
                           {BOrnato = 10;}
                           if (nomina.SueldoBase >= 1000.01 && nomina.SueldoBase <= 3000)
                           {BOrnato = 15;}
                           if (nomina.SueldoBase >= 3000.01 && nomina.SueldoBase <= 6000) 
                           {BOrnato = 50;} 
                           if (nomina.SueldoBase >= 6000.01 && nomina.SueldoBase <= 9000) 
                           {BOrnato = 75;}
                           if (nomina.SueldoBase >= 9000.01 && nomina.SueldoBase <= 12000) 
                           {BOrnato = 100;}
                           if (nomina.SueldoBase >= 12000.01) 
                           {BOrnato = 150;}
                           
                            if (nomina.OtrasDeducciones == 0)
                            {nomina.OtrasDeducciones = BOrnato;}
                            else
                            { nomina.OtrasDeducciones = BOrnato + nomina.OtrasDeducciones; }   
                }
                else
                {
                    if (nomina.OtrasDeducciones == 0 )
                            {
                                nomina.OtrasDeducciones = 0;
                            }
                    else
                            {
                                nomina.OtrasDeducciones = nomina.OtrasDeducciones;
                            }
                }
                return Math.Round(nomina.OtrasDeducciones, 2, MidpointRounding.ToEven);
        
        }
        private double EmpleadoAguinaldo(NominaEN nomina)
        {
            
            int Dias;
            double EmpleadoAguinaldo = 0;
            Dias = 0;
            DateTime FechaCalculo = new DateTime(nomina.Anio, 12, 31);
            DateTime fingreso = Convert.ToDateTime(nomina.fIngreso);
    
        if (fingreso.Year == nomina.Anio)
            {
            TimeSpan diferencia = FechaCalculo - fingreso;
            Dias = diferencia.Days + 1;
            EmpleadoAguinaldo = Math.Round((nomina.SueldoBase/ 365) * Dias, 2,MidpointRounding.ToEven);      
            }
        else
            {
                EmpleadoAguinaldo = Math.Round(nomina.SueldoBase, 2, MidpointRounding.ToEven);      
            }

        return EmpleadoAguinaldo;
        }
        private double EmpleadoBono(NominaEN nomina,int tipo)
        { 
                DateTime FCalculo;
                DateTime FInicial;
                DateTime FFinal;
                double SueldoInicial;
                double SueldoFinal;
                FInicial  = new DateTime(nomina.Anio - 1,12,1);
                FFinal = new DateTime(nomina.Anio-1,12,31); 
                SueldoInicial = 0;
                SueldoFinal = 0;
                int Dias=0;
                double EmpleadoBono = 0;
    
    
        switch(tipo)
        {
            case 1:
               
                FCalculo = new DateTime(nomina.Anio,6,30); 
                DateTime fingreso = Convert.ToDateTime(nomina.fIngreso);
                TimeSpan diferencia = FCalculo - fingreso;
                Dias = diferencia.Days + 1;
                if( Dias >= 365) 
                {Dias = 365;}
                else
                {Dias = diferencia.Days + 1;}
                
                if( fingreso >= FFinal) 
                {
                    EmpleadoBono = Math.Round((nomina.SueldoBase/ 365) * Dias, 2,MidpointRounding.ToEven);
                }
                else
                {
                    
                    DataTable tblBuscarNomina;
                    tblBuscarNomina = nominaAD.buscarNomina(Convert.ToString(FInicial),Convert.ToString(FFinal));
                    if (tblBuscarNomina.Rows.Count== 0 )
                    {EmpleadoBono=0;}
                    else
                    {
                    foreach (DataRow fila in tblBuscarNomina.Rows)
                        {
                               if (nomina.IDTIpo==1 || nomina.IDTIpo==2 || nomina.IDTIpo==4 ||nomina.IDTIpo==5 ||nomina.IDTIpo==13)
                                {
                                   DataTable buscarNominaDetalle;
                                   buscarNominaDetalle=nominaAD.buscarNominaDetalle(Convert.ToInt32(fila[0]),nomina.IDEmpleado,Convert.ToInt32(fila[1]));
                                   if (buscarNominaDetalle.Rows.Count==0)
                                   {SueldoInicial=SueldoInicial+0;}
                                   else
                                   {SueldoInicial = Math.Round(((Convert.ToDouble(buscarNominaDetalle.Rows[0][8]) / Convert.ToDouble(buscarNominaDetalle.Rows[0][7])) * 31) * 6, 2,MidpointRounding.ToEven);}
                                }
                        }

                        FInicial  = new DateTime(nomina.Anio,1,1);
                        FFinal = new DateTime(nomina.Anio,6,30); 
                        tblBuscarNomina=nominaAD.buscarNomina(Convert.ToString(FInicial),Convert.ToString(FFinal));
                        if (tblBuscarNomina.Rows.Count== 0 )
                    {EmpleadoBono=0;}
                    else
                    {
                    foreach (DataRow fila in tblBuscarNomina.Rows)
                        {
                               if (nomina.IDTIpo==1 || nomina.IDTIpo==2 || nomina.IDTIpo==4 ||nomina.IDTIpo==5 ||nomina.IDTIpo==13)
                                {
                                   DataTable buscarNominaDetalle;
                                   buscarNominaDetalle=nominaAD.buscarNominaDetalle(Convert.ToInt32(fila[0]),nomina.IDEmpleado,Convert.ToInt32(fila[1]));
                                   if (buscarNominaDetalle.Rows.Count==0)
                                   {SueldoFinal=SueldoInicial+0;}
                                   else
                                   {
                                      DateTime Fecha =  Convert.ToDateTime(fila[2]);  
                                       int diaMes = DateTime.DaysInMonth(Fecha.Year,Fecha.Month);
                                  
                                                SueldoFinal = Math.Round(SueldoFinal + ((Convert.ToDouble(buscarNominaDetalle.Rows[8]) / Convert.ToDouble(buscarNominaDetalle.Rows[7])) * diaMes), 2);                                 
                                        
                                   }
                                }
                        }

               
                    }
                }

        } // fin del Primer Else
                EmpleadoBono = Math.Round((((Math.Round(SueldoInicial + SueldoFinal, 2, MidpointRounding.ToEven)) / 12) / 365) * Dias, 2, MidpointRounding.ToEven);
            break;
            case 2:

            
                FCalculo = new DateTime(nomina.Anio,2,28); 
                DateTime fingreso3 = Convert.ToDateTime(nomina.fIngreso);
                TimeSpan diferencia3 = FCalculo - fingreso3;
                Dias = diferencia3.Days + 1;
                if (Dias >= 365)
                { EmpleadoBono = 200; }
                else
                { EmpleadoBono = (200 / 365) * Dias; }
                
                
            break;

                
        } // fin del case
        return EmpleadoBono; 
        } // fin de la funcion

        private int DiasTipoMes(NominaEN nomina)
        {
            
            int varDiasTipoMes=0;
            switch (nomina.IDTIpo)
            {   case 1: 
                        varDiasTipoMes = 30;
                    break;
                case 2:
                case 13:
                        varDiasTipoMes = 31;
                    break;
                case 3:
                case 6:
                case 14:
                        varDiasTipoMes = 1;
                    break;
                case 4:
                        varDiasTipoMes = 28;
                    break;
                case 5:
                        varDiasTipoMes = 29;
                    break;
                case 7: //Bono 14
                        if ( Convert.ToInt32(nomina.fIngreso.Substring(6,4))== nomina.Anio) 
                                {
                                    DateTime FechaCalculo = new DateTime(nomina.Anio,6,30);
                                    DateTime fingreso = Convert.ToDateTime(nomina.fIngreso);
                                   TimeSpan diferencia = FechaCalculo - fingreso;
                                    varDiasTipoMes = diferencia.Days;
                                }
                        else
                                {
                                    varDiasTipoMes = 365;
                                }
                    break;
                case 8: //Bono Vacacional
                        if ( Convert.ToInt32(nomina.fIngreso.Substring(6,4))== nomina.Anio) 
                                {
                                    DateTime FechaCalculo = new DateTime(nomina.Anio,3,31);
                                    DateTime fingreso = Convert.ToDateTime(nomina.fIngreso);
                                   TimeSpan diferencia = FechaCalculo - fingreso;
                                    varDiasTipoMes = diferencia.Days;
                                }
                        else
                                {
                                    varDiasTipoMes = 365;
                                }
                    break;
                case 9:  // Aguinaldos 50%
                case 10:// Aguinaldos 100%
                case 11: //Aguinaldos Destajo 50%
                case 12: //Aguinaldos Destajo 100%
                        if ( Convert.ToInt32(nomina.fIngreso.Substring(6,4))== nomina.Anio) 
                                {
                                    DateTime FechaCalculo = new DateTime(nomina.Anio,11,30);
                                    DateTime fingreso = Convert.ToDateTime(nomina.fIngreso);
                                   TimeSpan diferencia = FechaCalculo - fingreso;
                                    varDiasTipoMes = diferencia.Days;
                                }
                        else
                                {
                                    varDiasTipoMes = 365;
                                }
                   break;
             
            }

            return varDiasTipoMes;
            
        }


    }
      

}
