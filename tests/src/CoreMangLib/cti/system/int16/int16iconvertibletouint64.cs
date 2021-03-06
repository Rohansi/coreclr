using System;

//System.Int16.System.IConvertible.ToUInt64(System.IFormatProvider)
public class Int16IConvertibleToUInt64
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;

        TestLibrary.TestFramework.LogInformation("[Negative]");
        retVal = NegTest1() && retVal;

        return retVal;
    }

    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: Convert a random Int16 to UInt64");

        try
        {
            Int16 i1 = TestLibrary.Generator.GetInt16(-55);
            IConvertible Icon1 = (IConvertible)i1;
            ulong u1 = (ulong)i1;
            if (Icon1.ToUInt64(null) != u1)
            {
                TestLibrary.TestFramework.LogError("001", "The result is not the value as expected. The random number is: " + i1);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2: Convert zero to UInt64 ");

        try
        {
            Int16 i1 = 0;
            IConvertible Icon1 = (IConvertible)i1;
            if (Icon1.ToUInt64(null) != 0)
            {
                TestLibrary.TestFramework.LogError("003", "The result is not the value as expected.");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3: Check the boundary value ");

        try
        {
            Int16 i1 = Int16.MaxValue;
            IConvertible Icon1 = (IConvertible)i1;
            if (Icon1.ToUInt64(null) != (ulong)Int16.MaxValue)
            {
                TestLibrary.TestFramework.LogError("005", "The result is not the value as expected.");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    #endregion

    #region Nagetive Test Cases
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: Test the overflowException ");

        try
        {
            Int16 i1 = TestLibrary.Generator.GetInt16(-55);
            IConvertible Icon1 = (IConvertible)(-i1);
            ulong s1 = Icon1.ToUInt64(null);
            TestLibrary.TestFramework.LogError("101", "The overflow exception was not thrown as expected: ");
            retVal = false;
        }
        catch (OverflowException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("102", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    #endregion
    #endregion

    public static int Main()
    {
        Int16IConvertibleToUInt64 test = new Int16IConvertibleToUInt64();

        TestLibrary.TestFramework.BeginTestCase("Int16IConvertibleToUInt64");

        if (test.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
}

