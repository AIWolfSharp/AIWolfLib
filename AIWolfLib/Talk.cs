//
// Talk.cs
//
// Copyright 2018 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace AIWolf.Lib
{
#if JHELP
    /// <summary>
    /// 会話クラス
    /// </summary>
#else
    /// <summary>
    /// Talk class.
    /// </summary>
#endif
    [DataContract]
    public class Talk : IUtterance, IEquatable<Talk>
    {
#if JHELP
        /// <summary>
        /// 定数Talk.Empty
        /// </summary>
#else
        /// <summary>
        /// Constant Talk.Empty.
        /// </summary>
#endif
        public static readonly Talk Empty = new Talk(-1, -1, -1, Agent.NONE, string.Empty);

#if JHELP
        /// <summary>
        /// 発話することがない
        /// </summary>
#else
        /// <summary>
        /// There is nothing to utter.
        /// </summary>
#endif
        public static readonly string OVER = "Over";

#if JHELP
        /// <summary>
        /// 発話することはあるがこのターンはスキップ
        /// </summary>
#else
        /// <summary>
        /// Skip this turn though there is something to utter.
        /// </summary>
#endif
        public static readonly string SKIP = "Skip";

#if JHELP
        /// <summary>
        /// 発話のインデックス
        /// </summary>
#else
        /// <summary>
        /// The index number of this utterance.
        /// </summary>
#endif
        [DataMember(Name = "idx")]
        public int Idx { get; }

#if JHELP
        /// <summary>
        /// 発話日
        /// </summary>
#else
        /// <summary>
        /// The day of this utterance.
        /// </summary>
#endif
        [DataMember(Name = "day")]
        public int Day { get; }

#if JHELP
        /// <summary>
        /// 発話ターン
        /// </summary>
#else
        /// <summary>
        /// The turn of this utterance.
        /// </summary>
#endif
        [DataMember(Name = "turn")]
        public int Turn { get; }

#if JHELP
        /// <summary>
        /// 発話エージェント
        /// </summary>
#else
        /// <summary>
        /// The agent who uttered.
        /// </summary>
#endif
        public Agent Agent { get; }

        /// <summary>
        /// The index number of the agent who uttered.
        /// </summary>
        [DataMember(Name = "agent")]
        int agent;

#if JHELP
        /// <summary>
        /// 発話テキスト
        /// </summary>
#else
        /// <summary>
        /// The contents of this utterance.
        /// </summary>
#endif
        [DataMember(Name = "text")]
        public string Text { get; }

#if JHELP
        /// <summary>
        /// 会話の新しいインスタンスを初期化する
        /// </summary>
        /// <param name="idx">この会話のインデックス</param>
        /// <param name="day">この会話の発話日</param>
        /// <param name="turn">この会話の発話ターン</param>
        /// <param name="agent">この会話の発話エージェント</param>
        /// <param name="text">この会話の発話テキスト</param>
#else
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="idx">The index of this talk.</param>
        /// <param name="day">The day of this talk.</param>
        /// <param name="turn">The turn of this talk.</param>
        /// <param name="agent">The agent who talked.</param>
        /// <param name="text">The text of this talk.</param>
#endif
        public Talk(int idx, int day, int turn, Agent agent, string text)
        {
            Idx = idx;
            Day = day;
            Turn = turn;
            Agent = agent ?? Agent.NONE;
            this.agent = Agent.AgentIdx;
            Text = text ?? "";
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="idx">The index of this talk.</param>
        /// <param name="day">The day of this talk.</param>
        /// <param name="turn">The turn of this talk.</param>
        /// <param name="agent">The index of agent who talked.</param>
        /// <param name="text">The text of this talk.</param>
        [JsonConstructor]
        internal Talk(int idx, int day, int turn, int agent, string text)
            : this(idx, day, turn, Agent.GetAgent(agent), text) { }

        /// <inheritdoc />
        public override string ToString() => $"Talk: Day{Day:D2} {Turn:D2}[{Idx:D3}]\t{Agent}\t{Text}";

        /// <inheritdoc />
        public bool Equals(Talk other) => other != null && (ReferenceEquals(this, other) || GetType() == other.GetType()
                && other.Idx == Idx && other.Day == Day && other.Turn == Turn && other.Agent == Agent && other.Text == Text);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Talk talk && Equals(talk);

        /// <inheritdoc />
        public override int GetHashCode() => (UtteranceType.TALK, Idx, Day, Turn, Agent, Text).GetHashCode();

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
        public static bool operator ==(Talk lhs, Talk rhs) => ((object)lhs) == null || ((object)rhs) == null ? Equals(lhs, rhs) : lhs.Equals(rhs);

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
        public static bool operator !=(Talk lhs, Talk rhs) => !(lhs == rhs);
    }

#if JHELP
    /// <summary>
    /// 囁きクラス
    /// </summary>
#else
    /// <summary>
    /// Whisper class.
    /// </summary>
#endif
    public class Whisper : Talk, IEquatable<Whisper>
    {
#if JHELP
        /// <summary>
        /// 定数Whisper.Empty
        /// </summary>
#else
        /// <summary>
        /// Constant Whisper.Empty.
        /// </summary>
#endif
        public static new readonly Whisper Empty = new Whisper(-1, -1, -1, Agent.NONE, string.Empty);

#if JHELP
        /// <summary>
        /// 囁きの新しいインスタンスを初期化する
        /// </summary>
        /// <param name="idx">この囁きのインデックス</param>
        /// <param name="day">この囁きの発話日</param>
        /// <param name="turn">この囁きの発話ターン</param>
        /// <param name="agent">この囁きの発話エージェント</param>
        /// <param name="text">この囁きの発話テキスト</param>
#else
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="idx">The index of this talk.</param>
        /// <param name="day">The day of this talk.</param>
        /// <param name="turn">The turn of this talk.</param>
        /// <param name="agent">The agent who talked.</param>
        /// <param name="text">The text of this talk.</param>
#endif
        public Whisper(int idx, int day, int turn, Agent agent, string text)
            : base(idx, day, turn, agent, text) { }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="idx">The index of this whisper.</param>
        /// <param name="day">The day of this whisper.</param>
        /// <param name="turn">The turn of this whisper.</param>
        /// <param name="agent">The index of agent who whispered.</param>
        /// <param name="text">The text of this whisper.</param>
        [JsonConstructor]
        Whisper(int idx, int day, int turn, int agent, string text)
            : this(idx, day, turn, Agent.GetAgent(agent), text) { }

        /// <inheritdoc />
        public override string ToString() => $"Whisper: Day{Day:D2} {Turn:D2}[{Idx:D3}]\t{Agent}\t{Text}";

        /// <inheritdoc />
        public bool Equals(Whisper other) => other != null && (ReferenceEquals(this, other) || GetType() == other.GetType()
            && other.Idx == Idx && other.Day == Day && other.Turn == Turn && other.Agent == Agent && other.Text == Text);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Whisper whisper && Equals(whisper);

        /// <inheritdoc />
        public override int GetHashCode() => (UtteranceType.WHISPER, Idx, Day, Turn, Agent, Text).GetHashCode();

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
        public static bool operator ==(Whisper lhs, Whisper rhs) => ((object)lhs) == null || ((object)rhs) == null ? Equals(lhs, rhs) : lhs.Equals(rhs);

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
        public static bool operator !=(Whisper lhs, Whisper rhs) => !(lhs == rhs);

    }
}
