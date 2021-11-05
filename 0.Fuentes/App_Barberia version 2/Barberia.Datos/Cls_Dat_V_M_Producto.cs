using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_PRODUCTO : Repository<V_PRODUCTO>
    {
        public List<V_PRODUCTO> Listar_Producto(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{

                //    lista = db.V_PRODUCTO.OrderByDescending(t => t.ID_Producto).ToList();
                //}
                lista = GetAll().Where(x => x.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_PRODUCTO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        //public List<V_Producto> ListarPagina_Corte(out int PaginaTotal, int PaginaSelecionada=0)
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

        public List<V_PRODUCTO> Buscar_Producto(V_PRODUCTO entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            auditoria.Limpiar();
            IQueryable<V_PRODUCTO> query = Entities;

            try
            {
                query = query.Where(c => c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (!string.IsNullOrEmpty(entidad.COD_PRODUCTO))
                    query = query.Where(w => w.COD_PRODUCTO.Contains(entidad.COD_PRODUCTO));

                if (!string.IsNullOrEmpty(entidad.PRODUCTO))
                    query = query.Where(w => w.PRODUCTO.Contains(entidad.PRODUCTO));

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
 
                lista = query.ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<V_PRODUCTO> Buscar_Producto(V_PRODUCTO entidad, string fechaInicio, string fechaFin, string optReporte, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            auditoria.Limpiar();
            IQueryable<V_PRODUCTO> query = Entities;

            try
            {
                query = query.Where(c => c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (optReporte == "optStockProducto")
                {
                    query = query.Where(c => c.ID_CATEGORIA > 1);
                }
                else if (optReporte == "optProductoFaltante")
                {
                    query = query.Where(c => c.STOCK <= entidad.STOCK);
                }
                else if (optReporte == "optProductoVendido")
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

        public List<V_PRODUCTO> Buscar_Producto(V_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            auditoria.Limpiar();
            IQueryable<V_PRODUCTO> query = Entities;

            try
            {

                query = query.Where(c => c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (entidad.ID_CATEGORIA > 0)
                    query = query.Where(c => c.ID_CATEGORIA == entidad.ID_CATEGORIA);

                if (!string.IsNullOrEmpty(entidad.COD_PRODUCTO))
                    query = query.Where(w => w.COD_PRODUCTO.Contains(entidad.COD_PRODUCTO));

                if (!string.IsNullOrEmpty(entidad.PRODUCTO))
                    query = query.Where(w => w.PRODUCTO.Contains(entidad.PRODUCTO));

                if (!string.IsNullOrEmpty(entidad.DES_MARCA))
                    query = query.Where(w => w.DES_MARCA.Contains(entidad.DES_MARCA));


                lista = query.ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<V_PRODUCTO> Buscar_PopPupProducto(V_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PRODUCTO> lista = new List<V_PRODUCTO>();
            auditoria.Limpiar();

            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{

                //    lista = db.V_PRODUCTO.Where(x => x.COD_PRODUCTO.Contains(entidad.COD_PRODUCTO) || x.PRODUCTO.Contains(entidad.PRODUCTO) && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();
                //}
                //lista = FindAll(x => x.COD_PRODUCTO.Contains(entidad.COD_PRODUCTO) || x.PRODUCTO.Contains(entidad.PRODUCTO) || x.DES_MARCA.Contains(entidad.PRODUCTO)).Where(x => x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();
                lista = FindAll(x => x.COD_PRODUCTO.Contains(entidad.COD_PRODUCTO) || x.PRODUCTO.Contains(entidad.PRODUCTO) ).Where(x => x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public V_PRODUCTO Buscar_Producto(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_PRODUCTO lista = new V_PRODUCTO();
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_PRODUCTO == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}