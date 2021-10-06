using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_C_Anular
    {
        private Cls_Dat_C_Anular obj = new Cls_Dat_C_Anular();


        public List<T_C_ANULAR> Listar_C_Anular(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return obj.Listar_C_Anular(ref auditoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Actualizar_C_Anular(int id, string numero, DateTime fecha, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                obj.Actualizar_C_Anular(id, numero, fecha, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void Insertar_Voucher(T_BOLETA entidad) 
        //{

        //    try
        //    {
        //        obj.Insertar_VOUCHER(entidad);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public T_BOLETA Buscar_Voucher(string numero)
        //{
        //    T_BOLETA lista = new T_BOLETA();
        //    try
        //    {
        //        lista = obj.Buscar_VOUCHER(numero);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

    }
}
