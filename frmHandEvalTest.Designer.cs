namespace cBurch_Final_Project___Poker_Game
{
    partial class frmHandEvalTest
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
            this.btnDealHands = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumberOfHands = new System.Windows.Forms.TextBox();
            this.dgvHandTestResults = new System.Windows.Forms.DataGridView();
            this.btnCustomHand = new System.Windows.Forms.Button();
            this.txtBC3 = new System.Windows.Forms.TextBox();
            this.txtBC4 = new System.Windows.Forms.TextBox();
            this.txtBC5 = new System.Windows.Forms.TextBox();
            this.txtBC2 = new System.Windows.Forms.TextBox();
            this.txtBC1 = new System.Windows.Forms.TextBox();
            this.txtPC2 = new System.Windows.Forms.TextBox();
            this.txtPC1 = new System.Windows.Forms.TextBox();
            this.rtbHandData = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHandTestResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDealHands
            // 
            this.btnDealHands.Location = new System.Drawing.Point(12, 12);
            this.btnDealHands.Name = "btnDealHands";
            this.btnDealHands.Size = new System.Drawing.Size(75, 23);
            this.btnDealHands.TabIndex = 0;
            this.btnDealHands.TabStop = false;
            this.btnDealHands.Text = "Deal Hands";
            this.btnDealHands.UseVisualStyleBackColor = true;
            this.btnDealHands.Click += new System.EventHandler(this.btnDealHands_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "How many hands do you wish to deal?";
            // 
            // txtNumberOfHands
            // 
            this.txtNumberOfHands.Location = new System.Drawing.Point(289, 13);
            this.txtNumberOfHands.Name = "txtNumberOfHands";
            this.txtNumberOfHands.Size = new System.Drawing.Size(66, 20);
            this.txtNumberOfHands.TabIndex = 3;
            this.txtNumberOfHands.TabStop = false;
            this.txtNumberOfHands.Text = "100";
            // 
            // dgvHandTestResults
            // 
            this.dgvHandTestResults.AllowUserToDeleteRows = false;
            this.dgvHandTestResults.AllowUserToOrderColumns = true;
            this.dgvHandTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHandTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHandTestResults.Location = new System.Drawing.Point(13, 42);
            this.dgvHandTestResults.Name = "dgvHandTestResults";
            this.dgvHandTestResults.ReadOnly = true;
            this.dgvHandTestResults.Size = new System.Drawing.Size(678, 425);
            this.dgvHandTestResults.TabIndex = 4;
            this.dgvHandTestResults.TabStop = false;
            // 
            // btnCustomHand
            // 
            this.btnCustomHand.Location = new System.Drawing.Point(457, 15);
            this.btnCustomHand.Name = "btnCustomHand";
            this.btnCustomHand.Size = new System.Drawing.Size(97, 23);
            this.btnCustomHand.TabIndex = 8;
            this.btnCustomHand.Text = "Custom Hand";
            this.btnCustomHand.UseVisualStyleBackColor = true;
            this.btnCustomHand.Click += new System.EventHandler(this.btnCustomHand_Click);
            // 
            // txtBC3
            // 
            this.txtBC3.Location = new System.Drawing.Point(697, 17);
            this.txtBC3.Name = "txtBC3";
            this.txtBC3.Size = new System.Drawing.Size(23, 20);
            this.txtBC3.TabIndex = 5;
            this.txtBC3.Text = "7C";
            // 
            // txtBC4
            // 
            this.txtBC4.Location = new System.Drawing.Point(726, 17);
            this.txtBC4.Name = "txtBC4";
            this.txtBC4.Size = new System.Drawing.Size(23, 20);
            this.txtBC4.TabIndex = 6;
            this.txtBC4.Text = "JS";
            // 
            // txtBC5
            // 
            this.txtBC5.Location = new System.Drawing.Point(755, 17);
            this.txtBC5.Name = "txtBC5";
            this.txtBC5.Size = new System.Drawing.Size(23, 20);
            this.txtBC5.TabIndex = 7;
            this.txtBC5.Text = "8H";
            // 
            // txtBC2
            // 
            this.txtBC2.Location = new System.Drawing.Point(668, 17);
            this.txtBC2.Name = "txtBC2";
            this.txtBC2.Size = new System.Drawing.Size(23, 20);
            this.txtBC2.TabIndex = 4;
            this.txtBC2.Text = "2S";
            // 
            // txtBC1
            // 
            this.txtBC1.Location = new System.Drawing.Point(639, 17);
            this.txtBC1.Name = "txtBC1";
            this.txtBC1.Size = new System.Drawing.Size(23, 20);
            this.txtBC1.TabIndex = 3;
            this.txtBC1.Text = "2C";
            // 
            // txtPC2
            // 
            this.txtPC2.Location = new System.Drawing.Point(589, 17);
            this.txtPC2.Name = "txtPC2";
            this.txtPC2.Size = new System.Drawing.Size(23, 20);
            this.txtPC2.TabIndex = 2;
            this.txtPC2.Text = "2H";
            // 
            // txtPC1
            // 
            this.txtPC1.Location = new System.Drawing.Point(560, 17);
            this.txtPC1.Name = "txtPC1";
            this.txtPC1.Size = new System.Drawing.Size(23, 20);
            this.txtPC1.TabIndex = 1;
            this.txtPC1.Text = "2D";
            // 
            // rtbHandData
            // 
            this.rtbHandData.Location = new System.Drawing.Point(698, 44);
            this.rtbHandData.Name = "rtbHandData";
            this.rtbHandData.Size = new System.Drawing.Size(263, 346);
            this.rtbHandData.TabIndex = 9;
            this.rtbHandData.Text = "";
            // 
            // frmHandEvalTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 479);
            this.Controls.Add(this.rtbHandData);
            this.Controls.Add(this.txtPC1);
            this.Controls.Add(this.txtPC2);
            this.Controls.Add(this.txtBC1);
            this.Controls.Add(this.txtBC2);
            this.Controls.Add(this.txtBC5);
            this.Controls.Add(this.txtBC4);
            this.Controls.Add(this.txtBC3);
            this.Controls.Add(this.btnCustomHand);
            this.Controls.Add(this.dgvHandTestResults);
            this.Controls.Add(this.txtNumberOfHands);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDealHands);
            this.Name = "frmHandEvalTest";
            this.Text = "Hand Evaluation Tester";
            this.Load += new System.EventHandler(this.frmHandEvalTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHandTestResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDealHands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumberOfHands;
        private System.Windows.Forms.DataGridView dgvHandTestResults;
        private System.Windows.Forms.Button btnCustomHand;
        private System.Windows.Forms.TextBox txtBC3;
        private System.Windows.Forms.TextBox txtBC4;
        private System.Windows.Forms.TextBox txtBC5;
        private System.Windows.Forms.TextBox txtBC2;
        private System.Windows.Forms.TextBox txtBC1;
        private System.Windows.Forms.TextBox txtPC2;
        private System.Windows.Forms.TextBox txtPC1;
        private System.Windows.Forms.RichTextBox rtbHandData;
    }
}