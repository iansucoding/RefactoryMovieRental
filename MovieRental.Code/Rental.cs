﻿namespace MovieRental.Code
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
            return _movie.GetCharge(_daysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return _movie.GetFrequentRenterPoints(_daysRented);
        }
    }
}