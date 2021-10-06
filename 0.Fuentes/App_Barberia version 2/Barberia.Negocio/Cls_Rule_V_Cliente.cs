using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_Cliente
    {
       
        private Cls_Dat_V_Cliente objeto = new Cls_Dat_V_Cliente();

        public List<V_CLIENTE> Listar_V_Cliente(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_CLIENTE> lista = new List<V_CLIENTE>();
            try
            {
                lista = objeto.Listar_V_Cliente(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<V_CLIENTE> Buscar_V_Cliente(V_CLIENTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_CLIENTE> lista = new List<V_CLIENTE>();
            try
            {
                lista = objeto.Buscar_V_Cliente(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public V_CLIENTE ListarUno_V_Cliente(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_CLIENTE lista = new V_CLIENTE();
            try
            {
                lista = objeto.ListarUno_V_Cliente(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
