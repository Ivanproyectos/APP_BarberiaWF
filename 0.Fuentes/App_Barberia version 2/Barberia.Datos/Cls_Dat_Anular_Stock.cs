using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Anular_Stock : Repository<T_STOCK_ANULAR>
    {
        public List<T_STOCK_ANULAR> Listar_Anular_Stock(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_STOCK_ANULAR> lista = new List<T_STOCK_ANULAR>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_STOCK_ANULAR> Buscar_Anular_Stock(T_STOCK_ANULAR entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_STOCK_ANULAR> lista = new List<T_STOCK_ANULAR>();
            auditoria.Limpiar();
            try
            {
                //lista = FindAll(c => c.PRODUCTO.Contains(entidad.PRODUCTO)).Where(x => x.FLG_ESTADO == "1").ToList();
                if (entidad.PRODUCTO != "")
                    lista = FindAll(c => c.PRODUCTO.Contains(entidad.PRODUCTO)).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_STOCK_ANULAR> BuscarReporte_Anular_Stock(string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_STOCK_ANULAR> lista = new List<T_STOCK_ANULAR>();
            auditoria.Limpiar();
            IQueryable<T_STOCK_ANULAR> query = Entities;
            try
            {
                if (string.IsNullOrEmpty(fechaInicio) && string.IsNullOrEmpty(fechaFin))
                {
                    string fecha = DateTime.Today.ToString("yyyy-MM") + "-01";
                    DateTime fechaNueva = DateTime.Parse(fecha);
                    query = query.Where(w => w.FEC_ANULAR >= fechaNueva);
                }
                else
                {
                    if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
                    {
                        DateTime fec = DateTime.Parse(fechaInicio);
                        query = query.Where(w => w.FEC_ANULAR >= fec);
                    }
                    else if (fechaInicio != "" && fechaFin != "")
                    {
                        DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
                        DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
                        query = query.Where(w => w.FEC_ANULAR >= fechaNuevaInicio && w.FEC_ANULAR <= fechaNuevaFin);
                    }
                }
                lista = query.ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Anular_Stock(T_STOCK_ANULAR entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            T_STOCK_ANULAR lista = new T_STOCK_ANULAR();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                    Add(entidad);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return exito;
        }


    }
}
