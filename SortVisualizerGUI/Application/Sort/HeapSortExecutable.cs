using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SortVisualizerGUI.Application.Sort
{
    /// <summary>
    /// ヒープソート実行体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HeapSortExecutable<T> : SortExecutableBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="items"></param>
        public HeapSortExecutable( IEnumerable<T> items ) : base( items ) { }

        public override string Name => "ヒープソート";

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        public async override Task SortAsync()
        {
            var array = items.Clone() as T[];
            int i = 0;
            while ( i < array.Length )
            {
                await Task.Delay( DelayTime_ms );
                UpHeap( array, i++ );
            }
            while ( --i > 0 )
            {
                (array[0], array[i]) = (array[i], array[0]);

                await Task.Delay( DelayTime_ms );
                DownHeap( array, i - 1 );
            }
            Items = array;
        }

        private void UpHeap( T[] array, int n )
        {
            while ( n != 0 )
            {
                int parent = ( n - 1 ) / 2;
                if ( array[n].CompareTo( array[parent] ) > 0 )
                {
                    (array[n], array[parent]) = (array[parent], array[n]);
                    n = parent;
                    Items = array;
                }
                else
                {
                    break;
                }
            }
        }

        private void DownHeap( T[] array, int n )
        {
            if ( n == 0 ) return;
            int parent = 0;
            while ( true )
            {
                int child = 2 * parent + 1;
                if ( child > n ) break;
                if ( ( child < n ) && array[child].CompareTo( array[child + 1] ) < 0 )
                {
                    child++;
                }
                if ( array[parent].CompareTo( array[child] ) < 0 )
                {
                    (array[parent], array[child]) = (array[child], array[parent]);
                    parent = child;
                    Items = array;
                }
                else
                {
                    break;
                }
            }
        }
    }
}