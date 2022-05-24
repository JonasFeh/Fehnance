namespace Common.Currency
{
    [Serializable]
    public class Euro : ICurrency
    {
        public string Symbol => "€";

        public string Name => "Euro";

        public string Abbreviation => "EUR";

        private double _value;
        public double Value
        {
            get => _value;
            set => _value = value;
        }
        public Euro()
        {
            _value = 0.0;
        }

        public Euro(double value)
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
            return new Euro(scalar * right.Value);
        }

        public static Euro operator *(Euro left, double scalar)
        {
            return new Euro(left.Value * scalar);
        }

        public static Euro operator /(double scalar, Euro right)
        {
            if(right.Value == 0)
            {
                throw new DivideByZeroException();
            }
            return new Euro(scalar / right.Value);
        }

        public static Euro operator /(Euro left, double scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException();
            }
            return new Euro(left.Value / scalar);
        }

        #endregion
    }
}