using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SortVisualizerGUI.Application.Sort
{
    /// <summary>
    /// 奇遇転置ソート実行体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OddEvenSortExecutable<T> : SortExecutableBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="items"></param>
        public OddEvenSortExecutable( IEnumerable<T> items = null ) : base( items ) { }

        public override string Name => "奇遇転置ソート";

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        protected override void SortImplementation()
        {
            var array = Items.ToArray();
            bool isSwapped;
            do
            {
                isSwapped = false;

                // (偶数, 奇数)ペアの比較変換
                for ( int i = 0; i < array.Length - 1; i += 2 )
                {
                    if ( Compare( array[i + 1], array[i] ) < 0 )
                    {
                        Swap( ref array[i + 1], ref array[i] );
                        Thread.Sleep( DelayTime_ms );
                        Items = array;
                        isSwapped = true;
                    }
                }

                // (奇数, 偶数)ペアの比較変換
                for ( int i = 1; i < array.Length - 1; i += 2 )
                {
                    if ( Compare( array[i + 1], array[i] ) < 0 )
                    {
                        Swap( ref array[i + 1], ref array[i] );
                        Thread.Sleep( DelayTime_ms );
                        Items = array;

                        isSwapped = true;
                    }
                }
            }
            while ( isSwapped );
        }
    }
}