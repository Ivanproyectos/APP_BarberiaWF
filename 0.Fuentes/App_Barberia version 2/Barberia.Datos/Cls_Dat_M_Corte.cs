using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_M_Corte : Repository<T_M_CORTE>
    {
        //public List<T_M_PERSONAL> Listar_Personal()
        //{
        //    using (DB_BARBERIAEntities db = new DB_BARBERIAEntities())
        //    {
        //        return db.T_M_PERSONAL.OrderByDescending(t => t.ID_PERSONAL).ToList();
        //    }
        //}

        public List<T_M_CORTE> Buscar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CORTE> lista = new List<T_M_CORTE>();
            auditoria.Limpiar();
            //IQueryable<T_M_CORTE> query = Entities;
            try
            {
                if (entidad.ID_CORTE != 0)
                    lista = FindAll(c => c.ID_CORTE == entidad.ID_CORTE).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public int Insertar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            T_M_CORTE lista = new T_M_CORTE();
            auditoria.Limpiar();
            try
            {
                lista = Add(entidad);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista.ID_CORTE;
        }

        public bool Actualizar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CORTE> lista = new List<T_M_CORTE>();
            auditoria.Limpiar();
            bool exito = false;
            try
            {
                lista = Buscar_M_Corte(entidad, ref auditoria);
                if (lista.Count > 0)
                {
                    lista[0].TOTAL = entidad.TOTAL;
                    Update(lista[0], lista[0].ID_CORTE);
                    exito = true;
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CORTE lista = new T_M_CORTE();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_CORTE == entidad.ID_CORTE && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_CORTE.Equals(entidad.ID_CORTE))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_CORTE);
                }
                return exito;
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                exito = false;
                return exito;
            }

        }

        public string Numero_Corte(ref Cls_Ent_Auditoria auditoria)
        {
            string num = "";
            auditoria.Limpiar();
            try
            {
                List<T_M_CORTE> lista = new List<T_M_CORTE>();
                lista = GetAll().ToList();
                if (lista.Count == 0)
                {
                    num = "0";
                }
                else
                {
                    num = lista.Select(x => x.VOUCHER).Last();
                }

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return num;
        }

        public bool Anular_Corte(string boleta, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                List<T_M_CORTE> lista = new List<T_M_CORTE>();
                lista = GetAll().Where(x => x.VOUCHER == boleta).ToList();
                if (lista.Count != 0)
                {
                    exito = true;
                    foreach (var item in lista)
                    {
                        item.FLG_ESTADO = "0";
                        Update(item, item.ID_CORTE);
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
