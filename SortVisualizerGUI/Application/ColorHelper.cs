using System;
using System.Collections.Generic;
using System.Drawing;

namespace SortVisualizerGUI.Application {

    /// <summary>
    /// Color構造体に関する静的メソッドを提供するクラス
    /// </summary>
    public static class ColorHelper {

        /// <summary>
        ///  グラデーション色を生成する
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="totalNumberOfColors"></param>
        /// <returns></returns>
        public static IEnumerable<Color> CreateColorGradient( Color from, Color to, int totalNumberOfColors ) {
            double diffA = to.A - from.A;
            double diffR = to.R - from.R;
            double diffG = to.G - from.G;
            double diffB = to.B - from.B;

            var steps = totalNumberOfColors - 1;

            var stepA = diffA / steps;
            var stepR = diffR / steps;
            var stepG = diffG / steps;
            var stepB = diffB / steps;

            yield return from;

            for ( var i = 1; i < steps; ++i ) {
                yield return Color.FromArgb(
                    c( from.A, stepA ),
                    c( from.R, stepR ),
                    c( from.G, stepG ),
                    c( from.B, stepB ) );

                int c( int fromC, double stepC ) => (int)Math.Round( fromC + stepC * i );
            }

            yield return to;
        }
    }
}