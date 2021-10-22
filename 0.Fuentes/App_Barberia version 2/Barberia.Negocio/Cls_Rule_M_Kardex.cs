using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Kardex
    {
       
        private Cls_Dat_M_Kardex objeto = new Cls_Dat_M_Kardex();

        public int Insertar_Kardex(T_M_KARDEX entidad, ref Cls_Ent_Auditoria auditoria)
        {
            int id ;
            try
            {
                id = objeto.Insertar_Kardex(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

    }
}
