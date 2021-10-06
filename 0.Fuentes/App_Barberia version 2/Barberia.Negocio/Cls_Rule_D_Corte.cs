using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_D_Corte
    {
        private Cls_Dat_D_Corte ObjDCorte = new Cls_Dat_D_Corte();
        //private Cls_V_Personal VistaPersonal = new Cls_V_Personal();

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

        public bool Insertar_D_Corte(T_D_CORTE entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjDCorte.Insertar_D_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_D_Corte(T_D_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjDCorte.Actualizar_D_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public void Eliminar_D_Corte(int id, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                ObjDCorte.Eliminar_D_Corte(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T_D_CORTE> Buscar_D_Corte(T_D_CORTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_CORTE> lista = new List<T_D_CORTE>();
            try
            {
                lista = ObjDCorte.Buscar_D_Corte(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
