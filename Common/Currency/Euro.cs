namespace Common.Currency
{
    [Serializable]
    public struct Euro : ICurrency
    {
        public string Symbol => "€";

        public string Name => "Euro";

        public string Abbreviation => "EUR";

        private decimal _value;
        public decimal Value
        {
            get => _value;
            set => _value = value;
        }

        public string DisplayValue => Value.ToString("C2");

        public Euro()
        {
            _value = 0.0M;
        }

        public Euro(decimal value)
        {
            _value = value;
        }

        #region arithmetic operator

        public static Euro operator +(Euro right)
        {
            return right;
        }

        public static Euro operator +(Euro left, Euro right)
        {
            return new Euro(left.Value + right.Value);
        }

        public static Euro operator -(Euro right)
        {
            return new Euro(-right.Value);
        }

        public static Euro operator -(Euro left, Euro right)
        {
            return new Euro(left.Value - right.Value);
        }

        public static Euro operator *(double scalar, Euro right)
        {
            return new Euro((decimal)scalar * right.Value);
        }

        public static Euro operator *(Euro left, double scalar)
        {
            return new Euro(left.Value * (decimal)scalar);
        }

        public static Euro operator /(double scalar, Euro right)
        {
            if (right.Value == 0)
            {
                throw new DivideByZeroException();
            }
            return new Euro((decimal)scalar / right.Value);
        }

        public static Euro operator /(Euro left, double scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException();
            }
            return new Euro(left.Value / (decimal)scalar);
        }

        public static bool operator ==(Euro left, Euro right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(Euro left, Euro right)
        {
            return !(left.Value == right.Value);
        }

        #endregion
        public bool Equals(ICurrency? other)
        {
            if (!(other is Euro otherEuro))
            {
                return false;
            }
            const decimal epsilon = 1e-6M;
            return Math.Abs(Value - otherEuro.Value) < epsilon;
        }

    }
}