using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Utilities
{
    /// <summary>
    /// Custom attribute that specifies whether a field or property should be included in a report
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class IncludeInReportAttribute : Attribute
    {
        private bool _include;

        // Public properties that specify how an included item should be formatted
        public bool Underline { get; set; }
        public bool Bold { get; set; }

        // Public property that specifies a label (if any) for the item
        public string Label { get; set; }

        public IncludeInReportAttribute()
        {
            this._include = true;
            this.Underline = false;
            this.Bold = false;
            this.Label = string.Empty;
        }

        public IncludeInReportAttribute(bool includeInReport)
        {
            this._include = includeInReport;
            this.Underline = false;
            this.Bold = false;
            this.Label = string.Empty;
        }
    }

    /// <summary>
    /// Static class that encapsulates processing required by classes with properties and fields tagged with the IncludeInReport attribute
    /// </summary>
    public static class IncludeProcessor
    {
        // Examine the fields and properties in the dataForReport object and determine whether any are tagged with the IncludeInReport attribute
        // For each field or property that is tagged, create a FormatField item that specifies the formatting to apply
        // Return the collection of FormatField items that represents the set of fields and properties to be formatted
        public static List<FormatField> GetItemsToInclude(object o)
        {
            List<MemberInfo> fieldsAndProperties = new List<MemberInfo>();
            List<FormatField> items = new List<FormatField>();

            // Exercise 2: Task 1b: Find all the public fields and properties in the dataForReport object

            PropertyInfo[] properties = o.GetType().GetProperties();
            FieldInfo[] fields = o.GetType().GetFields();
            fieldsAndProperties.AddRange(properties);
            fieldsAndProperties.AddRange(fields);

            // TODO: Exercise 2: Task 1c: Iterate through all public fields and properties, and process each item that is tagged with the IncludeInReport attribute

            foreach (MemberInfo e in fieldsAndProperties)
            {
                // Exercise 2: Task 1d: Determine whether the current member is tagged with the IncludeInReport attribute
                IncludeInReportAttribute attribute = (IncludeInReportAttribute)e.GetCustomAttribute(typeof(IncludeInReportAttribute));
                // Array.Find(attributes,)


                if (attribute != null)
                {
                    // TODO: Exercise 2: Task 1e: If the member is tagged with the IncludeInReport attribute, construct a FormatField item
                    // and populate it with the data and format information specified by the attribute
                    String value = null;
                    if (e is FieldInfo)
                        value = ((FieldInfo)e).GetValue(o).ToString();
                    else if (e is PropertyInfo)
                        value = ((PropertyInfo)e).GetValue(o).ToString();

                    // TODO: Exercise 2: Task 1f: Construct a FormatField item with this data
                    FormatField ff = new FormatField()
                    {
                        Value = value,
                        Label = attribute.Label,
                        IsBold = attribute.Bold,
                        IsUnderlined = attribute.Underline
                    };

                    // TODO: Exercise 2: Task 1g: Add the FormatField item to the collection to be returned
                    items.Add(ff);
                }
            }

            // Return the list of FormatField items
            return items;
        }
    }

    // TODO: Exercise 2: Task 1a: Define a struct that specifies the formatting to apply to an item
    public struct FormatField
    {
        public String Value;
        public String Label;
        public Boolean IsBold;
        public Boolean IsUnderlined;
    }
}
