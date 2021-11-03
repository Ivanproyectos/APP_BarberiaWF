using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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

                if (entidad.ID_MONEDA > 0)
                    query = query.Where(w => w.ID_MONEDA == entidad.ID_MONEDA);

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
                lista = query.Where(w => w.ID_EMPRESA == entidad.ID_EMPRESA).OrderByDescending(x => x.FEC_VENTA).ToList();
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

        public List<Cls_Ent_V_Venta> ListarPaginado_Venta(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            var TABLA = "";
            auditoria.Limpiar();
            DbDataReader dr = null;
            List<Cls_Ent_V_Venta> lista = new List<Cls_Ent_V_Venta>();
            try
            {


                //using (var command = _context.GetStoredProcedureCommand("USP_PRODUCTO_PAGINADO",
                //new SqlParameter("@PI_PAGINA", PAGINA),
                //new SqlParameter("@PI_NROREGISTROS", FILAS),
                //new SqlParameter("@PI_ORDEN_COLUMNA", ORDEN_COLUMNA),
                //new SqlParameter("@PI_ORDEN", ORDEN),
                //new SqlParameter("@PI_WHERE", @WHERE),
                //new SqlParameter("@PI_TABLA", TABLA),
                //new SqlParameter
                //{
                //    ParameterName = "@PO_CUENTA",
                //    DbType = DbType.Int32,
                //    Direction = System.Data.ParameterDirection.Output
                //}))
                //{

                //    dr = command.ExecuteReader();
                //    int pos_ID_EMPRESA = dr.GetOrdinal("ID_EMPRESA");
                //    int pos_ID_VENTA = dr.GetOrdinal("ID_VENTA");
                //    int pos_VOUCHER = dr.GetOrdinal("VOUCHER");
                //    int pos_CLIENTE = dr.GetOrdinal("CLIENTE");
                //    int pos_TOTAL_IMPORTE = dr.GetOrdinal("TOTAL_IMPORTE");
                //    int pos_IGV = dr.GetOrdinal("IGV");
                //    int pos_DESCT_TOTAL = dr.GetOrdinal("DESCT_TOTAL");
                //    int pos_TOTAL = dr.GetOrdinal("TOTAL");
                //    int pos_EFECTIVO = dr.GetOrdinal("EFECTIVO");
                //    int pos_VUELTO = dr.GetOrdinal("VUELTO");
                //    int pos_USUARIO = dr.GetOrdinal("USUARIO");
                //    int pos_FEC_VENTA = dr.GetOrdinal("FEC_VENTA");
                //    int pos_CODIGO_ARCHIVO = dr.GetOrdinal("CODIGO_ARCHIVO");
                //    int pos_EXTENSION_ARCHIVO = dr.GetOrdinal("EXTENSION_ARCHIVO");

                //    if (dr.HasRows)
                //    {
                //        while (dr.Read())
                //        {
                //            Cls_Ent_V_Venta entidad = new Cls_Ent_V_Venta();


                //            if (dr.IsDBNull(pos_ID_EMPRESA)) entidad.ID_EMPRESA = 0;
                //            else entidad.ID_EMPRESA = int.Parse(dr[pos_ID_EMPRESA].ToString());

                //            if (dr.IsDBNull(pos_ID_VENTA)) entidad.ID_VENTA = 0;
                //            else entidad.ID_VENTA = int.Parse(dr[pos_ID_VENTA].ToString());

                //            if (dr.IsDBNull(pos_VOUCHER)) entidad.VOUCHER = "";
                //            else entidad.VOUCHER = dr[pos_VOUCHER].ToString();

                //            if (dr.IsDBNull(pos_TOTAL_IMPORTE)) entidad.TOTAL_IMPORTE = 0;
                //            else entidad.TOTAL_IMPORTE = decimal.Parse(dr[pos_TOTAL_IMPORTE].ToString());

                //            if (dr.IsDBNull(pos_IGV)) entidad.IGV = 0;
                //            else entidad.IGV = decimal.Parse(dr[pos_IGV].ToString());

                //            if(dr.IsDBNull(pos_DESCT_TOTAL)) entidad.DESCT_TOTAL = 0;
                //            else entidad.DESCT_TOTAL = decimal.Parse(dr[pos_DESCT_TOTAL].ToString());

                //            if (dr.IsDBNull(pos_TOTAL)) entidad.TOTAL = 0;
                //            else entidad.TOTAL = decimal.Parse(dr[pos_TOTAL].ToString());

                //            if (dr.IsDBNull(pos_EFECTIVO)) entidad.EFECTIVO = 0;
                //            else entidad.EFECTIVO = decimal.Parse(dr[pos_EFECTIVO].ToString());

                //            if (dr.IsDBNull(pos_VUELTO)) entidad.VUELTO = 0;
                //            else entidad.VUELTO = decimal.Parse(dr[pos_VUELTO].ToString());

                //            if (dr.IsDBNull(pos_USUARIO)) entidad.USUARIO = "";
                //            else entidad.USUARIO = dr[pos_USUARIO].ToString();

                //            if (dr.IsDBNull(pos_FEC_VENTA)) entidad.FEC_VENTA = "";
                //            else entidad.FEC_VENTA = dr[pos_FEC_VENTA].ToString();

                //            if (dr.IsDBNull(pos_CODIGO_ARCHIVO)) entidad.CODIGO_ARCHIVO = "";
                //            else entidad.CODIGO_ARCHIVO = dr[pos_CODIGO_ARCHIVO].ToString();

                //            if (dr.IsDBNull(pos_EXTENSION_ARCHIVO)) entidad.EXTENSION_ARCHIVO = "";
                //            else entidad.EXTENSION_ARCHIVO = dr[pos_EXTENSION_ARCHIVO].ToString();

                //            lista.Add(entidad);
                //        }
                //    }
                //    dr.Close();
                //    int CUENTA = int.Parse(command.Parameters["PO_CUENTA"].Value.ToString());
                //    auditoria.OBJETO = CUENTA;
                //}
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}