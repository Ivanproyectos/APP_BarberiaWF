using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_Corte
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_V_Corte VistaCorte = new Cls_Dat_V_Corte();

        public List<V_CORTE> Listar_Corte(ref Cls_Ent_Auditoria auditoria)
        {
            List<V_CORTE> lista = new List<V_CORTE>();
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

        public List<V_CORTE> ListarPagina_Corte(out int TotalPagina, ref Cls_Ent_Auditoria auditoria, int PaginaSelecion=0)
        {
            List<V_CORTE> lista = new List<V_CORTE>();
            try
            {
                lista = VistaCorte.ListarPagina_Corte(out int total, ref auditoria, PaginaSelecion);
                TotalPagina = total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<V_CORTE> Buscar_Corte(V_CORTE entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_CORTE> lista = new List<V_CORTE>();
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

    }
}
