using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Condition : ValueObject<Condition>
    {
        public Condition(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                switch (this.Value)
                {
                    case 1:
                        return "晴れ";
                    case 2:
                        return "曇り";
                    case 3:
                        return "雨";
                    default:
                        return "不明";
                }
            }
        }

        protected override bool EqualsCore(Condition other)
        {
            return this.Value == other.Value;
        }
    }
}
