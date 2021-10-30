
namespace SortVisualizerGUI {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmb_SortAlgorythm = new System.Windows.Forms.ComboBox();
            this.btn_Run = new System.Windows.Forms.Button();
            this.lbl_CompareCount = new System.Windows.Forms.Label();
            this.lbl_SwapCount = new System.Windows.Forms.Label();
            this.lbl_CompareCountTitle = new System.Windows.Forms.Label();
            this.lbl_SwapCountTitle = new System.Windows.Forms.Label();
            this.pbx_GraphView = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GraphView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_SortAlgorythm
            // 
            this.cmb_SortAlgorythm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmb_SortAlgorythm.FormattingEnabled = true;
            this.cmb_SortAlgorythm.Location = new System.Drawing.Point(12, 15);
            this.cmb_SortAlgorythm.Name = "cmb_SortAlgorythm";
            this.cmb_SortAlgorythm.Size = new System.Drawing.Size(211, 20);
            this.cmb_SortAlgorythm.TabIndex = 0;
            this.cmb_SortAlgorythm.SelectedIndexChanged += new System.EventHandler(this.Cmb_SortAlgorythm_SelectedIndexChanged);
            // 
            // btn_Run
            // 
            this.btn_Run.AutoSize = true;
            this.btn_Run.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Run.Location = new System.Drawing.Point(229, 12);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 25);
            this.btn_Run.TabIndex = 1;
            this.btn_Run.Text = "実行";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            // 
            // lbl_CompareCount
            // 
            this.lbl_CompareCount.AutoSize = true;
            this.lbl_CompareCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_CompareCount.Location = new System.Drawing.Point(381, 18);
            this.lbl_CompareCount.Name = "lbl_CompareCount";
            this.lbl_CompareCount.Size = new System.Drawing.Size(35, 12);
            this.lbl_CompareCount.TabIndex = 2;
            this.lbl_CompareCount.Text = "12345";
            this.lbl_CompareCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_SwapCount
            // 
            this.lbl_SwapCount.AutoSize = true;
            this.lbl_SwapCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_SwapCount.Location = new System.Drawing.Point(506, 18);
            this.lbl_SwapCount.Name = "lbl_SwapCount";
            this.lbl_SwapCount.Size = new System.Drawing.Size(35, 12);
            this.lbl_SwapCount.TabIndex = 3;
            this.lbl_SwapCount.Text = "12345";
            this.lbl_SwapCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_CompareCountTitle
            // 
            this.lbl_CompareCountTitle.AutoSize = true;
            this.lbl_CompareCountTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_CompareCountTitle.Location = new System.Drawing.Point(310, 18);
            this.lbl_CompareCountTitle.Name = "lbl_CompareCountTitle";
            this.lbl_CompareCountTitle.Size = new System.Drawing.Size(65, 12);
            this.lbl_CompareCountTitle.TabIndex = 4;
            this.lbl_CompareCountTitle.Text = "比較回数 :";
            // 
            // lbl_SwapCountTitle
            // 
            this.lbl_SwapCountTitle.AutoSize = true;
            this.lbl_SwapCountTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_SwapCountTitle.Location = new System.Drawing.Point(435, 18);
            this.lbl_SwapCountTitle.Name = "lbl_SwapCountTitle";
            this.lbl_SwapCountTitle.Size = new System.Drawing.Size(65, 12);
            this.lbl_SwapCountTitle.TabIndex = 4;
            this.lbl_SwapCountTitle.Text = "交換回数 :";
            // 
            // pbx_GraphView
            // 
            this.pbx_GraphView.BackColor = System.Drawing.Color.Black;
            this.pbx_GraphView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_GraphView.Location = new System.Drawing.Point(12, 41);
            this.pbx_GraphView.Name = "pbx_GraphView";
            this.pbx_GraphView.Size = new System.Drawing.Size(537, 537);
            this.pbx_GraphView.TabIndex = 5;
            this.pbx_GraphView.TabStop = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 595);
            this.Controls.Add(this.pbx_GraphView);
            this.Controls.Add(this.lbl_SwapCountTitle);
            this.Controls.Add(this.lbl_CompareCountTitle);
            this.Controls.Add(this.lbl_SwapCount);
            this.Controls.Add(this.lbl_CompareCount);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.cmb_SortAlgorythm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SortVisualizerGUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GraphView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.ComboBox cmb_SortAlgorythm;
        private System.Windows.Forms.Label lbl_CompareCount;
        private System.Windows.Forms.Label lbl_SwapCount;
        private System.Windows.Forms.Label lbl_CompareCountTitle;
        private System.Windows.Forms.Label lbl_SwapCountTitle;
        private System.Windows.Forms.PictureBox pbx_GraphView;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

