using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_D_Kardex : Repository<T_D_KARDEX>
    {

        //public T_M_KARDEX BusxarProducto_Kardex(int id, ref Cls_Ent_Auditoria auditoria)
        //{
        //    auditoria.Limpiar();
        //    T_M_KARDEX entidad = new T_M_KARDEX();
        //    try
        //    {
        //        using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
        //        {
        //            entidad = db.T_M_KARDEX.Find(id); 
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        auditoria.Error(ex);
        //    }
        //    return entidad;
        //}


        public bool Insertar_D_Kardex(T_D_KARDEX entidad, ref Cls_Ent_Auditoria auditoria)
        {

            bool exito = true;
            auditoria.Limpiar();
            try
            {

                    Add(entidad);

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

      

    }
}
