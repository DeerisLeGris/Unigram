// <auto-generated/>
using System;

namespace Telegram.Api.TL
{
	public partial class TLMessageMediaWebPage : TLMessageMediaBase 
	{
		public TLWebPageBase Webpage { get; set; }

		public TLMessageMediaWebPage() { }
		public TLMessageMediaWebPage(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.MessageMediaWebPage; } }

		public override void Read(TLBinaryReader from)
		{
			Webpage = TLFactory.Read<TLWebPageBase>(from);
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xA32DD600);
			to.WriteObject(Webpage);
		}
	}
}