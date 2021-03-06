//
// Vote.cs
//
// Copyright 2016 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace AIWolf.Lib
{
#if JHELP
    /// <summary>
    /// 追放投票情報
    /// </summary>
#else
    /// <summary>
    /// Information of vote for execution.
    /// </summary>
#endif
    [DataContract]
    public class Vote : IEquatable<Vote>
    {
#if JHELP
        /// <summary>
        /// 定数Vote.Empty
        /// </summary>
#else
        /// <summary>
        /// Constant Vote.Empty.
        /// </summary>
#endif
        public static readonly Vote Empty = new Vote(-1, Agent.NONE, Agent.NONE);

        /// <summary>
        /// The index number of the agent who voted.
        /// </summary>
        [DataMember(Name = "agent")]
        int agent;

        /// <summary>
        /// The index number of the voted agent.
        /// </summary>
        [DataMember(Name = "target")]
        int target;

#if JHELP
        /// <summary>
        /// この投票の日
        /// </summary>
#else
        /// <summary>
        /// The day of this vote.
        /// </summary>
#endif
        [DataMember(Name = "day")]
        public int Day { get; }

#if JHELP
        /// <summary>
        /// 投票したエージェント
        /// </summary>
#else
        /// <summary>
        /// The agent who voted.
        /// </summary>
#endif
        public Agent Agent { get; }

#if JHELP
        /// <summary>
        /// 投票されたエージェント
        /// </summary>
#else
        /// <summary>
        /// The voted agent.
        /// </summary>
#endif
        public Agent Target { get; }

#if JHELP
        /// <summary>
        /// 追放投票情報の新しいインスタンスを初期化する
        /// </summary>
        /// <param name="day">投票日</param>
        /// <param name="agent">投票したエージェント</param>
        /// <param name="target">投票されたエージェント</param>
        /// <remarks>agent/targetがnullの場合null参照例外</remarks>
#else
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="day">The day of this vote.</param>
        /// <param name="agent">The agent who voted.</param>
        /// <param name="target">The voted agent.</param>
        /// <remarks>NullReferenceException is thrown in case of null agent/target.</remarks>
#endif
        public Vote(int day, Agent agent, Agent target)
        {
            Day = day;
            Agent = agent;
            Target = target;
            // NullReferenceException is thrown in case of null agent/target.
            this.agent = agent.AgentIdx;
            this.target = target.AgentIdx;
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="day">The day of this vote.</param>
        /// <param name="agent">The index of agent who voted.</param>
        /// <param name="target">The index of voted agent.</param>
        [JsonConstructor]
        Vote(int day, int agent, int target)
        {
            Day = day;
            this.agent = agent;
            this.target = target;
            Agent = Agent.GetAgent(agent);
            Target = Agent.GetAgent(target);
        }

        /// <inheritdoc />
        public override string ToString() => $"{Agent}voted{Target}@{Day}";

        /// <inheritdoc />
        public bool Equals(Vote other) => other != null && (ReferenceEquals(this, other)
            || GetType() == other.GetType() && other.Day == Day && other.Agent == Agent && other.Target == Target);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Vote vote && Equals(vote);

        /// <inheritdoc />
        public override int GetHashCode() => (Day, Agent, Target).GetHashCode();

#if JHELP
        /// <summary>
        /// 等値演算子
        /// </summary>
        /// <param name="lhs">左辺</param>
        /// <param name="rhs">右辺</param>
        /// <returns>オペランドが等しい場合trueを返す</returns>
#else
        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>true if its oprands are equal.</returns>
#endif
        public static bool operator ==(Vote lhs, Vote rhs) => ((object)lhs) == null || ((object)rhs) == null ? Equals(lhs, rhs) : lhs.Equals(rhs);

#if JHELP
        /// <summary>
        /// 非等値演算子
        /// </summary>
        /// <param name="lhs">左辺</param>
        /// <param name="rhs">右辺</param>
        /// <returns>オペランドが等しくない場合trueを返す</returns>
#else
        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>true if its oprands are not equal.</returns>
#endif
        public static bool operator !=(Vote lhs, Vote rhs) => !(lhs == rhs);

    }
}
