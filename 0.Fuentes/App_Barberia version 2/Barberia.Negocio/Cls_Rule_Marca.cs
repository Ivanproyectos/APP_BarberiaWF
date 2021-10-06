using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Marca
    {
        private Cls_Dat_Marca ObjMarca = new Cls_Dat_Marca();

        public List<T_M_MARCA> Listar_Marca(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_MARCA> lista = new List<T_M_MARCA>();
            try
            {
                lista = ObjMarca.Listar_Marca(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_MARCA ListarUno_Marca(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_MARCA lista = new T_M_MARCA();
            try
            {
                lista = ObjMarca.ListarUno_Marca(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjMarca.Insertar_Marca(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjMarca.Actualizar_Marca(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = ObjMarca.Eliminar_Marca(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_MARCA> Buscar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_MARCA> lista = new List<T_M_MARCA>();
            try
            {
                lista = ObjMarca.Buscar_Marca(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
