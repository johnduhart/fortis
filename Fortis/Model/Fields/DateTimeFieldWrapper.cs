﻿using System;
using Sitecore.Data.Fields;
using System.Web;

namespace Fortis.Model.Fields
{
	public class DateTimeFieldWrapper : FieldWrapper, IDateTimeFieldWrapper
	{
		private DateTime _dateTime;

		protected DateField DateField
		{
			get { return (Sitecore.Data.Fields.DateField)Field; }
		}

		public DateTime Value
		{
			get { return IsLazy ? _dateTime : DateField.DateTime; }
		}

		public DateTimeFieldWrapper(Field field)
			: base(field) { }

		public DateTimeFieldWrapper(string key, ref ItemWrapper item, string value = null)
			: base(key, ref item, value) { }

		public DateTimeFieldWrapper(string key, ref ItemWrapper item, DateTime value)
			: base(key, ref item, value.ToString())
		{
			_dateTime = value;
		}

		public IHtmlString Render(bool includeTime)
		{
			return Render(includeTime ? Sitecore.Context.Language.CultureInfo.DateTimeFormat.FullDateTimePattern : Sitecore.Context.Language.CultureInfo.DateTimeFormat.ShortDatePattern);
		}

		public override IHtmlString Render(string dateTimeFormat = null, bool editing = false)
		{
			return base.Render(parameters: "format=" + dateTimeFormat);
		}

		public static implicit operator DateTime(DateTimeFieldWrapper field)
		{
			return field.Value;
		}
	}
}
