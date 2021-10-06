using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Corte
    {
        private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        
        private Cls_V_Personal VistaPersonal = new Cls_V_Personal();

        public List<V_PERSONAL> Listar_Personal(int idEmpresa,ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PERSONAL> lista = new List<V_PERSONAL>();
            try
            {
                lista = VistaPersonal.Listar_Personal(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Personal(T_M_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjPersonal.Insertar_Personal(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Personal(T_M_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjPersonal.Actualizar_Personal(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }


        public List<T_M_PERSONAL> Buscar_Personal(T_M_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PERSONAL> lista = new List<T_M_PERSONAL>();
            try
            {
                lista = ObjPersonal.Buscar_Personal(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        

    }
}
