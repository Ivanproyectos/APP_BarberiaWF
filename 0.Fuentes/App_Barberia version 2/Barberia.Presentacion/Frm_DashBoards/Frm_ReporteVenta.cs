using Barberia.Entidad;
using Barberia.Negocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia.Presentacion.Frm_DashBoards
{
    public partial class Frm_ReporteVenta : Form
    {
        private Cls_Rule_V_Venta objVVenta = new Cls_Rule_V_Venta();

        private Cls_Rule_Personal ObjPersonal = new Cls_Rule_Personal();
        private Cls_Rule_Factura ObjVoucherVenta = new Cls_Rule_Factura();
        public Frm_ReporteVenta()
        {
            InitializeComponent();
        }

        void EventoCarga()
        {
            List<T_M_CLIENTES> lisCliente = new List<T_M_CLIENTES>();
            List<T_M_PERSONAL> lisPersonal = new List<T_M_PERSONAL>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();

            lisPersonal = ObjPersonal.Listar_Personal(1, ref auditoria).Select(x => new T_M_PERSONAL
            {
                NOMBRES = x.NOMBRES + " " + x.APELLIDO_PAT + " " + x.APELLIDO_MAT,
                ID_PERSONAL = x.ID_PERSONAL
            }).ToList();

            lisPersonal.Insert(0, new T_M_PERSONAL
            {
                ID_PERSONAL = 0,
                NOMBRES = "-- SELECCIONE --"
            });
            cmbPersonal.DataSource = lisPersonal;
            cmbPersonal.DisplayMember = "NOMBRES";
            cmbPersonal.ValueMember = "ID_PERSONAL";

            //

            //this.reportViewer1.RefreshReport();
        }
        private void Frm_ReporteVenta_Load(object sender, EventArgs e)
        {
            Task tarea;
            CheckForIllegalCrossThreadCalls = false;
            tarea = Task.Run(() => EventoCarga()).ContinueWith(t => t.Dispose());
        }

        private void picBusPersonal_Click(object sender, EventArgs e)
        {
            Frm_Buscar form = new Frm_Buscar("PERSONAL");
            form.ShowDialog();
            if (form.DevolverNombre == null)
                cmbPersonal.SelectedIndex = 0;
            else
                cmbPersonal.Text = form.DevolverNombre;  
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //cmbCliente.SelectedIndex = 0;
            cmbPersonal.SelectedIndex = 0;
            txtVoucher.Text = string.Empty;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            V_VENTA entidad = new V_VENTA();
            string fechaInicio, fechaFin;

            entidad.PERSONAL = cmbPersonal.SelectedIndex == 0 ? "" : cmbPersonal.Text;
            entidad.VOUCHER = txtVoucher.Text;
            fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
            fechaFin = dtpFechaFin.Value.ToString("dd/MM/yyyy");

            List<V_VENTA> lista = new List<V_VENTA>();
            List<V_VENTA> lista2 = new List<V_VENTA>();
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();
            int auxiliar = 0;
            lista = objVVenta.Buscar_Venta(entidad, fechaInicio, fechaFin, ref auditoria);

            if (lista.Count > 0)
            {
                lista2.Add(new V_VENTA
                {
                    VOUCHER = lista[0].VOUCHER,
                    PERSONAL = lista[0].PERSONAL,
                    PRODUCTO = lista[0].PRODUCTO,
                    CANTIDAD = (int)lista[0].CANTIDAD,
                    PRECIO = (decimal)lista[0].PRECIO,
                    IMPORTE = (decimal)lista[0].IMPORTE,
                    TOTAL_IMPORTE = (decimal)lista[0].TOTAL_IMPORTE,
                    IGV = (decimal)lista[0].IGV,
                    DESCT_TOTAL = (decimal)lista[0].DESCT_TOTAL,
                    TOTAL = (decimal)lista[0].TOTAL,
                    FEC_VENTA = (DateTime)lista[0].FEC_VENTA
                });

                for (int i = 1; i < lista.Count; i++)
                {
                    if (lista[i].VOUCHER != lista2[auxiliar].VOUCHER)
                    {
                        lista2.Add(new V_VENTA
                        {
                            VOUCHER = lista[i].VOUCHER,
                            PERSONAL = lista[i].PERSONAL,
                            PRODUCTO = lista[i].PRODUCTO,
                            CANTIDAD = (int)lista[i].CANTIDAD,
                            PRECIO = (decimal)lista[i].PRECIO,
                            IMPORTE = (decimal)lista[i].IMPORTE,
                            TOTAL_IMPORTE = (decimal)lista[i].TOTAL_IMPORTE,
                            IGV = (decimal)lista[i].IGV,
                            DESCT_TOTAL = (decimal)lista[i].DESCT_TOTAL,
                            TOTAL = (decimal)lista[i].TOTAL,
                            FEC_VENTA = (DateTime)lista[i].FEC_VENTA
                        });
                        auxiliar += 1;
                    }
                    else
                    {
                        lista2.Add(new V_VENTA
                        {
                            VOUCHER = lista[i].VOUCHER,
                            PERSONAL = lista[i].PERSONAL,
                            PRODUCTO = lista[i].PRODUCTO,
                            CANTIDAD = (int)lista[i].CANTIDAD,
                            PRECIO = (decimal)lista[i].PRECIO,
                            IMPORTE = (decimal)lista[i].IMPORTE,
                            //TOTAL_IMPORTE = (decimal)lista[i].TOTAL_IMPORTE,
                            //IGV = (decimal)lista[i].IGV,
                            //DESCT_TOTAL = (decimal)lista[i].DESCT_TOTAL,
                            //TOTAL = (decimal)lista[i].TOTAL,
                            FEC_VENTA = (DateTime)lista[i].FEC_VENTA
                        });
                        lista2.Reverse(auxiliar, 2);
                        auxiliar += 1;
                        
                    }
                }
            }



            if (entidad.PERSONAL != "" || fechaInicio != "" || fechaFin != "")
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteVenta.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds1 = new ReportDataSource("DataSetVenta", lista2);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.RefreshReport();
            }
        }

        private void btnReporteDia_Click(object sender, EventArgs e)
        {
            V_VENTA entidad = new V_VENTA();
            List<DataTotal> dataTotal = new List<DataTotal>();
            string fechaInicio, fechaFin;
            int auxiliar = 0;
            fechaInicio = DateTime.Now.ToString("dd/MM/yyyy");
            fechaFin = DateTime.Now.ToString("dd/MM/yyyy");
            Cls_Ent_Auditoria auditoria = new Cls_Ent_Auditoria();

            List<V_VENTA> lista = new List<V_VENTA>();
            lista = objVVenta.Buscar_Venta(entidad, fechaInicio, fechaFin, ref auditoria);

            if (lista.Count > 0)
            {
                dataTotal.Add(new DataTotal
                {
                    VOUCHER = lista[0].VOUCHER,
                    PERSONAL = lista[0].PERSONAL,
                    //PRODUCTO = lista[0].PRODUCTO,
                    CANTIDAD = (int)lista[0].CANTIDAD,
                    TOTAL = (decimal)lista[0].TOTAL,
                    FECH_VENTA = (DateTime)lista[0].FEC_VENTA
                });

                for (int i = 1; i < lista.Count; i++)
                {
                    if (lista[i].VOUCHER != dataTotal[auxiliar].VOUCHER)
                    {
                        dataTotal.Add(new DataTotal
                        {
                            VOUCHER = lista[i].VOUCHER,
                            PERSONAL = lista[i].PERSONAL,
                            //PRODUCTO = lista[0].PRODUCTO,
                            CANTIDAD = (int)lista[i].CANTIDAD,
                            TOTAL = (decimal)lista[i].TOTAL,
                            FECH_VENTA = (DateTime)lista[i].FEC_VENTA
                        });
                        auxiliar += 1;
                    }
                }
            }


            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Barberia.Presentacion.Reporte.ReporteVentaXDia.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds1 = new ReportDataSource("DataSetVenta", dataTotal);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            //this.reportViewer1.ZoomPercent = 115;
            this.reportViewer1.RefreshReport();

        }
    }
}
