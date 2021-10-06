using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_C_Perfil
    {
        private Cls_Dat_C_Perfil ObjPerfil = new Cls_Dat_C_Perfil();

        public List<Cls_Ent_Perfil> Listar_Perfil(ref Cls_Ent_Auditoria auditoria)
        {
            List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
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

        public bool Insertar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria) 
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
        
        public bool Actualizar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
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

        public bool Eliminar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
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

        public List<Cls_Ent_Perfil> Buscar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
            try
            {
                lista = ObjPerfil.Buscar_C_Perfil(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
