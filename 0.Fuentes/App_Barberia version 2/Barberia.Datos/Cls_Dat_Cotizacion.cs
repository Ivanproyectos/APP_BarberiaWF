using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Cotizacion : Repository<T_M_COTIZACION>
    {
        public List<T_M_COTIZACION> Listar_Cotizacion(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {

            List<T_M_COTIZACION> lista = new List<T_M_COTIZACION>();
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

        public T_M_COTIZACION ListarUno_Cotizacion(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_COTIZACION entidad = new T_M_COTIZACION();
            try
            {
                entidad = Find(c => c.ID_COTIZACION == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_COTIZACION> Buscar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_COTIZACION> query = Entities;
            try
            {
                

                if (!string.IsNullOrEmpty(entidad.NUM_COTIZACION))
                    query = query.Where(c => c.NUM_COTIZACION.Contains(entidad.NUM_COTIZACION));

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

                query = query.Where(c => c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA).OrderByDescending(c => c.ID_COTIZACION);

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }

        public bool Insertar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            List<T_M_COTIZACION> lista = new List<T_M_COTIZACION>();
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

        public bool Actualizar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_COTIZACION lista = new T_M_COTIZACION();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.ID_COTIZACION == entidad.ID_COTIZACION);
                //lista.ID_EMPRESA_INTERNA = entidad.ID_EMPRESA_INTERNA;
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
                Update(lista, entidad.ID_COTIZACION);

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Cotizacion(T_M_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_COTIZACION lista = new T_M_COTIZACION();
            bool exito = true;

            try
            {

                lista = Find(x => x.ID_COTIZACION == entidad.ID_COTIZACION && x.FLG_ESTADO == "1");

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_COTIZACION);
                }

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;

        }

    }
}
