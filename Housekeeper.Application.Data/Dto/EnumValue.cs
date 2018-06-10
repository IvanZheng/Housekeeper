using System;
using System.Collections.Generic;
using System.Text;
using IFramework.Infrastructure;

namespace Housekeeper.Application.Contracts.Dto
{
    public class EnumValue
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public EnumValue() { }

        public EnumValue(int value, string text)
        {
            Value = value;
            Text = text;
        }

        public static implicit operator EnumValue(Enum @enum) => new EnumValue(Convert.ToInt32(@enum), @enum.GetDescription());
    }
}
