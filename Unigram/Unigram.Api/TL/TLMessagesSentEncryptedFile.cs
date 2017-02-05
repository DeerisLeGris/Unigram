// <auto-generated/>
using System;

namespace Telegram.Api.TL
{
	public partial class TLMessagesSentEncryptedFile : TLMessagesSentEncryptedMessageBase 
	{
		public TLEncryptedFileBase File { get; set; }

		public TLMessagesSentEncryptedFile() { }
		public TLMessagesSentEncryptedFile(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.MessagesSentEncryptedFile; } }

		public override void Read(TLBinaryReader from)
		{
			Date = from.ReadInt32();
			File = TLFactory.Read<TLEncryptedFileBase>(from);
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0x9493FF32);
			to.Write(Date);
			to.WriteObject(File);
		}
	}
}