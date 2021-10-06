using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_Producto
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_V_PRODUCTO VistaVenta = new Cls_Dat_V_PRODUCTO();

        public List<V_PRODUCTO> Listar_Producto(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            try
            {
                lista = VistaVenta.Listar_Producto(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        //public List<V_CORTE> ListarPagina_Corte(out int TotalPagina, int PaginaSelecion=0)
        //{
        //    List<V_CORTE> lista = new List<V_CORTE>();
        //    try
        //    {
        //        lista = VistaVenta.ListarPagina_Corte(out int total, PaginaSelecion);
        //        TotalPagina = total;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public List<V_PRODUCTO> Buscar_Producto(V_PRODUCTO entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            try
            {
                lista = VistaVenta.Buscar_Producto(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<V_PRODUCTO> Buscar_Producto(V_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            try
            {
                lista = VistaVenta.Buscar_Producto(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<V_PRODUCTO> Buscar_PopPupProducto(V_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            try
            {
                lista = VistaVenta.Buscar_PopPupProducto(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public V_PRODUCTO Buscar_Producto(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_PRODUCTO lista = new V_PRODUCTO();
            try
            {
                lista = VistaVenta.Buscar_Producto(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
