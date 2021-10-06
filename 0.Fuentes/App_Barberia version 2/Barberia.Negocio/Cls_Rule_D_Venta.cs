using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_D_Venta
    {
        private Cls_Dat_D_Venta ObjDVenta = new Cls_Dat_D_Venta();

        //public List<V_PERSONAL> Listar_Personal()
        //{
        //    List<V_PERSONAL> lista = new List<V_PERSONAL>();
        //    try
        //    {
        //        lista = VistaPersonal.Listar_Personal();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public bool Insertar_D_Venta(T_D_VENTA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjDVenta.Insertar_D_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_D_Venta(T_D_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjDVenta.Actualizar_D_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public void Eliminar_D_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                ObjDVenta.Eliminar_D_Venta(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T_D_VENTA> Buscar_D_Venta(T_D_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_VENTA> lista = new List<T_D_VENTA>();
            try
            {
                lista = ObjDVenta.Buscar_D_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<T_D_VENTA> Buscar_D_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_VENTA> lista = new List<T_D_VENTA>();
            try
            {
                lista = ObjDVenta.Buscar_D_Venta(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
