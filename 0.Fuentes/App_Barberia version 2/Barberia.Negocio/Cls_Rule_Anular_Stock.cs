using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Anular_Stock
    {
        private Cls_Dat_Anular_Stock Obj = new Cls_Dat_Anular_Stock();

        public List<T_STOCK_ANULAR> Listar_Anular_Stock(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_STOCK_ANULAR> lista = new List<T_STOCK_ANULAR>();
            try
            {
                lista = Obj.Listar_Anular_Stock(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Anular_Stock(T_STOCK_ANULAR entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Anular_Stock(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }


        public List<T_STOCK_ANULAR> Buscar_Anular_Stock(T_STOCK_ANULAR entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_STOCK_ANULAR> lista = new List<T_STOCK_ANULAR>();
            try
            {
                lista = Obj.Buscar_Anular_Stock(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<T_STOCK_ANULAR> BuscarReporte_Anular_Stock(string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_STOCK_ANULAR> lista = new List<T_STOCK_ANULAR>();
            try
            {
                lista = Obj.BuscarReporte_Anular_Stock(fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


    }
}
