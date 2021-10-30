using SortVisualizerGUI.Viewer;

using SortVisualizerLibrary;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SortVisualizerGUI {

    public partial class Form1 :Form {

        #region フィールド

        private GraphViewer graphViewer;
        private CompareCountViewer compareCountViewer;
        private SwapCountViewer swapCountViewer;
        private SortObject<int> sortObj;

        #endregion

        #region 初期化

        public Form1() {
            InitializeComponent();

            // フォームを画面中央に表示
            StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region フォーム

        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load( object sender, System.EventArgs e ) {
            // コンボボックスを初期化
            Cmb_SortAlgorythm_Initialize();

            // ビューの初期化
            InintializeViewers();
        }

        #endregion

        #region ボタン

        /// <summary>
        /// 実行ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Run_Click( object sender, EventArgs e ) {
            InintializeViewers();
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
            cmb_SortAlgorythm.DataSource = new List<SortObject<int>>
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
            sortObj = cmb_SortAlgorythm.SelectedItem as SortObject<int>;

        #endregion

        #region バックグラウンド処理

        /// <summary>
        /// バックグラウンド処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_DoWork( object sender, DoWorkEventArgs e ) {
            int count = pbx_GraphView.ClientSize.Height;
            count = sortObj switch {
                // 処理が遅いソートはデータ量を減らす
                BubbleSort<int> => count / 4,
                OddEvenSort<int> => count / 4,
                SelectionSort<int> => count / 2,
                _ => count,
            };
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
        private static IEnumerable<int> GenerateRandomNumber( int count ) => Enumerable.Range( 1, count ).OrderBy( _ => Guid.NewGuid() );

        /// <summary>
        /// 降順の数値データを生成する
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static IEnumerable<int> GenerateDescendingOrderedNumber( int count ) => Enumerable.Range( 1, count ).OrderByDescending( _ => _ );

        /// <summary>
        /// 各コントロールの初期化
        /// </summary>c
        private void InintializeViewers() {
            // ソートオブジェクトの初期化
            sortObj = cmb_SortAlgorythm.SelectedItem as SortObject<int>;

            // 各ビューの初期化
            int x = 50;
            var barColor1 = Color.FromArgb( 255, x, x );
            var barColor2 = Color.FromArgb( x, 255, x );
            var barColor3 = Color.FromArgb( x, x, 255 );
            graphViewer = new GraphViewer( pbx_GraphView, barColor1, barColor2, barColor3 );
            graphViewer.SetDataSource( sortObj );

            compareCountViewer = new CompareCountViewer( lbl_CompareCount );
            compareCountViewer.SetDataSource( sortObj );

            swapCountViewer = new SwapCountViewer( lbl_SwapCount );
            swapCountViewer.SetDataSource( sortObj );
        }
    }
}