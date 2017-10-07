using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using BitefightBot.Model;

namespace BitefightBot.Util
{
    public static class EnumUtil
    {
        public static string Description(this Enum eValue)
        {
            var nAttributes = eValue.GetType().GetField(eValue.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (nAttributes.Any())
            {
                var descriptionAttribute = nAttributes.First() as DescriptionAttribute;
                if (descriptionAttribute != null)
                    return descriptionAttribute.Description;
            }

            // If no description is found, the least we can do is replace underscores with spaces
            // You can add your own custom default formatting logic here
            var oTi = CultureInfo.CurrentCulture.TextInfo;
            return oTi.ToTitleCase(oTi.ToLower(eValue.ToString().Replace("_", " ")));
        }

        public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type t)
        {
            if (!t.IsEnum)
                throw new ArgumentException("t must be an enum type");

            return Enum.GetValues(t).Cast<Enum>()
                .Select((e) => new ValueDescription() {Value = e, Description = e.Description()}).ToList();
        }
    }
}