using System;
using System.Linq;

namespace KamiSama.Iso8583
{
	/// <summary>
	/// Iso Message
	/// </summary>
	public class IsoMessage
	{
		#region Properties and Variables
		/// <summary>
		/// MTI (message type id)
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// Primary bitmap
		/// </summary>
		public BitmapIsoField PrimaryBitmap => fields[0] as BitmapIsoField;
		/// <summary>
		/// Secondary bitmap (may be null)
		/// </summary>
		public BitmapIsoField SecondaryBitmap => fields[1] as BitmapIsoField;
		private IsoFieldBase[] fields; 
		#endregion
		#region Constructors
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="id"></param>
		public IsoMessage(string id)
		{
			this.Id = id;
			this.fields = new IsoFieldBase[129];
		}
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="id"></param>
		public IsoMessage(int id)
			: this(id.ToString("0000"))
		{
		} 
		#endregion
		/// <summary>
		/// Returns true if the specified field is present
		/// fieldno 0 means primary bitmap
		/// </summary>
		/// <param name="fieldNo"></param>
		/// <returns></returns>
		public bool Has(int fieldNo)
		{
			if ((fieldNo < 0) || (fieldNo > 128))
				throw new IndexOutOfRangeException($"field no must between 0 and 128");
			if (fieldNo == 0)
				return fields[0] != null;
			else if (fieldNo < 65)
				return PrimaryBitmap[fieldNo];
			else
				return SecondaryBitmap?[fieldNo - 64] == true;
		}
		/// <summary>
		/// Returns the field value of the specified field
		/// </summary>
		/// <param name="fieldNo"></param>
		/// <returns></returns>
		public IsoFieldBase this[int fieldNo]
		{
			get
			{
				if ((fieldNo < 0) || (fieldNo > 128))
					throw new IndexOutOfRangeException($"field no must be greater than zero: {fieldNo}");

				return fields[fieldNo];
			}
			set
			{
				if ((fieldNo < 0) || (fieldNo > 128))
					throw new IndexOutOfRangeException($"field no must be greater than zero: {fieldNo}");

				fields[fieldNo] = value;

				if ((fieldNo > 0) && (fieldNo <= 64))
				{
					if (PrimaryBitmap == null)
						fields[0] = new BitmapIsoField();
					PrimaryBitmap[fieldNo] = value != null;
				}
				else if (fieldNo > 64)
				{
					if (SecondaryBitmap == null)
					{
						if (value != null)
						{
							this[1] = new BitmapIsoField();

							SecondaryBitmap[fieldNo - 64] = true;
						}
					}
					else
						SecondaryBitmap[fieldNo - 64] = value != null;
				}
			}
		}
		/// <summary>
		/// Returns debug string
		/// </summary>
		/// <returns></returns>
		public string ToDebugString()
		{
			var all = Enumerable
				.Range(0, 129)
				.Where(x => fields[x] != null)
				.Select(x => ((x <= 64) ? "P" : "S") + x.ToString("00") + "\t : " + fields[x].ToDebugString(x));

			return $"Iso Message: {Id}\r\n{string.Join("\r\n", all)}";
		}
		/// <summary>
		/// Returns debug string
		/// </summary>
		/// <returns></returns>
		public override string ToString() => ToDebugString();
	}
}
