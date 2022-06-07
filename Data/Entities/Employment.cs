using System;
using Itenso.TimePeriod;

namespace D20.Data.Entities
{

    interface IEmployment
    {
        string EmployerName { get; set; }
        string Location { get; set; }
        string Position { get; set; }
        string Duration { get; set; }
        string[] RelatedPlots { get; set; }
        bool CurrentlyEmployed { get; set; }
        string EmploymentCheck();
    }

    public class Employment : Character, IEmployment
    {
        public string EmployerName { get; set; }
        public string Location { get; set; }

        public string Position { get; set; }

        public string Duration { get; set; }
        public string[] RelatedPlots { get; set; }
        public bool CurrentlyEmployed { get; set; }

        private readonly DateTime from;
        private readonly DateTime to;

        public Employment()
        {
            EmployerName = "";
            Location = "";
            Position = "";
            Duration = "";
            RelatedPlots = Array.Empty<string>();
            CurrentlyEmployed = false;
        }

        /// <summary>
        /// Fresh history for new characters. For previous employments.
        /// </summary>
        /// <param name="location">Where the employer was based. For space or off-world themed games,
        /// an example format would be 'city, state, planet' a fantasy world could use just 'city, state'</param>
        /// <param name="position">What the character did.</param>
        /// <param name="_from">When the character started.</param>
        /// <param name="_to">When employment ended.</param>
        public Employment(string location, string position, DateTime _from, DateTime _to)
        {
            from = _from;
            to = _to;

            Duration = DiffString(from, to);
            Location = location;
            Position = position;
        }

        /// <summary>
        /// For entries when a character's employment was directly involved in a past or ongoing plot.
        /// </summary>
        /// <param name="relatedPlots">Plots this entry is related to; past or present.</param>
        public Employment(string location, string position, string[] relatedPlots, DateTime _from, DateTime _to)
        {
            from = _from;
            to = _to;

            Duration = DiffString(from, to);
            Location = location;
            Position = position;
            RelatedPlots = relatedPlots;
        }

        /// <summary>
        /// For current employment of character that coincides with a plot.
        /// </summary>

        public Employment(string location, string position, string[] relatedPlots, DateTime _from)
        {
            from = _from;

            CurrentlyEmployed = true;
            Duration = DiffString(from);
            Location = location;
            Position = position;
            RelatedPlots = relatedPlots;
        }

        /// <summary>
        /// For current employment of character.
        /// </summary>
        public Employment(string location, string position, DateTime _from)
        {
            from = _from;

            this.CurrentlyEmployed = true;
            this.Duration = DiffString(from);
            this.Location = location;
            this.Position = position;
        }

        /// <summary>
        /// Provides a string that specifies a character's employment status with an employer.
        /// </summary>
        /// <returns></returns>
        public string EmploymentCheck()
        {
            if (this.CurrentlyEmployed)
            {
                return $"{FirstName} {LastName} is currently employed with {EmployerName}.";
            }
            else
            {
                return $"{FirstName} {LastName} is currently not employed with {EmployerName}.";
            }
        }

        internal static string DiffString(DateTime from, DateTime to = new DateTime())
        {
            DateDiff dateDiff = new(from, to);

            int years = dateDiff.Years;
            int months = dateDiff.Months;
            int days = dateDiff.Days;

            string dayString;

            if ( days < 2 && days > 0)
            {
                dayString = "day";
            }
            else
            {
                dayString = "days";
            }

            return $"{years} years, {months} months, and {days} {dayString}";
        }
    }
}
