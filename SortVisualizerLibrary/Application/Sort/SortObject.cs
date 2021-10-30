using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SortVisualizerLibrary {

    /// <summary>
    /// ソートクラス（抽象）
    /// </summary>
    public abstract class SortObject<T> :Observable where T : IComparable<T> {
        protected const int DelayTime_ms = 0;

        private T[] items = Array.Empty<T>();

        /// <summary>
        /// 比較回数。
        /// Setされるたびに更新した内容を通知を受ける側へ知らせる。
        /// </summary>
        public int CompareCount { get; private set; }

        /// <summary>
        /// 交換回数。
        /// </summary>
        public int SwapCount { get; private set; }

        /// <summary>
        /// コンボボックス表示用名称
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// ソート対象のデータ。
        ///  Setされるたびに更新した内容を通知を受ける側へ知らせる。
        /// </summary>
        public IReadOnlyCollection<T> Items {
            get => items;
            private set {
                if ( !value.SequenceEqual( items ) ) {
                    items = value.ToArray();
                    NotifyObservers(); // ★ココ！で通知を受ける側へ状態変更を知らせる
                    Thread.Sleep( DelayTime_ms );
                }
            }
        }

        /// <summary>
        /// ソートの実行。比較回数と交換回数をリセットしてからソートを実行する。
        /// </summary>
        public void Execute( IEnumerable<T> items ) {
            Items = items.ToArray();
            CompareCount = 0;
            SwapCount = 0;
            ExecuteSort( items );
        }

        /// <summary>
        /// 実際のソート処理。派生先クラスで各アルゴリズムの実装を強制させるため抽象メソッドとしている。
        /// このメソッド内で要素を交換した場合、必ずItemsプロパティを設定することにより通知を受ける側へ状態変更を知らせること。
        /// </summary>
        protected abstract void ExecuteSort( IEnumerable<T> items );

        /// <summary>
        /// 要素の比較。
        /// 比較回数をカウントアップし、通知を受ける側へ状態変更を知らせる。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected int Compare( T a, T b ) {
            CompareCount++;
            NotifyObservers();

            return a.CompareTo( b );
        }

        /// <summary>
        /// 要素の交換。
        /// 交換回数をカウントアップし、通知を受ける側へ状態変更を知らせる。
        /// </summary>
        /// <param name="array"></param>s
        /// <param name="indexA"></param>
        /// <param name="indexB"></param>
        protected void Swap( ref T[] array, int indexA, int indexB ) {
            (array[indexA], array[indexB]) = (array[indexB], array[indexA]);
            SwapCount++;
            NotifyObservers();
            Items = array;
        }
    }
}