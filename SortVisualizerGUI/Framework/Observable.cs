using System.Collections.Generic;

namespace SortVisualizerGUI.Framework {

    /// <summary>
    /// 通知する側の抽象クラス
    /// </summary>
    public abstract class Observable {

        /// <summary>
        ///  通知を受ける側への参照。
        /// </summary>
        private readonly List<IObserver> observers = new List<IObserver>();

        /// <summary>
        ///  通知を受ける側を追加する。
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver( IObserver observer ) => observers.Add( observer );

        /// <summary>
        ///  通知を受ける側を削除する。
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver( IObserver observer ) => observers.Remove( observer );

        /// <summary>
        ///  通知を受ける側へ自身の状態変更を知らせる。
        /// </summary>
        protected void NotifyObservers() => observers.ForEach( observer => observer?.Update( this ) );
    }
}