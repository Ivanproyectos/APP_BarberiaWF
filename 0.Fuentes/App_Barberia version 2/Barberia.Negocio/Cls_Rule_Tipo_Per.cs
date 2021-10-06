using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Tipo_Per
    {
       
        private Cls_Dat_Tipo_Per objeto = new Cls_Dat_Tipo_Per();

        public List<T_TIPO_PERSONA> Listar_Tipo_Per(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_TIPO_PERSONA> lista = new List<T_TIPO_PERSONA>();
            try
            {
                lista = objeto.Listar_Tipo_Per(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<T_TIPO_PERSONA> Buscar_Tipo_Per(string codDepartamento, string codProvincia, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_TIPO_PERSONA> lista = new List<T_TIPO_PERSONA>();
            try
            {
                lista = objeto.Buscar_Tipo_Per(codDepartamento, codProvincia, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
