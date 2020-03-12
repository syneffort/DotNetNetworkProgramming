namespace BasicClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnConnnect = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(348, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Send/Receive Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnConnnect
            // 
            this.btnConnnect.Location = new System.Drawing.Point(285, 20);
            this.btnConnnect.Name = "btnConnnect";
            this.btnConnnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnnect.TabIndex = 8;
            this.btnConnnect.Text = "Connect";
            this.btnConnnect.UseVisualStyleBackColor = true;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(95, 21);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(169, 21);
            this.txtServerIP.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "int Data :";
            // 
            // txtInt
            // 
            this.txtInt.Location = new System.Drawing.Point(95, 48);
            this.txtInt.Name = "txtInt";
            this.txtInt.Size = new System.Drawing.Size(265, 21);
            this.txtInt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "float Data :";
            // 
            // txtFloat
            // 
            this.txtFloat.Location = new System.Drawing.Point(95, 75);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.Size = new System.Drawing.Size(265, 21);
            this.txtFloat.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "string Data :";
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(95, 102);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(265, 21);
            this.txtString.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 166);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnConnnect);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFloat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnConnnect;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtString;
    }
}

