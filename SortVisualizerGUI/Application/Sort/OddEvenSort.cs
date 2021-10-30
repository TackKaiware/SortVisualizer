using System;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerGUI.Application.Sort {

    /// <summary>
    /// 奇遇転置ソート
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OddEvenSort<T> :Sort<T> where T : IComparable<T> {
        public override string Name => "奇遇転置ソート";

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        protected override void ExecuteSort( IEnumerable<T> items ) {
            var array = items.ToArray();
            bool isSwapped;
            do {
                isSwapped = false;

                // (偶数, 奇数)ペアの比較変換
                for ( int i = 0; i < array.Length - 1; i += 2 ) {
                    if ( Compare( array[i + 1], array[i] ) < 0 ) {
                        Swap( ref array, i + 1, i );
                        isSwapped = true;
                    }
                }

                // (奇数, 偶数)ペアの比較変換
                for ( int i = 1; i < array.Length - 1; i += 2 ) {
                    if ( Compare( array[i + 1], array[i] ) < 0 ) {
                        Swap( ref array, i + 1, i );
                        isSwapped = true;
                    }
                }
            }
            while ( isSwapped );
        }
    }
}