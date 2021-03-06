using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Act_Stock : Repository<T_ACTUALIZAR_STOCK>
    {
        public List<T_ACTUALIZAR_STOCK> Listar_Act_Stock(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ACTUALIZAR_STOCK> lista = new List<T_ACTUALIZAR_STOCK>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_ACTUALIZAR_STOCK.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_ACTUALIZAR_STOCK ListarUno_Act_Stock(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_ACTUALIZAR_STOCK entidad = new T_ACTUALIZAR_STOCK();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_ACTUALIZAR_STOCK.Find(id); //.Where(x => x.ID_CARGO == id && x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<V_ACTUALIZAR_STOCK> Buscar_Act_Stock(V_ACTUALIZAR_STOCK entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_ACTUALIZAR_STOCK> lista = new List<V_ACTUALIZAR_STOCK>();
            
            auditoria.Limpiar();

            
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    IQueryable<V_ACTUALIZAR_STOCK> query = db.V_ACTUALIZAR_STOCK;

                    if (string.IsNullOrEmpty(fechaInicio) && string.IsNullOrEmpty(fechaFin))
                    {
                        string fecha = DateTime.Today.ToString("yyyy-MM") + "-01";
                        DateTime fechaNueva = DateTime.Parse(fecha);
                        query = query.Where(w => w.FEC_OPERACION >= fechaNueva);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
                        {
                            DateTime fec = DateTime.Parse(fechaInicio);
                            query = query.Where(w => w.FEC_OPERACION >= fec);
                        }
                        else if (fechaInicio != "" && fechaFin != "")
                        {
                            DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
                            DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
                            query = query.Where(w => w.FEC_OPERACION >= fechaNuevaInicio && w.FEC_OPERACION <= fechaNuevaFin);
                        }
                    }

                    lista = query.Where(w => w.ID_EMPRESA == entidad.ID_EMPRESA).OrderByDescending(w => w.ID_ACTUALIZAR).ToList();
                }
                
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

        public bool Anular_Act_Stock(T_ACTUALIZAR_STOCK entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                T_ACTUALIZAR_STOCK lista = new T_ACTUALIZAR_STOCK();
                lista = Find(x => x.ID_ACTUALIZAR == entidad.ID_ACTUALIZAR);
                if (lista != null)
                {
                    
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    Update(lista, lista.ID_ACTUALIZAR);
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
