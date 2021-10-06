using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_M_Parametro : Repository<V_M_PARAMETRO>
    {
        public List<V_M_PARAMETRO> Listar_Parametro(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_PARAMETRO> lista = new List<V_M_PARAMETRO>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().Where(x => x.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_PARAMETRO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        //public List<V_VENTA> ListarPagina_Parametro(out int PaginaTotal, int PaginaSelecionada=0)
        //{
            
        //    using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
        //    {
        //        int cantidadRegistro = 20;
        //        decimal totalRegistro = db.V_Parametro.Count();
        //        int totalPagina = (int)Math.Ceiling(totalRegistro / cantidadRegistro);
        //        PaginaTotal = totalPagina;
        //        return db.V_Parametro.OrderByDescending(t => t.ID_DETALLE).Skip(PaginaSelecionada * cantidadRegistro)
        //            .Take(cantidadRegistro).ToList();
        //    }
        //}

        public List<V_M_PARAMETRO> Buscar_Parametro(V_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_M_PARAMETRO> lista = new List<V_M_PARAMETRO>();
            auditoria.Limpiar();
            IQueryable<V_M_PARAMETRO> query = Entities;

            try
            {
                if (!string.IsNullOrEmpty(entidad.COD_PARAMETRO))
                    query = query.Where(w => w.COD_PARAMETRO.Contains(entidad.COD_PARAMETRO));

                if (!string.IsNullOrEmpty(entidad.DESC_PARAMETRO))
                    query = query.Where(w => w.DESC_PARAMETRO.Contains(entidad.DESC_PARAMETRO));

                if (!string.IsNullOrEmpty(entidad.TIPO_PARAMETRO))
                    query = query.Where(w => w.TIPO_PARAMETRO == entidad.TIPO_PARAMETRO);


                //if (!string.IsNullOrEmpty(entidad.VOUCHER))
                //{

                //    query = query.Where(w => w.VOUCHER == entidad.VOUCHER);
                //}
                //else
                //{
                //    if (string.IsNullOrEmpty(fechaInicio) && string.IsNullOrEmpty(fechaFin))
                //    {
                //        string fecha = DateTime.Today.ToString("yyyy-MM") + "-01";
                //        DateTime fechaNueva = DateTime.Parse(fecha);
                //        query = query.Where(w => w.FEC_Parametro >= fechaNueva);
                //    }
                //    else
                //    {
                //        if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
                //        {
                //            DateTime fec = DateTime.Parse(fechaInicio);
                //            query = query.Where(w => w.FEC_Parametro >= fec);
                //        }
                //        else if (fechaInicio != "" && fechaFin != "")
                //        {
                //            DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
                //            DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
                //            query = query.Where(w => w.FEC_Parametro >= fechaNuevaInicio && w.FEC_Parametro <= fechaNuevaFin);
                //        }
                //    }
                //}
                lista = query.Where(x => x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public V_M_PARAMETRO Buscar_Parametro(int id, ref Cls_Ent_Auditoria auditoria)
        {
            V_M_PARAMETRO lista = new V_M_PARAMETRO();
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_PARAMETRO == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}