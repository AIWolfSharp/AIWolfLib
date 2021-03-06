//
// ShuffleExtensions.cs
//
// Copyright 2017 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace AIWolf.Lib
{
#if JHELP
    /// <summary>
    /// IEnumerableインターフェースを実装したクラスに対するShuffle拡張メソッド定義
    /// </summary>
#else
    /// <summary>
    /// Defines extension method to shuffle what implements IEnumerable interface.
    /// </summary>
#endif
    public static class ShuffleExtensions
    {
#if JHELP
        /// <summary>
        /// IEnumerableをシャッフルしたIListを返す
        /// </summary>
        /// <typeparam name="T">IEnumerableの要素の型</typeparam>
        /// <param name="s">TのIEnumerable</param>
        /// <returns>シャッフルされたTのIList</returns>
#else
        /// <summary>
        /// Returns shuffled IList of T.
        /// </summary>
        /// <typeparam name="T">Type of element of IEnumerable.</typeparam>
        /// <param name="s">IEnumerable of T.</param>
        /// <returns>Shuffled IList of T.</returns>
#endif
        public static IList<T> Shuffle<T>(this IEnumerable<T> s) => s.OrderBy(x => Guid.NewGuid()).ToList();
    }
}
