using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_OrdenCompra : Repository<T_M_ORDEN_COMPRA>
    {
        public List<T_M_ORDEN_COMPRA> Listar_OrdenCompra(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {

            List<T_M_ORDEN_COMPRA> lista = new List<T_M_ORDEN_COMPRA>();
            auditoria.Limpiar();

            try
            {
                lista = FindAll(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_ORDEN_COMPRA ListarUno_OrdenCompra(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_ORDEN_COMPRA entidad = new T_M_ORDEN_COMPRA();
            try
            {
                entidad = Find(c => c.ID_ORDEN_COMPRA == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_ORDEN_COMPRA> Buscar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_ORDEN_COMPRA> query = Entities;
            try
            {
                query = query.Where(c => c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (!string.IsNullOrEmpty(entidad.NUM_ORDEN_COMPRA))
                    query = query.Where(c => c.NUM_ORDEN_COMPRA.Contains(entidad.NUM_ORDEN_COMPRA));

                //if (!string.IsNullOrEmpty(entidad.PRODUCTO))
                //    query = query.Where(c => c.PRODUCTO.Contains(entidad.PRODUCTO));

                //if (entidad.ID_MARCA > 0)
                //    query = query.Where(c => c.ID_MARCA == entidad.ID_MARCA);

                //if (entidad.ID_MODELO > 0)
                //    query = query.Where(c => c.ID_MODELO == entidad.ID_MODELO);

                //if (entidad.ID_UNIDAD_MEDIDA > 0)
                //    query = query.Where(c => c.ID_UNIDAD_MEDIDA == entidad.ID_UNIDAD_MEDIDA);

                //if (entidad.STOCK > 0)
                //    query = query.Where(c => c.STOCK == entidad.STOCK);

                //if (entidad.PRECIO_COMPRA > 0)
                //    query = query.Where(c => c.PRECIO_COMPRA == entidad.PRECIO_COMPRA);

                //if (entidad.PRECIO_VENTA > 0)
                //    query = query.Where(c => c.PRECIO_VENTA == entidad.PRECIO_VENTA);

                query = query.OrderByDescending(c => c.ID_ORDEN_COMPRA);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }

        public bool Insertar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria) 
        {

            bool exito = true;
            auditoria.Limpiar();
            try
            {
                Add(entidad);
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_ORDEN_COMPRA lista = new T_M_ORDEN_COMPRA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.ID_ORDEN_COMPRA == entidad.ID_ORDEN_COMPRA && c.FLG_ESTADO == "1");

                lista.ID_EMPRESA_CONTRATA = entidad.ID_EMPRESA_CONTRATA;
                lista.FECHA = entidad.FECHA;
                lista.ID_PERSONA = entidad.ID_PERSONA;
                lista.ASUNTO = entidad.ASUNTO;
                lista.ID_FORMA_PAGO = entidad.ID_FORMA_PAGO;
                lista.GARANTIA = entidad.GARANTIA;
                lista.CANT_DIAS_VALIDES = entidad.CANT_DIAS_VALIDES;
                lista.ID_MONEDA = entidad.ID_MONEDA;
                lista.TIPO_CAMBIO = entidad.TIPO_CAMBIO;
                lista.SUBTOTAL = entidad.SUBTOTAL;
                lista.IGV = entidad.IGV;
                lista.DESCUENTO = entidad.DESCUENTO;
                lista.TOTAL = entidad.TOTAL;
                lista.USU_MODIFICA = entidad.USU_MODIFICA;
                lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                Update(lista, entidad.ID_ORDEN_COMPRA);

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_OrdenCompra(T_M_ORDEN_COMPRA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_ORDEN_COMPRA lista = new T_M_ORDEN_COMPRA();
            bool exito = true;

            try
            {

                lista = Find(x => x.ID_ORDEN_COMPRA == entidad.ID_ORDEN_COMPRA && x.FLG_ESTADO == "1");

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_ORDEN_COMPRA);
                }

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;

        }

        public List<Cls_Ent_V_OrdenCompra> ListarPaginado_OrdenCompra(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            var TABLA = "";
            auditoria.Limpiar();
            DbDataReader dr = null;
            List<Cls_Ent_V_OrdenCompra> lista = new List<Cls_Ent_V_OrdenCompra>();
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
                //    int pos_ID_ORDEN_COMPRA = dr.GetOrdinal("ID_ORDEN_COMPRA");
                //    int pos_ID_EMPRESA = dr.GetOrdinal("ID_EMPRESA");
                //    int pos_EMPRESA_EXTERNA = dr.GetOrdinal("EMPRESA_EXTERNA");
                //    int pos_NUM_COTIZACION_REF = dr.GetOrdinal("NUM_COTIZACION_REF");
                //    int pos_NUM_ORDEN_COMPRA = dr.GetOrdinal("NUM_ORDEN_COMPRA");
                //    int pos_FECHA = dr.GetOrdinal("FECHA");
                //    int pos_NOMBRES = dr.GetOrdinal("NOMBRES");
                //    int pos_ASUNTO = dr.GetOrdinal("ASUNTO");
                //    int pos_FORMA_PAGO = dr.GetOrdinal("FORMA_PAGO");
                //    int pos_GARANTIA = dr.GetOrdinal("GARANTIA");
                //    int pos_CANT_DIAS_VALIDES = dr.GetOrdinal("CANT_DIAS_VALIDES");
                //    int pos_USU_CREACION = dr.GetOrdinal("USU_CREACION");
                //    int pos_FEC_CREACION = dr.GetOrdinal("FEC_CREACION");
                //    int pos_USU_MODIFICA = dr.GetOrdinal("USU_MODIFICA");
                //    int pos_FEC_MODIFICA = dr.GetOrdinal("FEC_MODIFICA");

                //    if (dr.HasRows)
                //    {
                //        while (dr.Read())
                //        {
                //            Cls_Ent_V_OrdenCompra entidad = new Cls_Ent_V_OrdenCompra();


                //            if (dr.IsDBNull(pos_ID_EMPRESA)) entidad.ID_EMPRESA = 0;
                //            else entidad.ID_EMPRESA = int.Parse(dr[pos_ID_EMPRESA].ToString());

                //            if (dr.IsDBNull(pos_ID_ORDEN_COMPRA)) entidad.ID_ORDEN_COMPRA = 0;
                //            else entidad.ID_ORDEN_COMPRA = int.Parse(dr[pos_ID_ORDEN_COMPRA].ToString());

                //            if (dr.IsDBNull(pos_EMPRESA_EXTERNA)) entidad.EMPRESA_EXTERNA = "";
                //            else entidad.EMPRESA_EXTERNA = dr[pos_EMPRESA_EXTERNA].ToString();

                //            if (dr.IsDBNull(pos_NUM_COTIZACION_REF)) entidad.NUM_COTIZACION_REF = "";
                //            else entidad.NUM_COTIZACION_REF = dr[pos_NUM_COTIZACION_REF].ToString();

                //            if (dr.IsDBNull(pos_NUM_ORDEN_COMPRA)) entidad.NUM_ORDEN_COMPRA = "";
                //            else entidad.NUM_ORDEN_COMPRA = dr[pos_NUM_ORDEN_COMPRA].ToString();

                //            if (dr.IsDBNull(pos_FECHA)) entidad.FECHA = "";
                //            else entidad.FECHA = dr[pos_FECHA].ToString();

                //            if (dr.IsDBNull(pos_NOMBRES)) entidad.NOMBRES = "";
                //            else entidad.NOMBRES = dr[pos_NOMBRES].ToString();

                //            if (dr.IsDBNull(pos_ASUNTO)) entidad.ASUNTO = "";
                //            else entidad.ASUNTO = dr[pos_ASUNTO].ToString();

                //            if (dr.IsDBNull(pos_FORMA_PAGO)) entidad.FORMA_PAGO = "";
                //            else entidad.FORMA_PAGO = dr[pos_FORMA_PAGO].ToString();

                //            if (dr.IsDBNull(pos_GARANTIA)) entidad.GARANTIA = "";
                //            else entidad.GARANTIA = dr[pos_GARANTIA].ToString();

                //            if (dr.IsDBNull(pos_CANT_DIAS_VALIDES)) entidad.CANT_DIAS_VALIDES = 0;
                //            else entidad.CANT_DIAS_VALIDES = int.Parse(dr[pos_CANT_DIAS_VALIDES].ToString());

                //            if (dr.IsDBNull(pos_USU_CREACION)) entidad.USU_CREACION = "";
                //            else entidad.USU_CREACION = dr[pos_USU_CREACION].ToString();

                //            if (dr.IsDBNull(pos_FEC_CREACION)) entidad.FEC_CREACION = "";
                //            else entidad.FEC_CREACION = dr[pos_FEC_CREACION].ToString();

                //            if (dr.IsDBNull(pos_USU_MODIFICA)) entidad.USU_MODIFICA = "";
                //            else entidad.USU_MODIFICA = dr[pos_USU_MODIFICA].ToString();

                //            if (dr.IsDBNull(pos_FEC_MODIFICA)) entidad.FEC_MODIFICA = "";
                //            else entidad.FEC_MODIFICA = dr[pos_FEC_MODIFICA].ToString();

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
