using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_Corte : Repository<V_CORTE>
    {
        public List<V_CORTE> Listar_Corte(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<V_CORTE> lista = new List<V_CORTE>();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {

                    lista = db.V_CORTE.OrderByDescending(t => t.ID_CORTE).ToList();
                }
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public List<V_CORTE> ListarPagina_Corte(out int PaginaTotal, ref Cls_Ent_Auditoria auditoria, int PaginaSelecionada=0)
        {
            auditoria.Limpiar();
            List<V_CORTE> lista = new List<V_CORTE>();
            int totalPagina = 0;
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    int cantidadRegistro = 20;
                    decimal totalRegistro = db.V_CORTE.Count();
                    totalPagina = (int)Math.Ceiling(totalRegistro / cantidadRegistro);
                    
                    lista = db.V_CORTE.OrderByDescending(t => t.ID_DETALLE).Skip(PaginaSelecionada * cantidadRegistro)
                        .Take(cantidadRegistro).ToList();
                }
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            PaginaTotal = totalPagina;
            return lista;
        }

        public List<V_CORTE> Buscar_Corte(V_CORTE entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_CORTE> lista = new List<V_CORTE>();
            auditoria.Limpiar();
            IQueryable<V_CORTE> query = Entities;

            try
            {
                if (!string.IsNullOrEmpty(entidad.DES_SERVICIO))
                    query = query.Where(w => w.DES_SERVICIO == entidad.DES_SERVICIO);

                if (!string.IsNullOrEmpty(entidad.PERSONAL))
                    query = query.Where(w => w.PERSONAL.Contains(entidad.PERSONAL));

                if (!string.IsNullOrEmpty(entidad.CLIENTE))
                    query = query.Where(w => w.CLIENTE.Contains(entidad.CLIENTE));

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

                }

                if (entidad.ANIO > 0)
                    query = query.Where(w => w.ANIO == entidad.ANIO);

                query = query.OrderByDescending(o => o.ID_DETALLE);

                lista = query.ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }



    }
}
