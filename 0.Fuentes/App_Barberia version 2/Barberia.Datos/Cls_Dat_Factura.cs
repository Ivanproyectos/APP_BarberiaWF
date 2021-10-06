using Barberia.Entidad;
using System;

namespace Barberia.Datos
{
    public class Cls_Dat_Factura : Repository<T_FACTURA>
    {
        public T_FACTURA Listar_Factura(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_FACTURA entidad = new T_FACTURA();
            try
            {
                entidad = Get(1);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public void Actualizar_Factura(int numero, string anio, ref Cls_Ent_Auditoria auditoria)
        {
            T_FACTURA entidad = Find(x => x.ID_FACTURA == 1);
            auditoria.Limpiar();
            try
            {
                entidad.NUMERO = numero;
                entidad.ANIO = anio;
                Update(entidad);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

        //public T_FACTURA Buscar_VOUCHER(string voucher)
        //{
        //    T_FACTURA lista = new T_FACTURA();

        //    //IQueryable<T_VOUCHER_VENTA> query = Entities;


        //    if (!string.IsNullOrEmpty(voucher))
        //    {
        //        //int conteo = int.Parse(voucher);
        //        //string numero;
        //        //numero = ("00000000" + conteo).Substring(conteo.ToString().Length, 8);
        //        lista = Find(w => w.NUM_VOUCHER == voucher);
        //    }

        //    //query = query.OrderByDescending(o => o.ID_VENTA);
        //    return lista;
        //}

        //public void Insertar_VOUCHER(T_FACTURA entidad)
        //{
        //    try
        //    {
        //            Add(entidad);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    }
}
