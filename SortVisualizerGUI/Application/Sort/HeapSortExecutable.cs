using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
        public HeapSortExecutable( IEnumerable<T> items = null ) : base( items ) { }

        public override string Name => "ヒープソート";

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        protected override void SortImplementation()
        {
            var array = Items.ToArray();
            int i = 0;
            while ( i < array.Length )
            {
                Thread.Sleep( DelayTime_ms );
                UpHeap( array, i++ );
            }
            while ( --i > 0 )
            {
                //(array[0], array[i]) = (array[i], array[0]);
                Swap( ref array[0], ref array[i] );

                Thread.Sleep( DelayTime_ms );
                DownHeap( array, i - 1 );
            }
            Items = array;
        }

        private void UpHeap( T[] array, int n )
        {
            while ( n != 0 )
            {
                int parent = ( n - 1 ) / 2;
                if ( Compare( array[n], array[parent] ) > 0 )
                {
                    Swap( ref array[n], ref array[parent] );
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
                if ( ( child < n ) && Compare( array[child], array[child + 1] ) < 0 )
                {
                    child++;
                }
                if ( Compare( array[parent], array[child] ) < 0 )
                {
                    Swap( ref array[parent], ref array[child] );
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