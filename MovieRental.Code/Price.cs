namespace MovieRental.Code
{
    abstract public class Price
    {
        abstract public PriceCode GetPriceCode();

        abstract public double GetCharge(int daysRented);

        public int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public class ChildrensPrice : Price
    {
        public override PriceCode GetPriceCode()
        {
            return PriceCode.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5;
            }
            return result;
        }
    }

    public class NewReleasePrice : Price
    {
        public override PriceCode GetPriceCode()
        {
            return PriceCode.NewRelease;
        }

        public override double GetCharge(int daysRented)
        {
            return daysRented * 3; ;
        }

        public new int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }

    public class RegularPrice : Price
    {
        public override PriceCode GetPriceCode()
        {
            return PriceCode.Regular;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
            {
                result += (daysRented - 2) * 1.5;
            }
            return result;
        }
    }
}