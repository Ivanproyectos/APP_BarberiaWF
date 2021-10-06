using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Act_Stock
    {
        private Cls_Dat_Act_Stock Obj = new Cls_Dat_Act_Stock();

        public List<T_ACTUALIZAR_STOCK> Listar_Act_Stock(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ACTUALIZAR_STOCK> lista = new List<T_ACTUALIZAR_STOCK>();
            try
            {
                lista = Obj.Listar_Act_Stock(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Act_Stock(T_ACTUALIZAR_STOCK entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_Act_Stock(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        

        public bool Eliminar_Act_Stock(T_ACTUALIZAR_STOCK entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_Act_Stock(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_ACTUALIZAR_STOCK> Buscar_Act_Stock(T_ACTUALIZAR_STOCK entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_ACTUALIZAR_STOCK> lista = new List<T_ACTUALIZAR_STOCK>();
            try
            {
                lista = Obj.Buscar_Act_Stock(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Anular_Act_Stock(int id, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                return Obj.Anular_Act_Stock(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
