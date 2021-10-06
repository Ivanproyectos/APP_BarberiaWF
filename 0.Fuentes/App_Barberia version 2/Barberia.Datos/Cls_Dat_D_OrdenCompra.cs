using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_DaT_D_ORDEN_COMPRA : Repository<T_D_ORDEN_COMPRA>
    {


        //public List<T_D_ORDEN_COMPRA> Buscar_D_OrdenCompra(T_D_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<T_D_ORDEN_COMPRA> lista = new List<T_D_ORDEN_COMPRA>();
        //    auditoria.Limpiar();
        //    try
        //    {
        //        if (entidad.ID_OrdenCompra != 0)
        //            lista = FindAll(c => c.ID_OrdenCompra == entidad.ID_OrdenCompra).ToList();

        //    }
        //    catch (Exception ex)
        //    {

        //        auditoria.Error(ex);
        //    }
        //    return lista;
        //}

        public void Insertar_D_OrdenCompra(T_D_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                Add(entidad);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        //public bool Actualizar_D_OrdenCompra(T_D_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<T_D_ORDEN_COMPRA> lista = new List<T_D_ORDEN_COMPRA>();
        //    bool exito = true;
        //    auditoria.Limpiar();
        //    try
        //    {
        //        lista = Buscar_D_OrdenCompra(entidad, ref auditoria);
        //        if (lista.Count > 0 )
        //        {
        //            if (lista[0].ID_OrdenCompra.Equals(entidad.ID_OrdenCompra))
        //                exito = true;
        //            else
        //                exito = false;
        //        }

        //        if (exito)
        //        {
        //            Update(entidad, entidad.ID_DETALLE);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        auditoria.Error(ex);
        //    }
        //    return exito;
        //}

        public void Eliminar_D_OrdenCompra(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                DeleteUno(id);

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }

        }

    }
}
