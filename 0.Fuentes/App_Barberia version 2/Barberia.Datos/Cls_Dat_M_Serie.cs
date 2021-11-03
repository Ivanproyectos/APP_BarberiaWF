using Barberia.Entidad;
using System;

namespace Barberia.Datos
{
    public class Cls_Dat_M_Serie : Repository<T_M_SERIE>
    {
        public T_M_SERIE Buscar_Serie(T_M_SERIE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_M_SERIE ent = new T_M_SERIE();

            try
            {
                ent = Find(x => x.ID_EMPRESA == entidad.ID_EMPRESA && x.ID_TIPO_COMPROBANTE == entidad.ID_TIPO_COMPROBANTE);
                

            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return ent;
        }

        public void Actualizar_Serie(T_M_SERIE entidad, ref Cls_Ent_Auditoria auditoria)
        {
            T_M_SERIE ent = Find(x => x.ID_EMPRESA == entidad.ID_EMPRESA && x.ID_TIPO_COMPROBANTE == entidad.ID_TIPO_COMPROBANTE);
            auditoria.Limpiar();
            try
            {
                entidad.CORRELATIVO = entidad.CORRELATIVO;
                Update(entidad);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

    }
}
