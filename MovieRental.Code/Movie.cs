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