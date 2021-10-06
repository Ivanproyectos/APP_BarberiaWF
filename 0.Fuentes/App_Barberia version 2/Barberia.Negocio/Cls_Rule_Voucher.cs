using Barberia.Datos;
using Barberia.Entidad;
using System;

namespace Barberia.Negocio
{
    public class Cls_Rule_Voucher
    {
        private Cls_Dat_Voucher obj = new Cls_Dat_Voucher();


        public T_VOUCHER Listar_Voucher(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return obj.Listar_Voucher(ref auditoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Actualizar_Voucher(int numero, string anio, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                obj.Actualizar_Voucher(numero, anio, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
