using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Distrito
    {
       
        private Cls_Dat_Distrito objeto = new Cls_Dat_Distrito();

        public List<T_M_DISTRITO> Listar_Distrito(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_DISTRITO> lista = new List<T_M_DISTRITO>();
            try
            {
                lista = objeto.Listar_Distrito(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<T_M_DISTRITO> Buscar_Distrito(string codDepartamento, string codProvincia, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_DISTRITO> lista = new List<T_M_DISTRITO>();
            try
            {
                lista = objeto.Buscar_Distrito(codDepartamento, codProvincia, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
