using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Module.BusinessObjects;

[DefaultClassOptions]

// Use this attribute to specify the caption format for the objects of the entity class.
[ObjectCaptionFormat($"{{0:{nameof(FullName)}}}")]
[DefaultProperty(nameof(FullName))]
public class Employee : BaseObject
{
	public static string FullNameFormat = $"{{{nameof(FirstName)}}} {{{nameof(MiddleName)}}} {{{nameof(LastName)}}}";

	public virtual string FirstName { get; set; }

	public virtual string LastName { get; set; }

	public virtual string MiddleName { get; set; }

	public string FullName
	{
		get => ObjectFormatter.Format(FullNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
	}

	public string DisplayName
	{
		get => this.FullName;
	}

	public virtual DateTime? Birthday { get; set; }

	// Use this attribute to hide or show the editor of this property in the UI.
	[Browsable(false)]
	public virtual int TitleOfCourtesy_Int { get; set; }

	// Use this attribute to exclude the property from database mapping.
	[NotMapped]
	public virtual TitleOfCourtesy TitleOfCourtesy { get; set; }

	// Use this attribute to specify the maximum number of characters that users can type in the editor of this property.
	[FieldSize(255)]
	public virtual string Email { get; set; }

	// Use this attribute to define a pattern that the property value must match.
	[RuleRegularExpression(@"(((http|https)\://)[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})", CustomMessageTemplate = @"Invalid ""Web Page Address"".")]
	public virtual string WebPageAddress { get; set; }

	// Use this attribute to specify the maximum string length allowed for this data field.
	[StringLength(4096)]
	public virtual string Notes { get; set; }
}


public enum TitleOfCourtesy
{
	Dr,
	Miss,
	Mr,
	Mrs,
	Ms
}
