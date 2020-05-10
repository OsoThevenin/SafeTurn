using CleanArchitecture.Domain.Common;
using SafeTurn.Domain.Turns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeTurn.Domain.Shops
{
    public class Shop : IEntity
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

            Turns = new List<Turn>();
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
            //if (!IsAvailable(dateRangeStart)) throw new Exception("No disponible");
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

        public bool IsAvailable(DateTime date, int rangeMinutes)
        {
            var timeOpemShop = new TimeSpan(date.Hour, date.Minute, date.Second);
            var timeCloseShop = new TimeSpan(date.Hour, date.Minute + MinutesForTurn, date.Second);
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (timeCloseShop > MondayEnd || timeOpemShop < MondayStart) return false;
                    break;
                case DayOfWeek.Tuesday:
                    if (timeCloseShop > TuesdayEnd || timeOpemShop < TuesdayStart) return false;
                    break;
                case DayOfWeek.Wednesday:
                    if (timeCloseShop > WednesdayEnd || timeOpemShop < WednesdayStart) return false;
                    break;
                case DayOfWeek.Thursday:
                    if (timeCloseShop > ThursdayEnd || timeOpemShop < ThursdayStart) return false;
                    break;
                case DayOfWeek.Friday:
                    if (timeCloseShop > FridayEnd || timeOpemShop < FridayStart) return false;
                    break;
                case DayOfWeek.Saturday:
                    if (timeCloseShop > SaturdayEnd || timeOpemShop < SaturdayStart) return false;
                    break;
                case DayOfWeek.Sunday:
                    if (timeCloseShop > SundayEnd || timeOpemShop < SundayStart) return false;
                    break;
            }

            if (MinutesForTurn > rangeMinutes) rangeMinutes = MinutesForTurn;
            var timeRangeInit = new TimeSpan(date.Hour, date.Minute - rangeMinutes, date.Second);
            var timeRangeEnd = new TimeSpan(date.Hour, date.Minute + rangeMinutes, date.Second);

            var turns = Turns.Where(t =>
            {
                if (t.Date.Date != date.Date) return false;  //Descarta los turnos que no son de hoy
                var timeTurnInit = new TimeSpan(t.Date.Hour, t.Date.Minute, t.Date.Second);
                var timeTurnEnd = new TimeSpan(t.Date.Hour, t.Date.Minute + MinutesForTurn, t.Date.Second);
                if (timeRangeInit <= timeTurnInit && timeTurnInit <= timeRangeEnd) return true;  //Muestra el turno si este empieza dentro del margen
                if (timeRangeInit < timeTurnEnd && timeTurnEnd < timeRangeEnd) return true;  //Muestra el turno si este termina dentro del margen
                return false;   //Descarta el resto
            }).OrderBy(t => t.Date).ToList();

            if (turns.Count <= 1) return true;

            var firstTurn = turns[0].Date;
            if ((new TimeSpan(firstTurn.Hour, firstTurn.Minute, firstTurn.Second) - timeRangeInit).Minutes >= MinutesForTurn)
                return true;
            var lastTurnDateEnd = firstTurn.AddMinutes(MinutesForTurn);
            for (int i = 1; i < turns.Count; i++)
            {
                //FIXME: falta mirar el número de turnos
                var currentTurnDate = turns[i].Date;
                if ((currentTurnDate - lastTurnDateEnd).Minutes >= MinutesForTurn) return true;
                lastTurnDateEnd = currentTurnDate.AddMinutes(MinutesForTurn);
            }
            if (new TimeSpan(lastTurnDateEnd.Hour, lastTurnDateEnd.Minute, lastTurnDateEnd.Second) <= timeRangeEnd) return true;
            return false;
        }
    }
}
