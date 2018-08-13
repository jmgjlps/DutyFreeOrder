namespace DutyFreeOrder
{
    partial class DutyFreeMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnGoodsCheck = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.btnGoodsCheck);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtUserPassword);
            this.panel1.Controls.Add(this.txtUserID);
            this.panel1.Controls.Add(this.lblPassWord);
            this.panel1.Controls.Add(this.lblUserID);
            this.panel1.Location = new System.Drawing.Point(931, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 633);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 107);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 523);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // btnGoodsCheck
            // 
            this.btnGoodsCheck.Enabled = false;
            this.btnGoodsCheck.Location = new System.Drawing.Point(135, 78);
            this.btnGoodsCheck.Name = "btnGoodsCheck";
            this.btnGoodsCheck.Size = new System.Drawing.Size(75, 23);
            this.btnGoodsCheck.TabIndex = 4;
            this.btnGoodsCheck.Text = "查库存";
            this.btnGoodsCheck.UseVisualStyleBackColor = true;
            this.btnGoodsCheck.Click += new System.EventHandler(this.btnGoodsCheck_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(54, 78);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(62, 37);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(332, 21);
            this.txtUserPassword.TabIndex = 1;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(62, 10);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(332, 21);
            this.txtUserID.TabIndex = 1;
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Location = new System.Drawing.Point(15, 46);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(29, 12);
            this.lblPassWord.TabIndex = 0;
            this.lblPassWord.Text = "密码";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(15, 13);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(29, 12);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "账号";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCode,
            this.AirDate,
            this.ProductName,
            this.OrderStatus,
            this.OrderCnt,
            this.TargetCnt});
            this.dataGridView1.Location = new System.Drawing.Point(2, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(903, 101);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "商品ID";
            this.ProductCode.Name = "ProductCode";
            // 
            // AirDate
            // 
            this.AirDate.HeaderText = "机票日期";
            this.AirDate.Name = "AirDate";
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "商品名称";
            this.ProductName.Name = "ProductName";
            // 
            // OrderStatus
            // 
            this.OrderStatus.HeaderText = "状态";
            this.OrderStatus.Name = "OrderStatus";
            // 
            // OrderCnt
            // 
            this.OrderCnt.HeaderText = "已购数";
            this.OrderCnt.Name = "OrderCnt";
            // 
            // TargetCnt
            // 
            this.TargetCnt.HeaderText = "需求数";
            this.TargetCnt.Name = "TargetCnt";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView2.Location = new System.Drawing.Point(2, 165);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(903, 477);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView2_RowStateChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "브랜드";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "상품명";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "상품코드";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "가격(한화)";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "가격(달러)";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "상품 순번";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "상태";
            this.Column7.Name = "Column7";
            // 
            // DutyFreeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 778);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "DutyFreeMain";
            this.Text = "DutyFreeMain";
            this.Load += new System.EventHandler(this.DutyFreeMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetCnt;
        private System.Windows.Forms.Button btnGoodsCheck;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}