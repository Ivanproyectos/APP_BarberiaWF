using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Departamento
    {
       
        private Cls_Dat_Departamento objeto = new Cls_Dat_Departamento();

        public List<T_M_DEPARTAMENTO> Listar_Departamento(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_DEPARTAMENTO> lista = new List<T_M_DEPARTAMENTO>();
            try
            {
                lista = objeto.Listar_Departamento(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<T_M_DEPARTAMENTO> Buscar_Departamento(string entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_DEPARTAMENTO> lista = new List<T_M_DEPARTAMENTO>();
            try
            {
                lista = objeto.Buscar_Departamento(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
