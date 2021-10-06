using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_M_Corte
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_V_M_Corte VistaCorte = new Cls_Dat_V_M_Corte();

        public List<V_M_CORTE> Listar_M_Corte(ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_CORTE> lista = new List<V_M_CORTE>();
            try
            {
                lista = VistaCorte.Listar_Corte(ref auditoria);
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
        //        lista = VistaCorte.ListarPagina_Corte(out int total, PaginaSelecion);
        //        TotalPagina = total;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public List<V_M_CORTE> Buscar_M_Corte(V_M_CORTE entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_CORTE> lista = new List<V_M_CORTE>();
            try
            {
                lista = VistaCorte.Buscar_Corte(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public V_M_CORTE Buscar_M_Corte(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_CORTE lista = new V_M_CORTE();
            try
            {
                lista = VistaCorte.Buscar_Corte(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
