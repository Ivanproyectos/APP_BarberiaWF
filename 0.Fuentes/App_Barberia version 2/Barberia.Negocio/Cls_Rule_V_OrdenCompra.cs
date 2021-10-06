using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_ORDEN_COMPRA
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_V_ORDEN_COMPRA Vista = new Cls_Dat_V_ORDEN_COMPRA();

        public List<V_ORDEN_COMPRA> Listar_V_ORDEN_COMPRA(int id, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_ORDEN_COMPRA> lista = new List<V_ORDEN_COMPRA>();
            try
            {
                lista = Vista.Listar_V_ORDEN_COMPRA(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        //public List<V_ORDEN_COMPRA> Buscar_Venta(V_ORDEN_COMPRA entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<V_ORDEN_COMPRA> lista = new List<V_ORDEN_COMPRA>();
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

        //public List<V_ORDEN_COMPRA> Buscar_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<V_ORDEN_COMPRA> lista = new List<V_ORDEN_COMPRA>();
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
