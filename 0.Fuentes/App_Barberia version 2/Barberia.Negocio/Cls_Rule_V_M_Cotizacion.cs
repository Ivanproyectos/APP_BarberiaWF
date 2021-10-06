using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_M_Cotizacion
    {

        private Cls_Dat_V_M_Cotizacion Vista = new Cls_Dat_V_M_Cotizacion();

        public List<V_M_COTIZACION> Listar_V_Cotizacion(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_COTIZACION> lista = new List<V_M_COTIZACION>();
            try
            {
                lista = Vista.Listar_Cotizacion(idEmpresa, ref auditoria);
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

        public List<V_M_COTIZACION> Buscar_V_Cotizacion(V_M_COTIZACION entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_COTIZACION> lista = new List<V_M_COTIZACION>();
            try
            {
                lista = Vista.Buscar_Cotizacion(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public V_M_COTIZACION Buscar_V_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_COTIZACION lista = new V_M_COTIZACION();
            try
            {
                lista = Vista.Buscar_Cotizacion(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
