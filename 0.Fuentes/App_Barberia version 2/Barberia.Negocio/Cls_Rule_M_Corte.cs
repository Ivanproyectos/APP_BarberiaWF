using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_M_Corte
    {
        private Cls_Dat_M_Corte ObjMCorte = new Cls_Dat_M_Corte();

        //public List<V_PERSONAL> Listar_Personal()
        //{
        //    List<V_PERSONAL> lista = new List<V_PERSONAL>();
        //    try
        //    {
        //        lista = VistaPersonal.Listar_Personal();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public int Insertar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            int idCorte;
            try
            {
                idCorte = ObjMCorte.Insertar_M_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return idCorte;
        }
        
        public bool Actualizar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjMCorte.Actualizar_M_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
               exito = ObjMCorte.Eliminar_M_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_CORTE> Buscar_M_Corte(T_M_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CORTE> lista = new List<T_M_CORTE>();
            try
            {
                lista = ObjMCorte.Buscar_M_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public string Numero_Corte(ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return ObjMCorte.Numero_Corte(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Anular_Corte(string boleta, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return ObjMCorte.Anular_Corte(boleta, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
