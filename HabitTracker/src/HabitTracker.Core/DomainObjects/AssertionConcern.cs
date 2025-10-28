using System.Text.RegularExpressions;

namespace HabitTracker.Core.DomainObjects
{
    public class AssertionConcern //Validations
    {
        public static void ValidateIfEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfDifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCharacters(string value, int max, string message)
        {
            var length = value.Trim().Length;
            if (length > max)
                throw new DomainException(message);
        }

        public static void ValidateCharacters(string value, int min, int max, string message)
        {
            var length = value.Trim().Length;
            if (length > max || length < min)
                throw new DomainException(message);
        }

        public static void ValidateExpression(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(value))
                throw new DomainException(message);
        }

        public static void ValidateIfEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(message);
        }

        public static void ValidateIfNull(object object1, string message)
        {
            if (object1 == null)
                throw new DomainException(message);
        }

        public static void ValidateMinimumMaximum(int value, int min, int max, string message)
        {
            if (value < min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateMinimumMaximum(long value, long min, long max, string message)
        {
            if (value < min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateMinimumMaximum(float value, float min, float max, string message)
        {
            if (value < min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateMinimumMaximum(double value, double min, double max, string message)
        {
            if (value < min || value > max)
                throw new DomainException(message);
        }      

        public static void ValidateMinimumMaximum(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
                throw new DomainException(message);
        }

        public static void ValidateIfLessThan(int value, int min, string message)
        {
            if (value < min)
                throw new DomainException(message);
        }

        public static void ValidateIfLessThan(long value, long min, string message)
        {
            if (value < min)
                throw new DomainException(message);
        }

        public static void ValidateIfLessThan(double value, double min, string message)
        {
            if (value < min)
                throw new DomainException(message);
        }

        public static void ValidateIfLessThan(decimal value, decimal min, string message)
        {
            if (value < min)
                throw new DomainException(message);
        }

        public static void ValidateIfFalse(bool boolValue, string message)
        {
            if (!boolValue)
                throw new DomainException(message);
        }

        public static void ValidateIfTrue(bool boolValue, string message)
        {
            if (boolValue)
                throw new DomainException(message);
        }
    }
}
