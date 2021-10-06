using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Clase : Repository<T_M_CLASE>
    {
        public List<T_M_CLASE> Listar_Clase(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLASE> lista = new List<T_M_CLASE>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_M_CLASE.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CLASE).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).OrderByDescending(x => x.ID_CLASE).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_CLASE ListarUno_Clase(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_CLASE entidad = new T_M_CLASE();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_CLASE.Find(id);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_CLASE> Buscar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLASE> lista = new List<T_M_CLASE>();
            auditoria.Limpiar();
            try
            {

                if (entidad.DES_CLASE != "")
                    lista = FindAll(c => c.DES_CLASE.Contains(entidad.DES_CLASE)).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CLASE lista = new T_M_CLASE();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_CLASE == entidad.DES_CLASE && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CLASE lista = new T_M_CLASE();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_CLASE == entidad.DES_CLASE && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_CLASE.Equals(entidad.ID_CLASE))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_CLASE == entidad.ID_CLASE);
                    exito = true;
                }

                if (exito)
                {
                    lista.DES_CLASE = entidad.DES_CLASE;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_CLASE);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_CLASE lista = new T_M_CLASE();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_CLASE == entidad.ID_CLASE && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_CLASE.Equals(entidad.ID_CLASE))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_CLASE);
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
