using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public BubbleSortExecutable( IEnumerable<T> items ) : base( items ) { }

        public override string Name => "バブルソート";

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        public override async Task SortAsync()
        {
            var array = items.Clone() as T[];
            for ( int i = 0; i < array.Length - 1; i++ )
            {
                for ( int j = array.Length - 1; i < j; j-- )
                {
                    if ( array[j].CompareTo( array[j - 1] ) < 0 )
                    {
                        // System.ValueTapleの機能による要素の交換
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);

                        // ★ココ！で通知を受ける側へ状態変更を知らせる
                        await Task.Delay( DelayTime_ms );
                        Items = array;
                    }
                }
            }
        }
    }
}