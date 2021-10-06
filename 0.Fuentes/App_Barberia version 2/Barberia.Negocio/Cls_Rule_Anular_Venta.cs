using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Anular_Venta
    {
        private Cls_Dat_Anular_Venta Obj = new Cls_Dat_Anular_Venta();

        public List<T_ANULAR_VENTA> Listar_Anular_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_VENTA> lista = new List<T_ANULAR_VENTA>();
            try
            {
                lista = Obj.Listar_Anular_Venta(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Anular_Venta(T_ANULAR_VENTA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Anular_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_ANULAR_VENTA> Buscar_Anular_Venta(T_ANULAR_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_VENTA> lista = new List<T_ANULAR_VENTA>();
            try
            {
                lista = Obj.Buscar_Anular_Venta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<T_ANULAR_VENTA> BuscarReporte_Anular_Venta(string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_VENTA> lista = new List<T_ANULAR_VENTA>();
            try
            {
                lista = Obj.BuscarReporte_Anular_Venta(fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
