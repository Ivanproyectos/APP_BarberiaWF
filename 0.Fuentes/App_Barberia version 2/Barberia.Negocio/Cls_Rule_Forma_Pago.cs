using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Forma_Pago
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_Forma_Pago obj = new Cls_Dat_Forma_Pago();

        public List<T_FORMA_PAGO> Listar_FormaPago(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_FORMA_PAGO> lista = new List<T_FORMA_PAGO>();
            try
            {
                lista = obj.Listar_FormaPago(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

       

    }
}
