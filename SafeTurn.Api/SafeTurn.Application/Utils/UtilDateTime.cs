using System;

namespace SafeTurn.Application.Utils
{
    public class UtilDateTime : IUtilDateTime
    {
        public DateTime GetNow()
        {
            return DateTime.UtcNow;
        }
    }
}
