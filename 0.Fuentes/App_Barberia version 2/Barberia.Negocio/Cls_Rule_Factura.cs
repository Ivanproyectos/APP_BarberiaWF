using Barberia.Datos;
using Barberia.Entidad;
using System;

namespace Barberia.Negocio
{
    public class Cls_Rule_Factura
    {
        private Cls_Dat_Factura Obj = new Cls_Dat_Factura();

        public T_FACTURA Listar_Factura(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return Obj.Listar_Factura(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Factura(int numero, string anio, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                Obj.Actualizar_Factura(numero, anio, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
