using SortVisualizerGUI.Application.Sort;
using SortVisualizerGUI.Framework;

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SortVisualizerGUI.Application.Viewer {

    /// <summary>
    /// ソートの状態を横棒グラフで表示するクラス
    /// </summary>
    public class GraphViewer :IObserver {

        /// <summary>
        /// グラフを描画するPictreBoxへの参照
        /// </summary>
        private readonly PictureBox pictureBox;

        private readonly Color barColor1;
        private readonly Color barColor2;
        private readonly Color barColor3;
        private int[] itemsPrev = Array.Empty<int>();

        public GraphViewer( PictureBox pictureBox, Color barColor1, Color barColor2, Color barColor3 ) {
            this.pictureBox = pictureBox;
            this.barColor1 = barColor1;
            this.barColor2 = barColor2;
            this.barColor3 = barColor3;
        }

        /// <summary>
        /// ソートオブジェクト（通知する側）を設定し、自分自身を登録する。
        /// </summary>
        public void SetDataSource( Sort<int> value ) {
            value.AddObserver( this );

            // ソートオブジェクトの初期状態をピクチャボックスに表示するため
            Update( value );
        }

        /// <summary>
        /// ソートオブジェクトから変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable ) {
            if ( observable is Sort<int> sortObj ) {
                var items = sortObj.Items.ToArray();
                if ( !itemsPrev.SequenceEqual( items ) ) {
                    // 初期設定
                    var canvas = new Bitmap( pictureBox.Width, pictureBox.Height );
                    using var g = Graphics.FromImage( canvas );

                    // 棒グラフの色の作成
                    var gradationCount = 2;
                    var barColors1 = ColorHelper.CreateColorGradient( barColor1, barColor2, items.Length / gradationCount );
                    var barColors2 = ColorHelper.CreateColorGradient( barColor2, barColor3, items.Length / gradationCount );
                    var barColors = barColors1.Concat( barColors2 ).ToArray();

                    // 棒の幅・高さ
                    int barWidth = pictureBox.Width / items.Length;
                    int barHeight = pictureBox.Height / items.Length;

                    // dataに格納されている数値を横棒グラフとしてcanvasに描き出す
                    for ( int i = 0; i < items.Length; i++ ) {
                        using var brush = new SolidBrush( barColors[items[i] - 1] );
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