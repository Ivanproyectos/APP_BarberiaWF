using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Modelo
    {
        private Cls_Dat_Modelo obj = new Cls_Dat_Modelo();

        public List<T_M_MODELO> Listar_Modelo(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_MODELO> lista = new List<T_M_MODELO>();
            try
            {
                lista = obj.Listar_Modelo(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_MODELO ListarUno_Modelo(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_MODELO lista = new T_M_MODELO();
            try
            {
                lista = obj.ListarUno_Modelo(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = obj.Insertar_Modelo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = obj.Actualizar_Modelo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = obj.Eliminar_Modelo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_MODELO> Buscar_Modelo(T_M_MODELO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_MODELO> lista = new List<T_M_MODELO>();
            try
            {
                lista = obj.Buscar_Modelo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
