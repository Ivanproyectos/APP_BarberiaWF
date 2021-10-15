using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Tipo_Afectacion : Repository<T_TIPO_AFECTACION>
    {
        public List<T_TIPO_AFECTACION> Listar_Moneda(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_TIPO_AFECTACION> lista = new List<T_TIPO_AFECTACION>();
            try
            {
                lista = GetAll().OrderBy(x => x.ID_AFECTACION).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }


    }
}
