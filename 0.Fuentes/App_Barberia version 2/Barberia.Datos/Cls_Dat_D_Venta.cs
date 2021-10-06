using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barberia.Entidad;

namespace Barberia.Datos
{
    public class Cls_Dat_D_Venta : Repository<T_D_VENTA>
    {
        //public List<T_M_PERSONAL> Listar_Personal()
        //{
        //    using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
        //    {
        //        return db.T_M_PERSONAL.OrderByDescending(t => t.ID_PERSONAL).ToList();
        //    }
        //}

        public List<T_D_VENTA> Buscar_D_Venta(T_D_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_VENTA> lista = new List<T_D_VENTA>();
            auditoria.Limpiar();
            try
            {
                if (entidad.ID_VENTA != 0)
                    lista = FindAll(c => c.ID_VENTA == entidad.ID_VENTA).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_D_VENTA> Buscar_D_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_VENTA> lista = new List<T_D_VENTA>();
            auditoria.Limpiar();
            try
            {
                if (id != 0)
                    lista = FindAll(c => c.ID_VENTA == id).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_D_Venta(T_D_VENTA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            //List<T_D_VENTA> lista = new List<T_D_VENTA>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                //lista = Buscar_D_Venta(entidad);
                //if (lista.Count > 0)
                //{
                //    exito = false;
                //}

                //if (exito)
                //{
                //    Add(entidad);
                //}
                Add(entidad);
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_D_Venta(T_D_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_VENTA> lista = new List<T_D_VENTA>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Buscar_D_Venta(entidad, ref auditoria);
                if (lista.Count > 0 )
                {
                    if (lista[0].ID_VENTA.Equals(entidad.ID_VENTA))
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

        public void Eliminar_D_Venta(int id, ref Cls_Ent_Auditoria auditoria)
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
