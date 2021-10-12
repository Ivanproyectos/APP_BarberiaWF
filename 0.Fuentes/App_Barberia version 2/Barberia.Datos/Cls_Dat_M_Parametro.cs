using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_M_Parametro : Repository<T_M_PARAMETRO>
    {
        public List<T_M_PARAMETRO> Listar_Parametro(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PARAMETRO> lista = new List<T_M_PARAMETRO>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_M_PARAMETRO.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_PARAMETRO).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).OrderByDescending(x => x.ID_PARAMETRO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_PARAMETRO ListarUno_Parametro(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_PARAMETRO entidad = new T_M_PARAMETRO();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_PARAMETRO.Find(id);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        

        public List<T_M_PARAMETRO> Buscar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PARAMETRO> lista = new List<T_M_PARAMETRO>();
            auditoria.Limpiar();
            IQueryable<T_M_PARAMETRO> query = Entities;
            try
            {

                if (!string.IsNullOrEmpty( entidad.COD_PARAMETRO))
                    query = query.Where(c => c.COD_PARAMETRO == entidad.COD_PARAMETRO);

                if (entidad.ID_PARAMETRO > 0)
                    query = query.Where(c => c.ID_PARAMETRO == entidad.ID_PARAMETRO);

                lista = query.Where(x => x.ID_EMPRESA == entidad.ID_EMPRESA && x.FLG_ESTADO == "1").ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PARAMETRO lista = new T_M_PARAMETRO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.COD_PARAMETRO == entidad.COD_PARAMETRO && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PARAMETRO lista = new T_M_PARAMETRO();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.COD_PARAMETRO == entidad.COD_PARAMETRO && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_PARAMETRO.Equals(entidad.ID_PARAMETRO))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_PARAMETRO == entidad.ID_PARAMETRO);
                    exito = true;
                }

                if (exito)
                {
                    //lista.COD_PARAMETRO = entidad.COD_PARAMETRO;
                    lista.DESC_PARAMETRO = entidad.DESC_PARAMETRO;
                    //lista.TIPO_PARAMETRO = entidad.TIPO_PARAMETRO;
                    lista.VALOR_D = entidad.VALOR_D;
                    lista.VALOR_I = entidad.VALOR_I;
                    lista.VALOR_S = entidad.VALOR_S;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_PARAMETRO);
                }
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_Parametro(int idParametro, decimal valorDecimal,  ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PARAMETRO lista = new T_M_PARAMETRO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {

                lista = Find(c => c.ID_PARAMETRO == idParametro);
                lista.VALOR_D = valorDecimal;
                Update(lista, idParametro);

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }


        public bool Eliminar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_PARAMETRO lista = new T_M_PARAMETRO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_PARAMETRO == entidad.ID_PARAMETRO && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_PARAMETRO.Equals(entidad.ID_PARAMETRO))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_PARAMETRO);
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
