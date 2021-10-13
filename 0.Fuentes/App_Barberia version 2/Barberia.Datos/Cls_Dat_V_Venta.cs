using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_Venta : Repository<V_VENTA>
    {
        public List<V_VENTA> Listar_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            List<V_VENTA> lista = new List<V_VENTA>();
            auditoria.Limpiar();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {

                    lista = db.V_VENTA.OrderByDescending(t => t.ID_VENTA).ToList();
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

        public List<V_VENTA> Buscar_Venta(V_VENTA entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_VENTA> lista = new List<V_VENTA>();
            auditoria.Limpiar();
            IQueryable<V_VENTA> query = Entities;
            try
            {
                if (!string.IsNullOrEmpty(entidad.PERSONAL))
                    query = query.Where(w => w.PERSONAL.Contains(entidad.PERSONAL));

                //if (!string.IsNullOrEmpty(entidad.CLIENTE))
                //    query = query.Where(w => w.CLIENTE.Contains(entidad.CLIENTE));

                if (entidad.MES > 0)
                {
                    query = query.Where(w => w.MES == entidad.MES);
                }
                else
                {
                    if (!string.IsNullOrEmpty(entidad.VOUCHER))
                    {
                        //int conteo = int.Parse(entidad.VOUCHER);
                        //string numero;
                        //numero = ("00000000" + conteo).Substring(conteo.ToString().Length, 8);
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

                }

                if (entidad.ANIO > 0)
                    query = query.Where(w => w.ANIO == entidad.ANIO);

                //query = query.OrderByDescending(o => o.ID_VENTA);

                lista = query.Where(w => w.ID_EMPRESA == entidad.ID_EMPRESA).OrderByDescending(x => x.FEC_VENTA).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            
            
            return lista;
        }

        public List<V_VENTA> Buscar_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<V_VENTA> lista = new List<V_VENTA>();
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
