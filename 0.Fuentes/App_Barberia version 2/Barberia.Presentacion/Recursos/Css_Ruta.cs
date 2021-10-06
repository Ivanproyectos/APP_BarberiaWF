using System;
using System.Configuration;

namespace Barberia.Presentacion.Recursos
{
    class Css_Ruta
    {
        public class MisRuta
        {
            public string RUTA_COMPLETA { get; set; }
            public string RUTA { get; set; }
        }

        public static MisRuta Ruta_TemporalI()
        {
            MisRuta Mir = new MisRuta();

            Mir.RUTA_COMPLETA = AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Temporales\";
            Mir.RUTA = @"Recursos\Temporales\";

            return Mir;
        }

        public static string Ruta_Temporal()
        {
            string ruta = "";
            ruta = ConfigurationManager.AppSettings["Servidor_Temporal"].ToString();
            if (ruta == "")
            {
                ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Temporales\");
            }
            return ruta;
        }



        public static string Ruta_Historico_SISGED()
        {
            string ruta = "";
            ruta = ConfigurationManager.AppSettings["Servidor_Historico_SISGED"].ToString();
            if (ruta == "")
            {
                ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Historico\");
            }
            return ruta;
        }

        public static string Ruta_Historico()
        {
            string ruta = "";
            ruta = ConfigurationManager.AppSettings["Servidor_Historico"].ToString();
            if (ruta == "")
            {
                ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Historico\");
            }
            return ruta;
        }



        public static string Ruta_Peticiones()
        {
            string ruta = "";
            ruta = ConfigurationManager.AppSettings["Servidor_Peticiones"].ToString();
            if (ruta == "")
            {
                ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Peticiones\");
            }
            return ruta;
        }

    }
}
