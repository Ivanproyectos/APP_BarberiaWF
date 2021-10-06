using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Barberia.Entidad;

namespace Barberia.Datos
{
    public class Cls_Data_Backup
    {
        public void Ejecutar_Backup(string rutaBackup, string rutaSQL, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            //bool exito = false;
            string ruta = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            //SqlConnection cn = new SqlConnection("SERVER=YORDAN-PC;DATABASE=DB_BARBERIA;UID=sa;PWD=1234");
            string nombre = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "-DB_BARBERIA.bak";
            string sql = "BACKUP DATABASE [DB_BARBERIA] TO  DISK = N'"+rutaSQL + nombre + "' WITH NOFORMAT, NOINIT,  NAME = N'DB_BARBERIA-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlConnection cn = new SqlConnection(ruta);
              SqlCommand cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

                //string rutaObjetivo = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\BackupDB\");
                //string rutaFile = @"C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Backup\" + nombre;
                string rutaFile = rutaSQL + nombre;
                string nuevaRutaObj = Path.Combine(rutaBackup, nombre);
                File.Copy(rutaFile, nuevaRutaObj, true);

                cn.Close();
                cn.Dispose();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            
        }
        
    }
}
