using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SortVisualizerGUI.Application.Sort
{
    /// <summary>
    ///  バブルソート実行体
    /// </summary>
    public class BubbleSortExecutable<T> : SortExecutableBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="items"></param>
        public BubbleSortExecutable( IEnumerable<T> items = null ) : base( items ) { }

        public override string Name => "バブルソート";

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        protected override void SortImplementation()
        {
            var array = Items.ToArray();
            for ( int i = 0; i < array.Length - 1; i++ )
            {
                for ( int j = array.Length - 1; i < j; j-- )
                {
                    if ( Compare( array[j], array[j - 1] ) < 0 )
                    {
                        // System.ValueTapleの機能による要素の交換
                        Swap( ref array[j], ref array[j - 1] );

                        // ★ココ！で通知を受ける側へ状態変更を知らせる
                        Thread.Sleep( DelayTime_ms );
                        Items = array;
                    }
                }
            }
        }
    }
}