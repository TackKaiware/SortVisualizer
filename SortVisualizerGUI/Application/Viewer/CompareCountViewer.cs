﻿using SortVisualizerGUI.Application.Sort;
using SortVisualizerGUI.Framework;
using System.Windows.Forms;

namespace SortVisualizerGUI.Application.Viewer
{
    internal class CompareCountViewer : IObserver
    {
        /// <summary>
        /// ソートの比較回数をラベルに表示するクラス
        /// </summary>
        private readonly Label label;

        private int compareCountPrev = 0;

        public CompareCountViewer( Label label )
        {
            this.label = label;
        }

        /// <summary>
        /// ソート実行体（通知する側）を設定し、自分自身を登録する。
        /// </summary>
        public SortExecutableBase<int> DataSource { set => value.AddObserver( this ); }

        /// <summary>
        /// ソート実行体から変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable )
        {
            if ( observable is SortExecutableBase<int> sortExecutable )
            {
                int compareCount = sortExecutable.CompareCount;
                if ( compareCount != compareCountPrev )
                {
                    label.Invoke( (MethodInvoker)( () => label.Text = compareCount.ToString() ) );
                    compareCountPrev = compareCount;
                }
            }
        }
    }
}