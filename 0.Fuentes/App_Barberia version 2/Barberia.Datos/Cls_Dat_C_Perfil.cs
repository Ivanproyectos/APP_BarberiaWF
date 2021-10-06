using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_C_Perfil: Repository<T_C_PERFIL>
    {
        public List<Cls_Ent_Perfil> Listar_Perfil(ref Cls_Ent_Auditoria auditoria)
        {

            //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
            //{
            //    IQueryable lista = db.T_C_PERFIL.Join(db.T_M_PERFIL, c => c.ID_PERFIL, m => m.ID_PERFIL,(c, m) => new { c, m }).Where(x => x.c.ID_PERFIL == 4);
            //    return (List<Cls_Ent_Perfil>)lista;
            //}
            List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
            List<T_C_PERFIL> temp = new List<T_C_PERFIL>();
            auditoria.Limpiar();
            // SOLO FUNCIONA USANDO BD
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    temp = db.T_C_PERFIL.Where(t => t.FLG_ESTADO == "1").OrderByDescending(t => t.ID_CONFIG).ToList();
                    foreach (var p in temp)
                    {
                        lista.Add(new Cls_Ent_Perfil
                        {
                            ID_CONFIG = p.ID_CONFIG,
                            ID_PERFIL = p.ID_PERFIL,
                            PERFIL = p.T_M_PERFIL.DESCRIPCION,
                            DESCRIPCION = p.DESCRIPCION,
                            FLG_ESTADO = p.FLG_ESTADO,
                            USU_CREACION = p.USU_CREACION,
                            FEC_CREACION = p.FEC_CREACION,
                            USU_MODIFICA = p.USU_MODIFICA,
                            FEC_MODIFICA = p.FEC_MODIFICA
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            
            return lista;
        }

        private List<T_C_PERFIL> Buscar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_C_PERFIL> lista = new List<T_C_PERFIL>();
            auditoria.Limpiar();
            try
            {
                if (entidad.ID_PERFIL > 0)
                    lista = FindAll(c => c.ID_PERFIL == entidad.ID_PERFIL && c.DESCRIPCION == entidad.DESCRIPCION).Where(C => C.FLG_ESTADO == "1").ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public List<Cls_Ent_Perfil> Buscar_C_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {

            List<Cls_Ent_Perfil> lista = new List<Cls_Ent_Perfil>();
            List<T_C_PERFIL> lista2 = new List<T_C_PERFIL>();
            auditoria.Limpiar();
            //lista = GetAll().Select(p => new Cls_Ent_Perfil
            //{
            //    ID_CONFIG = p.ID_CONFIG,
            //    ID_PERFIL = p.ID_PERFIL,
            //    PERFIL = p.T_M_PERFIL.DESCRIPCION,
            //    DESCRIPCION = p.DESCRIPCION,
            //    USU_CREACION = p.USU_CREACION,
            //    FEC_CREACION = p.FEC_CREACION,
            //    USU_MODIFICA = p.USU_MODIFICA,
            //    FEC_MODIFICA = p.FEC_MODIFICA,
            //}).Where(c => c.ID_PERFIL == entidad.ID_PERFIL || c.DESCRIPCION == entidad.DESCRIPCION).OrderByDescending(p => p.ID_CONFIG).ToList();
            //return lista;
            IQueryable<T_C_PERFIL> query = Entities;
            try
            {
                query = query.Where(c => c.FLG_ESTADO == "1");

                if (!string.IsNullOrEmpty(entidad.DESCRIPCION))
                    query = query.Where(c => c.DESCRIPCION.Contains(entidad.DESCRIPCION));

                if (entidad.ID_PERFIL > 0)
                    query = query.Where(c => c.ID_PERFIL == entidad.ID_PERFIL);


                query = query.OrderByDescending(c => c.ID_CONFIG);
                lista2 = query.ToList();
                lista = (List<Cls_Ent_Perfil>)lista2.Select(p => new Cls_Ent_Perfil
                {
                    ID_CONFIG = p.ID_CONFIG,
                    ID_PERFIL = p.ID_PERFIL,
                    PERFIL = p.T_M_PERFIL.DESCRIPCION,
                    DESCRIPCION = p.DESCRIPCION,
                    FLG_ESTADO = p.FLG_ESTADO,
                    USU_CREACION = p.USU_CREACION,
                    FEC_CREACION = p.FEC_CREACION,
                    USU_MODIFICA = p.USU_MODIFICA,
                    FEC_MODIFICA = p.FEC_MODIFICA,
                }).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            
            return lista;
        }

        public bool Insertar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            List<T_C_PERFIL> lista = new List<T_C_PERFIL>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Buscar_Perfil(entidad, ref auditoria);
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

        public bool Actualizar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_C_PERFIL> lista = new List<T_C_PERFIL>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Buscar_Perfil(entidad, ref auditoria);
                if (lista.Count > 0 )
                {
                    if (lista[0].ID_CONFIG.Equals(entidad.ID_CONFIG))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    Update(entidad, entidad.ID_CONFIG);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Perfil(T_C_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_C_PERFIL> lista = new List<T_C_PERFIL>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                if (entidad.ID_CONFIG > 0)
                {
                    lista = FindAll(c => c.ID_CONFIG == entidad.ID_CONFIG).ToList();
                    if (lista.Count > 0)
                    {
                        foreach (var item in lista)
                        {
                            item.FLG_ESTADO = entidad.FLG_ESTADO;
                            item.USU_MODIFICA = entidad.USU_MODIFICA;
                            item.FEC_MODIFICA = entidad.FEC_MODIFICA;
                            Update(item, item.ID_CONFIG);
                        }
                    }
                    else
                    {
                        exito = false;
                    }
                }
                else
                {
                    lista = FindAll(c => c.ID_PERFIL == entidad.ID_PERFIL).ToList();
                    if (lista.Count > 0)
                    {
                        foreach (var item in lista)
                        {
                            item.FLG_ESTADO = entidad.FLG_ESTADO;
                            item.USU_MODIFICA = entidad.USU_MODIFICA;
                            item.FEC_MODIFICA = entidad.FEC_MODIFICA;
                            Update(item, item.ID_CONFIG);
                        }
                    }
                    else
                    {
                        exito = false;
                    }
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
