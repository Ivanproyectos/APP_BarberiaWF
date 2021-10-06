using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Venta
    {
        private Cls_Dat_Venta ObjVenta = new Cls_Dat_Venta();

        public List<T_M_VENTA> Listar_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_VENTA> lista = new List<T_M_VENTA>();
            try
            {
                lista = ObjVenta.Listar_Venta(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Venta(List<T_M_VENTA> entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjVenta.Insertar_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public int Insertar_M_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            int id;
            try
            {
                id = ObjVenta.Insertar_M_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public bool Actualizar_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjVenta.Actualizar_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public void Eliminar_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                ObjVenta.Eliminar_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T_M_VENTA> Buscar_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_VENTA> lista = new List<T_M_VENTA>();
            try
            {
                lista = ObjVenta.Buscar_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<T_M_VENTA> Buscar_Venta(string voucher, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_VENTA> lista = new List<T_M_VENTA>();
            try
            {
                lista = ObjVenta.Buscar_Venta(voucher, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public int Contar_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return ObjVenta.Conteo_Venta(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public string Numero_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return ObjVenta.Numero_Venta(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Anular_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return ObjVenta.Anular_Venta(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
