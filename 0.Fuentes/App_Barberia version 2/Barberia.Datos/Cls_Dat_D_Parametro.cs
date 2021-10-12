using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_D_Parametro : Repository<T_D_PARAMETRO>
    {
        public List<T_D_PARAMETRO> Listar_D_Parametro(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_PARAMETRO> lista = new List<T_D_PARAMETRO>();
            auditoria.Limpiar();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    lista = db.T_D_PARAMETRO.Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_D_PARAMETRO).ToList();
                //}
                lista = GetAll().Where(x => x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_D_PARAMETRO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public T_D_PARAMETRO ListarUno_D_Parametro(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_D_PARAMETRO entidad = new T_D_PARAMETRO();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    entidad = db.T_D_PARAMETRO.Find(id);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public T_D_PARAMETRO ListarUltimo_D_Parametro(int idParametro, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_D_PARAMETRO entidad = new T_D_PARAMETRO();
            try
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    //var idDetalleParametro = (int?)db.T_D_PARAMETRO.Where(x => x.ID_PARAMETRO == idParametro && x.FLG_ESTADO == "1").Max(x => x.ID_D_PARAMETRO) ?? 0;
                    var entidad2 = db.T_D_PARAMETRO.Where(x => x.ID_PARAMETRO == idParametro && x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_D_PARAMETRO).Take(1).FirstOrDefault();
                    if (entidad2 != null)
                    {
                        entidad = (T_D_PARAMETRO)entidad2;
                    }
                    
                    //entidad = db.T_D_PARAMETRO.Where(x => x.ID_PARAMETRO == idParametro).FirstOrDefault(x => x.ID_D_PARAMETRO == idDetalleParametro);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }

        public List<T_D_PARAMETRO> Buscar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_PARAMETRO> lista = new List<T_D_PARAMETRO>();
            auditoria.Limpiar();
            try
            {

                if (entidad.ID_PARAMETRO > 0)
                    lista = FindAll(c => c.ID_PARAMETRO == entidad.ID_PARAMETRO).Where(x => x.FLG_ESTADO == "1").OrderByDescending(c => c.FEC_FIN).ToList();

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;

        }

        public List<T_D_PARAMETRO> Buscar_D_Parametro(T_D_PARAMETRO entidad, string fechaInicio, string fechaFin, ref Cls_Ent_Auditoria auditoria)
        {
            List<T_D_PARAMETRO> lista = new List<T_D_PARAMETRO>();
            auditoria.Limpiar();
            IQueryable<T_D_PARAMETRO> query = Entities;

            try
            {
                if (entidad.ID_PARAMETRO > 0)
                    query = query.Where(c => c.ID_PARAMETRO == entidad.ID_PARAMETRO);

                if (string.IsNullOrEmpty(fechaInicio) && string.IsNullOrEmpty(fechaFin))
                {
                    string fecha = DateTime.Today.ToString("yyyy-MM") + "-01";
                    DateTime fechaNueva = DateTime.Parse(fecha);
                    query = query.Where(w => w.FEC_CREACION >= fechaNueva);
                }
                else
                {
                    if (!string.IsNullOrEmpty(fechaInicio) && fechaFin == "")
                    {
                        DateTime fec = DateTime.Parse(fechaInicio);
                        query = query.Where(w => w.FEC_CREACION >= fec);
                    }
                    else if (fechaInicio != "" && fechaFin != "")
                    {
                        DateTime fechaNuevaInicio = DateTime.Parse(fechaInicio);
                        DateTime fechaNuevaFin = DateTime.Parse(fechaFin + " 11:59:59 pm");
                        query = query.Where(w => w.FEC_INICIO >= fechaNuevaInicio && w.FEC_FIN <= fechaNuevaFin);
                    }
                }

                lista = query.Where(x => x.FLG_ESTADO == "1").OrderByDescending(c => c.FEC_INICIO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public bool Insertar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.FEC_INICIO == entidad.FEC_INICIO && c.VALOR_D == entidad.VALOR_D && c.VALOR_I == entidad.VALOR_I && c.FLG_ESTADO == "1" && c.ID_PARAMETRO == entidad.ID_PARAMETRO);
                if (lista != null)
                {
                    exito = false;
                }

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

        public bool Actualizar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.FEC_INICIO == entidad.FEC_INICIO && c.VALOR_D == entidad.VALOR_D && c.VALOR_I == entidad.VALOR_I && c.FLG_ESTADO == "1");
                if (lista != null )
                {
                    if (lista.ID_D_PARAMETRO.Equals(entidad.ID_D_PARAMETRO))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_D_PARAMETRO == entidad.ID_D_PARAMETRO);
                    exito = true;
                }

                if (exito)
                {
                    lista.FEC_INICIO = entidad.FEC_INICIO;
                    lista.VALOR_D = entidad.VALOR_D;
                    lista.VALOR_I = entidad.VALOR_I;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, entidad.ID_D_PARAMETRO);
                }
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Actualizar_D_Parametro(int idDetalleParametro, decimal valorDecimal, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {

                lista = Find(c => c.ID_D_PARAMETRO == idDetalleParametro);
                lista.VALOR_D = valorDecimal;
                Update(lista, idDetalleParametro);

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool ActualizarHide_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.FEC_INICIO == entidad.FEC_INICIO && c.VALOR_D == entidad.VALOR_D && c.VALOR_I == entidad.VALOR_I && c.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_D_PARAMETRO.Equals(entidad.ID_D_PARAMETRO))
                        exito = true;
                    else
                        exito = false;
                }
                else
                {
                    lista = Find(c => c.ID_D_PARAMETRO == entidad.ID_D_PARAMETRO);
                    exito = true;
                }

                if (exito)
                {
                    lista.FEC_FIN = entidad.FEC_FIN;
                    Update(lista, entidad.ID_D_PARAMETRO);
                }
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool ActualizarFechaFin_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {

                Update(entidad, entidad.ID_D_PARAMETRO);

            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public bool Eliminar_D_Parametro(T_D_PARAMETRO entidad, ref Cls_Ent_Auditoria auditoria)
        {

            T_D_PARAMETRO lista = new T_D_PARAMETRO();
            bool exito = true;
            auditoria.Limpiar();
            try
            {
                lista = Find(x => x.ID_D_PARAMETRO == entidad.ID_D_PARAMETRO && x.FLG_ESTADO == "1");
                if (lista != null)
                {
                    if (lista.ID_D_PARAMETRO.Equals(entidad.ID_D_PARAMETRO))
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.FLG_ESTADO = entidad.FLG_ESTADO;
                    lista.USU_MODIFICA = entidad.USU_MODIFICA;
                    lista.FEC_MODIFICA = entidad.FEC_MODIFICA;
                    Update(lista, lista.ID_D_PARAMETRO);
                }
            }
            catch (Exception ex)
            {
                exito = false;
                auditoria.Error(ex);
            }
            return exito;
        }

        public decimal Igv_D_Parametro(int idEmpresa,ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            decimal valorIgv = 0;
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{

                //    var entidad2 = db.V_PARAMETRO.Where(x => x.ID_EMPRESA == idEmpresa &&  x.FEC_FIN.Value.Year == 2100 &&  x.FLG_ESTADO == "1").FirstOrDefault();
                //    if (entidad2 != null)
                //    {
                //        entidad = (V_PARAMETRO)entidad2;
                //    }

                //}
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    var anio = db.T_M_PARAMETRO.Where(x => x.COD_PARAMETRO == "ANIO" && x.ID_EMPRESA == idEmpresa && x.FLG_ESTADO == "1").Select(x => x.VALOR_I).FirstOrDefault();
                    if (anio != null)
                    {
                        var entidad2 = db.V_PARAMETRO.Where(x => x.ID_EMPRESA == idEmpresa && x.FEC_FIN.Value.Year == anio && x.COD_PARAMETRO == "IGV"
                        && x.ID_EMPRESA == idEmpresa && x.FLG_ESTADO == "1").Select(x => x.DETALLE_VALOR_D).FirstOrDefault();
                        if (entidad2 != null)
                        {
                            valorIgv = (decimal)entidad2;
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                valorIgv = 0;
                auditoria.Error(ex);
            }
            return valorIgv;
        }

    }
}
