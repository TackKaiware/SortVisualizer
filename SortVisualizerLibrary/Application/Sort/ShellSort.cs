using System;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerLibrary {

    /// <summary>
    /// シェルソート
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ShellSort<T> :SortObject<T> where T : IComparable<T> {
        public override string Name => "シェルソート";

        /// <summary>
        /// ソートの実行
        /// </summary>
        /// <param name="items"></param>
        protected override void ExecuteSort( IEnumerable<T> items ) {
            var array = items.ToArray();
            int n = array.Length;

            int h = 1;
            while ( h < ( n / 9 ) ) {
                h = ( h * 3 + 1 );
            }

            for ( ; h > 0; h /= 3 ) {
                for ( int i = h; i < n; i++ ) {
                    for ( int j = i; j >= h && Compare( array[j - h], array[j] ) > 0; j -= h ) {
                        Swap( ref array, j, j - h );
                    }
                }
            }
        }
    }
}