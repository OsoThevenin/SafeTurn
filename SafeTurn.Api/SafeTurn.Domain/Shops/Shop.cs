using CleanArchitecture.Domain.Common;
using SafeTurn.Domain.Turns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeTurn.Domain.Shops
{
    public class Shop :IEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SimultaneousTurns { get; set; }
        public int MinutesForTurn { get; set; }

        public TimeSpan MondayStart { get; set; }
        public TimeSpan MondayEnd { get; set; }
        public TimeSpan TuesdayStart { get; set; }
        public TimeSpan TuesdayEnd { get; set; }
        public TimeSpan WednesdayStart { get; set; }
        public TimeSpan WednesdayEnd { get; set; }
        public TimeSpan ThursdayStart { get; set; }
        public TimeSpan ThursdayEnd { get; set; }
        public TimeSpan FridayStart { get; set; }
        public TimeSpan FridayEnd { get; set; }
        public TimeSpan SaturdayStart { get; set; }
        public TimeSpan SaturdayEnd { get; set; }
        public TimeSpan SundayStart { get; set; }
        public TimeSpan SundayEnd { get; set; }

        public List<Turn> Turns { get; set; }

        public bool Published { get; set; }

        public Shop(string code, string name)
        {
            Code = code;
            Name = name;

            //FIXME: hardcoded
            SimultaneousTurns = 2;
            MinutesForTurn = 5;
            MondayStart = new TimeSpan(9, 0, 0);
            MondayEnd = new TimeSpan(20, 0, 0);
            TuesdayStart = new TimeSpan(9, 0, 0);
            TuesdayEnd = new TimeSpan(20, 0, 0);
            WednesdayStart = new TimeSpan(9, 0, 0);
            WednesdayEnd = new TimeSpan(20, 0, 0);
            ThursdayStart = new TimeSpan(9, 0, 0);
            ThursdayEnd = new TimeSpan(20, 0, 0);
            FridayStart = new TimeSpan(9, 0, 0);
            FridayEnd = new TimeSpan(20, 0, 0);
            SaturdayStart = new TimeSpan(9, 0, 0);
            SaturdayEnd = new TimeSpan(20, 0, 0);
            SundayStart = new TimeSpan(9, 0, 0);
            SundayEnd = new TimeSpan(20, 0, 0);
        }

        public void Update(string name, int simultaneousTurns, int minutesForTurn)
        {
            Name = name;
            SimultaneousTurns = simultaneousTurns;
            MinutesForTurn = minutesForTurn;

            //FIXME: hardcoded
            MondayStart = new TimeSpan(9, 0, 0);
            MondayEnd = new TimeSpan(20, 0, 0);
            TuesdayStart = new TimeSpan(9, 0, 0);
            TuesdayEnd = new TimeSpan(20, 0, 0);
            WednesdayStart = new TimeSpan(9, 0, 0);
            WednesdayEnd = new TimeSpan(20, 0, 0);
            ThursdayStart = new TimeSpan(9, 0, 0);
            ThursdayEnd = new TimeSpan(20, 0, 0);
            FridayStart = new TimeSpan(9, 0, 0);
            FridayEnd = new TimeSpan(20, 0, 0);
            SaturdayStart = new TimeSpan(9, 0, 0);
            SaturdayEnd = new TimeSpan(20, 0, 0);
            SundayStart = new TimeSpan(9, 0, 0);
            SundayEnd = new TimeSpan(20, 0, 0);
        }

        public void Publish()
        {
            Published = true;
        }

        public void Unpublish()
        {
            Published = false;
        }

        public void SetNewTurn(DateTime dateRangeStart, DateTime dateRangeEnd, string clientName)
        {
            if (!IsAvailable(dateRangeStart)) throw new Exception("No disponible");
            var dateAssign = GetDateAvailable(dateRangeStart);
            Turns.Add(new Turn(Id, dateAssign, clientName, Turns.Select(t => t.Number).ToList()));
        }

        private DateTime GetDateAvailable(DateTime date)
        {
            switch ((new Random()).Next(1, 10))
            {
                case 1:
                    return new DateTime(date.Year, date.Month, date.Day, 10, 0, 0);
                case 2:
                    return new DateTime(date.Year, date.Month, date.Day, 10, 15, 0);
                case 3:
                    return new DateTime(date.Year, date.Month, date.Day, 10, 30, 0);
                case 4:
                    return new DateTime(date.Year, date.Month, date.Day, 11, 0, 0);
                case 5:
                    return new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
                case 6:
                    return new DateTime(date.Year, date.Month, date.Day, 14, 0, 0);
                case 7:
                    return new DateTime(date.Year, date.Month, date.Day, 10, 45, 0);
                case 8:
                    return new DateTime(date.Year, date.Month, date.Day, 9, 55, 0);
                case 9:
                    return new DateTime(date.Year, date.Month, date.Day, 10, 25, 0);
                default:
                    return new DateTime(date.Year, date.Month, date.Day, 11, 5, 0);
            }
        }

        public bool IsAvailable(DateTime date)
        {
            var timeStart = new TimeSpan(date.Hour, date.Minute, date.Second);
            var timeEnd = new TimeSpan(date.Hour, date.Minute + MinutesForTurn, date.Second);
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (timeEnd > MondayEnd || timeStart < MondayStart) return false;
                    break;
                case DayOfWeek.Tuesday:
                    if (timeEnd > TuesdayEnd || timeStart < TuesdayStart) return false;
                    break;
                case DayOfWeek.Wednesday:
                    if (timeEnd > WednesdayEnd || timeStart < WednesdayStart) return false;
                    break;
                case DayOfWeek.Thursday:
                    if (timeEnd > ThursdayEnd || timeStart < ThursdayStart) return false;
                    break;
                case DayOfWeek.Friday:
                    if (timeEnd > FridayEnd || timeStart < FridayStart) return false;
                    break;
                case DayOfWeek.Saturday:
                    if (timeEnd > SaturdayEnd || timeStart < SaturdayStart) return false;
                    break;
                case DayOfWeek.Sunday:
                    if (timeEnd > SundayEnd || timeStart < SundayStart) return false;
                    break;
            }
            //TODO: en funció dels turns ja reservats
            //return Turns.Any(t =>
            //{
            //    var time = new TimeSpan(t.Date.Hour, t.Date.Minute, t.Date.Second);
            //    var rangeMin = timeStart
            //    return true;
            //});

            return (new Random()).Next(0, 100) <= 75;
        }
    }
}
