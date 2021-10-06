using Barberia.Datos;
using Barberia.Entidad;
using System;


namespace Barberia.Negocio
{
    public class Cls_Rule_Backup
    {
        Cls_Data_Backup objBackup = new Cls_Data_Backup();

        public void Ejecutar_Backup(string ruta, string rutaSQL, ref Cls_Ent_Auditoria auditoria) 
        {
            try
            {
                objBackup.Ejecutar_Backup(ruta, rutaSQL, ref auditoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
