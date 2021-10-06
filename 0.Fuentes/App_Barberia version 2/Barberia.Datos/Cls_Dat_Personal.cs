using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Personal : Repository<T_M_PERSONAL>
    {
        public List<T_M_PERSONAL> Listar_Personal(int idEmpresa,ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_M_PERSONAL> lista = new List<T_M_PERSONAL>();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    lista = db.T_M_PERSONAL.Where(t => t.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_PERSONAL).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_M_PERSONAL ListarUno_Cargo(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_PERSONAL entidad = new T_M_PERSONAL();
            try
            {
                entidad = Find(x => x.ID_PERSONAL == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_M_PERSONAL> Buscar_Personal(T_M_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_PERSONAL> query = Entities;
            try
            {
                query = query.Where(c => c.FLG_ESTADO == "1" && c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (entidad.ID_PERSONAL > 0)
                    query = query.Where(c => c.ID_PERSONAL == entidad.ID_PERSONAL);

                if (!string.IsNullOrEmpty(entidad.TIPO_DOC))
                    query = query.Where(c => c.TIPO_DOC.Contains(entidad.TIPO_DOC));

                if (!string.IsNullOrEmpty(entidad.NUM_DOC))
                    query = query.Where(c => c.NUM_DOC.Contains(entidad.NUM_DOC));

                if (!string.IsNullOrEmpty(entidad.NOMBRES))
                    query = query.Where(c => c.NOMBRES.Contains(entidad.NOMBRES));

                if (!string.IsNullOrEmpty(entidad.APELLIDO_PAT))
                    query = query.Where(c => c.APELLIDO_PAT.Contains(entidad.APELLIDO_PAT));

                if (!string.IsNullOrEmpty(entidad.APELLIDO_MAT))
                    query = query.Where(c => c.APELLIDO_MAT.Contains(entidad.APELLIDO_MAT));

                if (!string.IsNullOrEmpty(entidad.CORREO))
                    query = query.Where(c => c.CORREO.Contains(entidad.CORREO));

                if (!string.IsNullOrEmpty(entidad.TELEFONO))
                    query = query.Where(c => c.TELEFONO.Contains(entidad.TELEFONO));

                if (entidad.ID_CARGO > 0)
                    query = query.Where(c => c.ID_CARGO == entidad.ID_CARGO);

                query = query.OrderByDescending(c => c.ID_PERSONAL);

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }

        public bool Insertar_Personal(T_M_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            T_M_PERSONAL lista = new T_M_PERSONAL();
            auditoria.Limpiar();
            bool exito = true;
            try
            {
                lista = Find(x => x.TIPO_DOC == entidad.TIPO_DOC && x.NUM_DOC == entidad.NUM_DOC && x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Personal(T_M_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PERSONAL lista = new T_M_PERSONAL();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.TIPO_DOC == entidad.TIPO_DOC && x.NUM_DOC == entidad.NUM_DOC && x.FLG_ESTADO == "1" && x.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null)
                {
                    if (lista.ID_PERSONAL != entidad.ID_PERSONAL)
                    {
                        exito = false;
                    }
                }
                else
                {
                    lista = Find(x => x.ID_PERSONAL == entidad.ID_PERSONAL);
                }

                if (exito)
                {
                    lista.NOMBRES = entidad.NOMBRES;
                    lista.APELLIDO_PAT = entidad.APELLIDO_PAT;
                    lista.APELLIDO_MAT = entidad.APELLIDO_MAT;
                    lista.TIPO_DOC = entidad.TIPO_DOC;
                    lista.NUM_DOC = entidad.NUM_DOC;
                    lista.ID_CARGO = entidad.ID_CARGO;
                    lista.COD_DEPARTAMENTO = entidad.COD_DEPARTAMENTO;
                    lista.COD_PROVINCIA = entidad.COD_PROVINCIA;
                    lista.COD_DISTRITO = entidad.COD_DISTRITO;
                    lista.DIRECCION = entidad.DIRECCION;
                    lista.CORREO = entidad.CORREO;
                    lista.TELEFONO = entidad.TELEFONO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_PERSONAL);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Personal(T_M_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PERSONAL> lista = new List<T_M_PERSONAL>();
            bool exito = true;
            auditoria.Limpiar();

            try
            {
                if (entidad.ID_PERSONAL > 0)
                {
                    lista = FindAll(c => c.ID_PERSONAL == entidad.ID_PERSONAL).Where(c => c.FLG_ESTADO == "1").ToList();
                    if (lista.Count > 0)
                    {
                        lista[0].FLG_ESTADO = entidad.FLG_ESTADO;
                        lista[0].USU_MODIFICA = entidad.USU_MODIFICA;
                        lista[0].FEC_MODIFICA = entidad.FEC_MODIFICA;
                        Update(lista[0], lista[0].ID_PERSONAL);
                    }
                    else
                    {
                        exito = false;
                    }
                }
                else if (entidad.ID_CARGO > 0) // eliminar por cargo
                {
                    lista = FindAll(c => c.ID_CARGO == entidad.ID_CARGO).Where(c => c.FLG_ESTADO == "1").ToList();
                    if (lista.Count > 0)
                    {
                        foreach (var item in lista)
                        {
                            item.FLG_ESTADO = entidad.FLG_ESTADO;
                            item.USU_MODIFICA = entidad.USU_MODIFICA;
                            item.FEC_MODIFICA = entidad.FEC_MODIFICA;
                            Update(item, item.ID_PERSONAL);
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
