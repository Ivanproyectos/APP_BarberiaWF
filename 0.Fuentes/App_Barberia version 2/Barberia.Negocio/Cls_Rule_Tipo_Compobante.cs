using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Tipo_Compobante
    {
       
        private Cls_Dat_Tipo_Comprobante objeto = new Cls_Dat_Tipo_Comprobante();

        public List<T_TIPO_COMPROBANTE> Listar_Tipo_Comprobante(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_TIPO_COMPROBANTE> lista = new List<T_TIPO_COMPROBANTE>();
            try
            {
                lista = objeto.Listar_Tipo_Comprobante(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
