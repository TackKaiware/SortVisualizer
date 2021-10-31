using System;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerLibrary {

    /// <summary>
    ///  選択ソートオブジェクト
    /// </summary>
    public class SelectionSort<T> :SortObject<T> where T : IComparable<T> {
        public override string Name => "選択ソート";

        /// <summary>
        /// ソートの実行
        /// </summary>
        /// <param name="items"></param>
        protected override void ExecuteSort( IEnumerable<T> items ) {
            var array = items.ToArray();
            for ( int i = 0; i < array.Length - 1; i++ ) {
                int min = i;    // 最小値のインデックス保持用
                                // このループが終われば min には最小値のインデックスが入っている
                for ( int j = i + 1; j < array.Length; j++ ) {
                    if ( Compare( array[min], array[j] ) > 0 ) {
                        min = j;
                    }
                }
                // 見つかった最小値の値を交換
                Swap( ref array, min, i );
            }
        }
    }
}