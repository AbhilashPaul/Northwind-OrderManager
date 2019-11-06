namespace OrderManager
{
    partial class OrderManagerForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.txtRequiredDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpShippedDate = new System.Windows.Forms.DateTimePicker();
            this.btnNullShippedDate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewOrderItems = new System.Windows.Forms.DataGridView();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.cboOrderID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ForeColor = System.Drawing.Color.Maroon;
            this.btnExit.Location = new System.Drawing.Point(454, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 34);
            this.btnExit.TabIndex = 33;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(162, 197);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 23);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Update Shipped Date";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(162, 105);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(93, 20);
            this.txtOrderDate.TabIndex = 23;
            this.txtOrderDate.TabStop = false;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(35, 108);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 13);
            this.lblOrderDate.TabIndex = 22;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(162, 77);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(50, 20);
            this.txtCustomerID.TabIndex = 21;
            this.txtCustomerID.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Customer ID:";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(35, 47);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(50, 13);
            this.lblOrderID.TabIndex = 17;
            this.lblOrderID.Text = "Order ID:";
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.Location = new System.Drawing.Point(162, 136);
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.ReadOnly = true;
            this.txtRequiredDate.Size = new System.Drawing.Size(93, 20);
            this.txtRequiredDate.TabIndex = 35;
            this.txtRequiredDate.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Required Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Shipped Date:";
            // 
            // dtpShippedDate
            // 
            this.dtpShippedDate.CustomFormat = "\'\'";
            this.dtpShippedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShippedDate.Location = new System.Drawing.Point(162, 168);
            this.dtpShippedDate.Name = "dtpShippedDate";
            this.dtpShippedDate.Size = new System.Drawing.Size(93, 20);
            this.dtpShippedDate.TabIndex = 38;
            this.dtpShippedDate.Tag = "Shipped Date";
            this.dtpShippedDate.ValueChanged += new System.EventHandler(this.dtpShippedDate_ValueChanged);
            this.dtpShippedDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpShippedDate_MouseDown);
            // 
            // btnNullShippedDate
            // 
            this.btnNullShippedDate.BackColor = System.Drawing.Color.White;
            this.btnNullShippedDate.Enabled = false;
            this.btnNullShippedDate.ForeColor = System.Drawing.Color.Black;
            this.btnNullShippedDate.Location = new System.Drawing.Point(299, 197);
            this.btnNullShippedDate.Name = "btnNullShippedDate";
            this.btnNullShippedDate.Size = new System.Drawing.Size(118, 23);
            this.btnNullShippedDate.TabIndex = 39;
            this.btnNullShippedDate.Text = "Not yet shipped";
            this.btnNullShippedDate.UseVisualStyleBackColor = false;
            this.btnNullShippedDate.Click += new System.EventHandler(this.btnNullShippedDate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Or";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewOrderItems
            // 
            this.dataGridViewOrderItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderItems.Location = new System.Drawing.Point(38, 266);
            this.dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            this.dataGridViewOrderItems.ReadOnly = true;
            this.dataGridViewOrderItems.Size = new System.Drawing.Size(478, 209);
            this.dataGridViewOrderItems.TabIndex = 41;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(162, 240);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(120, 20);
            this.txtTotal.TabIndex = 43;
            this.txtTotal.TabStop = false;
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.AutoSize = true;
            this.lblOrderTotal.Location = new System.Drawing.Point(35, 243);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(63, 13);
            this.lblOrderTotal.TabIndex = 42;
            this.lblOrderTotal.Text = "Order Total:";
            // 
            // cboOrderID
            // 
            this.cboOrderID.FormattingEnabled = true;
            this.cboOrderID.Location = new System.Drawing.Point(162, 44);
            this.cboOrderID.Name = "cboOrderID";
            this.cboOrderID.Size = new System.Drawing.Size(93, 21);
            this.cboOrderID.TabIndex = 44;
            this.cboOrderID.SelectedIndexChanged += new System.EventHandler(this.cboOrderID_SelectedIndexChanged);
            // 
            // OrderManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(567, 496);
            this.Controls.Add(this.cboOrderID);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.dataGridViewOrderItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNullShippedDate);
            this.Controls.Add(this.dtpShippedDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOrderID);
            this.Name = "OrderManagerForm";
            this.Text = "Order Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.TextBox txtRequiredDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpShippedDate;
        private System.Windows.Forms.Button btnNullShippedDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewOrderItems;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.ComboBox cboOrderID;
    }
}

