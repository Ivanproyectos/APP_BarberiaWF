using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_OrdenCompra
    {
        private Cls_Dat_OrdenCompra Obj = new Cls_Dat_OrdenCompra();

        public List<T_M_ORDEN_COMPRA> Listar_OrdenCompra(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_ORDEN_COMPRA> lista = new List<T_M_ORDEN_COMPRA>();
            try
            {
                lista = Obj.Listar_OrdenCompra(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_ORDEN_COMPRA ListarUno_OrdenCompra(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_ORDEN_COMPRA lista = new T_M_ORDEN_COMPRA();
            try
            {
                lista = Obj.ListarUno_OrdenCompra(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_OrdenCompra(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_OrdenCompra(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }


        public bool Eliminar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_OrdenCompra(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_ORDEN_COMPRA> Buscar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_ORDEN_COMPRA> lista = new List<T_M_ORDEN_COMPRA>();
            try
            {
                lista = Obj.Buscar_OrdenCompra(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


    }
}
