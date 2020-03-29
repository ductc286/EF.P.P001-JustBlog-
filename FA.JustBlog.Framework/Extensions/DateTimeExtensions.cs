using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FA.JustBlog.Framework.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a string representation of this date/time. If the
        /// value is close to now, a relative description is returned.
        /// </summary>
        public static HtmlString DisplayRelativeDateTime(this HtmlHelper htmlHelper, DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                var relativeString = GenerateRelativeString(dateTime.Value);
                string result = string.Format("<label title='{0}'>{1}</label>", dateTime.Value.ToString("dd/MMM/yyyy hh:mm tt"), relativeString);
                return new HtmlString(result);
            }

            return new HtmlString(string.Empty);
        }
        
        /// <summary>
        /// Returns a string representation of this date/time. If the
        /// value is close to now, a relative description is returned.
        /// </summary>
        public static HtmlString DisplayRelativeDateTime(this HtmlHelper htmlHelper, DateTime dateTime)
        {

            var relativeString = GenerateRelativeString(dateTime);

            string result = string.Format("<label title='{0}'>{1}</label>", dateTime.ToString("dd/MMM/yyyy hh:mm tt"), relativeString);
            return new HtmlString(result);

        }

        /// <summary>
        /// Returns a string representation of this date/time. If the
        /// value is close to now, a relative description is returned.
        /// </summary>
        public static HtmlString DisplayRelativeDateTimeFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            if (data.Model is DateTime && !Convert.ToDateTime(data.Model).Equals(DateTime.MinValue))
            {
                var dateTime = Convert.ToDateTime(data.Model);
                var relativeString = GenerateRelativeString(dateTime);
                string result = string.Format("<label title='{0}'>{1}</label>", dateTime.ToString("dd/MMM/yyyy hh:mm tt"), relativeString);
                return new HtmlString(result);
            }

            return new HtmlString(string.Empty);

        }

        private static string GenerateRelativeString(DateTime dateTime)
        {
            TimeSpan span = (DateTime.Now - dateTime);

            // Normalize time span
            bool future = false;
            if (span.TotalSeconds < 0)
            {
                // In the future
                span = -span;
                future = true;
            }

            // Test for Now
            double totalSeconds = span.TotalSeconds;
            if (totalSeconds < 0.9)
            {
                return "Now";
            }

            // Date/time near current date/time
            string format = (future) ? "in {0} {1}" : "{0} {1} ago";
            if (totalSeconds < 55)
            {
                // Seconds
                int seconds = Math.Max(1, span.Seconds);
                return String.Format(format, seconds,
                    (seconds == 1) ? "second" : "seconds");
            }

            if (totalSeconds < (55 * 60))
            {
                // Minutes
                int minutes = Math.Max(1, span.Minutes);
                return String.Format(format, minutes,
                    (minutes == 1) ? "minute" : "minutes");
            }
            if (totalSeconds < (24 * 60 * 60))
            {
                // Hours
                int hours = Math.Max(1, span.Hours);
                return String.Format(format, hours,
                    (hours == 1) ? "hour" : "hours");
            }

            // Format both date and time
            if (totalSeconds < (48 * 60 * 60))
            {
                // 1 Day
                format = (future) ? "tomorrow" : "yesterday";
            }
            else if (totalSeconds < (3 * 24 * 60 * 60))
            {
                // 2 Days
                format = String.Format(format, 2, "days");
            }
            else
            {
                // Absolute date
                if (dateTime.Year == DateTime.Now.Year)
                    format = dateTime.ToString(@"MMM d");
                else
                    format = dateTime.ToString(@"MMM d, yyyy");
            }

            // Add time
            return String.Format("{0} at {1:h:mm tt}", format, dateTime);
        }

        public static string GetRelativeString(this DateTime dateTime)
        {
            TimeSpan span = (DateTime.Now - dateTime);

            // Normalize time span
            bool future = false;
            if (span.TotalSeconds < 0)
            {
                // In the future
                span = -span;
                future = true;
            }

            // Test for Now
            double totalSeconds = span.TotalSeconds;
            if (totalSeconds < 0.9)
            {
                return "now";
            }

            // Date/time near current date/time
            string format = (future) ? "in {0} {1}" : "{0} {1} ago";
            if (totalSeconds < 55)
            {
                // Seconds
                int seconds = Math.Max(1, span.Seconds);
                return String.Format(format, seconds,
                    (seconds == 1) ? "second" : "seconds");
            }

            if (totalSeconds < (55 * 60))
            {
                // Minutes
                int minutes = Math.Max(1, span.Minutes);
                return String.Format(format, minutes,
                    (minutes == 1) ? "minute" : "minutes");
            }
            if (totalSeconds < (24 * 60 * 60))
            {
                // Hours
                int hours = Math.Max(1, span.Hours);
                return String.Format(format, hours,
                    (hours == 1) ? "hour" : "hours");
            }

            // Format both date and time
            if (totalSeconds < (48 * 60 * 60))
            {
                // 1 Day
                format = (future) ? "tomorrow" : "yesterday";
            }
            else if (totalSeconds < (3 * 24 * 60 * 60))
            {
                // 2 Days
                format = String.Format(format, 2, "days");
            }
            else
            {
                // Absolute date
                if (dateTime.Year == DateTime.Now.Year)
                    format = dateTime.ToString(@"MMM d");
                else
                    format = dateTime.ToString(@"MMM d, yyyy");
            }

            // Add time
            return String.Format("{0} at {1:h:mm tt}", format, dateTime);
        }
    }
}
