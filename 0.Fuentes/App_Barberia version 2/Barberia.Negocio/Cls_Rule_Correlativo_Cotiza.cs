using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Correlativo_Cotiza
    {
        //private Cls_Dat_Personal ObjPersonal = new Cls_Dat_Personal();
        private Cls_Dat_Correlativo_Cotizacion obj = new Cls_Dat_Correlativo_Cotizacion();

        public T_CORRELATIVO_COTIZACION Listar_Correlativo(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            T_CORRELATIVO_COTIZACION lista = new T_CORRELATIVO_COTIZACION();
            try
            {
                lista = obj.Listar_Correlativo(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Correlativo(T_CORRELATIVO_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = obj.Insertar_Correlativo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Actualizar_Correlativo(T_CORRELATIVO_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = obj.Actualizar_Correlativo(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }


    }
}
