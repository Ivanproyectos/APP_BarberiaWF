using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_M_Corte : Repository<V_M_CORTE>
    {
        public List<V_M_CORTE> Listar_Corte(ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_CORTE> lista = new List<V_M_CORTE>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().OrderByDescending(t => t.ID_CORTE).ToList();
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

        public List<V_M_CORTE> Buscar_Corte(V_M_CORTE entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_CORTE> lista = new List<V_M_CORTE>();
            auditoria.Limpiar();
            IQueryable<V_M_CORTE> query = Entities;

            try
            {
                if (!string.IsNullOrEmpty(entidad.PERSONAL))
                    query = query.Where(w => w.PERSONAL.Contains(entidad.PERSONAL));

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
                        query = query.Where(w => w.FEC_CORTE >= fechaNueva);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
                        {
                            DateTime fec = DateTime.Parse(fechaInicio);
                            query = query.Where(w => w.FEC_CORTE >= fec);
                        }
                        else if (fechaInicio != "" && fechaFin != "")
                        {
                            DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
                            DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
                            query = query.Where(w => w.FEC_CORTE >= fechaNuevaInicio && w.FEC_CORTE <= fechaNuevaFin);
                        }
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

        public V_M_CORTE Buscar_Corte(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_CORTE lista = new V_M_CORTE();
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_CORTE == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}