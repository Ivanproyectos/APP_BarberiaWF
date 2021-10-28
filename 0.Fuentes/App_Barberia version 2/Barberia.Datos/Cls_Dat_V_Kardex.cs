using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_Kardex : Repository<V_KARDEX>
    {
        public V_KARDEX Listar_Ultimo_Kardex(int idProducto, ref Cls_Ent_Auditoria auditoria)
        {
            V_KARDEX entidad = new V_KARDEX();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{

                //    lista = db.V_KARDEX.fial.OrderByDescending(t => t.ID_KARDEX).ToList();
                //}
                entidad = FindAll(x => x.ID_PRODUCTO == idProducto).LastOrDefault();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }


        public List<V_KARDEX> Buscar_Kardex(V_KARDEX entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_KARDEX> lista = new List<V_KARDEX>();
            auditoria.Limpiar();
            IQueryable<V_KARDEX> query = Entities;

            try
            {


                if (!string.IsNullOrEmpty(entidad.PRODUCTO))
                    query = query.Where(w => w.PRODUCTO == entidad.PRODUCTO);



                if (string.IsNullOrEmpty(fechaInicio) && string.IsNullOrEmpty(fechaFin))
                {
                    string fecha = DateTime.Today.ToString("yyyy-MM") + "-01";
                    DateTime fechaNueva = DateTime.Parse(fecha);
                    query = query.Where(w => w.FEC_CREACION >= fechaNueva);
                }
                else
                {
                    if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
                    {
                        DateTime fec = DateTime.Parse(fechaInicio);
                        query = query.Where(w => w.FEC_CREACION >= fec);
                    }
                    else if (fechaInicio != "" && fechaFin != "")
                    {
                        DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
                        DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
                        query = query.Where(w => w.FEC_CREACION >= fechaNuevaInicio && w.FEC_CREACION <= fechaNuevaFin);
                    }
                }

                lista = query.Where(w => w.ID_EMPRESA == entidad.ID_EMPRESA).OrderByDescending(x => x.FEC_CREACION).ToList();
                //lista = query.ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}