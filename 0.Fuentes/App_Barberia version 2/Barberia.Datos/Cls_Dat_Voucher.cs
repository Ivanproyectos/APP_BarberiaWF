using Barberia.Entidad;
using System;

namespace Barberia.Datos
{
    public class Cls_Dat_Voucher : Repository<T_VOUCHER>
    {
        public T_VOUCHER Listar_Voucher(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_VOUCHER entidad = new T_VOUCHER();
            try
            {
                entidad = Get(1);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return entidad;
        }

        public void Actualizar_Voucher(int numero, string anio, ref Cls_Ent_Auditoria auditoria)
        {
            T_VOUCHER entidad = Find(x => x.ID_VOUCHER == 1);
            auditoria.Limpiar();
            try
            {
                entidad.NUMERO = numero;
                entidad.ANIO = anio;
                entidad.SERIE = anio;
                Update(entidad);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

    }
}
