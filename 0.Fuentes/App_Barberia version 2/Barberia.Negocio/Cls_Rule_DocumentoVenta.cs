using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_DocumentoVenta
    {
        private Cls_Dat_DocumentoVenta obj = new Cls_Dat_DocumentoVenta();

        public List<T_D_DOCUMENTOS_VENTAS> Listar_DocumentoVenta(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_DOCUMENTOS_VENTAS> lista = new List<T_D_DOCUMENTOS_VENTAS>();
            try
            {
                lista = obj.Listar_DocumentoVenta(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_D_DOCUMENTOS_VENTAS ListarUno_DocumentoVenta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_DOCUMENTOS_VENTAS lista = new T_D_DOCUMENTOS_VENTAS();
            try
            {
                lista = obj.ListarUno_DocumentoVenta(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = obj.Insertar_DocumentoVenta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = obj.Actualizar_DocumentoVenta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = obj.Eliminar_DocumentoVenta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_D_DOCUMENTOS_VENTAS> Buscar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_DOCUMENTOS_VENTAS> lista = new List<T_D_DOCUMENTOS_VENTAS>();
            try
            {
                lista = obj.Buscar_DocumentoVenta(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
