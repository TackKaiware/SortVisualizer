namespace SortVisualizerLibrary {

    /// <summary>
    /// 通知を受ける側のインターフェース定義
    /// </summary>
    public interface IObserver {

        /// <summary>
        ///  通知する側から状態変更の知らせを受けた時の更新処理
        /// </summary>
        /// <param name="observable"></param>
        void Update( Observable observable );
    }
}