using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_Cotizacion
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_V_Cotizacion Vista = new Cls_Dat_V_Cotizacion();

        public List<V_COTIZACION> Listar_V_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_COTIZACION> lista = new List<V_COTIZACION>();
            try
            {
                lista = Vista.Listar_V_Cotizacion(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        //public List<V_COTIZACION> Buscar_Venta(V_COTIZACION entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<V_COTIZACION> lista = new List<V_COTIZACION>();
        //    try
        //    {
        //        lista = Vista.Buscar_Venta(entidad, fechaInicio, fechaFin, ref auditoria);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        //public List<V_COTIZACION> Buscar_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<V_COTIZACION> lista = new List<V_COTIZACION>();
        //    try
        //    {
        //        lista = Vista.Buscar_Venta(id, ref auditoria);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

    }
}
