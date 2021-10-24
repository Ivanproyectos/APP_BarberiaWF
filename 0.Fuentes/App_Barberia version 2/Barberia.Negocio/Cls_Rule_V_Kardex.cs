using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_V_Kardex
    {

        private Cls_Dat_V_Kardex VistaKardex = new Cls_Dat_V_Kardex();


        public V_KARDEX Listar_Ultimo_Kardex(int idProducto, ref Cls_Ent_Auditoria auditoria)
        {
            V_KARDEX lista = new V_KARDEX();
            try
            {
                lista = VistaKardex.Listar_Ultimo_Kardex(idProducto, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<V_KARDEX> Buscar_Kardex(V_KARDEX entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_KARDEX> lista = new List<V_KARDEX>();
            try
            {
                lista = VistaKardex.Buscar_Kardex(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
