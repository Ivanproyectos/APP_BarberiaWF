using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Parametro
    {
        private Cls_Dat_M_Parametro Obj = new Cls_Dat_M_Parametro();

        public List<T_M_PARAMETRO> Listar_Parametro(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PARAMETRO> lista = new List<T_M_PARAMETRO>();
            try
            {
                lista = Obj.Listar_Parametro(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_PARAMETRO ListarUno_Parametro(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PARAMETRO lista = new T_M_PARAMETRO();
            try
            {
                lista = Obj.ListarUno_Parametro(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        

        public bool Insertar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_PARAMETRO> Buscar_Parametro(T_M_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PARAMETRO> lista = new List<T_M_PARAMETRO>();
            try
            {
                lista = Obj.Buscar_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
