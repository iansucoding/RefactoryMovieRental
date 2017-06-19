namespace MovieRental.Code
{
    /// <summary>
    /// 租貸 (表示顧客租了一部影片)
    /// </summary>
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this._movie = movie;
            this._daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        public double GetCharge()
        {
            double result = 0;
            switch (GetMovie().GetPriceCode())
            {
                case PriceCode.Regular:
                    result += 2;
                    if (GetDaysRented() > 2)
                    {
                        result += (GetDaysRented() - 2) * 1.5;
                    }
                    break;

                case PriceCode.NewRelease:
                    result += GetDaysRented() * 3;
                    break;

                case PriceCode.Childrens:
                    result += 1.5;
                    if (GetDaysRented() > 3)
                    {
                        result += (GetDaysRented() - 3) * 1.5;
                    }
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints()
        {
            if (GetMovie().GetPriceCode() == PriceCode.NewRelease && GetDaysRented() > 1)
            {
                return 2;
            }

            return 1;
        }
    }
}