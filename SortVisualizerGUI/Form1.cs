using SortVisualizerGUI.Application.Sort;
using SortVisualizerGUI.Application.Viewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SortVisualizerGUI
{
    public partial class Form1 : Form
    {
        #region フィールド

        private GraphViewer graphViewer;
        private CompareCountViewer compareCountViewer;
        private SwapCountViewer swapCountViewer;
        private SortExecutableBase<int> sortExecutable;

        #endregion

        #region 初期化

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region フォーム

        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load( object sender, System.EventArgs e )
        {
            Cmb_SortAlgorythm_Initialize();
            Prepare();
        }

        #endregion

        #region ボタン

        /// <summary>
        /// 実行ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Run_Click( object sender, EventArgs e )
        {
            Prepare();
            backgroundWorker.RunWorkerAsync();
            btn_Run.Enabled = false;
        }

        #endregion

        #region コンボボックス

        /// <summary>
        /// コンボボックスの初期化処理
        /// </summary>
        private void Cmb_SortAlgorythm_Initialize()
        {
            // ソートアルゴリズム選択ComboBox用データ作成
            var data = GenerateRandomNumber( pbx_GraphView.Height / 2 );
            cmb_SortAlgorythm.DataSource = new List<SortExecutableBase<int>>
            {
                new BubbleSortExecutable<int>(),
                new SelectionSortExecutable<int>(),
                new OddEvenSortExecutable<int>(),
                new HeapSortExecutable<int>(),
            }
            .OrderBy( x => x.Name ).ToList();

            cmb_SortAlgorythm.DisplayMember = nameof( sortExecutable.Name );
            cmb_SortAlgorythm.SelectedIndex = 0;
        }

        /// <summary>
        /// ソートアルゴリズム選択コンボボックスの選択内容を変更した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_SortAlgorythm_SelectedIndexChanged( object sender, EventArgs e )
        {
            sortExecutable = cmb_SortAlgorythm.SelectedItem as SortExecutableBase<int>;
        }

        #endregion

        #region バックグラウンド処理

        /// <summary>
        /// バックグラウンド処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            // ソートの実行（時間のかかる処理）
            sortExecutable.Sort();
        }

        /// <summary>
        /// バックグラウンド処理が完了した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            btn_Run.Enabled = true;
        }

        #endregion

        /// <summary>
        /// ランダムな数値データを生成する
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private IEnumerable<int> GenerateRandomNumber( int count ) => Enumerable.Range( 1, count ).OrderBy( _ => Guid.NewGuid() );

        /// <summary>
        /// 降順の数値データを生成する
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private IEnumerable<int> GenerateDescendingOrderedNumber( int count ) => Enumerable.Range( 1, count ).OrderByDescending( _ => _ );

        /// <summary>
        /// ソートデータ・ビューの準備
        /// </summary>c
        private void Prepare()
        {
            // ソート実行体の初期化
            sortExecutable = cmb_SortAlgorythm.SelectedItem as SortExecutableBase<int>;
            //sortExecutable.Items = GenerateRandomNumber( pbx_GraphView.ClientSize.Height / 5 ).ToArray();
            sortExecutable.Items = GenerateRandomNumber( 100 ).ToArray();

            // 各ビューの初期化
            graphViewer = new GraphViewer( pbx_GraphView ) { DataSource = sortExecutable };
            compareCountViewer = new CompareCountViewer( lbl_CompareCount ) { DataSource = sortExecutable };
            swapCountViewer = new SwapCountViewer( lbl_SwapCount ) { DataSource = sortExecutable };
        }
    }
}