using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Tipo_Afectacion
    {
       
        private Cls_Dat_Tipo_Afectacion objeto = new Cls_Dat_Tipo_Afectacion();

        public List<T_TIPO_AFECTACION> Listar_Tipo_Comprobante(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_TIPO_AFECTACION> lista = new List<T_TIPO_AFECTACION>();
            try
            {
                lista = objeto.Listar_Moneda(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
