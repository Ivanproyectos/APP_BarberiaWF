using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Usuario
    {
        private Cls_Dat_Usuario ObjUsuario = new Cls_Dat_Usuario();

        public List<Cls_Ent_UsuarioWForm> Listar_Usuario(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<Cls_Ent_UsuarioWForm> lista = new List<Cls_Ent_UsuarioWForm>();
            try
            {
                lista = ObjUsuario.Listar_Usuario(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_USUARIO ListarUno_Usuario(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_USUARIO lista = new T_M_USUARIO();
            try
            {
                lista = ObjUsuario.ListarUno_Cargo(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjUsuario.Insertar_Usuario(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjUsuario.Actualizar_Usuario(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = ObjUsuario.Eliminar_Usuario(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<Cls_Ent_UsuarioWForm> Buscar_Usuario(T_M_USUARIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<Cls_Ent_UsuarioWForm> lista = new List<Cls_Ent_UsuarioWForm>();
            try
            {
                lista = ObjUsuario.Buscar_Usuario(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public string Login_Usuario(string user, string pass, out int IdPerfil, out int IdPersonal, ref Cls_Ent_Auditoria auditoria)
        {
            string mensaje;
            try
            {
                mensaje = ObjUsuario.Login_Usuario(user, pass, out int idPerfil, out int idPersonal, ref auditoria);
                IdPerfil = idPerfil;
                IdPersonal = idPersonal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

    }
}
