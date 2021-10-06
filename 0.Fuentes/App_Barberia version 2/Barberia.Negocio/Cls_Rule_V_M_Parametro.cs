using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_M_Parametro
    {

        private Cls_Dat_V_M_Parametro VistaVenta = new Cls_Dat_V_M_Parametro();

        public List<V_M_PARAMETRO> Listar_Parametro(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_PARAMETRO> lista = new List<V_M_PARAMETRO>();
            try
            {
                lista = VistaVenta.Listar_Parametro(idEmpresa, ref auditoria);
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

        public List<V_M_PARAMETRO> Buscar_Parametro(V_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_PARAMETRO> lista = new List<V_M_PARAMETRO>();
            try
            {
                lista = VistaVenta.Buscar_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public V_M_PARAMETRO Buscar_Parametro(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_PARAMETRO lista = new V_M_PARAMETRO();
            try
            {
                lista = VistaVenta.Buscar_Parametro(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
