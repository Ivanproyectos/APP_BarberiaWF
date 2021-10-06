using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Provincia : Repository<T_M_PROVINCIA>
    {
        public List<T_M_PROVINCIA> Listar_Provincia(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_PROVINCIA> lista = new List<T_M_PROVINCIA>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().OrderBy(x => x.PROVINCIA).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_M_PROVINCIA> Buscar_Provincia(string codDepartamento, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_PROVINCIA> query = Entities;
            try
            {
                //query = query.Where(c => c.FLG_ESTADO == "1");

                if (!string.IsNullOrEmpty(codDepartamento))
                    query = query.Where(c => c.COD_DEPARTAMENTO == codDepartamento);

                //if (!string.IsNullOrEmpty(entidad.NUM_DOC))
                //    query = query.Where(c => c.NUM_DOC.Contains(entidad.NUM_DOC));

                //if (!string.IsNullOrEmpty(entidad.NOMBRES))
                //    query = query.Where(c => c.NOMBRES.Contains(entidad.NOMBRES));

                //if (!string.IsNullOrEmpty(entidad.APELLIDOS))
                //    query = query.Where(c => c.APELLIDOS.Contains(entidad.APELLIDOS));

                //if (!string.IsNullOrEmpty(entidad.CORREO))
                //    query = query.Where(c => c.CORREO.Contains(entidad.CORREO));

                //if (!string.IsNullOrEmpty(entidad.TELEFONO))
                //    query = query.Where(c => c.TELEFONO.Contains(entidad.TELEFONO));

                //if (!string.IsNullOrEmpty(entidad.DESC_CARGO))
                //    query = query.Where(c => c.DESC_CARGO == entidad.DESC_CARGO);

                query = query.OrderBy(c => c.PROVINCIA);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }



    }
}
