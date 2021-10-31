using System;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerLibrary {

    /// <summary>
    /// ヒープソート
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HeapSort<T> :SortObject<T> where T : IComparable<T> {
        public override string Name => "ヒープソート";

        /// <summary>
        /// ソートの実行
        /// </summary>
        /// <param name="items"></param>
        protected override void ExecuteSort( IEnumerable<T> items ) {
            var array = items.ToArray();
            int i = 0;
            while ( i < array.Length ) {
                UpHeap( array, i++ );
            }
            while ( --i > 0 ) {
                Swap( ref array, 0, i );
                DownHeap( array, i - 1 );
            }
        }

        private void UpHeap( T[] array, int n ) {
            while ( n != 0 ) {
                int parent = ( n - 1 ) / 2;
                if ( Compare( array[n], array[parent] ) > 0 ) {
                    Swap( ref array, n, parent );
                    n = parent;
                } else {
                    break;
                }
            }
        }

        private void DownHeap( T[] array, int n ) {
            if ( n == 0 )
                return;
            int parent = 0;
            while ( true ) {
                int child = 2 * parent + 1;
                if ( child > n )
                    break;
                if ( ( child < n ) && Compare( array[child], array[child + 1] ) < 0 ) {
                    child++;
                }
                if ( Compare( array[parent], array[child] ) < 0 ) {
                    Swap( ref array, parent, child );
                    parent = child;
                } else {
                    break;
                }
            }
        }
    }
}