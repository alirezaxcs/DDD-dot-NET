using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.Clinic.Domain.ValueObject
{
    public record Text
    {
        public string Value { get; set; }
        public Text(string value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length > 500)
            {
                throw new ArgumentException("too larg text");
            }

        }
        public static implicit operator Text(string value) { return new Text(value); }
    }
}
