using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Cotizacion
    {
        private Cls_Dat_Cotizacion Obj = new Cls_Dat_Cotizacion();

        public List<T_M_COTIZACION> Listar_Cotizacion(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_COTIZACION> lista = new List<T_M_COTIZACION>();
            try
            {
                lista = Obj.Listar_Cotizacion(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_COTIZACION ListarUno_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_COTIZACION lista = new T_M_COTIZACION();
            try
            {
                lista = Obj.ListarUno_Cotizacion(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Cotizacion(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_Cotizacion(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }


        public bool Eliminar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_Cotizacion(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_COTIZACION> Buscar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_COTIZACION> lista = new List<T_M_COTIZACION>();
            try
            {
                lista = Obj.Buscar_Cotizacion(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


    }
}
