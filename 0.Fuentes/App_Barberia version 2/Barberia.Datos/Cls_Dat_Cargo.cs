using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Cargo : Repository<T_M_CARGO>
    {
        public List<T_M_CARGO> Listar_Cargo(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_CARGO> lista = new List<T_M_CARGO>();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    lista = db.T_M_CARGO.Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == idEmpresa).OrderByDescending(x => x.ID_CARGO).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_CARGO ListarUno_Cargo(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_CARGO entidad = new T_M_CARGO();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_M_CARGO.Find(id); //.Where(x => x.ID_CARGO == id && x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_CARGO> Buscar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_CARGO> lista = new List<T_M_CARGO>();
            try
            {
                if (entidad.DESC_CARGO != "")
                    lista = FindAll(c => c.DESC_CARGO.Contains(entidad.DESC_CARGO)).Where(x => x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA).ToList();

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            auditoria.Limpiar();
            T_M_CARGO lista = new T_M_CARGO();
            bool exito = true;
            try
            {
                lista = Find(c => c.DESC_CARGO == entidad.DESC_CARGO && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CARGO lista = new T_M_CARGO();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.DESC_CARGO == entidad.DESC_CARGO && c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null )
                {
                    if (lista.ID_CARGO == entidad.ID_CARGO)
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_CARGO == entidad.ID_CARGO);
                    exito = true;
                }

                if (exito)
                {
                    lista.DESC_CARGO = entidad.DESC_CARGO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_CARGO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Cargo(T_M_CARGO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_CARGO lista = new T_M_CARGO();
                bool exito = true;

                try
                {
                    lista = Find(x => x.ID_CARGO == entidad.ID_CARGO && x.FLG_ESTADO == "1");
                    if (lista != null)
                    {
                        if (lista.ID_CARGO.Equals(entidad.ID_CARGO))
                            exito = true;
                        else
                            exito = false;

                    }

                    if (exito)
                    {
                        lista.FLG_ESTADO = entidad.FLG_ESTADO;
                        lista.USU_MODIFICA = entidad.USU_MODIFICA;
                        lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                        Update(lista, lista.ID_CARGO);
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
