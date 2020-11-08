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
        /// ソート実行体（通知する側）を設定し、自分自身を登録する。
        /// </summary>
        public SortExecutable DataSource
        {
            set => value.AddObserver( this );
        }

        /// <summary>
        /// ソート実行体から変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable )
        {
            if ( observable is SortExecutable sortExecutable )
            {
                var str = string.Empty;
                foreach ( var n in sortExecutable.Items )
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