using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Barberia.Datos
{
    public class Cls_Dat_Producto : Repository<T_M_PRODUCTO>
    {
        public List<Cls_Ent_Producto> Listar_Producto(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {

            List<Cls_Ent_Producto> lista = new List<Cls_Ent_Producto>();
            auditoria.Limpiar();
            //lista = GetAll().Where(x => x.FLG_ESTADO == "1").Select(x => new T_M_PRODUCTO()
            //{
            //    ID_PRODUCTO = x.ID_PRODUCTO,
            //    COD_PRODUCTO = x.COD_PRODUCTO,
            //    PRODUCTO = x.PRODUCTO,
            //    ID_MARCA = x.ID_MARCA,
            //    ID_MODELO = x.ID_MODELO,
            //    ID_UNIDAD_MEDIDA = x.ID_UNIDAD_MEDIDA,
            //    STOCK = x.STOCK,
            //    PRECIO_COMPRA = x.PRECIO_COMPRA,
            //    PRECIO_VENTA = x.PRECIO_VENTA,
            //    FEC_COMPRA = x.FEC_COMPRA,
            //    NOM_FILE = x.NOM_FILE,
            //    RUTA = x.RUTA,
            //    USU_CREACION = x.USU_CREACION,
            //    FEC_CREACION = x.FEC_CREACION,
            //    USU_MODIFICA = x.USU_MODIFICA,
            //    FEC_MODIFICA = x.FEC_MODIFICA

            //}).OrderByDescending(t => t.ID_PRODUCTO).ToList();

            //return lista;

            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {

                    lista = db.T_M_PRODUCTO.Where(t => t.FLG_ESTADO == "1" && t.ID_EMPRESA == idEmpresa).Select(x => new Cls_Ent_Producto()
                    {
                        ID_PRODUCTO = x.ID_PRODUCTO,
                        COD_PRODUCTO = x.COD_PRODUCTO,
                        PRODUCTO = x.PRODUCTO,
                        ID_MARCA = x.ID_MARCA,
                        ID_MODELO = x.ID_MODELO,
                        ID_UNIDAD_MEDIDA = x.ID_UNIDAD_MEDIDA,
                        STOCK = (int)x.STOCK,
                        PRECIO_COMPRA = x.PRECIO_COMPRA,
                        PRECIO_VENTA = x.PRECIO_VENTA,
                        FEC_COMPRA = x.FEC_COMPRA,
                        NOM_FILE = x.NOM_FILE,
                        RUTA = x.RUTA,
                        USU_CREACION = x.USU_CREACION,
                        FEC_CREACION = x.FEC_CREACION,
                        USU_MODIFICA = x.USU_MODIFICA,
                        FEC_MODIFICA = x.FEC_MODIFICA

                    }).OrderByDescending(t => t.ID_PRODUCTO).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_PRODUCTO ListarUno_Producto(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_PRODUCTO entidad = new T_M_PRODUCTO();
            try
            {
                entidad = Find(c => c.ID_PRODUCTO == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_PRODUCTO> Buscar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_PRODUCTO> query = Entities;
            try
            {
                query = query.Where(c => c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (!string.IsNullOrEmpty(entidad.COD_PRODUCTO))
                    query = query.Where(c => c.COD_PRODUCTO.Contains(entidad.COD_PRODUCTO));

                if (!string.IsNullOrEmpty(entidad.PRODUCTO))
                    query = query.Where(c => c.PRODUCTO.Contains(entidad.PRODUCTO));

                if (entidad.ID_MARCA > 0)
                    query = query.Where(c => c.ID_MARCA == entidad.ID_MARCA);

                if (entidad.ID_MODELO > 0)
                    query = query.Where(c => c.ID_MODELO == entidad.ID_MODELO);

                if (entidad.ID_UNIDAD_MEDIDA > 0)
                    query = query.Where(c => c.ID_UNIDAD_MEDIDA == entidad.ID_UNIDAD_MEDIDA);

                if (entidad.STOCK > 0)
                    query = query.Where(c => c.STOCK == entidad.STOCK);

                if (entidad.PRECIO_COMPRA > 0)
                    query = query.Where(c => c.PRECIO_COMPRA == entidad.PRECIO_COMPRA);

                if (entidad.PRECIO_VENTA > 0)
                    query = query.Where(c => c.PRECIO_VENTA == entidad.PRECIO_VENTA);

                query = query.OrderByDescending(c => c.ID_PRODUCTO);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }

        public bool Insertar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            List<T_M_PRODUCTO> lista = new List<T_M_PRODUCTO>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                if (entidad.ID_MARCA == null)
                {
                    lista = FindAll(c => c.PRODUCTO == entidad.PRODUCTO).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();
                }
                else
                {
                    lista = FindAll(c => c.PRODUCTO == entidad.PRODUCTO).Where(x => x.FLG_ESTADO == "1" && x.ID_MARCA == entidad.ID_MARCA && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();
                }
                
                if (lista.Count > 0)
                {
                    exito = false;
                }

                if (exito)
                {
                    Add(entidad);
                }    
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PRODUCTO lista = new T_M_PRODUCTO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.PRODUCTO == entidad.PRODUCTO && x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null)
                {
                    if (lista.ID_PRODUCTO.Equals(entidad.ID_PRODUCTO))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(x => x.ID_PRODUCTO == entidad.ID_PRODUCTO);
                    exito = true;
                }

                if (exito)
                {
                    lista.PRODUCTO = entidad.PRODUCTO;
                    lista.ID_ALMACEN = entidad.ID_ALMACEN;
                    lista.ID_CLASE = entidad.ID_CLASE;
                    lista.ID_MARCA = entidad.ID_MARCA;
                    lista.ID_MODELO = entidad.ID_MODELO;
                    lista.ID_UNIDAD_MEDIDA = entidad.ID_UNIDAD_MEDIDA;
                    lista.STOCK = entidad.STOCK;
                    lista.PRECIO_COMPRA = entidad.PRECIO_COMPRA;
                    lista.PRECIO_VENTA = entidad.PRECIO_VENTA;
                    lista.FEC_COMPRA = entidad.FEC_COMPRA;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_PRODUCTO);

                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool ActualizarIMG_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PRODUCTO lista = new T_M_PRODUCTO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.PRODUCTO == entidad.PRODUCTO && x.FLG_ESTADO == "1");
                
                if (lista != null)
                {
                    if (lista.ID_PRODUCTO.Equals(entidad.ID_PRODUCTO))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(x => x.ID_PRODUCTO == entidad.ID_PRODUCTO);
                }

                if (exito)
                {
                    lista.COD_PRODUCTO = entidad.COD_PRODUCTO;
                    lista.PRODUCTO = entidad.PRODUCTO;
                    lista.ID_MARCA = entidad.ID_MARCA;
                    lista.ID_MODELO = entidad.ID_MODELO;
                    lista.ID_UNIDAD_MEDIDA = entidad.ID_UNIDAD_MEDIDA;
                    lista.STOCK = entidad.STOCK;
                    lista.PRECIO_COMPRA = entidad.PRECIO_COMPRA;
                    lista.PRECIO_VENTA = entidad.PRECIO_VENTA;
                    lista.FEC_COMPRA = entidad.FEC_COMPRA;
                    lista.NOM_FILE = entidad.NOM_FILE;
                    lista.RUTA = entidad.RUTA;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_PRODUCTO);
                    exito = true;
                }

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_PRODUCTO lista = new T_M_PRODUCTO();
            bool exito = true;

            try
            {

                lista = Find(x => x.ID_PRODUCTO == entidad.ID_PRODUCTO && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_PRODUCTO.Equals(entidad.ID_PRODUCTO))
                        exito = true;
                    else
                        exito = false;

                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_PRODUCTO);
                }

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;

        }

        public void NuevoStock_Producto(int IdProducto, int NuevoStock, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                T_M_PRODUCTO lista = new T_M_PRODUCTO();
                lista = Find(x => x.ID_PRODUCTO == IdProducto && x.FLG_ESTADO == "1");
                lista.STOCK = NuevoStock;
                Update(lista, lista.ID_PRODUCTO);

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }

        }

        public string getCodigo_Producto( ref Cls_Ent_Auditoria auditoria) 
        {

            string codigo;
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    codigo = (from c in db.T_M_PRODUCTO
                                      orderby c.ID_PRODUCTO descending
                                      select c.COD_PRODUCTO).FirstOrDefault();
                    if (codigo == null)
                    {
                        codigo = "1000001";
                    }
                    else
                    {
                        codigo = (int.Parse(codigo) + 1).ToString();
                    }
                }

                return codigo;
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return "";
            }
        }


        public List<Cls_Ent_V_Producto> ListarPaginado_Producto(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref Cls_Ent_Auditoria auditoria)
        {
            var TABLA = "";
            auditoria.Limpiar();
            DbDataReader dr = null;
            List<Cls_Ent_V_Producto> lista = new List<Cls_Ent_V_Producto>();
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
                //    int pos_DESC_CATEGORIA = dr.GetOrdinal("DESC_CATEGORIA");
                //    int pos_ID_CATEGORIA = dr.GetOrdinal("ID_CATEGORIA");
                //    int pos_ID_PRODUCTO = dr.GetOrdinal("ID_PRODUCTO");
                //    int pos_COD_PRODUCTO = dr.GetOrdinal("COD_PRODUCTO");
                //    int pos_DES_ALMACEN = dr.GetOrdinal("DES_ALMACEN");
                //    int pos_DES_CLASE = dr.GetOrdinal("DES_CLASE");
                //    int pos_PRODUCTO = dr.GetOrdinal("PRODUCTO");
                //    int pos_DES_UNIDAD_MEDIDA = dr.GetOrdinal("DES_UNIDAD_MEDIDA");
                //    int pos_DES_MODELO = dr.GetOrdinal("DES_MODELO");
                //    int pos_DES_MARCA = dr.GetOrdinal("DES_MARCA");
                //    int pos_STOCK = dr.GetOrdinal("STOCK");
                //    int pos_PRECIO_COMPRA = dr.GetOrdinal("PRECIO_COMPRA");
                //    int pos_PRECIO_VENTA = dr.GetOrdinal("PRECIO_VENTA");
                //    int pos_USU_CREACION = dr.GetOrdinal("USU_CREACION");
                //    int pos_FEC_CREACION = dr.GetOrdinal("FEC_CREACION");
                //    int pos_USU_MODIFICA = dr.GetOrdinal("USU_MODIFICA");
                //    int pos_FEC_MODIFICA = dr.GetOrdinal("FEC_MODIFICA");

                //    if (dr.HasRows)
                //    {
                //        while (dr.Read())
                //        {
                //            Cls_Ent_V_Producto entidad = new Cls_Ent_V_Producto();


                //            if (dr.IsDBNull(pos_ID_EMPRESA)) entidad.ID_EMPRESA = 0;
                //            else entidad.ID_EMPRESA = int.Parse(dr[pos_ID_EMPRESA].ToString());

                //            if (dr.IsDBNull(pos_DESC_CATEGORIA)) entidad.DESC_CATEGORIA = "";
                //            else entidad.DESC_CATEGORIA = dr[pos_DESC_CATEGORIA].ToString();

                //            if (dr.IsDBNull(pos_ID_CATEGORIA)) entidad.ID_CATEGORIA = 0;
                //            else entidad.ID_CATEGORIA = int.Parse(dr[pos_ID_CATEGORIA].ToString());

                //            if (dr.IsDBNull(pos_ID_PRODUCTO)) entidad.ID_PRODUCTO = 0;
                //            else entidad.ID_PRODUCTO = int.Parse(dr[pos_ID_PRODUCTO].ToString());

                //            if (dr.IsDBNull(pos_COD_PRODUCTO)) entidad.COD_PRODUCTO = "";
                //            else entidad.COD_PRODUCTO = dr[pos_COD_PRODUCTO].ToString();

                //            if (dr.IsDBNull(pos_DES_ALMACEN)) entidad.DES_ALMACEN = "";
                //            else entidad.DES_ALMACEN = dr[pos_DES_ALMACEN].ToString();

                //            if (dr.IsDBNull(pos_DES_CLASE)) entidad.DES_CLASE = "";
                //            else entidad.DES_CLASE = dr[pos_DES_CLASE].ToString();

                //            if (dr.IsDBNull(pos_PRODUCTO)) entidad.PRODUCTO = "";
                //            else entidad.PRODUCTO = dr[pos_PRODUCTO].ToString();

                //            if (dr.IsDBNull(pos_DES_UNIDAD_MEDIDA)) entidad.DES_UNIDAD_MEDIDA = "";
                //            else entidad.DES_UNIDAD_MEDIDA = dr[pos_DES_UNIDAD_MEDIDA].ToString();

                //            if (dr.IsDBNull(pos_DES_MODELO)) entidad.DES_MODELO = "";
                //            else entidad.DES_MODELO = dr[pos_DES_MODELO].ToString();

                //            if (dr.IsDBNull(pos_DES_MARCA)) entidad.DES_MARCA = "";
                //            else entidad.DES_MARCA = dr[pos_DES_MARCA].ToString();

                //            if (dr.IsDBNull(pos_STOCK)) entidad.STOCK = 0;
                //            else entidad.STOCK = int.Parse(dr[pos_STOCK].ToString());

                //            if (dr.IsDBNull(pos_PRECIO_COMPRA)) entidad.PRECIO_COMPRA = 0;
                //            else entidad.PRECIO_COMPRA = int.Parse(dr[pos_PRECIO_COMPRA].ToString());

                //            if (dr.IsDBNull(pos_PRECIO_VENTA)) entidad.PRECIO_VENTA = 0;
                //            else entidad.PRECIO_VENTA = int.Parse(dr[pos_PRECIO_VENTA].ToString());

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
