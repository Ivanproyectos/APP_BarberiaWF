using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_M_Perfil: Repository<T_M_PERFIL>
    {
        public List<T_M_PERFIL> Listar_Perfil(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PERFIL> lista = new List<T_M_PERFIL>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().Where(c => c.FLG_ESTADO == "1").Select(p => new T_M_PERFIL
                {
                    ID_PERFIL = p.ID_PERFIL,
                    DESCRIPCION = p.DESCRIPCION,
                    FLG_ESTADO = p.FLG_ESTADO,
                    USU_CREACION = p.USU_CREACION,
                    FEC_CREACION = p.FEC_CREACION,
                    USU_MODIFICA = p.USU_MODIFICA,
                    FEC_MODIFICA = p.FEC_MODIFICA
                }).OrderByDescending(p => p.ID_PERFIL).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_PERFIL ListarUno_Perfil(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_PERFIL entidad = new T_M_PERFIL();
            try
            {
                entidad = Find(c => c.ID_PERFIL == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_PERFIL> Buscar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_PERFIL> query = Entities;
            try
            {
                query = query.Where(c => c.FLG_ESTADO == "1");

                if (entidad.ID_PERFIL > 0)
                    query = query.Where(c => c.ID_PERFIL == entidad.ID_PERFIL);

                if (!string.IsNullOrEmpty(entidad.DESCRIPCION))
                    query = query.Where(c => c.DESCRIPCION.Contains(entidad.DESCRIPCION));

                query = query.OrderByDescending(c => c.ID_PERFIL);

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }

        public bool Insertar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            auditoria.Limpiar();
            List<T_M_PERFIL> lista = new List<T_M_PERFIL>();
            bool exito = true;
            try
            {
                lista = FindAll(c => c.DESCRIPCION == entidad.DESCRIPCION).Where(c => c.FLG_ESTADO == "1").ToList();
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

        public bool Actualizar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_PERFIL lista = new T_M_PERFIL();
            bool exito = true;

            try
            {
                lista = Find(c => c.DESCRIPCION == entidad.DESCRIPCION && c.FLG_ESTADO == "1");

                if (lista != null)
                {
                    if (lista.ID_PERFIL == entidad.ID_PERFIL)
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_PERFIL == entidad.ID_PERFIL);
                    exito = true;
                }

                if (exito)
                {
                    lista.DESCRIPCION = entidad.DESCRIPCION;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_PERFIL);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Perfil(T_M_PERFIL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_PERFIL entPerfil = new T_M_PERFIL();
            bool exito = true;
            try
            {
                entPerfil = Find(c => c.ID_PERFIL == entidad.ID_PERFIL && c.FLG_ESTADO == "1");
                if (entPerfil != null)
                {
                    if (entPerfil.ID_PERFIL.Equals(entidad.ID_PERFIL))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    entPerfil.FLG_ESTADO = entidad.FLG_ESTADO;
                    entPerfil.USU_MODIFICA = entidad.USU_MODIFICA;
                    entPerfil.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(entPerfil, entPerfil.ID_PERFIL);
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
