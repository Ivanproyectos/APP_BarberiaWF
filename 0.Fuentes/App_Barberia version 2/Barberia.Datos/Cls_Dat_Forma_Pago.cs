using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Forma_Pago : Repository<T_FORMA_PAGO>
    {
        public List<T_FORMA_PAGO> Listar_FormaPago(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_FORMA_PAGO> lista = new List<T_FORMA_PAGO>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().ToList();

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        

    }
}
