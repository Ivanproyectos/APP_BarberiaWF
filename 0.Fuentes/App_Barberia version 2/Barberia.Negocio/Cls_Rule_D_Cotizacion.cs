using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_D_Cotizacion
    {
        private Cls_Dat_D_Cotizacion Obj = new Cls_Dat_D_Cotizacion();

        public void Insertar_D_Cotizacion(T_D_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                 Obj.Insertar_D_Cotizacion(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool Actualizar_D_Cotizacion(T_D_Cotizacion entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    bool exito = false;
        //    try
        //    {
        //        exito = Obj.Actualizar_D_Cotizacion(entidad, ref auditoria);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return exito;
        //}

        //public List<T_D_Cotizacion> Buscar_D_Cotizacion(T_D_Cotizacion entidad, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<T_D_Cotizacion> lista = new List<T_D_Cotizacion>();
        //    try
        //    {
        //        lista = Obj.Buscar_D_Cotizacion(entidad, ref auditoria);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public void Eliminar_D_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                Obj.Eliminar_D_Cotizacion(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
