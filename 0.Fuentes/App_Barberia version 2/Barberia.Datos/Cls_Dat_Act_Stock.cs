using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Act_Stock : Repository<T_ACTUALIZAR_STOCK>
    {
        public List<T_ACTUALIZAR_STOCK> Listar_Act_Stock(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ACTUALIZAR_STOCK> lista = new List<T_ACTUALIZAR_STOCK>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_ACTUALIZAR_STOCK.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1").ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_ACTUALIZAR_STOCK> Buscar_Act_Stock(T_ACTUALIZAR_STOCK entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ACTUALIZAR_STOCK> lista = new List<T_ACTUALIZAR_STOCK>();
            auditoria.Limpiar();
            IQueryable<T_ACTUALIZAR_STOCK> query = Entities;
            try
            {

                if (!string.IsNullOrEmpty(entidad.FACTURA))
                    query = query.Where(w => w.FACTURA == entidad.FACTURA && w.FLG_ESTADO == "1");

                if (!string.IsNullOrEmpty(entidad.GUIA))
                    query = query.Where(w => w.GUIA == entidad.GUIA && w.FLG_ESTADO == "1");

                if (!string.IsNullOrEmpty(entidad.NRO_BOLETA))
                    query = query.Where(w => w.NRO_BOLETA == entidad.NRO_BOLETA && w.FLG_ESTADO == "1");

                lista = query.ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Act_Stock(T_ACTUALIZAR_STOCK entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            T_ACTUALIZAR_STOCK lista = new T_ACTUALIZAR_STOCK();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
    
                Add(entidad);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }


        public bool Eliminar_Act_Stock(T_ACTUALIZAR_STOCK entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_ACTUALIZAR_STOCK lista = new T_ACTUALIZAR_STOCK();
                bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_ACTUALIZAR == entidad.ID_ACTUALIZAR && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    //if (lista.ID_CARGO.Equals(entidad.ID_CARGO))
                    //    exito = true;
                    //else
                    //    exito = false;
                    exito = true;

                }

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
                return exito;

        }

        public bool Anular_Act_Stock(int id, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                T_ACTUALIZAR_STOCK lista = new T_ACTUALIZAR_STOCK();
                lista = Find(x => x.ID_ACTUALIZAR == id);
                if (lista != null)
                {
                    exito = true;

                    lista.FLG_ESTADO = "0";
                        Update(lista, lista.ID_ACTUALIZAR);
                }
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return exito;
        }

    }
}
