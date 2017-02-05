// <auto-generated/>
using System;

namespace Telegram.Api.TL.Methods.Messages
{
	/// <summary>
	/// RCP method messages.installStickerSet
	/// </summary>
	public partial class TLMessagesInstallStickerSet : TLObject
	{
		public TLInputStickerSetBase StickerSet { get; set; }
		public Boolean Archived { get; set; }

		public TLMessagesInstallStickerSet() { }
		public TLMessagesInstallStickerSet(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.MessagesInstallStickerSet; } }

		public override void Read(TLBinaryReader from)
		{
			StickerSet = TLFactory.Read<TLInputStickerSetBase>(from);
			Archived = from.ReadBoolean();
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xC78FE460);
			to.WriteObject(StickerSet);
			to.Write(Archived);
		}
	}
}