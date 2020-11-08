namespace SortVisualizerGUI
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbx_GraphView = new System.Windows.Forms.PictureBox();
            this.btn_Run = new System.Windows.Forms.Button();
            this.cmb_SortAlgorythm = new System.Windows.Forms.ComboBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lbl_CompareCounTtitle = new System.Windows.Forms.Label();
            this.lbl_SwapCountTitle = new System.Windows.Forms.Label();
            this.lbl_CompareCount = new System.Windows.Forms.Label();
            this.lbl_SwapCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GraphView)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_GraphView
            // 
            this.pbx_GraphView.Location = new System.Drawing.Point(12, 38);
            this.pbx_GraphView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbx_GraphView.Name = "pbx_GraphView";
            this.pbx_GraphView.Size = new System.Drawing.Size(400, 400);
            this.pbx_GraphView.TabIndex = 0;
            this.pbx_GraphView.TabStop = false;
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(218, 9);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 23);
            this.btn_Run.TabIndex = 1;
            this.btn_Run.Text = "実行";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            // 
            // cmb_SortAlgorythm
            // 
            this.cmb_SortAlgorythm.FormattingEnabled = true;
            this.cmb_SortAlgorythm.Location = new System.Drawing.Point(12, 12);
            this.cmb_SortAlgorythm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_SortAlgorythm.Name = "cmb_SortAlgorythm";
            this.cmb_SortAlgorythm.Size = new System.Drawing.Size(200, 20);
            this.cmb_SortAlgorythm.TabIndex = 2;
            this.cmb_SortAlgorythm.SelectedIndexChanged += new System.EventHandler(this.Cmb_SortAlgorythm_SelectedIndexChanged);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // lbl_CompareCounTtitle
            // 
            this.lbl_CompareCounTtitle.AutoSize = true;
            this.lbl_CompareCounTtitle.Font = new System.Drawing.Font("Osaka", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompareCounTtitle.Location = new System.Drawing.Point(419, 39);
            this.lbl_CompareCounTtitle.Name = "lbl_CompareCounTtitle";
            this.lbl_CompareCounTtitle.Size = new System.Drawing.Size(55, 15);
            this.lbl_CompareCounTtitle.TabIndex = 3;
            this.lbl_CompareCounTtitle.Text = "比較回数";
            // 
            // lbl_SwapCountTitle
            // 
            this.lbl_SwapCountTitle.AutoSize = true;
            this.lbl_SwapCountTitle.Font = new System.Drawing.Font("Osaka", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SwapCountTitle.Location = new System.Drawing.Point(419, 54);
            this.lbl_SwapCountTitle.Name = "lbl_SwapCountTitle";
            this.lbl_SwapCountTitle.Size = new System.Drawing.Size(55, 15);
            this.lbl_SwapCountTitle.TabIndex = 3;
            this.lbl_SwapCountTitle.Text = "交換回数";
            // 
            // lbl_CompareCount
            // 
            this.lbl_CompareCount.AutoSize = true;
            this.lbl_CompareCount.Font = new System.Drawing.Font("Osaka", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompareCount.Location = new System.Drawing.Point(480, 39);
            this.lbl_CompareCount.Name = "lbl_CompareCount";
            this.lbl_CompareCount.Size = new System.Drawing.Size(15, 15);
            this.lbl_CompareCount.TabIndex = 3;
            this.lbl_CompareCount.Text = "0";
            // 
            // lbl_SwapCount
            // 
            this.lbl_SwapCount.AutoSize = true;
            this.lbl_SwapCount.Font = new System.Drawing.Font("Osaka", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SwapCount.Location = new System.Drawing.Point(480, 54);
            this.lbl_SwapCount.Name = "lbl_SwapCount";
            this.lbl_SwapCount.Size = new System.Drawing.Size(15, 15);
            this.lbl_SwapCount.TabIndex = 3;
            this.lbl_SwapCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 452);
            this.Controls.Add(this.lbl_SwapCount);
            this.Controls.Add(this.lbl_SwapCountTitle);
            this.Controls.Add(this.lbl_CompareCount);
            this.Controls.Add(this.lbl_CompareCounTtitle);
            this.Controls.Add(this.cmb_SortAlgorythm);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.pbx_GraphView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GraphView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_GraphView;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.ComboBox cmb_SortAlgorythm;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lbl_CompareCounTtitle;
        private System.Windows.Forms.Label lbl_SwapCountTitle;
        private System.Windows.Forms.Label lbl_CompareCount;
        private System.Windows.Forms.Label lbl_SwapCount;
    }
}

