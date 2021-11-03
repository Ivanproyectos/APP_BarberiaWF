using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Serie
    {
        private Cls_Dat_M_Serie obj = new Cls_Dat_M_Serie();


        public T_M_SERIE Buscar_Serie(T_M_SERIE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return obj.Buscar_Serie(entidad, ref auditoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Actualizar_Serie(T_M_SERIE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                obj.Actualizar_Serie(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
