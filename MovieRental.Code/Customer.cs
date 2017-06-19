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
            double totalAmount = 0;
            int frequentRenterPoints = 0; // 積分
            string result = $"Rental Record for {GetName()} \n";
            foreach (var each in _rentals)
            {
                double thisAmount = 0;
                thisAmount = AmountFor(each);

                // add frequent renter points
                frequentRenterPoints++;

                // add bonus for two day new release rental
                if (each.GetMovie().GetPriceCode() == PriceCode.NewRelease && each.GetDaysRented() > 1)
                {
                    frequentRenterPoints++;
                }

                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }
            // ad footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";
            return result;
        }

        private double AmountFor(Rental aRental)
        {
            double result = 0;
            switch (aRental.GetMovie().GetPriceCode())
            {
                case PriceCode.Regular:
                    result += 2;
                    if (aRental.GetDaysRented() > 2)
                    {
                        result += (aRental.GetDaysRented() - 2) * 1.5;
                    }
                    break;

                case PriceCode.NewRelease:
                    result += aRental.GetDaysRented() * 3;
                    break;

                case PriceCode.Childrens:
                    result += 1.5;
                    if (aRental.GetDaysRented() > 3)
                    {
                        result += (aRental.GetDaysRented() - 3) * 1.5;
                    }
                    break;
            }

            return result;
        }
    }
}