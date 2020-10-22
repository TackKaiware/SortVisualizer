﻿using SortVisualizerCUI.Application;
using System;
using System.Linq;

namespace SortVisualizerCUI
{
    internal class Program
    {
        /// <summary>
        /// エントリーポイント
        /// </summary>s
        private static void Main()
        {
            // 1~20の数値を生成・シャッフルし、バブルソートの初期値とする。
            var bubbleSort = new BubbleSortExecutable(
                                Enumerable.Range( 1, 20 ).OrderBy( x => Guid.NewGuid() ) );

            // バブルソート実行体を通知を受ける側へ設定する
            var sortObserver = new SortObserver()
            {
                DataSource = bubbleSort
            };

            //  バブルソートの実行。この処理内でソート処理のアニメーションが実行される。
            bubbleSort.Sort();
        }
    }
}