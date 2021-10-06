using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Anular_Corte
    {
        private Cls_Dat_Anular_Corte Obj = new Cls_Dat_Anular_Corte();

        public List<T_ANULAR_CORTE> Listar_Anular_Corte(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_CORTE> lista = new List<T_ANULAR_CORTE>();
            try
            {
                lista = Obj.Listar_Anular_Corte(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Anular_Corte(T_ANULAR_CORTE entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Anular_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
       


        public List<T_ANULAR_CORTE> Buscar_Anular_Corte(T_ANULAR_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_CORTE> lista = new List<T_ANULAR_CORTE>();
            try
            {
                lista = Obj.Buscar_Anular_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<T_ANULAR_CORTE> BuscarReporte_Anular_Corte(string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_CORTE> lista = new List<T_ANULAR_CORTE>();
            try
            {
                lista = Obj.BuscarReporte_Anular_Corte(fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


    }
}
