using System;

namespace threepowers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ulong is just large enough for input.
            ulong input = ulong.Parse(Console.ReadLine());
            while (input != 0)
            {
                Case(input);
                input = ulong.Parse(Console.ReadLine());
            }
        }

        private static void Case(ulong input)
        {
            input--;
            BigInteger number = new BigInteger(1); ;
            string output = "{ ";

            //go to first non zero
            while (input > 0 && input % 2 == 0)
            {
                number *= 3;
                input /= 2;
            }
            //print first
            if (input % 2 == 1)
            {
                output += number;
                number *= 3;
                input /= 2;
            }
            //print rest
            while (input > 0)
            {
                if (input % 2 == 1)
                {
                    output += ", " + number;
                }
                number *= 3;
                input /= 2;
            }
            output += " }";
            Console.WriteLine(output);
        }
    }

    //class BigNum
    //{
    //    private BigNum bigNum;

    //    //little endian
    //    const int maxParts = 4;
    //    uint[] parts = new uint[maxParts];

    //    public BigNum(BigNum bigNum)
    //    {
    //        for (int i = 0; i < maxParts; i++)
    //        {
    //            this.parts[i] = bigNum.parts[i];
    //        }
    //    }

    //    public BigNum(ulong number)
    //    {
    //        parts[0] = (uint)(number & 0xFFFFFFFF);
    //        number = number >> 32;
    //        parts[1] = (uint)(number & 0xFFFFFFFF);
    //    }

    //    public BigNum()
    //    {
    //    }

    //    public void MultiplyByThree()
    //    {
    //        uint overflow = 0;
    //        for (int i = 0; i < parts.Length; i++)
    //        {
    //            ulong tmp = parts[i];
    //            tmp *= 3;
    //            tmp += overflow;

    //            parts[i] = (uint)(tmp & 0xFFFFFFFF);
    //            overflow = (uint)((tmp >> 32) & 0xFFFFFFFF);
    //        }
    //        if (overflow > 0)
    //            throw new OverflowException("BigNum is not big enough!");
    //    }
    //    public override string ToString()
    //    {
    //        string s = "";

    //        if (parts[0] == 0 && parts[1] == 0 && parts[2] == 0 && parts[3] == 0)
    //            s = "0";
    //        else
    //        {
    //            BigNum a = new BigNum(this);
    //            BigNum quotient = new BigNum();
    //            int remainder;
    //            while (a.parts[0] != 0 || a.parts[1] != 0 || a.parts[2] != 0 || a.parts[3] != 0)
    //            {
    //                DivideByTen(a,quotient,out remainder);
    //                s = remainder + s;
    //                a = quotient;
    //            }
    //        }


    //        foreach (var num in parts)
    //        {
    //            //todo: pad with zeroes where needed. and convert to base 10 properly!
    //            if (num != 0)
    //                s = num + s;
    //        }
    //        return s;
    //    }

    //    private void DivideByTen(BigNum a, BigNum quotient, out int remainder)
    //    {



    //        remainder = 0;
    //        return;
    //    }
    //}

    public class BigInteger
    {
        // maximum length of the BigInteger in uint (4 bytes)
        // change this to suit the required level of precision.

        private const int maxLength = 4;

        // primes smaller than 2000 to test the generated prime number



        private uint[] data = null;             // stores bytes from the Big Integer
        public int dataLength;                 // number of actual chars used


        //***********************************************************************
        // Constructor (Default value for BigInteger is 0
        //***********************************************************************

        public BigInteger()
        {
            data = new uint[maxLength];
            dataLength = 1;
        }


        //***********************************************************************
        // Constructor (Default value provided by long)
        //***********************************************************************

        public BigInteger(long value)
        {
            data = new uint[maxLength];
            long tempVal = value;

            // copy bytes from long to BigInteger without any assumption of
            // the length of the long datatype

            dataLength = 0;
            while (value != 0 && dataLength < maxLength)
            {
                data[dataLength] = (uint)(value & 0xFFFFFFFF);
                value >>= 32;
                dataLength++;
            }

            if (tempVal > 0)         // overflow check for +ve value
            {
                if (value != 0 || (data[maxLength - 1] & 0x80000000) != 0)
                    throw (new ArithmeticException("Positive overflow in constructor."));
            }
            else if (tempVal < 0)    // underflow check for -ve value
            {
                if (value != -1 || (data[dataLength - 1] & 0x80000000) == 0)
                    throw (new ArithmeticException("Negative underflow in constructor."));
            }

            if (dataLength == 0)
                dataLength = 1;
        }


        //***********************************************************************
        // Constructor (Default value provided by ulong)
        //***********************************************************************

        public BigInteger(ulong value)
        {
            data = new uint[maxLength];

            // copy bytes from ulong to BigInteger without any assumption of
            // the length of the ulong datatype

            dataLength = 0;
            while (value != 0 && dataLength < maxLength)
            {
                data[dataLength] = (uint)(value & 0xFFFFFFFF);
                value >>= 32;
                dataLength++;
            }

            if (value != 0 || (data[maxLength - 1] & 0x80000000) != 0)
                throw (new ArithmeticException("Positive overflow in constructor."));

            if (dataLength == 0)
                dataLength = 1;
        }



        //***********************************************************************
        // Constructor (Default value provided by BigInteger)
        //***********************************************************************

        public BigInteger(BigInteger bi)
        {
            data = new uint[maxLength];

            dataLength = bi.dataLength;

            for (int i = 0; i < dataLength; i++)
                data[i] = bi.data[i];
        }






        //***********************************************************************
        // Overloading of the typecast operator.
        // For BigInteger bi = 10;
        //***********************************************************************

        public static implicit operator BigInteger(long value)
        {
            return (new BigInteger(value));
        }

        public static implicit operator BigInteger(ulong value)
        {
            return (new BigInteger(value));
        }

        public static implicit operator BigInteger(int value)
        {
            return (new BigInteger((long)value));
        }

        public static implicit operator BigInteger(uint value)
        {
            return (new BigInteger((ulong)value));
        }




        //***********************************************************************
        // Overloading of multiplication operator
        //***********************************************************************

        public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
        {
            int lastPos = maxLength - 1;
            bool bi1Neg = false, bi2Neg = false;

            // take the absolute value of the inputs
            try
            {
                if ((bi1.data[lastPos] & 0x80000000) != 0)     // bi1 negative
                {
                    bi1Neg = true; bi1 = -bi1;
                }
                if ((bi2.data[lastPos] & 0x80000000) != 0)     // bi2 negative
                {
                    bi2Neg = true; bi2 = -bi2;
                }
            }
            catch (Exception) { }

            BigInteger result = new BigInteger();

            // multiply the absolute values
            try
            {
                for (int i = 0; i < bi1.dataLength; i++)
                {
                    if (bi1.data[i] == 0) continue;

                    ulong mcarry = 0;
                    for (int j = 0, k = i; j < bi2.dataLength; j++, k++)
                    {
                        // k = i + j
                        ulong val = ((ulong)bi1.data[i] * (ulong)bi2.data[j]) +
                                     (ulong)result.data[k] + mcarry;

                        result.data[k] = (uint)(val & 0xFFFFFFFF);
                        mcarry = (val >> 32);
                    }

                    if (mcarry != 0)
                        result.data[i + bi2.dataLength] = (uint)mcarry;
                }
            }
            catch (Exception)
            {
                throw (new ArithmeticException("Multiplication overflow."));
            }


            result.dataLength = bi1.dataLength + bi2.dataLength;
            if (result.dataLength > maxLength)
                result.dataLength = maxLength;

            while (result.dataLength > 1 && result.data[result.dataLength - 1] == 0)
                result.dataLength--;

            // overflow check (result is -ve)
            if ((result.data[lastPos] & 0x80000000) != 0)
            {
                if (bi1Neg != bi2Neg && result.data[lastPos] == 0x80000000)    // different sign
                {
                    // handle the special case where multiplication produces
                    // a max negative number in 2's complement.

                    if (result.dataLength == 1)
                        return result;
                    else
                    {
                        bool isMaxNeg = true;
                        for (int i = 0; i < result.dataLength - 1 && isMaxNeg; i++)
                        {
                            if (result.data[i] != 0)
                                isMaxNeg = false;
                        }

                        if (isMaxNeg)
                            return result;
                    }
                }

                throw (new ArithmeticException("Multiplication overflow."));
            }

            // if input has different signs, then result is -ve
            if (bi1Neg != bi2Neg)
                return -result;

            return result;
        }



        //***********************************************************************
        // Overloading of the NEGATE operator (2's complement)
        //***********************************************************************

        public static BigInteger operator -(BigInteger bi1)
        {
            // handle neg of zero separately since it'll cause an overflow
            // if we proceed.

            if (bi1.dataLength == 1 && bi1.data[0] == 0)
                return (new BigInteger());

            BigInteger result = new BigInteger(bi1);

            // 1's complement
            for (int i = 0; i < maxLength; i++)
                result.data[i] = (uint)(~(bi1.data[i]));

            // add one to result of 1's complement
            long val, carry = 1;
            int index = 0;

            while (carry != 0 && index < maxLength)
            {
                val = (long)(result.data[index]);
                val++;

                result.data[index] = (uint)(val & 0xFFFFFFFF);
                carry = val >> 32;

                index++;
            }

            if ((bi1.data[maxLength - 1] & 0x80000000) == (result.data[maxLength - 1] & 0x80000000))
                throw (new ArithmeticException("Overflow in negation.\n"));

            result.dataLength = maxLength;

            while (result.dataLength > 1 && result.data[result.dataLength - 1] == 0)
                result.dataLength--;
            return result;
        }



        //***********************************************************************
        // Private function that supports the division of two numbers with
        // a divisor that has only 1 digit.
        //***********************************************************************

        private static void singleByteDivide(BigInteger bi1, BigInteger bi2,
                                             BigInteger outQuotient, BigInteger outRemainder)
        {
            uint[] result = new uint[maxLength];
            int resultPos = 0;

            // copy dividend to reminder
            for (int i = 0; i < maxLength; i++)
                outRemainder.data[i] = bi1.data[i];
            outRemainder.dataLength = bi1.dataLength;

            while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0)
                outRemainder.dataLength--;

            ulong divisor = (ulong)bi2.data[0];
            int pos = outRemainder.dataLength - 1;
            ulong dividend = (ulong)outRemainder.data[pos];

            //Console.WriteLine("divisor = " + divisor + " dividend = " + dividend);
            //Console.WriteLine("divisor = " + bi2 + "\ndividend = " + bi1);

            if (dividend >= divisor)
            {
                ulong quotient = dividend / divisor;
                result[resultPos++] = (uint)quotient;

                outRemainder.data[pos] = (uint)(dividend % divisor);
            }
            pos--;

            while (pos >= 0)
            {
                //Console.WriteLine(pos);

                dividend = ((ulong)outRemainder.data[pos + 1] << 32) + (ulong)outRemainder.data[pos];
                ulong quotient = dividend / divisor;
                result[resultPos++] = (uint)quotient;

                outRemainder.data[pos + 1] = 0;
                outRemainder.data[pos--] = (uint)(dividend % divisor);
                //Console.WriteLine(">>>> " + bi1);
            }

            outQuotient.dataLength = resultPos;
            int j = 0;
            for (int i = outQuotient.dataLength - 1; i >= 0; i--, j++)
                outQuotient.data[j] = result[i];
            for (; j < maxLength; j++)
                outQuotient.data[j] = 0;

            while (outQuotient.dataLength > 1 && outQuotient.data[outQuotient.dataLength - 1] == 0)
                outQuotient.dataLength--;

            if (outQuotient.dataLength == 0)
                outQuotient.dataLength = 1;

            while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0)
                outRemainder.dataLength--;
        }




        //***********************************************************************
        // Returns a string representing the BigInteger in base 10.
        //***********************************************************************

        public override string ToString()
        {
            return ToString(10);
        }


        //***********************************************************************
        // Returns a string representing the BigInteger in sign-and-magnitude
        // format in the specified radix.
        //
        // Example
        // -------
        // If the value of BigInteger is -255 in base 10, then
        // ToString(16) returns "-FF"
        //
        //***********************************************************************

        public string ToString(int radix)
        {
            if (radix < 2 || radix > 36)
                throw (new ArgumentException("Radix must be >= 2 and <= 36"));

            string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";

            BigInteger a = this;

            bool negative = false;
            if ((a.data[maxLength - 1] & 0x80000000) != 0)
            {
                negative = true;
                try
                {
                    a = -a;
                }
                catch (Exception) { }
            }

            BigInteger quotient = new BigInteger();
            BigInteger remainder = new BigInteger();
            BigInteger biRadix = new BigInteger(radix);

            if (a.dataLength == 1 && a.data[0] == 0)
                result = "0";
            else
            {
                while (a.dataLength > 1 || (a.dataLength == 1 && a.data[0] != 0))
                {
                    singleByteDivide(a, biRadix, quotient, remainder);

                    if (remainder.data[0] < 10)
                        result = remainder.data[0] + result;
                    else
                        result = charSet[(int)remainder.data[0] - 10] + result;

                    a = quotient;
                }
                if (negative)
                    result = "-" + result;
            }

            return result;
        }







    }

}
