using SortVisualizerCUI.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SortVisualizerCUI.Application
{
    /// <summary>
    /// ソート実行体抽象クラス
    /// </summary>
    public abstract class SortExecutable : Observable
    {
        /// <summary>
        /// ソート対象のデータ
        /// </summary>
        protected int[] items;

        /// <summary>
        /// コンストラクタ。ソート対象のデータで初期化する。
        /// </summary>
        /// <param name="items"></param>
        protected SortExecutable( IEnumerable<int> items )
        {
            this.items = items.ToArray();
        }

        /// <summary>
        /// ソート対象のデータ。
        ///  Setされるたびに更新した内容を通知を受ける側へ知らせる。
        /// </summary>
        public IReadOnlyCollection<int> Items
        {
            get => items;
            set
            {
                if( !value.SequenceEqual( items ) )
                {
                    items = value.ToArray();
                    NotifyObservers(); // ★ココ！で通知を受ける側へ状態変更を知らせる
                }
            }
        }

        /// <summary>
        /// 実際のソート処理。派生先クラスで各アルゴリズムの実装を強制させるため抽象メソッドとしている。
        /// このメソッド内で要素を交換した場合、必ずItemsプロパティを設定することにより通知を受ける側へ状態変更を知らせること。
        /// </summary>
        public abstract void Sort();
    }
}