using System;
namespace Barberia.Presentacion.Frm_AnularPryVe
{
    public class DataActStock
    {
        public int ID_ACTUALIZAR { get; set; }
        public string PRODUCTO { get; set; }
        public string MARCA { get; set; }
        public string CANTIDAD { get; set; }
        public decimal PRECIO_UND { get; set; }
        public string USER_OPERACION { get; set; }
        public DateTime FECHA_OPERACION { get; set; }
    }
}
