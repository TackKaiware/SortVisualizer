using System.Collections.Generic;

namespace SortVisualizerCUI.Application
{
    /// <summary>
    ///  バブルソート実行体
    /// </summary>
    public class BubbleSortExecutable : SortExecutable
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="items"></param>
        public BubbleSortExecutable( IEnumerable<int> items ) : base( items )
        {
        }

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        public override void Sort()
        {
            var array = items.Clone() as int[];
            for( int i = 0; i < array.Length - 1; i++ )
            {
                for( int j = array.Length - 1; i < j; j-- )
                {
                    if( array[j] < array[j - 1] )
                    {
                        // System.ValueTapleの機能による要素の交換
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);

                        // ★ココ！で通知を受ける側へ状態変更を知らせる
                        Items = array;
                    }
                }
            }
        }
    }
}