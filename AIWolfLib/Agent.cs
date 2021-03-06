//
// Agent.cs
//
// Copyright 2016 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AIWolf.Lib
{
#if JHELP
    /// <summary>
    /// エージェントクラス
    /// </summary>
#else
    /// <summary>
    /// Agent class.
    /// </summary>
#endif
    [DataContract]
    public sealed class Agent
    {
        static Dictionary<int, Agent> agentMap = new Dictionary<int, Agent>();

#if JHELP
        /// <summary>
        /// 定数NONE
        /// </summary>
#else
        /// <summary>
        /// Constant NONE.
        /// </summary>
#endif
        public static readonly Agent NONE = GetAgent(0);

#if JHELP
        /// <summary>
        /// 定数ANY
        /// </summary>
#else
        /// <summary>
        /// Constant ANY.
        /// </summary>
#endif
        public static readonly Agent ANY = GetAgent(int.MaxValue);

#if JHELP
        /// <summary>
        /// 指定したインデックスのエージェントを返す
        /// </summary>
        /// <param name="idx">インデックス</param>
        /// <returns>指定したインデックスのエージェント</returns>
        /// <remarks>インデックスが負の場合nullを返す</remarks>
#else
        /// <summary>
        /// Returns the agent of given index.
        /// </summary>
        /// <param name="idx">Agent's index number.</param>
        /// <returns>The agent of given index number.</returns>
        /// <remarks>If idx is negative, this returns null.</remarks>
#endif
        public static Agent GetAgent(int idx)
        {
            if (idx < 0)
            {
                return null;
            }
            if (!agentMap.ContainsKey(idx))
            {
                agentMap[idx] = new Agent(idx);
            }
            return agentMap[idx];
        }

#if JHELP
        /// <summary>
        /// このエージェントのインデックス
        /// </summary>
#else
        /// <summary>
        /// The index number of this agent.
        /// </summary>
#endif
        [DataMember(Name = "agentIdx")]
        public int AgentIdx { get; }

        /// <summary>
        /// Initializes a new instance of Agent class with given index number.
        /// </summary>
        /// <param name="idx">The index number of this agent.</param>
        Agent(int idx) => AgentIdx = idx;

#if JHELP
        /// <summary>
        /// このオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>このオブジェクトを表す文字列</returns>
#else
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
#endif
        public override string ToString() => AgentIdx == 0 ? "NONE" : AgentIdx == int.MaxValue ? "ANY" : $"Agent[{AgentIdx:00}]";
    }
}
