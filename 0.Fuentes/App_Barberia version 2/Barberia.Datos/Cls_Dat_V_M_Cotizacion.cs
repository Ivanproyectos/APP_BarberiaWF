using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_M_Cotizacion : Repository<V_M_COTIZACION>
    {
        public List<V_M_COTIZACION> Listar_Cotizacion(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_COTIZACION> lista = new List<V_M_COTIZACION>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().Where(x => x.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_COTIZACION).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        //public List<V_VENTA> ListarPagina_Cotizacion(out int PaginaTotal, int PaginaSelecionada=0)
        //{
            
        //    using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
        //    {
        //        int cantidadRegistro = 20;
        //        decimal totalRegistro = db.V_Cotizacion.Count();
        //        int totalPagina = (int)Math.Ceiling(totalRegistro / cantidadRegistro);
        //        PaginaTotal = totalPagina;
        //        return db.V_Cotizacion.OrderByDescending(t => t.ID_DETALLE).Skip(PaginaSelecionada * cantidadRegistro)
        //            .Take(cantidadRegistro).ToList();
        //    }
        //}

        public List<V_M_COTIZACION> Buscar_Cotizacion(V_M_COTIZACION entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_COTIZACION> lista = new List<V_M_COTIZACION>();
            auditoria.Limpiar();
            IQueryable<V_M_COTIZACION> query = Entities;

            try
            {
                

                if (!string.IsNullOrEmpty(entidad.EMPRESA_EXTERNA))
                    query = query.Where(w => w.EMPRESA_EXTERNA.Contains(entidad.EMPRESA_EXTERNA));


                if (!string.IsNullOrEmpty(entidad.NUM_COTIZACION))
                {
                    query = query.Where(w => w.NUM_COTIZACION.Contains(entidad.NUM_COTIZACION));
                }
                else
                {
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
                }
                //query = query;
                lista = query.Where(c => c.ID_EMPRESA == entidad.ID_EMPRESA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public V_M_COTIZACION Buscar_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_COTIZACION lista = new V_M_COTIZACION();
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_COTIZACION == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}