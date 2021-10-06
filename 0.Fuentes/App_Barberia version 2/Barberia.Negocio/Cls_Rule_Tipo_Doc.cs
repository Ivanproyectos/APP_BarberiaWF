using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Tipo_Doc
    {
       
        private Cls_Dat_Tipo_Doc objeto = new Cls_Dat_Tipo_Doc();

        public List<T_TIPO_DOCUMENTO> Listar_Tipo_Doc(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_TIPO_DOCUMENTO> lista = new List<T_TIPO_DOCUMENTO>();
            try
            {
                lista = objeto.Listar_Tipo_Doc(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<T_TIPO_DOCUMENTO> Buscar_Tipo_Doc(string codDepartamento, string codProvincia, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_TIPO_DOCUMENTO> lista = new List<T_TIPO_DOCUMENTO>();
            try
            {
                lista = objeto.Buscar_Tipo_Doc(codDepartamento, codProvincia, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
