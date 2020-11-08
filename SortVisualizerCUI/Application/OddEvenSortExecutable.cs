using System.Collections.Generic;

namespace SortVisualizerCUI.Application
{
    public class OddEvenSortExecutable : SortExecutable
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="items"></param>
        public OddEvenSortExecutable( IEnumerable<int> items ) : base( items ) { }

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を知らせる。
        /// </summary>
        public override void Sort()
        {
            var array = items.Clone() as int[];
            bool isSwapped;
            do
            {
                isSwapped = false;

                // (偶数, 奇数)ペアの比較変換
                for ( int i = 0; i < array.Length - 1; i += 2 )
                {
                    if ( array[i + 1].CompareTo( array[i] ) < 0 )
                    {
                        (array[i + 1], array[i]) = (array[i], array[i + 1]);
                        Items = array;
                        isSwapped = true;
                    }
                }

                // (奇数, 偶数)ペアの比較変換
                for ( int i = 1; i < array.Length - 1; i += 2 )
                {
                    if ( array[i + 1].CompareTo( array[i] ) < 0 )
                    {
                        (array[i + 1], array[i]) = (array[i], array[i + 1]);
                        Items = array;
                        isSwapped = true;
                    }
                }
            }
            while ( isSwapped );
        }
    }
}