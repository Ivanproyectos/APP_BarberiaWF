using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_Cotizacion : Repository<V_COTIZACION>
    {
        public List<V_COTIZACION> Listar_V_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_COTIZACION> lista = new List<V_COTIZACION>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{

                //    lista = db.V_COTIZACION.OrderByDescending(t => t.ID_COTIZACION).ToList();
                //}
                lista = FindAll(x => x.ID_COTIZACION == id).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        //public List<V_COTIZACION> ListarPagina_Corte(out int PaginaTotal, int PaginaSelecionada=0)
        //{
            
        //    using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
        //    {
        //        int cantidadRegistro = 20;
        //        decimal totalRegistro = db.V_CORTE.Count();
        //        int totalPagina = (int)Math.Ceiling(totalRegistro / cantidadRegistro);
        //        PaginaTotal = totalPagina;
        //        return db.V_CORTE.OrderByDescending(t => t.ID_DETALLE).Skip(PaginaSelecionada * cantidadRegistro)
        //            .Take(cantidadRegistro).ToList();
        //    }
        //}

        //public List<V_COTIZACION> BuscarV_Cotizacion(V_COTIZACION entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        //{
        //    List<V_COTIZACION> lista = new List<V_COTIZACION>();
        //    auditoria.Limpiar();
        //    IQueryable<V_COTIZACION> query = Entities;
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(entidad.PERSONAL))
        //            query = query.Where(w => w.PERSONAL.Contains(entidad.PERSONAL));

        //        //if (!string.IsNullOrEmpty(entidad.CLIENTE))
        //        //    query = query.Where(w => w.CLIENTE.Contains(entidad.CLIENTE));

        //        if (entidad.MES > 0)
        //        {
        //            query = query.Where(w => w.MES == entidad.MES);
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(entidad.VOUCHER))
        //            {
        //                //int conteo = int.Parse(entidad.VOUCHER);
        //                //string numero;
        //                //numero = ("00000000" + conteo).Substring(conteo.ToString().Length, 8);
        //                query = query.Where(w => w.VOUCHER == entidad.VOUCHER);
        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(fechaInicio) && string.IsNullOrEmpty(fechaFin))
        //                {
        //                    string fecha = DateTime.Today.ToString("yyyy-MM") + "-01";
        //                    DateTime fechaNueva = DateTime.Parse(fecha);
        //                    query = query.Where(w => w.FECV_Cotizacion >= fechaNueva);
        //                }
        //                else
        //                {
        //                    if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
        //                    {
        //                        DateTime fec = DateTime.Parse(fechaInicio);
        //                        query = query.Where(w => w.FECV_Cotizacion >= fec);
        //                    }
        //                    else if (fechaInicio != "" && fechaFin != "")
        //                    {
        //                        DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
        //                        DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
        //                        query = query.Where(w => w.FECV_Cotizacion >= fechaNuevaInicio && w.FECV_Cotizacion <= fechaNuevaFin);
        //                    }
        //                }
        //            }

        //        }

        //        if (entidad.ANIO > 0)
        //            query = query.Where(w => w.ANIO == entidad.ANIO);

        //        //query = query.OrderByDescending(o => o.IDV_Cotizacion);

        //        lista = query.ToList();
        //    }
        //    catch (Exception ex)
        //    {

        //        auditoria.Error(ex);
        //    }
            
            
        //    return lista;
        //}

        //public List<V_COTIZACION> BuscarV_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        //{
        //    auditoria.Limpiar();
        //    List<V_COTIZACION> lista = new List<V_COTIZACION>();
        //    try
        //    {
        //        lista = FindAll(x => x.IDV_Cotizacion == id).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        auditoria.Error(ex);
        //    }
        //    return lista;
        //}

    }
}
