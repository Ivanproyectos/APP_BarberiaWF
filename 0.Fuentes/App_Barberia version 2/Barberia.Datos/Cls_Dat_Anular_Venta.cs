using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Anular_Venta : Repository<T_ANULAR_VENTA>
    {
        public List<T_ANULAR_VENTA> Listar_Anular_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_VENTA> lista = new List<T_ANULAR_VENTA>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_ANULAR_VENTA.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO).ToList();
                //}
                lista = GetAll().ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_ANULAR_VENTA> Buscar_Anular_Venta(T_ANULAR_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_VENTA> lista = new List<T_ANULAR_VENTA>();
            auditoria.Limpiar();
            try
            {
                //lista = FindAll(c => c.PRODUCTO.Contains(entidad.PRODUCTO)).Where(x => x.FLG_ESTADO == "1").ToList();
                if (entidad.VOUCHER != "")
                    lista = FindAll(c => c.VOUCHER.Contains(entidad.VOUCHER)).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }
        public List<T_ANULAR_VENTA> BuscarReporte_Anular_Venta(string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ANULAR_VENTA> lista = new List<T_ANULAR_VENTA>();
            auditoria.Limpiar();
            IQueryable<T_ANULAR_VENTA> query = Entities;
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

        public bool Insertar_Anular_Venta(T_ANULAR_VENTA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            T_ANULAR_VENTA lista = new T_ANULAR_VENTA();
            auditoria.Limpiar();
            bool exito = true;
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
