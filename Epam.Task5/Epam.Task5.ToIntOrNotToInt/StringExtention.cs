using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ToIntOrNotToInt
{
    public static class StringExtention
    {
        private const char Plus = '+';
        private const char Minus = '-';
        private const char Comma = ',';
        private const char ExponentUpper = 'E';
        private const char ExponentLower = 'e';

        public static bool IsNaturalNumber(this string number)
        {
            if (number.Length == 0 || number == string.Empty || number == null)
            {
                return false;
            }

            int index = 0;
            int length = number.Length;
            bool comma = false;
            bool exponent = false;
            bool plus = false;
            bool minus = false;
            int wholePart = 0;
            int fractionalPart = 0;

            if (number[index] == Plus)
            {
                if (index + 1 <= length - 1 && number[index + 1] != '0' && IsNumber(number[index + 1]))
                {
                    index = 0;
                    length--;
                    wholePart++;
                }
                else
                {
                    return false;
                }
            }

            if (index <= length - 1 && number[index] != '0' && IsNumber(number[index]))
            {
                index++;
                wholePart++;
            }
            else
            {
                return false;
            }

            for (int i = index; i < number.Length; i++)
            {
                if (!IsNumber(number[i]) &&
                    number[i] != Comma &&
                    (number[i] != ExponentUpper || number[i] != ExponentLower) &&
                    number[i] != Plus &&
                    number[i] != Minus)
                {
                    return false;
                }

                if (number[i] == Comma)
                {
                    if (!comma)
                    {
                        comma = true;
                        if (i + 1 == number.Length || !IsNumber(number[i - 1]) || !IsNumber(number[i + 1]))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (number[i] == ExponentUpper || number[i] == ExponentLower)
                {
                    if (!exponent)
                    {
                        exponent = true;
                        if (i + 1 == number.Length)
                        {
                            return false;
                        }

                        if (!IsNumber(number[i - 1]))
                        {
                            return false;
                        }

                        while (i < number.Length)
                        {
                            if (!IsNumber(number[i]))
                            {
                                if (number[i] != Plus && number[i] != Minus)
                                {
                                    return false;
                                }
                            }

                            if (number[i] == Minus)
                            {
                                if (!minus)
                                {
                                    minus = true;
                                    i++;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                            if (number[i] == Plus)
                            {
                                if (!plus)
                                {
                                    plus = true;
                                    i++;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                            if (i == number.Length)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (!comma)
                {
                    wholePart++;
                }
            }

            if (fractionalPart == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsNumber(char character)
        {
            if (character >= '0' && character <= '9')
            {
                return true;
            }

            return false;
        }
    }
}
