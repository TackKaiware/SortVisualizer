namespace SortVisualizerLibrary {

    /// <summary>
    /// 監視する側のインターフェース定義
    /// </summary>
    public interface IObserver {

        /// <summary>
        ///  通知してくるオブジェクトから状態変更通知を受けた時の更新処理
        /// </summary>
        /// <param name="observable"></param>
        void Update( Observable observable );
    }
}