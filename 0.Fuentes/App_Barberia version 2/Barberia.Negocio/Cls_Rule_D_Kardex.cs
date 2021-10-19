using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_D_Kardex
    {
       
        private Cls_Dat_D_Kardex objeto = new Cls_Dat_D_Kardex();

        public bool Insertar_D_Kardex(T_D_KARDEX entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = true;
            try
            {
                exito = objeto.Insertar_D_Kardex(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

    }
}
