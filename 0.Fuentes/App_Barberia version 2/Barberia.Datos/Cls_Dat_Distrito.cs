using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_Distrito : Repository<T_M_DISTRITO>
    {
        public List<T_M_DISTRITO> Listar_Distrito(ref Cls_Ent_Auditoria auditoria)
        {
            List<T_M_DISTRITO> lista = new List<T_M_DISTRITO>();
            auditoria.Limpiar();
            try
            {
                lista = GetAll().OrderBy(x => x.DISTRITO).ToList();
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return lista;
        }

        public List<T_M_DISTRITO> Buscar_Distrito(string codDepartamento, string codProvincia, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            IQueryable<T_M_DISTRITO> query = Entities;
            try
            {
                //query = query.Where(c => c.FLG_ESTADO == "1");

                if (!string.IsNullOrEmpty(codDepartamento))
                    query = query.Where(c => c.COD_DEPARTAMENTO == codDepartamento);

                if (!string.IsNullOrEmpty(codProvincia))
                    query = query.Where(c => c.COD_PROVINCIA == codProvincia);

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

                query = query.OrderBy(c => c.DISTRITO);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return query.ToList();
        }



    }
}
