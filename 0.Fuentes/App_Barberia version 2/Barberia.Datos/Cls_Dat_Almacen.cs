using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Almacen : Repository<T_M_ALMACEN>
    {
        public List<T_M_ALMACEN> Listar_Almacen(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_ALMACEN> lista = new List<T_M_ALMACEN>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_M_ALMACEN.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_ALMACEN).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).OrderByDescending(x => x.ID_ALMACEN).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_ALMACEN ListarUno_Almacen(int idAlmacen, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_ALMACEN entidad = new T_M_ALMACEN();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_ALMACEN.Find(idAlmacen);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_ALMACEN> Buscar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_ALMACEN> lista = new List<T_M_ALMACEN>();
            auditoria.Limpiar();
            try
            {

                if (entidad.DES_ALMACEN != "")
                    lista = FindAll(c => c.DES_ALMACEN.Contains(entidad.DES_ALMACEN)).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_ALMACEN lista = new T_M_ALMACEN();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_ALMACEN == entidad.DES_ALMACEN && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_ALMACEN lista = new T_M_ALMACEN();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_ALMACEN == entidad.DES_ALMACEN && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_ALMACEN.Equals(entidad.ID_ALMACEN))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_ALMACEN == entidad.ID_ALMACEN);
                    exito = true;
                }

                if (exito)
                {
                    lista.DES_ALMACEN = entidad.DES_ALMACEN;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_ALMACEN);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Almacen(T_M_ALMACEN entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_ALMACEN lista = new T_M_ALMACEN();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_ALMACEN == entidad.ID_ALMACEN && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_ALMACEN.Equals(entidad.ID_ALMACEN))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_ALMACEN);
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
