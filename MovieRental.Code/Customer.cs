using System.Collections.Generic;

namespace MovieRental.Code
{
    /// <summary>
    /// 顧客
    /// </summary>
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            this._name = name;
        }

        public void AddRental(Rental arg)
        {
            this._rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// 生成樣單 (根據租貸時間和影片類型計算出費用)
        /// </summary>
        /// <returns></returns>
        public string Statement()
        {
            string result = $"Rental Record for {GetName()} \n";
            foreach (var each in _rentals)
            {
                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + each.GetCharge() + "\n";
            }
            // ad footer lines
            result += "Amount owed is " + GetTotalCharge().ToString() + "\n";
            result += "You earned " + GetTotalrequentRenterPoints().ToString() + " frequent renter points";
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (var each in _rentals)
            {
                result += each.GetCharge();
            }
            return result;
        }

        private int GetTotalrequentRenterPoints()
        {
            int result = 0;
            foreach (var each in _rentals)
            {
                result += each.GetFrequentRenterPoints();
            }
            return result;
        }
    }
}