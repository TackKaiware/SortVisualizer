using SortVisualizerGUI.Application.Sort;
using SortVisualizerGUI.Framework;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SortVisualizerGUI.Application.Viewer
{
    /// <summary>
    /// ソートの状態を横棒グラフで表示するクラス
    /// </summary>
    public class GraphViewer : IObserver
    {
        /// <summary>
        /// グラフを描画するPictreBoxへの参照
        /// </summary>
        private readonly PictureBox pictureBox;

        private int[] itemsPrev = Array.Empty<int>();

        public GraphViewer( PictureBox pictureBox )
        {
            this.pictureBox = pictureBox;
        }

        /// <summary>
        /// ソート実行体（通知する側）を設定し、自分自身を登録する。
        /// </summary>
        public SortExecutableBase<int> DataSource
        {
            set
            {
                value.AddObserver( this );

                // ソート実行体の初期状態をピクチャボックスに表示するため
                Update( value );
            }
        }

        /// <summary>
        /// ソート実行体から変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable )
        {
            if ( observable is SortExecutableBase<int> sortExecutable )
            {
                var items = sortExecutable.Items.ToArray();
                if ( !itemsPrev.SequenceEqual( items ) )
                {
                    // 初期設定
                    var canvas = new Bitmap( pictureBox.Width, pictureBox.Height );
                    using var g = Graphics.FromImage( canvas );

                    // 棒グラフの色の作成
                    var gradationCount = 2;
                    var barColors1 = ColorHelper.CreateColorGradient( Color.Aqua, Color.Yellow, items.Length / gradationCount );
                    var barColors2 = ColorHelper.CreateColorGradient( Color.Yellow, Color.LimeGreen, items.Length / gradationCount );
                    var barColors = barColors1.Concat( barColors2 );

                    // 棒の幅・高さ
                    int barWidth = pictureBox.Width / items.Length;
                    int barHeight = pictureBox.Height / items.Length;

                    // dataに格納されている数値を横棒グラフとしてcanvasに描き出す
                    for ( int i = 0; i < items.Length; i++ )
                    {
                        using var brush = new SolidBrush( barColors.ToArray()[items[i] - 1] );
                        g.FillRectangle( brush,
                            x: 0,
                            y: i * barHeight,
                            width: items[i] * barWidth,
                            height: barHeight );
                    }

                    // pictureBoxへ反映する
                    pictureBox.Invoke( (MethodInvoker)( () => pictureBox.Image = canvas ) );
                    pictureBox.Invoke( (MethodInvoker)( () => pictureBox.Update() ) );

                    itemsPrev = items;
                }
            }
        }
    }
}