using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Almacen
    {
        private Cls_Dat_Almacen Obj = new Cls_Dat_Almacen();

        public List<T_M_ALMACEN> Listar_Almacen(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_ALMACEN> lista = new List<T_M_ALMACEN>();
            try
            {
                lista = Obj.Listar_Almacen(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_ALMACEN ListarUno_Almacen(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_ALMACEN lista = new T_M_ALMACEN();
            try
            {
                lista = Obj.ListarUno_Almacen(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Almacen(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_Almacen(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_Almacen(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_ALMACEN> Buscar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_ALMACEN> lista = new List<T_M_ALMACEN>();
            try
            {
                lista = Obj.Buscar_Almacen(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
