using SortVisualizerLibrary;

using System.Windows.Forms;

namespace SortVisualizerGUI.Viewer {

    internal class CompareCountViewer :IObserver {

        /// <summary>
        /// ソートの比較回数をラベルに表示するクラス
        /// </summary>
        private readonly Label label;

        public CompareCountViewer( Label label ) {
            this.label = label;
            this.label.Text = 0.ToString();
        }

        /// <summary>
        /// ソートオブジェクト（通知する側）を設定し、自分自身を登録する。
        /// </summary>
        public void SetDataSource( SortObject<int> value ) => value.AddObserver( this );

        /// <summary>
        /// ソートオブジェクトから変更通知を受け取った時の更新処理。
        /// </summary>
        /// <param name="observable"></param>
        public void Update( Observable observable ) {
            if ( observable is SortObject<int> sortObj ) {
                label.Invoke( (MethodInvoker)( () => label.Text = sortObj.CompareCount.ToString() ) );
            }
        }
    }
}