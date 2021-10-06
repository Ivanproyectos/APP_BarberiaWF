
namespace Barberia.Presentacion.Frm_Perfiles
{
    partial class Frm_Perfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Perfil));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPerfil = new System.Windows.Forms.TabControl();
            this.tpMPerfil = new System.Windows.Forms.TabPage();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.lblFlagPerfil = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserM = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblFechaM = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblidPerfilM = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tpCPerfil = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFlagSeccion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIdConfig = new System.Windows.Forms.Label();
            this.btnBuscarSeccion = new System.Windows.Forms.Button();
            this.btnEliminarSeccion = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnActualizarSeccion = new System.Windows.Forms.Button();
            this.btnLimpiarSeccion = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnGuardarSeccion = new System.Windows.Forms.Button();
            this.lblIdPerfil = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPerfil.SuspendLayout();
            this.tpMPerfil.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tpCPerfil.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPerfil
            // 
            this.tabPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPerfil.Controls.Add(this.tpMPerfil);
            this.tabPerfil.Controls.Add(this.tpCPerfil);
            this.tabPerfil.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPerfil.Location = new System.Drawing.Point(110, 95);
            this.tabPerfil.Name = "tabPerfil";
            this.tabPerfil.Padding = new System.Drawing.Point(16, 10);
            this.tabPerfil.SelectedIndex = 0;
            this.tabPerfil.Size = new System.Drawing.Size(741, 544);
            this.tabPerfil.TabIndex = 0;
            this.tabPerfil.Click += new System.EventHandler(this.tabPerfil_Click);
            // 
            // tpMPerfil
            // 
            this.tpMPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.tpMPerfil.Controls.Add(this.pnlContenedor);
            this.tpMPerfil.Controls.Add(this.dataGridView1);
            this.tpMPerfil.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpMPerfil.Location = new System.Drawing.Point(4, 37);
            this.tpMPerfil.Name = "tpMPerfil";
            this.tpMPerfil.Padding = new System.Windows.Forms.Padding(3);
            this.tpMPerfil.Size = new System.Drawing.Size(733, 503);
            this.tpMPerfil.TabIndex = 0;
            this.tpMPerfil.Text = "PERFIL";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlContenedor.Controls.Add(this.lblFlagPerfil);
            this.pnlContenedor.Controls.Add(this.label1);
            this.pnlContenedor.Controls.Add(this.lblUserM);
            this.pnlContenedor.Controls.Add(this.txtDescripcion);
            this.pnlContenedor.Controls.Add(this.lblFechaM);
            this.pnlContenedor.Controls.Add(this.btnActualizar);
            this.pnlContenedor.Controls.Add(this.lblidPerfilM);
            this.pnlContenedor.Controls.Add(this.btnEliminar);
            this.pnlContenedor.Controls.Add(this.btnGuardar);
            this.pnlContenedor.Controls.Add(this.btnLimpiar);
            this.pnlContenedor.Controls.Add(this.btnBuscar);
            this.pnlContenedor.Location = new System.Drawing.Point(66, 26);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(600, 176);
            this.pnlContenedor.TabIndex = 30;
            // 
            // lblFlagPerfil
            // 
            this.lblFlagPerfil.AutoSize = true;
            this.lblFlagPerfil.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlagPerfil.ForeColor = System.Drawing.Color.White;
            this.lblFlagPerfil.Location = new System.Drawing.Point(306, 65);
            this.lblFlagPerfil.Name = "lblFlagPerfil";
            this.lblFlagPerfil.Size = new System.Drawing.Size(22, 16);
            this.lblFlagPerfil.TabIndex = 60;
            this.lblFlagPerfil.Text = "flg";
            this.lblFlagPerfil.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "DESCRIPCIÓN:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUserM
            // 
            this.lblUserM.AutoSize = true;
            this.lblUserM.ForeColor = System.Drawing.Color.White;
            this.lblUserM.Location = new System.Drawing.Point(178, 65);
            this.lblUserM.Name = "lblUserM";
            this.lblUserM.Size = new System.Drawing.Size(30, 14);
            this.lblUserM.TabIndex = 29;
            this.lblUserM.Text = "user";
            this.lblUserM.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(191, 22);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(184, 22);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // lblFechaM
            // 
            this.lblFechaM.AutoSize = true;
            this.lblFechaM.ForeColor = System.Drawing.Color.White;
            this.lblFechaM.Location = new System.Drawing.Point(236, 65);
            this.lblFechaM.Name = "lblFechaM";
            this.lblFechaM.Size = new System.Drawing.Size(37, 14);
            this.lblFechaM.TabIndex = 28;
            this.lblFechaM.Text = "fecha";
            this.lblFechaM.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(416, 17);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 30);
            this.btnActualizar.TabIndex = 18;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblidPerfilM
            // 
            this.lblidPerfilM.AutoSize = true;
            this.lblidPerfilM.ForeColor = System.Drawing.Color.White;
            this.lblidPerfilM.Location = new System.Drawing.Point(88, 65);
            this.lblidPerfilM.Name = "lblidPerfilM";
            this.lblidPerfilM.Size = new System.Drawing.Size(46, 14);
            this.lblidPerfilM.TabIndex = 27;
            this.lblidPerfilM.Text = "id perfil";
            this.lblidPerfilM.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(416, 65);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(119, 114);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 30);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(265, 114);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 30);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(416, 114);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 30);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 211);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(600, 244);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // tpCPerfil
            // 
            this.tpCPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.tpCPerfil.Controls.Add(this.panel1);
            this.tpCPerfil.Controls.Add(this.dataGridView2);
            this.tpCPerfil.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCPerfil.Location = new System.Drawing.Point(4, 37);
            this.tpCPerfil.Name = "tpCPerfil";
            this.tpCPerfil.Padding = new System.Windows.Forms.Padding(3);
            this.tpCPerfil.Size = new System.Drawing.Size(733, 503);
            this.tpCPerfil.TabIndex = 1;
            this.tpCPerfil.Text = "SECCIÓN PERFIL";
            this.tpCPerfil.Click += new System.EventHandler(this.tpCPerfil_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.lblFlagSeccion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblIdConfig);
            this.panel1.Controls.Add(this.btnBuscarSeccion);
            this.panel1.Controls.Add(this.btnEliminarSeccion);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.btnActualizarSeccion);
            this.panel1.Controls.Add(this.btnLimpiarSeccion);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.btnGuardarSeccion);
            this.panel1.Controls.Add(this.lblIdPerfil);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbPerfil);
            this.panel1.Controls.Add(this.cmbModulo);
            this.panel1.Location = new System.Drawing.Point(68, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 178);
            this.panel1.TabIndex = 46;
            // 
            // lblFlagSeccion
            // 
            this.lblFlagSeccion.AutoSize = true;
            this.lblFlagSeccion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlagSeccion.ForeColor = System.Drawing.Color.White;
            this.lblFlagSeccion.Location = new System.Drawing.Point(364, 138);
            this.lblFlagSeccion.Name = "lblFlagSeccion";
            this.lblFlagSeccion.Size = new System.Drawing.Size(22, 16);
            this.lblFlagSeccion.TabIndex = 61;
            this.lblFlagSeccion.Text = "flg";
            this.lblFlagSeccion.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(107, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "PERFIL:";
            // 
            // lblIdConfig
            // 
            this.lblIdConfig.AutoSize = true;
            this.lblIdConfig.ForeColor = System.Drawing.Color.White;
            this.lblIdConfig.Location = new System.Drawing.Point(105, 140);
            this.lblIdConfig.Name = "lblIdConfig";
            this.lblIdConfig.Size = new System.Drawing.Size(65, 14);
            this.lblIdConfig.TabIndex = 45;
            this.lblIdConfig.Text = "ID CONFIG";
            this.lblIdConfig.Visible = false;
            // 
            // btnBuscarSeccion
            // 
            this.btnBuscarSeccion.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBuscarSeccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarSeccion.FlatAppearance.BorderSize = 0;
            this.btnBuscarSeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarSeccion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarSeccion.ForeColor = System.Drawing.Color.White;
            this.btnBuscarSeccion.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarSeccion.Image")));
            this.btnBuscarSeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSeccion.Location = new System.Drawing.Point(367, 96);
            this.btnBuscarSeccion.Name = "btnBuscarSeccion";
            this.btnBuscarSeccion.Size = new System.Drawing.Size(120, 30);
            this.btnBuscarSeccion.TabIndex = 33;
            this.btnBuscarSeccion.Text = "BUSCAR";
            this.btnBuscarSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarSeccion.UseVisualStyleBackColor = false;
            this.btnBuscarSeccion.Click += new System.EventHandler(this.btnBuscarSeccion_Click);
            // 
            // btnEliminarSeccion
            // 
            this.btnEliminarSeccion.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEliminarSeccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarSeccion.FlatAppearance.BorderSize = 0;
            this.btnEliminarSeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarSeccion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarSeccion.ForeColor = System.Drawing.Color.White;
            this.btnEliminarSeccion.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarSeccion.Image")));
            this.btnEliminarSeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarSeccion.Location = new System.Drawing.Point(367, 53);
            this.btnEliminarSeccion.Name = "btnEliminarSeccion";
            this.btnEliminarSeccion.Size = new System.Drawing.Size(120, 30);
            this.btnEliminarSeccion.TabIndex = 31;
            this.btnEliminarSeccion.Text = "ELIMINAR";
            this.btnEliminarSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarSeccion.UseVisualStyleBackColor = false;
            this.btnEliminarSeccion.Click += new System.EventHandler(this.btnEliminarSeccion_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(307, 140);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 14);
            this.lblFecha.TabIndex = 44;
            this.lblFecha.Text = "FECHA";
            this.lblFecha.Visible = false;
            // 
            // btnActualizarSeccion
            // 
            this.btnActualizarSeccion.BackColor = System.Drawing.Color.SeaGreen;
            this.btnActualizarSeccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarSeccion.FlatAppearance.BorderSize = 0;
            this.btnActualizarSeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarSeccion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarSeccion.ForeColor = System.Drawing.Color.White;
            this.btnActualizarSeccion.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarSeccion.Image")));
            this.btnActualizarSeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarSeccion.Location = new System.Drawing.Point(367, 11);
            this.btnActualizarSeccion.Name = "btnActualizarSeccion";
            this.btnActualizarSeccion.Size = new System.Drawing.Size(120, 30);
            this.btnActualizarSeccion.TabIndex = 30;
            this.btnActualizarSeccion.Text = "ACTUALIZAR";
            this.btnActualizarSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarSeccion.UseVisualStyleBackColor = false;
            this.btnActualizarSeccion.Click += new System.EventHandler(this.btnActualizarSeccion_Click);
            // 
            // btnLimpiarSeccion
            // 
            this.btnLimpiarSeccion.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLimpiarSeccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarSeccion.FlatAppearance.BorderSize = 0;
            this.btnLimpiarSeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarSeccion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarSeccion.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarSeccion.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarSeccion.Image")));
            this.btnLimpiarSeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarSeccion.Location = new System.Drawing.Point(221, 96);
            this.btnLimpiarSeccion.Name = "btnLimpiarSeccion";
            this.btnLimpiarSeccion.Size = new System.Drawing.Size(110, 30);
            this.btnLimpiarSeccion.TabIndex = 32;
            this.btnLimpiarSeccion.Text = "LIMPIAR";
            this.btnLimpiarSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarSeccion.UseVisualStyleBackColor = false;
            this.btnLimpiarSeccion.Click += new System.EventHandler(this.btnLimpiarSeccion_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(254, 140);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(36, 14);
            this.lblUser.TabIndex = 43;
            this.lblUser.Text = "USER";
            this.lblUser.Visible = false;
            // 
            // btnGuardarSeccion
            // 
            this.btnGuardarSeccion.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardarSeccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarSeccion.FlatAppearance.BorderSize = 0;
            this.btnGuardarSeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSeccion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarSeccion.ForeColor = System.Drawing.Color.White;
            this.btnGuardarSeccion.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarSeccion.Image")));
            this.btnGuardarSeccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarSeccion.Location = new System.Drawing.Point(99, 96);
            this.btnGuardarSeccion.Name = "btnGuardarSeccion";
            this.btnGuardarSeccion.Size = new System.Drawing.Size(110, 30);
            this.btnGuardarSeccion.TabIndex = 34;
            this.btnGuardarSeccion.Text = "GUARDAR";
            this.btnGuardarSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarSeccion.UseVisualStyleBackColor = false;
            this.btnGuardarSeccion.Click += new System.EventHandler(this.btnGuardarSeccion_Click);
            // 
            // lblIdPerfil
            // 
            this.lblIdPerfil.AutoSize = true;
            this.lblIdPerfil.ForeColor = System.Drawing.Color.White;
            this.lblIdPerfil.Location = new System.Drawing.Point(186, 140);
            this.lblIdPerfil.Name = "lblIdPerfil";
            this.lblIdPerfil.Size = new System.Drawing.Size(60, 14);
            this.lblIdPerfil.TabIndex = 42;
            this.lblIdPerfil.Text = "ID PERFIL";
            this.lblIdPerfil.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(96, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "MÓDULO:";
            // 
            // cmbPerfil
            // 
            this.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.Location = new System.Drawing.Point(180, 15);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(151, 22);
            this.cmbPerfil.TabIndex = 40;
            // 
            // cmbModulo
            // 
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(180, 53);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(151, 22);
            this.cmbModulo.TabIndex = 41;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(68, 213);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(600, 226);
            this.dataGridView2.TabIndex = 29;
            this.dataGridView2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(110, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(741, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(110, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label7.Location = new System.Drawing.Point(138, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 46;
            this.label7.Text = "PERFIL";
            // 
            // Frm_Perfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(900, 666);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabPerfil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Perfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Perfil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Perfil_Load);
            this.tabPerfil.ResumeLayout(false);
            this.tpMPerfil.ResumeLayout(false);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tpCPerfil.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabPerfil;
        private System.Windows.Forms.TabPage tpMPerfil;
        private System.Windows.Forms.TabPage tpCPerfil;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblIdPerfil;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardarSeccion;
        private System.Windows.Forms.Button btnBuscarSeccion;
        private System.Windows.Forms.Button btnLimpiarSeccion;
        private System.Windows.Forms.Button btnEliminarSeccion;
        private System.Windows.Forms.Button btnActualizarSeccion;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIdConfig;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUserM;
        private System.Windows.Forms.Label lblFechaM;
        private System.Windows.Forms.Label lblidPerfilM;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblFlagPerfil;
        private System.Windows.Forms.Label lblFlagSeccion;
    }
}