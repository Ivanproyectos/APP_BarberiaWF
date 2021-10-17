using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Moneda
    {
       
        private Cls_Dat_M_Moneda objeto = new Cls_Dat_M_Moneda();

        public List<T_M_MONEDA> Listar_Moneda(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_MONEDA> lista = new List<T_M_MONEDA>();
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
