using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_V_Personal : Repository<V_PERSONAL>
    {
        public List<V_PERSONAL> Listar_Personal(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            List<V_PERSONAL> lista = new List<V_PERSONAL>();
            auditoria.Limpiar();
            try 
            {
                using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                {
                    lista = db.V_PERSONAL.Where(t => t.ID_EMPRESA == idEmpresa).OrderByDescending(t => t.ID_PERSONAL).ToList();
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public List<V_PERSONAL> Buscar_Personal(V_PERSONAL entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<V_PERSONAL> query = Entities;
            try
            {

                if (!string.IsNullOrEmpty(entidad.DOCUMENTO))
                    query = query.Where(c => c.DOCUMENTO.Contains(entidad.DOCUMENTO));

                if (!string.IsNullOrEmpty(entidad.NUM_DOC))
                    query = query.Where(c => c.NUM_DOC.Contains(entidad.NUM_DOC));

                if (!string.IsNullOrEmpty(entidad.NOMBRES))
                    query = query.Where(c => c.NOMBRES.Contains(entidad.NOMBRES));

                if (!string.IsNullOrEmpty(entidad.APELLIDO_PAT))
                    query = query.Where(c => c.APELLIDO_PAT.Contains(entidad.APELLIDO_PAT));

                if (!string.IsNullOrEmpty(entidad.APELLIDO_MAT))
                    query = query.Where(c => c.APELLIDO_MAT.Contains(entidad.APELLIDO_MAT));

                if (!string.IsNullOrEmpty(entidad.DOCUMENTO))
                    query = query.Where(c => c.DOCUMENTO == entidad.DOCUMENTO);

                if (!string.IsNullOrEmpty(entidad.NUM_DOC))
                    query = query.Where(c => c.NUM_DOC == entidad.NUM_DOC);

                if (!string.IsNullOrEmpty(entidad.DEPARTAMENTO))
                    query = query.Where(c => c.DEPARTAMENTO == entidad.DEPARTAMENTO);

                if (!string.IsNullOrEmpty(entidad.PROVINCIA))
                    query = query.Where(c => c.PROVINCIA == entidad.PROVINCIA);

                if (!string.IsNullOrEmpty(entidad.DISTRITO))
                    query = query.Where(c => c.DISTRITO == entidad.DISTRITO);

                if (!string.IsNullOrEmpty(entidad.DIRECCION))
                    query = query.Where(c => c.DIRECCION.Contains(entidad.DIRECCION));

                if (!string.IsNullOrEmpty(entidad.CORREO))
                    query = query.Where(c => c.CORREO.Contains(entidad.CORREO));

                if (!string.IsNullOrEmpty(entidad.TELEFONO))
                    query = query.Where(c => c.TELEFONO.Contains(entidad.TELEFONO));

                if (!string.IsNullOrEmpty(entidad.DESC_CARGO))
                    query = query.Where(c => c.DESC_CARGO == entidad.DESC_CARGO);

                query = query.Where(t => t.ID_EMPRESA == entidad.ID_EMPRESA).OrderByDescending(c => c.ID_PERSONAL);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return query.ToList();
        }



    }
}
