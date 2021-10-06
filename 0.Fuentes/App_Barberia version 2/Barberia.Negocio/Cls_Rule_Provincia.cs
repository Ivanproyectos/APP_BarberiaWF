using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Provincia
    {
       
        private Cls_Dat_Provincia objeto = new Cls_Dat_Provincia();

        public List<T_M_PROVINCIA> Listar_Provincia(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PROVINCIA> lista = new List<T_M_PROVINCIA>();
            try
            {
                lista = objeto.Listar_Provincia(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<T_M_PROVINCIA> Buscar_Provincia(string codDepartamento, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PROVINCIA> lista = new List<T_M_PROVINCIA>();
            try
            {
                lista = objeto.Buscar_Provincia(codDepartamento, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
