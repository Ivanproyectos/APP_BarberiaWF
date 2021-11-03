using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_UndMedida : Repository<T_M_UNIDAD_MEDIDA>
    {
        public List<T_M_UNIDAD_MEDIDA> Listar_UndMedida(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_UNIDAD_MEDIDA> lista = new List<T_M_UNIDAD_MEDIDA>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_M_UNIDAD_MEDIDA.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_UNIDAD_MEDIDA).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_UNIDAD_MEDIDA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_UNIDAD_MEDIDA ListarUno_UndMedida(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_UNIDAD_MEDIDA entidad = new T_M_UNIDAD_MEDIDA();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_UNIDAD_MEDIDA.Find(id);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_UNIDAD_MEDIDA> Buscar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_UNIDAD_MEDIDA> lista = new List<T_M_UNIDAD_MEDIDA>();
            auditoria.Limpiar();
            try
            {

                if (entidad.DES_UNIDAD_MEDIDA != "")
                    lista = FindAll(c => c.DES_UNIDAD_MEDIDA.Contains(entidad.DES_UNIDAD_MEDIDA)).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_UNIDAD_MEDIDA lista = new T_M_UNIDAD_MEDIDA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_UNIDAD_MEDIDA == entidad.DES_UNIDAD_MEDIDA && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_UNIDAD_MEDIDA lista = new T_M_UNIDAD_MEDIDA();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DES_UNIDAD_MEDIDA == entidad.DES_UNIDAD_MEDIDA && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_UNIDAD_MEDIDA.Equals(entidad.ID_UNIDAD_MEDIDA))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_UNIDAD_MEDIDA == entidad.ID_UNIDAD_MEDIDA);
                    exito = true;
                }

                if (exito)
                {
                    lista.DES_UNIDAD_MEDIDA = entidad.DES_UNIDAD_MEDIDA;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_UNIDAD_MEDIDA);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_M_UNIDAD_MEDIDA lista = new T_M_UNIDAD_MEDIDA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_UNIDAD_MEDIDA == entidad.ID_UNIDAD_MEDIDA && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_UNIDAD_MEDIDA.Equals(entidad.ID_UNIDAD_MEDIDA))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_UNIDAD_MEDIDA);
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
