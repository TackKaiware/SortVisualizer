using SortVisualizerGUI.Application.Sort;
using SortVisualizerGUI.Framework;

using System.Windows.Forms;

namespace SortVisualizerGUI.Application.Viewer {

    /// <summary>
    /// ソートの比較回数をラベルに表示するクラス
    /// </summary>
    public class SwapCountViewer :IObserver {
        private readonly Label label;

        public SwapCountViewer( Label label ) {
            this.label = label;
        }

        /// <summary>
        /// ソートオブジェクト（通知する側）を設定し、自分自身を登録する。
        /// </summary>
        public void SetDataSource( Sort<int> value ) => value.AddObserver( this );

        /// <summary>
        /// ソートオブジェクトから変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable ) {
            if ( observable is Sort<int> sortObj ) {
                label.Invoke( (MethodInvoker)( () => label.Text = sortObj.SwapCount.ToString() ) );
            }
        }
    }
}