
using System.Runtime.CompilerServices;

namespace Gof.Design.Patterns.Winforms.Forms
{
    partial class FrmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private static FrmEmployee _instance = null;

        public static FrmEmployee Instance
        {
            get
            {
                if (_instance == null) return new FrmEmployee();
                return _instance;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            _instance = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployee));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuCreate = new System.Windows.Forms.ToolStripButton();
            this.mnuEdit = new System.Windows.Forms.ToolStripButton();
            this.mnuDelete = new System.Windows.Forms.ToolStripButton();
            this.mnuRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProcess = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.mnuCompute = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreate,
            this.mnuEdit,
            this.mnuDelete,
            this.mnuRefresh,
            this.toolStripSeparator1,
            this.mnuProcess,
            this.mnuCompute});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuCreate
            // 
            this.mnuCreate.Image = ((System.Drawing.Image)(resources.GetObject("mnuCreate.Image")));
            this.mnuCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCreate.Name = "mnuCreate";
            this.mnuCreate.Size = new System.Drawing.Size(45, 35);
            this.mnuCreate.Text = "Create";
            this.mnuCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuCreate.Click += new System.EventHandler(this.button_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = ((System.Drawing.Image)(resources.GetObject("mnuEdit.Image")));
            this.mnuEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(31, 35);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuEdit.Click += new System.EventHandler(this.button_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(44, 35);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuDelete.Click += new System.EventHandler(this.button_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuRefresh.Image")));
            this.mnuRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(50, 35);
            this.mnuRefresh.Text = "Refresh";
            this.mnuRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuRefresh.Click += new System.EventHandler(this.button_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // mnuProcess
            // 
            this.mnuProcess.Image = ((System.Drawing.Image)(resources.GetObject("mnuProcess.Image")));
            this.mnuProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuProcess.Name = "mnuProcess";
            this.mnuProcess.Size = new System.Drawing.Size(51, 35);
            this.mnuProcess.Tag = "Process";
            this.mnuProcess.Text = "Process";
            this.mnuProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuProcess.ToolTipText = "Process Attendance and Deduction";
            this.mnuProcess.Click += new System.EventHandler(this.button_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 38);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 25;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(800, 390);
            this.dgvList.TabIndex = 2;
            this.dgvList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_ColumnHeaderMouseClick);
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // mnuCompute
            // 
            this.mnuCompute.Image = ((System.Drawing.Image)(resources.GetObject("mnuCompute.Image")));
            this.mnuCompute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCompute.Name = "mnuCompute";
            this.mnuCompute.Size = new System.Drawing.Size(61, 35);
            this.mnuCompute.Text = "Compute";
            this.mnuCompute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuCompute.Click += new System.EventHandler(this.button_Click);
            // 
            // FrmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEmployee_Load);
            this.Resize += new System.EventHandler(this.FrmEmployee_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuCreate;
        private System.Windows.Forms.ToolStripButton mnuEdit;
        private System.Windows.Forms.ToolStripButton mnuDelete;
        public System.Windows.Forms.ToolStripButton mnuRefresh;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuProcess;
        private System.Windows.Forms.ToolStripButton mnuCompute;
    }
}