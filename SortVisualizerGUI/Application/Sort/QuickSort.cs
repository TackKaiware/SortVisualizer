using System;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerGUI.Application.Sort {

    /// <summary>
    /// クイックソート
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSort<T> :Sort<T> where T : IComparable<T> {
        public override string Name => "クイックソート";

        /// <summary>
        /// ソートの実行
        protected override void ExecuteSort( IEnumerable<T> items ) {
            var array = items.ToArray();
            QuickSortCore( array, array.GetLowerBound( 0 ), array.GetUpperBound( 0 ) );
        }

        /// <summary>
        /// クイックソート
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private void QuickSortCore( T[] array, int left, int right ) {
            // 範囲が一つだけなら処理を抜ける
            if ( left >= right ) { return; }

            // ピボットを選択（範囲の先頭・真ん中・末尾の中央を使用）
            T pivot = Median( array[left], array[( left + right ) / 2], array[right] );

            int i = left;
            int j = right;

            while ( i <= j ) {
                // array[i] < pivot まで左から探索
                while ( ( i < right ) && ( Compare( array[i], pivot ) < 0 ) ) { i++; }
                // array[i] >= pivot まで右から探索
                while ( ( j > left ) && ( Compare( array[j], pivot ) >= 0 ) ) { j--; }

                if ( i > j ) { break; }
                Swap( ref array, i, j );

                // 交換を行った要素の次の要素にインデックスを進める
                i++;
                j--;
            }
            QuickSortCore( array, left, i - 1 );
            QuickSortCore( array, i, right );

            /// <summary>
            /// 中央値値を求める
            /// </summary>
            static T Median( T x, T y, T z ) {
                if ( x.CompareTo( y ) > 0 ) { (x, y) = (y, x); }
                if ( x.CompareTo( z ) > 0 ) { (_, z) = (z, x); }
                if ( y.CompareTo( z ) > 0 ) { (y, _) = (z, y); }
                return y;
            }
        }
    }
}