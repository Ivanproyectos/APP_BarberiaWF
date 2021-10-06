using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Perfil
    {
        private Cls_Dat_M_Perfil ObjPerfil = new Cls_Dat_M_Perfil();

        public List<T_M_PERFIL> Listar_Perfil(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PERFIL> lista = new List<T_M_PERFIL>();
            try
            {
                lista = ObjPerfil.Listar_Perfil(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_PERFIL ListarUno_Perfil(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PERFIL lista = new T_M_PERFIL();
            try
            {
                lista = ObjPerfil.ListarUno_Perfil(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjPerfil.Insertar_Perfil(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjPerfil.Actualizar_Perfil(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = ObjPerfil.Eliminar_Perfil(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_PERFIL> Buscar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PERFIL> lista = new List<T_M_PERFIL>();
            try
            {
                lista = ObjPerfil.Buscar_Perfil(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
