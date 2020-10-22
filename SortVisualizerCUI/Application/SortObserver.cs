using SortVisualizerCUI.Framework;
using System;
using System.Linq;

namespace SortVisualizerCUI.Application
{
    /// <summary>
    /// ソートの状態変更の通知を受ける側
    /// </summary>
    public class SortObserver : IObserver
    {
        /// <summary>
        /// ここにソート実行体を設定し紐づける。
        /// </summary>
        public SortExecutable DataSource
        {
            set => value.Add( this );
        }

        /// <summary>
        /// ソート実行オブジェクトから変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable )
        {
            if( observable is SortExecutable sortExecutable )
            {
                var str = string.Empty;
                foreach( var n in sortExecutable.Items )
                {
                    // 現在のソートの状態を数値の並び→横棒グラフ状の文字列に変換する。
                    str += new string( Enumerable.Repeat( "■", n ).SelectMany( x => x ).ToArray() )
                        + Environment.NewLine;
                }

                // アニメの一コマ分として画面に表示する
                Animator.DisplaySingleFrame( str );
            }
        }
    }
}