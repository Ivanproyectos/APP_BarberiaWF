using Barberia.Entidad;
using System;

namespace Barberia.Datos
{
    public class Cls_Dat_Boleta : Repository<T_BOLETA>
    {
        public T_BOLETA Listar_Boleta(ref Cls_Ent_Auditoria auditoria)
        {
            auditoria.Limpiar();
            T_BOLETA entidad = new T_BOLETA();
            try
            {
                entidad = Get(1);
            }
            catch (Exception ex)
            {

                auditoria.Error(ex);
            }
            return entidad;
        }

        public void Actualizar_Boleta(int numero, string anio, ref Cls_Ent_Auditoria auditoria)
        {
            T_BOLETA entidad = Find(x => x.ID_BOLETA == 1);
            auditoria.Limpiar();
            try
            {
                entidad.NUMERO = numero;
                entidad.ANIO = anio;
                Update(entidad);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }

    }
}
