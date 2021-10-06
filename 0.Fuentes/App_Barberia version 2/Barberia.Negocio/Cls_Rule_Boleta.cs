using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Boleta
    {
        private Cls_Dat_Boleta obj = new Cls_Dat_Boleta();


        public T_BOLETA Listar_Boleta(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return obj.Listar_Boleta(ref auditoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Actualizar_Boleta(int numero, string anio, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                obj.Actualizar_Boleta(numero, anio, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
