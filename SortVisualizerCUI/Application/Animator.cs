using System;
using System.Threading;

namespace SortVisualizerCUI.Application
{
    /// <summary>
    /// コンソールに対しアニメ表示を行う人
    /// </summary>
    public static class Animator
    {
        private const int WaitTime_ms = 100;    // 画面の表示更新の間隔[ms ]

        /// <summary>
        /// アニメでいうところの一コマ分を表示する
        /// </summary>
        public static void DisplaySingleFrame( string value )
        {
            Console.Clear();
            Console.WriteLine( value );

            Thread.Sleep( WaitTime_ms );
        }
    }
}