using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_M_ORDEN_COMPRA
    {

        private Cls_Dat_V_M_ORDEN_COMPRA Vista = new Cls_Dat_V_M_ORDEN_COMPRA();

        public List<V_M_ORDEN_COMPRA> Listar_V_OrdenCompra(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_ORDEN_COMPRA> lista = new List<V_M_ORDEN_COMPRA>();
            try
            {
                lista = Vista.Listar_OrdenCompra(idEmpresa, ref auditoria);
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
        //        lista = Vista.ListarPagina_Corte(out int total, PaginaSelecion);
        //        TotalPagina = total;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public List<V_M_ORDEN_COMPRA> Buscar_V_OrdenCompra(V_M_ORDEN_COMPRA entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_ORDEN_COMPRA> lista = new List<V_M_ORDEN_COMPRA>();
            try
            {
                lista = Vista.Buscar_OrdenCompra(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public V_M_ORDEN_COMPRA Buscar_V_OrdenCompra(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_ORDEN_COMPRA lista = new V_M_ORDEN_COMPRA();
            try
            {
                lista = Vista.Buscar_OrdenCompra(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
