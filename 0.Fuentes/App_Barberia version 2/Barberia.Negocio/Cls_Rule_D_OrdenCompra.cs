using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_D_OrdenCompra
    {
        private Cls_DaT_D_ORDEN_COMPRA Obj = new Cls_DaT_D_ORDEN_COMPRA();

        public void Insertar_D_OrdenCompra(T_D_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                 Obj.Insertar_D_OrdenCompra(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool Actualizar_D_OrdenCompra(T_D_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    bool exito = false;
        //    try
        //    {
        //        exito = Obj.Actualizar_D_OrdenCompra(entidad, ref auditoria);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return exito;
        //}

        //public List<T_D_ORDEN_COMPRA> Buscar_D_OrdenCompra(T_D_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<T_D_ORDEN_COMPRA> lista = new List<T_D_ORDEN_COMPRA>();
        //    try
        //    {
        //        lista = Obj.Buscar_D_OrdenCompra(entidad, ref auditoria);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public void Eliminar_D_OrdenCompra(int id, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                Obj.Eliminar_D_OrdenCompra(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
