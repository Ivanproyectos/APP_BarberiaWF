using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Tipo_Comprobante : Repository<T_TIPO_COMPROBANTE>
    {
        public List<T_TIPO_COMPROBANTE> Listar_Tipo_Comprobante(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_TIPO_COMPROBANTE> lista = new List<T_TIPO_COMPROBANTE>();
            try
            {
                lista = GetAll().OrderBy(x => x.ID_TIPO_COMPROBANTE).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }


    }
}
