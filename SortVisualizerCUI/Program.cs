using SortVisualizerLibrary;

using System;
using System.Linq;

namespace SortVisualizerCUI {

    internal static class Program {

        private static void Main() {
            // 監視対象のオブジェクトを生成
            var sortObj = new BubbleSort<int>();

            // 監視するオブジェクトを生成
            var sortObserver = new SortObserver();

            // 監視するオブジェクトに監視対象のオブジェクトを設定
            sortObserver.SetDataSource( sortObj );

            // ソート対象のデータを生成
            var values = Enumerable.Range( 1, 20 ).OrderBy( x => Guid.NewGuid() ).ToArray();

            // ソートを実行
            sortObj.Execute( values );
        }
    }
}