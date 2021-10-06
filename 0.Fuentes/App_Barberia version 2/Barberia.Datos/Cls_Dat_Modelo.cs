using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Modelo : Repository<T_M_MODELO>
    {
        public List<T_M_MODELO> Listar_Modelo(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_MODELO> lista = new List<T_M_MODELO>();
            try
            {
                //using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
                //{
                //    lista = db.T_D_CARGO.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).OrderByDescending(x => x.ID_MODELO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_MODELO ListarUno_Modelo(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_MODELO entidad = new T_M_MODELO();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_MODELO.Find(id);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_MODELO> Buscar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_MODELO> lista = new List<T_M_MODELO>();
            try
            {

                if (entidad.DES_MODELO != "")
                    lista = FindAll(c => c.DES_MODELO.Contains(entidad.DES_MODELO)).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_MODELO lista = new T_M_MODELO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_MODELO == entidad.DES_MODELO && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_MODELO lista = new T_M_MODELO();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_MODELO == entidad.DES_MODELO && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_MODELO.Equals(entidad.ID_MODELO))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_MODELO == entidad.ID_MODELO);
                    exito = true;
                }

                if (exito)
                {
                    lista.DES_MODELO = entidad.DES_MODELO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_MODELO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_MODELO lista = new T_M_MODELO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_MODELO == entidad.ID_MODELO && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_MODELO.Equals(entidad.ID_MODELO))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_MODELO);
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
