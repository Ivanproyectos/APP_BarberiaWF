using System;

namespace Barberia.Entidad
{
    public class Cls_Ent_Auditoria
    {
        public object OBJETO { get; set; }
        public string MENSAJE_SALIDA { get; set; }
        public string ERROR_LOG { get; set; }
        public bool EJECUCION_PROCEDIMIENTO { get; set; }
        public bool AUTORIZADO { get; set; }
        public string URL { get; set; }
        public bool CAPTCHA { get; set; }

        public bool RECHAZAR { get; set; } // Auxiliar
        public bool RECHAZAR2 { get; set; } // Auxiliar

        public void NoAutorizado(string URL_)
        {
            URL = URL_;
            MENSAJE_SALIDA = "";
            ERROR_LOG = "";
            AUTORIZADO = false;
            RECHAZAR = false;
            EJECUCION_PROCEDIMIENTO = true;
        }

        public void Limpiar()
        {
            MENSAJE_SALIDA = "";
            ERROR_LOG = "";
            RECHAZAR = false;
            AUTORIZADO = true;
            CAPTCHA = true;
            EJECUCION_PROCEDIMIENTO = true;
        }

        public void Rechazar(String mensaje)
        {

            MENSAJE_SALIDA = mensaje;
            ERROR_LOG = mensaje;
            RECHAZAR = true;
            AUTORIZADO = true;
            EJECUCION_PROCEDIMIENTO = true;
        }

        public void Error(Exception ex)
        {
            MENSAJE_SALIDA = ex.Message;
            ERROR_LOG = ex.ToString();
            RECHAZAR = true;
            AUTORIZADO = true;
            EJECUCION_PROCEDIMIENTO = false;
        }

        public void Rechazar_Captcha()
        {
            CAPTCHA = false;
            EJECUCION_PROCEDIMIENTO = true;
        }
    }
}
