namespace MovieRental.Code
{
    /// <summary>
    /// 影片 (只是一個簡單的純數據類)
    /// </summary>
    public class Movie
    {
        private string _title;
        private Price _price;

        public Movie(string title, PriceCode priceCode)
        {
            this._title = title;
            SetPriceCode(priceCode);
        }

        public PriceCode GetPriceCode()
        {
            return _price.GetPriceCode();
        }

        public void SetPriceCode(PriceCode arg)
        {
            switch (arg)
            {
                case PriceCode.Regular:
                    this._price = new RegularPrice();
                    break;

                case PriceCode.NewRelease:
                    this._price = new NewReleasePrice();
                    break;

                case PriceCode.Childrens:
                    this._price = new ChildrensPrice();
                    break;
            }
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
            return _price.GetCharge(daysRented);
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