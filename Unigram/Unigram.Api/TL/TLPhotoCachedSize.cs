// <auto-generated/>
using System;

namespace Telegram.Api.TL
{
	public partial class TLPhotoCachedSize : TLPhotoSizeBase 
	{
		public TLFileLocationBase Location { get; set; }
		public Int32 W { get; set; }
		public Int32 H { get; set; }
		public Byte[] Bytes { get; set; }

		public TLPhotoCachedSize() { }
		public TLPhotoCachedSize(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.PhotoCachedSize; } }

		public override void Read(TLBinaryReader from)
		{
			Type = from.ReadString();
			Location = TLFactory.Read<TLFileLocationBase>(from);
			W = from.ReadInt32();
			H = from.ReadInt32();
			Bytes = from.ReadByteArray();
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xE9A734FA);
			to.Write(Type);
			to.WriteObject(Location);
			to.Write(W);
			to.Write(H);
			to.WriteByteArray(Bytes);
		}
	}
}