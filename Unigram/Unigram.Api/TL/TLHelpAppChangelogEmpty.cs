// <auto-generated/>
using System;

namespace Telegram.Api.TL
{
	public partial class TLHelpAppChangelogEmpty : TLHelpAppChangelogBase 
	{
		public TLHelpAppChangelogEmpty() { }
		public TLHelpAppChangelogEmpty(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.HelpAppChangelogEmpty; } }

		public override void Read(TLBinaryReader from)
		{
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xAF7E0394);
		}
	}
}