using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Servicio
    {
        private Cls_Dat_Servicio ObjServicio = new Cls_Dat_Servicio();

        public List<T_M_SERVICIO> Listar_Servicio(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_SERVICIO> lista = new List<T_M_SERVICIO>();
            try
            {
                lista = ObjServicio.Listar_Servicio(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_SERVICIO ListarUno_Servicio(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_SERVICIO lista = new T_M_SERVICIO();
            try
            {
                lista = ObjServicio.ListarUno_Servicio(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjServicio.Insertar_Servicio(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjServicio.Actualizar_Servicio(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = ObjServicio.Eliminar_Servicio(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_SERVICIO> Buscar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_SERVICIO> lista = new List<T_M_SERVICIO>();
            try
            {
                lista = ObjServicio.Buscar_Servicio(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
