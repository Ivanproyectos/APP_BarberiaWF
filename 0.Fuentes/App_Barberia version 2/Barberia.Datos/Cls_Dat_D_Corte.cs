using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_D_Corte : Repository<T_D_CORTE>
    {
        //public List<T_M_PERSONAL> Listar_Personal()
        //{
        //    using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
        //    {
        //        return db.T_M_PERSONAL.OrderByDescending(t => t.ID_PERSONAL).ToList();
        //    }
        //}

        public List<T_D_CORTE> Buscar_D_Corte(T_D_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_CORTE> lista = new List<T_D_CORTE>();
            auditoria.Limpiar();
            try
            {
                if (entidad.ID_CORTE != 0)
                    lista = FindAll(c => c.ID_CORTE == entidad.ID_CORTE).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_D_Corte(T_D_CORTE entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            auditoria.Limpiar();
            bool exito = true;
            try
            {

                    Add(entidad);

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_D_Corte(T_D_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_CORTE> lista = new List<T_D_CORTE>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Buscar_D_Corte(entidad, ref auditoria);
                if (lista.Count > 0 )
                {
                    if (lista[0].ID_CORTE.Equals(entidad.ID_CORTE))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    Update(entidad, entidad.ID_DETALLE);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public void Eliminar_D_Corte(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                DeleteUno(id);

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }

        }

    }
}
