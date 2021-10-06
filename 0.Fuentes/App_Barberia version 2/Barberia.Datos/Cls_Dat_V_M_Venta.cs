using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_M_Venta : Repository<V_M_VENTA>
    {
        public List<V_M_VENTA> Listar_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_VENTA> lista = new List<V_M_VENTA>();
            auditoria.Limpiar();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {

                    lista = db.V_M_VENTA.OrderByDescending(t => t.ID_VENTA).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        //public List<V_VENTA> ListarPagina_Corte(out int PaginaTotal, int PaginaSelecionada=0)
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

        public List<V_M_VENTA> Buscar_Venta(V_M_VENTA entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_VENTA> lista = new List<V_M_VENTA>();
            auditoria.Limpiar();
            IQueryable<V_M_VENTA> query = Entities;

            try
            {
                //if (!string.IsNullOrEmpty(entidad.PERSONAL))
                //    query = query.Where(w => w.PERSONAL.Contains(entidad.PERSONAL));

                if (!string.IsNullOrEmpty(entidad.CLIENTE))
                    query = query.Where(w => w.CLIENTE == entidad.CLIENTE);


                if (!string.IsNullOrEmpty(entidad.VOUCHER))
                {

                    query = query.Where(w => w.VOUCHER == entidad.VOUCHER);
                }
                else
                {
                    if (string.IsNullOrEmpty(fechaInicio) && string.IsNullOrEmpty(fechaFin))
                    {
                        string fecha = DateTime.Today.ToString("yyyy-MM") + "-01";
                        DateTime fechaNueva = DateTime.Parse(fecha);
                        query = query.Where(w => w.FEC_VENTA >= fechaNueva);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
                        {
                            DateTime fec = DateTime.Parse(fechaInicio);
                            query = query.Where(w => w.FEC_VENTA >= fec);
                        }
                        else if (fechaInicio != "" && fechaFin != "")
                        {
                            DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
                            DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
                            query = query.Where(w => w.FEC_VENTA >= fechaNuevaInicio && w.FEC_VENTA <= fechaNuevaFin);
                        }
                    }
                }
                lista = query.OrderByDescending(x => x.FEC_VENTA).ToList();
                //lista = query.ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<V_M_VENTA> Buscar_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_VENTA> lista = new List<V_M_VENTA>();
            auditoria.Limpiar();
            try
            {
                lista = FindAll(x => x.ID_VENTA == id).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}