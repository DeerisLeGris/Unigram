// <auto-generated/>
using System;

namespace Telegram.Api.TL.Methods.Help
{
	/// <summary>
	/// RCP method help.getConfig
	/// </summary>
	public partial class TLHelpGetConfig : TLObject
	{
		public TLHelpGetConfig() { }
		public TLHelpGetConfig(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.HelpGetConfig; } }

		public override void Read(TLBinaryReader from)
		{
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xC4F9186B);
		}
	}
}