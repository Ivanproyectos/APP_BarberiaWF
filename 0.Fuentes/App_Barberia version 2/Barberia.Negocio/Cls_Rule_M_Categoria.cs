using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Categoria
    {
        private Cls_DaT_M_CATEGORIA Obj = new Cls_DaT_M_CATEGORIA();

        public List<T_M_CATEGORIA> Listar_Categoria(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CATEGORIA> lista = new List<T_M_CATEGORIA>();
            try
            {
                lista = Obj.Listar_Categoria(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_CATEGORIA ListarUno_Categoria(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CATEGORIA lista = new T_M_CATEGORIA();
            try
            {
                lista = Obj.ListarUno_Categoria(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Categoria(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_Categoria(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_Categoria(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_CATEGORIA> Buscar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CATEGORIA> lista = new List<T_M_CATEGORIA>();
            try
            {
                lista = Obj.Buscar_Categoria(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
