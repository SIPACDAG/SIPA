using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Data;

namespace CapaLN
{
    public class ProfesionLN
    {

        public DataTable ObtenerProfesion()
        {
            ProfesionAD profesionAD = new ProfesionAD();
            return profesionAD.ListadoProfesion();
        }

        public DataTable CrearProfesion(String profesion)
        {
            ProfesionAD profesionAD = new ProfesionAD();
            return profesionAD.CrearProfesion(profesion);
        }

        public DataTable EditarProfesion (int id, string profesion)
        {
            ProfesionAD profesionAD = new ProfesionAD();
            return profesionAD.EditarProfesion(id, profesion);
        }

        public DataTable EliminarProfesion(int id)
        {
            ProfesionAD profesionAD = new ProfesionAD();
            return profesionAD.EliminarProfesion(id);
        }

        public DataTable GetProfesion(int id)
        {
            ProfesionAD profesionAD = new ProfesionAD();
            return profesionAD.GetProfesion(id);
        }
    }
}
