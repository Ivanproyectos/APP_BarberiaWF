using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Clientes
    {
        private Cls_Dat_Clientes ObjCliente = new Cls_Dat_Clientes();

        public List<T_M_CLIENTES> Listar_Clientes(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLIENTES> lista = new List<T_M_CLIENTES>();
            try
            {
                lista = ObjCliente.Listar_Clientes(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_CLIENTES ListarUno_Clientes(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CLIENTES lista = new T_M_CLIENTES();
            try
            {
                lista = ObjCliente.ListarUno_Clientes(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjCliente.Insertar_Clientes(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Actualizar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjCliente.Actualizar_Clientes(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjCliente.Eliminar_Clientes(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_CLIENTES> Buscar_Clientes(T_M_CLIENTES entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLIENTES> lista = new List<T_M_CLIENTES>();
            try
            {
                lista = ObjCliente.Buscar_Clientes(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_CLIENTES Buscar_Clientes(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CLIENTES entidad = new T_M_CLIENTES();
            try
            {
                entidad = ObjCliente.Buscar_Clientes(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidad;
        }

        public List<T_M_CLIENTES> ListarEmpInt_Clientes(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLIENTES> lista = new List<T_M_CLIENTES>();
            try
            {
                lista = ObjCliente.ListarEmpresaInt_Clientes(idEmpresa,ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<T_M_CLIENTES> ListarEmpresa_Clientes(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLIENTES> lista = new List<T_M_CLIENTES>();
            try
            {
                lista = ObjCliente.ListarEmpresa_Clientes(idEmpresa,ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<V_CLIENTE> ListarPaginado_Cliente(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_CLIENTE> lista = new List<V_CLIENTE>();
            try
            {
                lista = ObjCliente.ListarPaginado_Cliente(ORDEN_COLUMNA,ORDEN, FILAS, PAGINA, WHERE,  ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


    }
}
