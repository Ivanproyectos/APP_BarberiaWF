using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_M_ORDEN_COMPRA : Repository<V_M_ORDEN_COMPRA>
    {
        public List<V_M_ORDEN_COMPRA> Listar_OrdenCompra(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_ORDEN_COMPRA> lista = new List<V_M_ORDEN_COMPRA>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().Where(x => x.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_ORDEN_COMPRA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        //public List<V_VENTA> ListarPagina_OrdenCompra(out int PaginaTotal, int PaginaSelecionada=0)
        //{
            
        //    using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
        //    {
        //        int cantidadRegistro = 20;
        //        decimal totalRegistro = db.V_OrdenCompra.Count();
        //        int totalPagina = (int)Math.Ceiling(totalRegistro / cantidadRegistro);
        //        PaginaTotal = totalPagina;
        //        return db.V_OrdenCompra.OrderByDescending(t => t.ID_DETALLE).Skip(PaginaSelecionada * cantidadRegistro)
        //            .Take(cantidadRegistro).ToList();
        //    }
        //}

        public List<V_M_ORDEN_COMPRA> Buscar_OrdenCompra(V_M_ORDEN_COMPRA entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_ORDEN_COMPRA> lista = new List<V_M_ORDEN_COMPRA>();
            auditoria.Limpiar();
            IQueryable<V_M_ORDEN_COMPRA> query = Entities;

            try
            {
                query = query.Where(c => c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (!string.IsNullOrEmpty(entidad.NUM_ORDEN_COMPRA))
                    query = query.Where(w => w.NUM_ORDEN_COMPRA.Contains(entidad.NUM_ORDEN_COMPRA));

                if (!string.IsNullOrEmpty(entidad.EMPRESA_EXTERNA))
                    query = query.Where(w => w.EMPRESA_EXTERNA == entidad.EMPRESA_EXTERNA);

                if (!string.IsNullOrEmpty(entidad.NUM_ORDEN_COMPRA))
                {
                    query = query.Where(w => w.NUM_ORDEN_COMPRA.Contains(entidad.NUM_ORDEN_COMPRA));
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
                lista = query.ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public V_M_ORDEN_COMPRA Buscar_OrdenCompra(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_ORDEN_COMPRA lista = new V_M_ORDEN_COMPRA();
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_ORDEN_COMPRA == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}