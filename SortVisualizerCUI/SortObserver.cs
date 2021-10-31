using SortVisualizerLibrary;

using System;
using System.Linq;

namespace SortVisualizerCUI {

    /// <summary>
    /// ソート状態を監視するクラス
    /// </summary>
    public class SortObserver :IObserver {
        private int[] items = null;

        /// <summary>
        /// ソートオブジェクト（通知してくる側）に、自分自身を登録する
        /// </summary>
        public void SetDataSource( SortObject<int> value ) => value.AddObserver( this );

        /// <summary>
        /// ソートオブジェクトから状態変更の通知を受け取った時の処理
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable ) {
            // ソートオブジェクトではない
            if ( observable is not SortObject<int> ) {
                return; // 画面は更新しない
            }

            // 配列の並びに変更がない
            var sortObject = observable as SortObject<int>;
            items ??= new int[sortObject.Items.Count];
            if ( items.SequenceEqual( sortObject.Items ) ) {
                return; // 画面は更新しない
            }

            // 数値の大小を横棒グラフで表す文字列に変換する
            var str = string.Join(
                string.Empty,
                sortObject.Items.SelectMany( n =>
                    Enumerable.Repeat( "■", n ).Append( Environment.NewLine ) ) );

            // アニメの一コマ分として画面に表示する
            Animator.DisplaySingleFrame( str );
            items = sortObject.Items.ToArray();
        }
    }
}