using System.Collections.Generic;

namespace SortVisualizerCUI.Application
{
    /// <summary>
    ///  選択ソート実行体
    /// </summary>
    public class SelectionSortExecutable : SortExecutable
    {
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        /// <param name="items"></param>
        public SelectionSortExecutable( IEnumerable<int> items ) : base( items )
        {
        }

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を状態変更を知らせる。
        /// </summary>
        public override void Sort()
        {
            var array = items.Clone() as int[];
            for( int i = 0; i < array.Length - 1; i++ )
            {
                int min = i;    // 最小値のインデックス保持用
                                // このループが終われば min には最小値のインデックスが入っている
                for( int j = i + 1; j < array.Length; j++ )
                {
                    if( array[min].CompareTo( array[j] ) > 0 )
                    {
                        min = j;
                    }
                }
                // 見つかった最小値の値を交換
                (array[min], array[i]) = (array[i], array[min]);
                Items = array;
            }
        }
    }
}