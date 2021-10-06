using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_M_Venta
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_V_M_Venta VistaVenta = new Cls_Dat_V_M_Venta();

        public List<V_M_VENTA> Listar_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_VENTA> lista = new List<V_M_VENTA>();
            try
            {
                lista = VistaVenta.Listar_Venta(ref auditoria);
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

        public List<V_M_VENTA> Buscar_Venta(V_M_VENTA entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_VENTA> lista = new List<V_M_VENTA>();
            try
            {
                lista = VistaVenta.Buscar_Venta(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<V_M_VENTA> Buscar_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_VENTA> lista = new List<V_M_VENTA>();
            try
            {
                lista = VistaVenta.Buscar_Venta(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
