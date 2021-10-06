using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Venta : Repository<T_M_VENTA>
    {
        public List<T_M_VENTA> Listar_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            //using (DB_BARBERIAEntities2 db = new DB_BARBERIAEntities2())
            //{
            //    List<T_M_PRODUCTO> lista = new List<T_M_PRODUCTO>();
            //    lista =  db.T_M_PRODUCTO.Select(x => new T_M_PRODUCTO()
            //    {
            //        ID_PRODUCTO = x.ID_PRODUCTO,
            //        PRODUCTO = x.PRODUCTO,
            //        STOCK = x.STOCK,
            //        PRECIO_COMPRA = x.PRECIO_COMPRA,
            //        PRECIO_VENTA = x.PRECIO_VENTA,
            //        FEC_COMPRA = x.FEC_COMPRA
            //        //FOTO = x.FOTO
            //    }).OrderByDescending(t => t.ID_PRODUCTO).ToList();

            //    return lista;
            //}
            List<T_M_VENTA> lista = new List<T_M_VENTA>();
            try
            {
                lista = GetAll().ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_M_VENTA> Buscar_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_VENTA> lista = new List<T_M_VENTA>();
            try
            {
                lista = FindAll(x => x.ID_VENTA == entidad.ID_VENTA).ToList();

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Venta(List<T_M_VENTA> entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            auditoria.Limpiar();
            bool exito = true;
            try
            {
                AddRange(entidad);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }


                auditoria.Error(ex);
            }
            return exito;
        }

        public int Insertar_M_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_VENTA lista = new T_M_VENTA();
            try
            {

               lista = Add(entidad);

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
                auditoria.Error(ex);
            }
            return lista.ID_VENTA;
        }

        public bool Actualizar_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_VENTA> lista = new List<T_M_VENTA>();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Buscar_Venta(entidad, ref auditoria);
                if (lista.Count > 0 )
                {

                    lista[0].TOTAL_IMPORTE = entidad.TOTAL_IMPORTE;
                    lista[0].DESCT_TOTAL = entidad.DESCT_TOTAL;
                    lista[0].IGV = entidad.IGV;
                    lista[0].TOTAL = entidad.TOTAL;
                    //lista[0].CODIGO_FILE = entidad.CODIGO_FILE;
                    //lista[0].NOMBRE_FILE = entidad.NOMBRE_FILE;
                    //lista[0].EXTENSION_FILE = entidad.EXTENSION_FILE;
                    Update(lista[0], lista[0].ID_VENTA);
                    exito = true;
                }

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public void Eliminar_Venta(T_M_VENTA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                DeleteUno(entidad.ID_VENTA);

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }

        }

        public int Conteo_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            int contador = 0;
            try
            {
                contador = Count();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return contador;
        }

        public string Numero_Venta(ref Cls_Ent_Auditoria auditoria)
        {
            string num = "";
            auditoria.Limpiar();
            try
            {
                List<T_M_VENTA> lista = new List<T_M_VENTA>();
                lista = GetAll().ToList();
                if (lista.Count == 0)
                {
                    num = "0";
                }
                else
                {
                    num = lista.Select(x => x.VOUCHER).Last();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return num;
        }

        public bool Anular_Venta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                //List<T_M_VENTA> lista = new List<T_M_VENTA>();
                T_M_VENTA lista = new T_M_VENTA();
                lista = Find(x=> x.ID_VENTA == id);
                //if (lista.Count != 0)
                //{
                //    exito = true;
                //    foreach (var item in lista)
                //    {
                //        item.FLG_ESTADO = "0";
                //        Update(item, item.ID_VENTA);
                //    }
                //}
                if (lista != null)
                {
                    exito = true;
                    lista.FLG_ESTADO = "0";
                    Update(lista, lista.ID_VENTA);
                }

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return exito;
        }

        public List<T_M_VENTA> Buscar_Venta(string voucher, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_VENTA> lista = new List<T_M_VENTA>();
            try
            {
                lista = FindAll(x => x.VOUCHER == voucher && x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_VENTA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

    }
}
