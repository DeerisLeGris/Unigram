// <auto-generated/>
using System;

namespace Telegram.Api.TL.Methods.Auth
{
	/// <summary>
	/// RCP method auth.requestPasswordRecovery
	/// </summary>
	public partial class TLAuthRequestPasswordRecovery : TLObject
	{
		public TLAuthRequestPasswordRecovery() { }
		public TLAuthRequestPasswordRecovery(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.AuthRequestPasswordRecovery; } }

		public override void Read(TLBinaryReader from)
		{
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xD897BC66);
		}
	}
}