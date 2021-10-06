using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barberia.Datos;
using Barberia.Entidad;

namespace Barberia.Negocio
{
    public class Cls_Rule_Producto
    {
        private Cls_Dat_Producto ObjProducto = new Cls_Dat_Producto();

        public List<Cls_Ent_Producto> Listar_Producto(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<Cls_Ent_Producto> lista = new List<Cls_Ent_Producto>();
            try
            {
                lista = ObjProducto.Listar_Producto(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_M_PRODUCTO ListarUno_Producto(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_PRODUCTO lista = new T_M_PRODUCTO();
            try
            {
                lista = ObjProducto.ListarUno_Producto(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = ObjProducto.Insertar_Producto(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjProducto.Actualizar_Producto(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool ActualizarIMG_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = ObjProducto.ActualizarIMG_Producto(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = ObjProducto.Eliminar_Producto(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_M_PRODUCTO> Buscar_Producto(T_M_PRODUCTO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PRODUCTO> lista = new List<T_M_PRODUCTO>();
            try
            {
                lista = ObjProducto.Buscar_Producto(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public void NuevoStock_Producto(int IdProducto, int NuevoStock, ref Cls_Ent_Auditoria auditoria)
        {
            try
            {
                ObjProducto.NuevoStock_Producto(IdProducto, NuevoStock, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getCodigo_Producto( ref Cls_Ent_Auditoria auditoria)
        {
            string lista = "";
            try
            {
                lista = ObjProducto.getCodigo_Producto(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }
    }
}
