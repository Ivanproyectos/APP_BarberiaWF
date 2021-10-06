using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_UndMedida
    {
        private Cls_Dat_UndMedida ObjUndMedida = new Cls_Dat_UndMedida();

        public List<T_M_UNIDAD_MEDIDA> Listar_UndMedida(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_UNIDAD_MEDIDA> lista = new List<T_M_UNIDAD_MEDIDA>();
            try
            {
                lista = ObjUndMedida.Listar_UndMedida(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_UNIDAD_MEDIDA ListarUno_UndMedida(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_UNIDAD_MEDIDA lista = new T_M_UNIDAD_MEDIDA();
            try
            {
                lista = ObjUndMedida.ListarUno_UndMedida(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjUndMedida.Insertar_UndMedida(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjUndMedida.Actualizar_UndMedida(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = ObjUndMedida.Eliminar_UndMedida(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_UNIDAD_MEDIDA> Buscar_UndMedida(T_M_UNIDAD_MEDIDA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_UNIDAD_MEDIDA> lista = new List<T_M_UNIDAD_MEDIDA>();
            try
            {
                lista = ObjUndMedida.Buscar_UndMedida(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
