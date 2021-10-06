using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_Empresa
    {
        private Cls_Dat_V_Empresa obj = new Cls_Dat_V_Empresa();


        public List<V_EMPRESA> Listar_Empresa(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return obj.Listar_V_Empresa(ref auditoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
