using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_DocumentoVenta : Repository<T_D_DOCUMENTOS_VENTAS>
    {
        public List<T_D_DOCUMENTOS_VENTAS> Listar_DocumentoVenta(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_DOCUMENTOS_VENTAS> lista = new List<T_D_DOCUMENTOS_VENTAS>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().OrderByDescending(x => x.ID_DOCUMENTO_VENTA).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_D_DOCUMENTOS_VENTAS ListarUno_DocumentoVenta(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_D_DOCUMENTOS_VENTAS entidad = new T_D_DOCUMENTOS_VENTAS();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_D_DOCUMENTOS_VENTAS.Find(id); 
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_D_DOCUMENTOS_VENTAS> Buscar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_DOCUMENTOS_VENTAS> lista = new List<T_D_DOCUMENTOS_VENTAS>();
            auditoria.Limpiar();
            try
            {

                if (entidad.NOMBRE_ARCHIVO != "")
                    lista = FindAll(c => c.NOMBRE_ARCHIVO.Contains(entidad.NOMBRE_ARCHIVO)).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_DOCUMENTOS_VENTAS lista = new T_D_DOCUMENTOS_VENTAS();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                //lista = Find(c => c.DES_DocumentoVenta == entidad.DES_DocumentoVenta && c.FLG_ESTADO == "1");
                //if (lista != null)
                //{
                //    exito = false;
                //}

                if (exito)
                {
                    Add(entidad);
                }    
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_DOCUMENTOS_VENTAS lista = new T_D_DOCUMENTOS_VENTAS();
            bool exito = false;
            auditoria.Limpiar();
            //try
            //{
            //    lista = Find(c => c.DES_DocumentoVenta == entidad.DES_DocumentoVenta && c.FLG_ESTADO == "1");
            //    if (lista != null )
            //    {
            //        if (lista.ID_DocumentoVenta.Equals(entidad.ID_DocumentoVenta))
            //            exito = true;
            //        else
            //            exito = false;
            //    }
            //    else
            //    {
            //        lista = Find(c => c.ID_DocumentoVenta == entidad.ID_DocumentoVenta);
            //        exito = true;
            //    }

            //    if (exito)
            //    {
            //        lista.DES_DocumentoVenta = entidad.DES_DocumentoVenta;
            //        lista.USU_MODIFICA = entidad.USU_MODIFICA;
            //        lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
            //        Update(lista, entidad.ID_DocumentoVenta);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    auditoria.Error(ex);
            //}
            return exito;
        }

        public bool Eliminar_DocumentoVenta(T_D_DOCUMENTOS_VENTAS entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_D_DOCUMENTOS_VENTAS lista = new T_D_DOCUMENTOS_VENTAS();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                //lista = Find(x => x.ID_DocumentoVenta == entidad.ID_DocumentoVenta && x.FLG_ESTADO == "1");
                //if (lista != null)
                //{
                //    if (lista.ID_DocumentoVenta.Equals(entidad.ID_DocumentoVenta))
                //        exito = true;
                //    else
                //        exito = false;
                //}

                //if (exito)
                //{
                //    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                //    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                //    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                //    Update(lista, lista.ID_DocumentoVenta);
                //}
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;

        }

    }
}
