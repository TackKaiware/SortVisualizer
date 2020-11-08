using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SortVisualizerGUI.Application.Sort
{
    /// <summary>
    ///  選択ソート実行体
    /// </summary>
    public class SelectionSortExecutable<T> : SortExecutableBase<T> where T : IComparable<T>
    {
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        /// <param name="items"></param>
        public SelectionSortExecutable( IEnumerable<T> items = null ) : base( items ) { }

        public override string Name => "選択ソート";

        /// <summary>
        /// ソートの実行。要素を入れ替えるたびに通知を受ける側へ状態変更を状態変更を知らせる。
        /// </summary>
        protected override void SortImplementation()
        {
            var array = Items.ToArray();
            for ( int i = 0; i < array.Length - 1; i++ )
            {
                int min = i;    // 最小値のインデックス保持用
                                // このループが終われば min には最小値のインデックスが入っている
                for ( int j = i + 1; j < array.Length; j++ )
                {
                    if ( Compare( array[min], array[j] ) > 0 )
                    {
                        min = j;
                    }
                }
                // 見つかった最小値の値を交換
                Swap( ref array[min], ref array[i] );

                Thread.Sleep( DelayTime_ms );
                Items = array;
            }
        }
    }
}