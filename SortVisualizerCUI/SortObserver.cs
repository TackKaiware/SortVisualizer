using SortVisualizerLibrary;

using System;
using System.Linq;
using System.Text;

namespace SortVisualizerCUI {

    /// <summary>
    /// ソートの状態変更の通知を受ける側
    /// </summary>
    public class SortObserver :IObserver {
        private int[] items = null;

        /// <summary>
        /// ソート実行体（通知する側）を設定し、自分自身を登録する。
        /// </summary>
        public void SetDataSource( SortObject<int> value ) => value.AddObserver( this );

        /// <summary>
        /// ソート実行体から変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable ) {
            if ( observable is SortObject<int> sortObject ) {
                items ??= new int[sortObject.Items.Count];
                if ( !items.SequenceEqual( sortObject.Items ) ) {
                    var sb = new StringBuilder();
                    foreach ( var n in sortObject.Items ) {
                        // 現在のソートの状態を数値の並び→横棒グラフ状の文字列に変換する。
                        sb.Append( Enumerable.Repeat( "■", n ).SelectMany( x => x ).ToArray() );
                        sb.Append( Environment.NewLine );
                    }

                    // アニメの一コマ分として画面に表示する
                    Animator.DisplaySingleFrame( sb.ToString() );
                }
                items = sortObject.Items.ToArray();
            }
        }
    }
}