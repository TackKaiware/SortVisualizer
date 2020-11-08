using System;
using System.Linq;

namespace SortTest
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            var data = Enumerable.Range( 0, 10 ).OrderBy( x => Guid.NewGuid() ).ToArray();

            Array.ForEach( data, x => Console.Write( $"{x} " ) );
            Console.WriteLine();

            HeapSort( data );

            Array.ForEach( data, x => Console.Write( $"{x} " ) );
            Console.WriteLine();
        }

        #region ヒープソート

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        private static void HeapSort<T>( T[] array ) where T : IComparable<T>
        {
            int i = 0;
            while ( i < array.Length )
            {
                UpHeap( array, i++ );
            }
            while ( --i > 0 )
            {
                (array[0], array[i]) = (array[i], array[0]);
                DownHeap( array, i - 1 );
            }
        }

        /// <summary>
        /// 配列をヒープ構造に変換する。
        /// </summary>
        /// <param name="array"></param>
        private static void UpHeap<T>( T[] array, int n ) where T : IComparable<T>
        {
            while ( n != 0 )
            {
                int parent = ( n - 1 ) / 2;
                if ( array[n].CompareTo( array[parent] ) > 0 )
                {
                    (array[n], array[parent]) = (array[parent], array[n]);
                    n = parent;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ヒープ構造となっている配列を使ってソートを行う。
        /// </summary>
        /// <param name="array"></param>
        private static void DownHeap<T>( T[] array, int n ) where T : IComparable<T>
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
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 確認中のインデックスの要素が持つ子要素で、大きな要素のインデックスを返す。
        /// 子要素がない場合は-1を返す。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="currentIndex"></param>
        /// <param name="heapRange"></param>
        /// <returns></returns>
        private static int GetBiggerChildrIndex( int[] array, int currentIndex, int heapRange )
        {
            int leftChild = ( currentIndex + 1 ) * 2 - 1;
            if ( leftChild > heapRange - 1 )
                return -1;

            int rightChild = leftChild + 1;
            if ( rightChild > heapRange - 1 )
                return leftChild;

            if ( array[leftChild] > array[rightChild] )
                return leftChild;
            else
                return rightChild;
        }

        #endregion
    }
}