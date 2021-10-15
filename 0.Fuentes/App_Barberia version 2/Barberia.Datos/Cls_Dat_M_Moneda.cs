using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_M_Moneda : Repository<T_M_MONEDA>
    {
        public List<T_M_MONEDA> Listar_Moneda(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_MONEDA> lista = new List<T_M_MONEDA>();
            try
            {
                lista = GetAll().OrderBy(x => x.ID_MONEDA).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }


    }
}
