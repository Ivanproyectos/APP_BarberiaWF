using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Marca : Repository<T_M_MARCA>
    {
        public List<T_M_MARCA> Listar_Marca(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_MARCA> lista = new List<T_M_MARCA>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
                //{
                //    lista = db.T_D_CARGO.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).OrderByDescending(x => x.ID_MARCA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_MARCA ListarUno_Marca(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_MARCA entidad = new T_M_MARCA();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_MARCA.Find(id); //.Where(x => x.ID_CARGO == id && x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_MARCA> Buscar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_MARCA> lista = new List<T_M_MARCA>();
            auditoria.Limpiar();
            try
            {

                if (entidad.DES_MARCA != "")
                    lista = FindAll(c => c.DES_MARCA.Contains(entidad.DES_MARCA)).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_MARCA lista = new T_M_MARCA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_MARCA == entidad.DES_MARCA && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_MARCA lista = new T_M_MARCA();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_MARCA == entidad.DES_MARCA && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_MARCA.Equals(entidad.ID_MARCA))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_MARCA == entidad.ID_MARCA);
                    exito = true;
                }

                if (exito)
                {
                    lista.DES_MARCA = entidad.DES_MARCA;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_MARCA);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Marca(T_M_MARCA entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_MARCA lista = new T_M_MARCA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_MARCA == entidad.ID_MARCA && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_MARCA.Equals(entidad.ID_MARCA))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_MARCA);
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
