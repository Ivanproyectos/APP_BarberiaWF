using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_D_Cotizacion : Repository<T_D_COTIZACION>
    {


        //public List<T_D_COTIZACION> Buscar_D_Cotizacion(T_D_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<T_D_COTIZACION> lista = new List<T_D_COTIZACION>();
        //    auditoria.Limpiar();
        //    try
        //    {
        //        if (entidad.ID_Cotizacion != 0)
        //            lista = FindAll(c => c.ID_Cotizacion == entidad.ID_Cotizacion).ToList();

        //    }
        //    catch (Exception ex)
        //    {

        //        auditoria.Error(ex);
        //    }
        //    return lista;
        //}

        public void Insertar_D_Cotizacion(T_D_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
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

        //public bool Actualizar_D_Cotizacion(T_D_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<T_D_COTIZACION> lista = new List<T_D_COTIZACION>();
        //    bool exito = true;
        //    auditoria.Limpiar();
        //    try
        //    {
        //        lista = Buscar_D_Cotizacion(entidad, ref auditoria);
        //        if (lista.Count > 0 )
        //        {
        //            if (lista[0].ID_Cotizacion.Equals(entidad.ID_Cotizacion))
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

        public void Eliminar_D_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
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
