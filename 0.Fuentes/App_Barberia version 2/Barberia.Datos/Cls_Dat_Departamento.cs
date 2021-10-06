using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Departamento: Repository<T_M_DEPARTAMENTO>
    {
        public List<T_M_DEPARTAMENTO> Listar_Departamento(ref Cls_Ent_Auditoria auditoria)
        {
            //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
            //{
            //    return db.V_PERSONAL.Where(c => c.FLG_ESTADO == "1").OrderByDescending(t => t.ID_PERSONAL).ToList();
            //}
            auditoria.Limpiar();
            List<T_M_DEPARTAMENTO> lista = new List<T_M_DEPARTAMENTO>();
            try
            {
                lista = GetAll().OrderBy(x => x.DEPARTAMENTO).ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_M_DEPARTAMENTO> Buscar_Departamento(string cod, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_DEPARTAMENTO> query = Entities;
            try
            {
                //query = query.Where(c => c.FLG_ESTADO == "1");

                //if (!string.IsNullOrEmpty(entidad.TIPO_DOC))
                //    query = query.Where(c => c.TIPO_DOC.Contains(entidad.TIPO_DOC));

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

                //query = query.OrderByDescending(c => c.ID_PERSONAL);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }



    }
}
