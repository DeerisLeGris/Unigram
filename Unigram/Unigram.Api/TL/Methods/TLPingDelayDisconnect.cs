// <auto-generated/>
using System;

namespace Telegram.Api.TL.Methods
{
	/// <summary>
	/// RCP method ping_delay_disconnect
	/// </summary>
	public partial class TLPingDelayDisconnect : TLObject
	{
		public Int64 PingId { get; set; }
		public Int32 DisconnectDelay { get; set; }

		public TLPingDelayDisconnect() { }
		public TLPingDelayDisconnect(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.PingDelayDisconnect; } }

		public override void Read(TLBinaryReader from)
		{
			PingId = from.ReadInt64();
			DisconnectDelay = from.ReadInt32();
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xF3427B8C);
			to.Write(PingId);
			to.Write(DisconnectDelay);
		}
	}
}