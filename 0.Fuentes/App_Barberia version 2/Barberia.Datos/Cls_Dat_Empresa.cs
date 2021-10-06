using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Empresa : Repository<T_M_EMPRESA>
    {
        public List<T_M_EMPRESA> Listar_Empresa(ref Cls_Ent_Auditoria auditoria)
        {
            
            List<T_M_EMPRESA> lista = new List<T_M_EMPRESA>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;

        }

        
        public bool Insertar_Empresa(T_M_EMPRESA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            List<T_M_EMPRESA> lista = new List<T_M_EMPRESA>();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = FindAll(x => x.RUC == entidad.RUC).Where(x => x.FLG_ESTADO == "1").ToList();
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

        public bool Actualizar_Empresa(T_M_EMPRESA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_EMPRESA lista = new T_M_EMPRESA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.RUC == entidad.RUC && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_EMPRESA != entidad.ID_EMPRESA)
                    {
                        exito = false;
                    }
                }
                else
                {
                    lista = Find(x => x.ID_EMPRESA == entidad.ID_EMPRESA);
                }

                if (exito)
                {
                    
                    lista.R_SOCIAL = entidad.R_SOCIAL;
                    lista.RUC = entidad.RUC;
                    lista.NOM_COMERCIAL = entidad.NOM_COMERCIAL;
                    lista.COD_DEPARTAMENTO = entidad.COD_DEPARTAMENTO;
                    lista.COD_PROVINCIA = entidad.COD_PROVINCIA;
                    lista.COD_DISTRITO = entidad.COD_DISTRITO;
                    lista.UBIGEO = entidad.UBIGEO;
                    lista.DIRECCION = entidad.DIRECCION;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_Empresa(T_M_EMPRESA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_EMPRESA ent = new T_M_EMPRESA();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                ent = Find(x => x.ID_EMPRESA == entidad.ID_EMPRESA && x.FLG_ESTADO == "1");
                if (ent != null)
                {
                    ent.FLG_ESTADO = entidad.FLG_ESTADO;
                    ent.USU_MODIFICA = entidad.USU_MODIFICA;
                    ent.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(ent, ent.ID_EMPRESA);
                }
                else
                {
                    exito = false;
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
