using Barberia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barberia.Datos
{
    public class Cls_Dat_C_Anular : Repository<T_C_ANULAR>
    {
        public List<T_C_ANULAR> Listar_C_Anular(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            List<T_C_ANULAR> lista = new List<T_C_ANULAR>();
            try
            {
                lista = GetAll().ToList();
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return lista;
        }

        public void Actualizar_C_Anular(int id,string numero, DateTime fecha, ref Cls_Ent_Auditoria auditoria)
        {
            T_C_ANULAR entidad = Find(x => x.ID_C_ANULAR == id);
            auditoria.Limpiar();
            try
            {
                entidad.NUMERO = numero;
                entidad.FECHA = fecha;
                Update(entidad);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

    }
}
