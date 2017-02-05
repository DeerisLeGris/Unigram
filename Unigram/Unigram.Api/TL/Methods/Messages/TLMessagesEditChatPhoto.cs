// <auto-generated/>
using System;

namespace Telegram.Api.TL.Methods.Messages
{
	/// <summary>
	/// RCP method messages.editChatPhoto
	/// </summary>
	public partial class TLMessagesEditChatPhoto : TLObject
	{
		public Int32 ChatId { get; set; }
		public TLInputChatPhotoBase Photo { get; set; }

		public TLMessagesEditChatPhoto() { }
		public TLMessagesEditChatPhoto(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.MessagesEditChatPhoto; } }

		public override void Read(TLBinaryReader from)
		{
			ChatId = from.ReadInt32();
			Photo = TLFactory.Read<TLInputChatPhotoBase>(from);
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xCA4C79D8);
			to.Write(ChatId);
			to.WriteObject(Photo);
		}
	}
}