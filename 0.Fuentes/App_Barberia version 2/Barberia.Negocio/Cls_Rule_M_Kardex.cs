using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Kardex
    {
       
        private Cls_Dat_M_Kardex objeto = new Cls_Dat_M_Kardex();

        public bool Insertar_Kardex(T_M_KARDEX entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = true;
            try
            {
                exito = objeto.Insertar_Kardex(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

    }
}
