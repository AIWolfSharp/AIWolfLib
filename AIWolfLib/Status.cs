//
// Status.cs
//
// Copyright 2016 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

namespace AIWolf.Lib
{
#if JHELP
    /// <summary>
    /// プレイヤーの生死
    /// </summary>
#else
    /// <summary>
    /// Enumeration type for player's status (alive/dead).
    /// </summary>
#endif
    public enum Status
    {
#if JHELP
        /// <summary>
        /// 不明
        /// </summary>
#else
        /// <summary>
        /// Uncertain.
        /// </summary>
#endif
        UNC,

#if JHELP
        /// <summary>
        /// 生存
        /// </summary>
#else
        /// <summary>
        /// Alive.
        /// </summary>
#endif
        ALIVE,

#if JHELP
        /// <summary>
        /// 死亡
        /// </summary>
#else
        /// <summary>
        /// Dead.
        /// </summary>
#endif
        DEAD
    }
}
