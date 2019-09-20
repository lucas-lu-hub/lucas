using C1.Win.C1FlexGrid;
namespace StaffManagementSystem
{
    partial class StaffView
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
            this.StaffGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.EditBtn = new System.Windows.Forms.Button();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.CommitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StaffGrid)).BeginInit();
            this.EditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StaffGrid
            // 
            this.StaffGrid.AllowEditing = false;
            this.StaffGrid.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.StaffGrid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.StaffGrid.ColumnInfo = "7,1,0,0,0,95,Columns:";
            this.StaffGrid.Location = new System.Drawing.Point(1, 38);
            this.StaffGrid.Name = "StaffGrid";
            this.StaffGrid.Rows.Count = 15;
            this.StaffGrid.Rows.DefaultSize = 19;
            this.StaffGrid.Size = new System.Drawing.Size(603, 287);
            this.StaffGrid.TabIndex = 0;
            this.StaffGrid.Click += new System.EventHandler(this.StaffGrid_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(12, 331);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 23);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "编辑";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // InsertBtn
            // 
            this.InsertBtn.Location = new System.Drawing.Point(0, 0);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(75, 23);
            this.InsertBtn.TabIndex = 2;
            this.InsertBtn.Text = "行插入";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(81, 0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "行删除";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditPanel
            // 
            this.EditPanel.Controls.Add(this.CancelBtn);
            this.EditPanel.Controls.Add(this.CommitBtn);
            this.EditPanel.Controls.Add(this.DeleteBtn);
            this.EditPanel.Controls.Add(this.InsertBtn);
            this.EditPanel.Location = new System.Drawing.Point(94, 331);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(510, 23);
            this.EditPanel.TabIndex = 4;
            this.EditPanel.Visible = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(435, 0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CommitBtn
            // 
            this.CommitBtn.Location = new System.Drawing.Point(344, 0);
            this.CommitBtn.Name = "CommitBtn";
            this.CommitBtn.Size = new System.Drawing.Size(75, 23);
            this.CommitBtn.TabIndex = 4;
            this.CommitBtn.Text = "确定";
            this.CommitBtn.UseVisualStyleBackColor = true;
            this.CommitBtn.Click += new System.EventHandler(this.CommitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Staff Information";
            // 
            // StaffView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.StaffGrid);
            this.Name = "StaffView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.StaffGrid)).EndInit();
            this.EditPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1FlexGrid StaffGrid;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button CommitBtn;
        private System.Windows.Forms.Label label1;
    }
}

