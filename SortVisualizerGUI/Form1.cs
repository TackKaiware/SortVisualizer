using SortVisualizerGUI.Application.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SortVisualizerGUI
{
    public partial class Form1 : Form
    {
        private GraphViewer graphViewer;
        private SortExecutableBase<int> sortExecutable;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実行ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Run_Click( object sender, System.EventArgs e )
        {
            // ソートを実行する
            btn_Run.Enabled = false;
            var task = sortExecutable.SortAsync().ConfigureAwait( false );
            btn_Run.Enabled = true;
        }

        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load( object sender, System.EventArgs e )
        {
            Initialize();
        }

        /// <summary>
        /// ランダムな数値データを生成する
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private IEnumerable<int> GenerateRandomNumber( int count ) => Enumerable.Range( 1, count ).OrderBy( _ => Guid.NewGuid() );

        /// <summary>
        /// ソートデータ・ビューの初期化
        /// </summary>
        private void Initialize()
        {
            sortExecutable = new HeapSortExecutable<int>( GenerateRandomNumber( pbx_GraphView.Height ) );
            graphViewer = new GraphViewer( pbx_GraphView )
            {
                DataSource = sortExecutable
            };

            pbx_GraphView.Update();
        }
    }
}