using System;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerLibrary {

    /// <summary>
    ///  バブルソート
    /// </summary>
    public class BubbleSort<T> :SortObject<T> where T : IComparable<T> {
        public override string Name => "バブルソート";

        /// <summary>
        /// ソートの実行
        /// </summary>
        /// <param name="items"></param>
        protected override void ExecuteSort( IEnumerable<T> items ) {
            var array = items.ToArray();
            for ( int i = 0; i < array.Length - 1; i++ ) {
                for ( int j = array.Length - 1; i < j; j-- ) {
                    if ( Compare( array[j], array[j - 1] ) < 0 ) {
                        Swap( ref array, j, j - 1 );
                    }
                }
            }
        }
    }
}