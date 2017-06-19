namespace MovieRental.Code
{
    /// <summary>
    /// 影片 (只是一個簡單的純數據類)
    /// </summary>
    public class Movie
    {
        private string _title;
        private PriceCode _priceCode;

        public Movie(string title, PriceCode priceCode)
        {
            this._title = title;
            this._priceCode = priceCode;
        }

        public PriceCode GetPriceCode()
        {
            return this._priceCode;
        }

        public void SetPriceCode(PriceCode arg)
        {
            this._priceCode = arg;
        }

        public string GetTitle()
        {
            return _title;
        }

        /// <summary>
        /// 計算費用
        /// </summary>
        /// <param name="daysRented">租約長度</param>
        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (GetPriceCode())
            {
                case PriceCode.Regular:
                    result += 2;
                    if (daysRented > 2)
                    {
                        result += (daysRented - 2) * 1.5;
                    }
                    break;

                case PriceCode.NewRelease:
                    result += daysRented * 3;
                    break;

                case PriceCode.Childrens:
                    result += 1.5;
                    if (daysRented > 3)
                    {
                        result += (daysRented - 3) * 1.5;
                    }
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            if (GetPriceCode() == PriceCode.NewRelease && daysRented > 1)
            {
                return 2;
            }

            return 1;
        }
    }

    /// <summary>
    /// 影片類型
    /// </summary>
    public enum PriceCode
    {
        /// <summary>
        /// 普通片
        /// </summary>
        Regular,

        /// <summary>
        /// 新片
        /// </summary>
        NewRelease,

        /// <summary>
        /// 兒童片
        /// </summary>
        Childrens
    }
}