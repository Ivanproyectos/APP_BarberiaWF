using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

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

    }
}
