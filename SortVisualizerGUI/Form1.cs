using SortVisualizerGUI.Application.Sort;
using SortVisualizerGUI.Application.Viewer;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SortVisualizerGUI {

    public partial class Form1 :Form {

        #region フィールド

        private const int DataCount = 200;  // ソート対象のデータ個数

        #endregion

        #region フィールド

        private GraphViewer graphViewer;
        private CompareCountViewer compareCountViewer;
        private SwapCountViewer swapCountViewer;
        private Sort<int> sortObj;

        #endregion

        #region 初期化

        public Form1() {
            InitializeComponent();
        }

        #endregion

        #region フォーム

        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load( object sender, System.EventArgs e ) {
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
        private void Btn_Run_Click( object sender, EventArgs e ) {
            Prepare();
            backgroundWorker.RunWorkerAsync();
            btn_Run.Enabled = false;
            cmb_SortAlgorythm.Enabled = false;
        }

        #endregion

        #region コンボボックス

        /// <summary>
        /// コンボボックスの初期化処理
        /// </summary>
        private void Cmb_SortAlgorythm_Initialize() {
            cmb_SortAlgorythm.DataSource = new List<Sort<int>>
            {
                new BubbleSort<int>(),
                new SelectionSort<int>(),
                new OddEvenSort<int>(),
                new HeapSort<int>(),
                new QuickSort<int>(),
                new ShellSort<int>(),
            }
            .OrderBy( x => x.Name ).ToList();

            cmb_SortAlgorythm.DisplayMember = nameof( sortObj.Name );
            cmb_SortAlgorythm.SelectedIndex = 0;
        }

        /// <summary>
        /// ソートアルゴリズム選択コンボボックスの選択内容を変更した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_SortAlgorythm_SelectedIndexChanged( object sender, EventArgs e ) =>
            sortObj = cmb_SortAlgorythm.SelectedItem as Sort<int>;

        #endregion

        #region バックグラウンド処理

        /// <summary>
        /// バックグラウンド処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_DoWork( object sender, DoWorkEventArgs e ) {
            // 処理が遅いソートはデータ量を半分に減らす
            int count = DataCount;
            if ( ( sortObj is BubbleSort<int> ) ||
                 ( sortObj is OddEvenSort<int> ) ) {
                count /= 2;
            }
            sortObj.Execute( GenerateRandomNumber( count ) );
        }

        /// <summary>
        /// バックグラウンド処理が完了した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
            btn_Run.Enabled = true;
            cmb_SortAlgorythm.Enabled = true;
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
        private void Prepare() {
            // ソートオブジェクトの初期化
            sortObj = cmb_SortAlgorythm.SelectedItem as Sort<int>;

            // 各ビューの初期化
            graphViewer = new GraphViewer( pbx_GraphView, Color.Salmon, Color.Yellow, Color.YellowGreen );
            graphViewer.SetDataSource( sortObj );

            compareCountViewer = new CompareCountViewer( lbl_CompareCount );
            compareCountViewer.SetDataSource( sortObj );

            swapCountViewer = new SwapCountViewer( lbl_SwapCount );
            swapCountViewer.SetDataSource( sortObj );
        }
    }
}