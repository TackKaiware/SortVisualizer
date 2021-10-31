using System.Collections.Generic;

namespace SortVisualizerLibrary {

    /// <summary>
    /// 通知する側の抽象クラス
    /// </summary>
    public abstract class Observable {

        /// <summary>
        /// 通知先オブジェクトへの参照
        /// </summary>
        private readonly List<IObserver> observers = new();

        /// <summary>
        /// 通知先オブジェクトを追加する
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver( IObserver observer ) => observers.Add( observer );

        /// <summary>
        /// 通知先オブジェクトを削除する
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver( IObserver observer ) => observers.Remove( observer );

        /// <summary>
        /// 通知先オブジェクトへ自身の状態変更を知らせる
        /// </summary>
        protected void NotifyObservers() => observers.ForEach( observer => observer?.Update( this ) );
    }
}