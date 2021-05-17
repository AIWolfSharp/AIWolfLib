//
// Judge.cs
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
    /// プレイヤーが人間か人狼かの判定
    /// </summary>
#else
    /// <summary>
    /// The judge whether the player is human or werewolf.
    /// </summary>
#endif
    [DataContract]
    public class Judge : IEquatable<Judge>
    {
        /// <summary>
        /// Constant Judge.Empty.
        /// </summary>
        public static readonly Judge Empty = new Judge(-1, Agent.NONE, Agent.NONE, Species.UNC);

        /// <summary>
        /// The index number of the agent who judged.
        /// </summary>
        [DataMember(Name = "agent")]
        int agent;

        /// <summary>
        /// The index nunmber of the judged agent.
        /// </summary>
        [DataMember(Name = "target")]
        int target;

        /// <summary>
        /// The result of this judge in string.
        /// </summary>
        [DataMember(Name = "result")]
        string result;

#if JHELP
        /// <summary>
        /// 判定した日
        /// </summary>
#else
        /// <summary>
        /// The day of this judge.
        /// </summary>
#endif
        [DataMember(Name = "day")]
        public int Day { get; }

#if JHELP
        /// <summary>
        /// 判定を下したエージェント
        /// </summary>
#else
        /// <summary>
        /// The agent who judged.
        /// </summary>
#endif
        public Agent Agent { get; }

#if JHELP
        /// <summary>
        /// 判定されたエージェント
        /// </summary>
#else
        /// <summary>
        /// The judged agent.
        /// </summary>
#endif
        public Agent Target { get; }

#if JHELP
        /// <summary>
        /// 判定結果
        /// </summary>
#else
        /// <summary>
        /// The result of this judge.
        /// </summary>
#endif
        public Species Result { get; }

#if JHELP
        /// <summary>
        /// Judgeクラスの新しいインスタンスを初期化する
        /// </summary>
        /// <param name="day">判定の日</param>
        /// <param name="agent">判定を下したエージェント</param>
        /// <param name="target">判定されたエージェント</param>
        /// <param name="result">判定結果</param>
        /// <remarks>agent/target/resultがnullの場合null参照例外</remarks>
#else
        /// <summary>
        /// Initializes a new instance of Judge class.
        /// </summary>
        /// <param name="day">The day of this judge.</param>
        /// <param name="agent">The agent who judged.</param>
        /// <param name="target">The judged agent.</param>
        /// <param name="result">The result of this judge.</param>
        /// <remarks>NullReferenceException is thrown in case of null agent/target/result.</remarks>
#endif
        public Judge(int day = 0, Agent agent = null, Agent target = null, Species result = Species.UNC)
        {
            Day = day;
            Agent = agent;
            Target = target;
            Result = result;
            // NullReferenceException is thrown in case of null agent/target/result.
            this.agent = agent.AgentIdx;
            this.target = target.AgentIdx;
            this.result = result.ToString();
        }

        /// <summary>
        /// Initializes a new instance of Judge class.
        /// </summary>
        /// <param name="day">The day of this judge.</param>
        /// <param name="agent">The index of agent who judged.</param>
        /// <param name="target">The index of judged agent.</param>
        /// <param name="result">The result of this judge.</param>
        [JsonConstructor]
        Judge(int day, int agent, int target, string result)
        {
            Day = day;
            this.agent = agent;
            this.target = target;
            this.result = result;
            Agent = Agent.GetAgent(agent);
            Target = Agent.GetAgent(target);
            Result = (Species)Enum.Parse(typeof(Species), result);
        }

        public override string ToString() => $"{Agent}->{Target}@{Day}:{Result}";

        public bool Equals(Judge other) => other != null && (ReferenceEquals(this, other) || GetType() == other.GetType()
                && other.Day == Day && other.Agent == Agent && other.Target == Target && other.Result == Result);

        public override bool Equals(object obj) => obj is Judge judge && Equals(judge);

        public override int GetHashCode() => (Day, Agent, Target, Result).GetHashCode();

        public static bool operator ==(Judge lhs, Judge rhs) => ((object)lhs) == null || ((object)rhs) == null ? Equals(lhs, rhs) : lhs.Equals(rhs);

        public static bool operator !=(Judge lhs, Judge rhs) => !(lhs == rhs);

    }
}
