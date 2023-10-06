using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocias
{
    public class metodosComunes
    {
        public static DataTable consultaAbiertaSinParametros(string consulta)
        {
            return datos.GetDataTable(consulta);
        }
    }
}
