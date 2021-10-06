using Barberia.Entidad;
using System;

namespace Barberia.Datos
{
    public class Cls_Dat_Correlativo_Cotizacion : Repository<T_CORRELATIVO_COTIZACION>
    {
        public T_CORRELATIVO_COTIZACION Listar_Correlativo(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_CORRELATIVO_COTIZACION entidad = new T_CORRELATIVO_COTIZACION();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    codigo = (from c in db.T_CORRELATIVO_COTIZACION
                //              orderby c.ID_CORRELATIVO descending
                //              select c.NUM_COTIZACION).FirstOrDefault();
                //    if (codigo == null)
                //    {
                //        codigo = DateTime.Now.ToShortDateString() +  "-00000001";
                //    }
                //    else
                //    {
                //        int numero = codigo.Substring(5, 8);

                //        codigo = (int.Parse(codigo) + 1).ToString();
                //    }
                //}
                entidad = Find(x => x.ID_EMPRESA == idEmpresa);
                
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new T_CORRELATIVO_COTIZACION();
            }
            return entidad;
        }

        public bool Insertar_Correlativo(T_CORRELATIVO_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_CORRELATIVO_COTIZACION lista = new T_CORRELATIVO_COTIZACION();
            bool exito = true;
            try
            {
                lista = Find(c => c.ID_EMPRESA == entidad.ID_EMPRESA);
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

        public bool Actualizar_Correlativo(T_CORRELATIVO_COTIZACION entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_CORRELATIVO_COTIZACION lista = new T_CORRELATIVO_COTIZACION();
            bool exito = false;
            auditoria.Limpiar();
            try
            {
                lista = Find(c => c.ID_EMPRESA == entidad.ID_EMPRESA);
                if (lista != null)
                {
                    if (lista.ID_EMPRESA == entidad.ID_EMPRESA)
                        exito = true;
                    else
                        exito = false;
                }

                if (exito)
                {
                    lista.NUM_COTIZACION = entidad.NUM_COTIZACION;
                    lista.ANIO = entidad.ANIO;
                    Update(lista, lista.ID_CORRELATIVO);
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return exito;
        }

    }
}
