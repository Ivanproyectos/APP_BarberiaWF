using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_V_Cliente : Repository<V_CLIENTE>
    {
        public List<V_CLIENTE> Listar_V_Cliente(int idEmpresa, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<V_CLIENTE> listCliente = new List<V_CLIENTE>();
            try
            {
                listCliente = GetAll().Where(x=> x.ID_EMPRESA == idEmpresa).OrderByDescending(x => x.PERSONA).OrderByDescending(x => x.ID_CLIENTE).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return listCliente;
            
        }

        public List<V_CLIENTE> Buscar_V_Cliente(V_CLIENTE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<V_CLIENTE> query = Entities;
            try
            {
                query = query.Where(c => c.ID_EMPRESA == entidad.ID_EMPRESA);

                if (!string.IsNullOrEmpty(entidad.PERSONA))
                    query = query.Where(c => c.PERSONA == entidad.PERSONA);

                if (!string.IsNullOrEmpty(entidad.R_SOCIAL))
                    query = query.Where(c => c.R_SOCIAL.Contains(entidad.R_SOCIAL));

                if (!string.IsNullOrEmpty(entidad.NUM_DOC))
                    query = query.Where(c => c.NUM_DOC.Contains(entidad.NUM_DOC));

                if (!string.IsNullOrEmpty(entidad.NOMBRE))
                    query = query.Where(c => c.NOMBRE.Contains(entidad.NOMBRE));

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

                //query = query.OrderBy(c => c.PROVINCIA);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }

        public V_CLIENTE ListarUno_V_Cliente(int id, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            V_CLIENTE entidad = new V_CLIENTE();
            try
            {
                //using (DB_BARBERIAEntities1 db = new DB_BARBERIAEntities1())
                //{
                //    entidad = db.T_D_CARGO.Find(id); //.Where(x => x.ID_CARGO == id && x.FLG_ESTADO == "1").OrderByDescending(x => x.ID_CARGO);
                //}
                entidad = Find(x => x.ID_CLIENTE == id);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return entidad;
        }


    }
}
