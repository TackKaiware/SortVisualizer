using SortVisualizerGUI.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerGUI.Application.Sort
{
    /// <summary>
    /// ソート実行体抽象クラス
    /// </summary>
    public abstract class SortExecutableBase<T> : Observable where T : IComparable<T>
    {
        protected const int DelayTime_ms = 5;

        private T[] items;

        /// <summary>
        /// コンストラクタ。ソート対象のデータで初期化する。
        /// </summary>
        /// <param name="items"></param>
        protected SortExecutableBase( IEnumerable<T> items = null )
        {
            this.items = items?.ToArray() ?? Array.Empty<T>();
        }

        /// <summary>
        /// ソート対象のデータ。
        ///  Setされるたびに更新した内容を通知を受ける側へ知らせる。
        /// </summary>
        public IReadOnlyCollection<T> Items
        {
            get => items;
            set
            {
                if ( !value.SequenceEqual( items ) )
                {
                    items = value.ToArray();
                    NotifyObservers(); // ★ココ！で通知を受ける側へ状態変更を知らせる
                }
            }
        }

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
        /// ソートの実行。比較回数と交換回数をリセットしてからソートを実行する。
        /// </summary>
        public void Sort()
        {
            CompareCount = 0;
            SwapCount = 0;
            SortImplementation();
        }

        /// <summary>
        /// 実際のソート処理。派生先クラスで各アルゴリズムの実装を強制させるため抽象メソッドとしている。
        /// このメソッド内で要素を交換した場合、必ずItemsプロパティを設定することにより通知を受ける側へ状態変更を知らせること。
        /// </summary>
        protected abstract void SortImplementation();

        /// <summary>
        /// 要素の比較。
        /// 比較回数をカウントアップし、通知を受ける側へ状態変更を知らせる。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected int Compare( T a, T b )
        {
            CompareCount++;
            NotifyObservers();

            return a.CompareTo( b );
        }

        /// <summary>
        /// 要素の交換。
        /// 交換回数をカウントアップし、通知を受ける側へ状態変更を知らせる。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected void Swap( ref T a, ref T b )
        {
            T t = a;
            a = b;
            b = t;

            SwapCount++;
            NotifyObservers();
        }
    }
}