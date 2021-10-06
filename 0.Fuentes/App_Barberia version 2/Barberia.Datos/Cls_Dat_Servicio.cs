using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Servicio : Repository<T_M_SERVICIO>
    {
        public List<T_M_SERVICIO> Listar_Servicio(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_SERVICIO> lista = new List<T_M_SERVICIO>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
                //{
                //    lista = db.T_D_CARGO.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_SERVICIO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_SERVICIO ListarUno_Servicio(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_SERVICIO entidad = new T_M_SERVICIO();
            try
            {
                entidad = Find(x => x.ID_SERVICIO == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_SERVICIO> Buscar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_SERVICIO> lista = new List<T_M_SERVICIO>();
            auditoria.Limpiar();
            try
            {

                if (entidad.DES_SERVICIO != "")
                    lista = FindAll(c => c.DES_SERVICIO.Contains(entidad.DES_SERVICIO)).Where(x => x.FLG_ESTADO == "1").ToList();

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_SERVICIO lista = new T_M_SERVICIO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_SERVICIO == entidad.DES_SERVICIO && c.FLG_ESTADO == "1");
                if (lista != null)
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

        public bool Actualizar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_SERVICIO lista = new T_M_SERVICIO();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_SERVICIO == entidad.DES_SERVICIO && c.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_SERVICIO == entidad.ID_SERVICIO)
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_SERVICIO == entidad.ID_SERVICIO);
                    exito = true;
                }

                if (exito)
                {
                    lista.DES_SERVICIO = entidad.DES_SERVICIO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_SERVICIO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Servicio(T_M_SERVICIO entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_SERVICIO lista = new T_M_SERVICIO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_SERVICIO == entidad.ID_SERVICIO && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_SERVICIO.Equals(entidad.ID_SERVICIO))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_SERVICIO);
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
