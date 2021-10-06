using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Clase
    {
        private Cls_Dat_Clase Obj = new Cls_Dat_Clase();

        public List<T_M_CLASE> Listar_Clase(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLASE> lista = new List<T_M_CLASE>();
            try
            {
                lista = Obj.Listar_Clase(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_CLASE ListarUno_Clase(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_CLASE lista = new T_M_CLASE();
            try
            {
                lista = Obj.ListarUno_Clase(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Clase(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_Clase(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_Clase(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_CLASE> Buscar_Clase(T_M_CLASE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_CLASE> lista = new List<T_M_CLASE>();
            try
            {
                lista = Obj.Buscar_Clase(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
