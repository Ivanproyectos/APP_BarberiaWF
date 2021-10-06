using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_Empresa
    {
        private Cls_Dat_Empresa ObjCliente = new Cls_Dat_Empresa();

        public List<T_M_EMPRESA> Listar_Empresa(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_EMPRESA> lista = new List<T_M_EMPRESA>();
            try
            {
                lista = ObjCliente.Listar_Empresa(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Empresa(T_M_EMPRESA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjCliente.Insertar_Empresa(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Actualizar_Empresa(T_M_EMPRESA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjCliente.Actualizar_Empresa(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Empresa(T_M_EMPRESA entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjCliente.Eliminar_Empresa(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }



    }
}
