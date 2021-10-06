using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Cargo
    {
        private Cls_Dat_Cargo ObjCargo = new Cls_Dat_Cargo();

        public List<T_M_CARGO> Listar_Cargo(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CARGO> lista = new List<T_M_CARGO>();
            try
            {
                lista = ObjCargo.Listar_Cargo(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_CARGO ListarUno_Cargo(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CARGO lista = new T_M_CARGO();
            try
            {
                lista = ObjCargo.ListarUno_Cargo(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjCargo.Insertar_Cargo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjCargo.Actualizar_Cargo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = ObjCargo.Eliminar_Cargo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_CARGO> Buscar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CARGO> lista = new List<T_M_CARGO>();
            try
            {
                lista = ObjCargo.Buscar_Cargo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
