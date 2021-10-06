using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_DaT_M_CATEGORIA : Repository<T_M_CATEGORIA>
    {
        public List<T_M_CATEGORIA> Listar_Categoria(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CATEGORIA> lista = new List<T_M_CATEGORIA>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_M_CATEGORIA.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CATEGORIA).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa || x.ID_EMPRESA == 0).OrderByDescending(x => x.ID_CATEGORIA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_CATEGORIA ListarUno_Categoria(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_CATEGORIA entidad = new T_M_CATEGORIA();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_CATEGORIA.Find(id);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_CATEGORIA> Buscar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CATEGORIA> lista = new List<T_M_CATEGORIA>();
            auditoria.Limpiar();
            try
            {

                if (entidad.DESC_CATEGORIA != "")
                    lista = FindAll(c => c.DESC_CATEGORIA.Contains(entidad.DESC_CATEGORIA)).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CATEGORIA lista = new T_M_CATEGORIA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DESC_CATEGORIA == entidad.DESC_CATEGORIA && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CATEGORIA lista = new T_M_CATEGORIA();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DESC_CATEGORIA == entidad.DESC_CATEGORIA && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_CATEGORIA.Equals(entidad.ID_CATEGORIA))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_CATEGORIA == entidad.ID_CATEGORIA);
                    exito = true;
                }

                if (exito)
                {
                    lista.DESC_CATEGORIA = entidad.DESC_CATEGORIA;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_CATEGORIA);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Categoria(T_M_CATEGORIA entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_CATEGORIA lista = new T_M_CATEGORIA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_CATEGORIA == entidad.ID_CATEGORIA && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_CATEGORIA.Equals(entidad.ID_CATEGORIA))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_CATEGORIA);
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
