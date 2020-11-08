using SortVisualizerGUI.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortVisualizerGUI.Application.Sort
{
    /// <summary>
    /// ソート実行体抽象クラス
    /// </summary>
    public abstract class SortExecutableBase<T> : Observable where T : IComparable<T>
    {
        protected const int DelayTime_ms = 1;

        /// <summary>
        /// ソート対象のデータ
        /// </summary>
        protected T[] items;

        /// <summary>
        /// コンストラクタ。ソート対象のデータで初期化する。
        /// </summary>
        /// <param name="items"></param>
        protected SortExecutableBase( IEnumerable<T> items )
        {
            this.items = items.ToArray();
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
        /// コンボボックス表示用名称
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 実際のソート処理。派生先クラスで各アルゴリズムの実装を強制させるため抽象メソッドとしている。
        /// このメソッド内で要素を交換した場合、必ずItemsプロパティを設定することにより通知を受ける側へ状態変更を知らせること。
        /// </summary>
        public abstract Task SortAsync();
    }
}