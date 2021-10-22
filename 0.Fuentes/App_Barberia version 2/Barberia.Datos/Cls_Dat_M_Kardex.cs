using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_M_Kardex : Repository<T_M_KARDEX>
    {

        public T_M_KARDEX BuscarProducto_Kardex(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_KARDEX entidad = new T_M_KARDEX();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_KARDEX.Find(id); 
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }


        public int Insertar_Kardex(T_M_KARDEX entidad, ref Cls_Ent_Auditoria auditoria)
        {

            int idKardex;
            auditoria.Limpiar();
            try
            {

                idKardex = Add(entidad).ID_KARDEX;

            }
            catch (Exception ex)
            {
                idKardex = 0;
                auditoria.Error(ex);
            }
            return idKardex;
        }

      

    }
}
