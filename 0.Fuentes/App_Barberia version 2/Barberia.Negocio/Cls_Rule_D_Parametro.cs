using Barberia.Datos;
using Barberia.Entidad;
using System;
using System.Collections.Generic;

namespace Barberia.Negocio
{
    public class Cls_Rule_D_Parametro
    {
        private Cls_Dat_D_Parametro Obj = new Cls_Dat_D_Parametro();

        public List<T_D_PARAMETRO> Listar_D_Parametro(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_PARAMETRO> lista = new List<T_D_PARAMETRO>();
            try
            {
                lista = Obj.Listar_D_Parametro(ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_D_PARAMETRO ListarUno_D_Parametro(int id, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            try
            {
                lista = Obj.ListarUno_D_Parametro(id, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public T_D_PARAMETRO ListarUltimo_D_Parametro(int idParametro, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            try
            {
                lista = Obj.ListarUltimo_D_Parametro(idParametro, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool Insertar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria) 
        {
            bool exito = false;
            try
            {
                exito = Obj.Insertar_D_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        
        public bool Actualizar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_D_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Actualizar_D_Parametro(int idDetalleParametro, decimal valorDecimal, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.Actualizar_D_Parametro(idDetalleParametro, valorDecimal, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool ActualizarHide_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.ActualizarHide_D_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool ActualizarFechaFin_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito = false;
            try
            {
                exito = Obj.ActualizarFechaFin_D_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool Eliminar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            bool exito;
            try
            {
                exito = Obj.Eliminar_D_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<T_D_PARAMETRO> Buscar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_PARAMETRO> lista = new List<T_D_PARAMETRO>();
            try
            {
                lista = Obj.Buscar_D_Parametro(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<T_D_PARAMETRO> Buscar_D_Parametro(T_D_PARAMETRO entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_PARAMETRO> lista = new List<T_D_PARAMETRO>();
            try
            {
                lista = Obj.Buscar_D_Parametro(entidad, fechaInicio, fechaFin, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public decimal Igv_D_Parametro(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            decimal lista;
            try
            {
                lista = Obj.Igv_D_Parametro(idEmpresa, ref auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}
