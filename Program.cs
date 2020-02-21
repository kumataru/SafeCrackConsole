using System;
using SafeCracker;
using SafeCracker.SafeResponses;

namespace SafeCrackConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to safe cracker");

            digitSolve digit = new digitSolve();


            //           digit.digitValid();
            //
            //           digit.finalAnswer();
            digit.numberCorrect();
            digit.finalAnswer();

        }

    }

    /*
    * function
    * 
    */
    class digitSolve
    {
        //public long safeKey = 0;
        public Safe safe = new Safe();



 


 //     public void digitValid()
 //     {
 //         int i = 0;
 //
 //         if (safe.IsOpen)
 //         {
 //             Console.WriteLine("You already solved it!");
 //         }
 //         else
 //         {
 //             Console.WriteLine("Let's crack some safes.");        //debug print, I know it gets into this loop
 //
 //             string fmt = "000000000";
 //             int firstAttempt = 000000000;   //if "000000000" returns 0 correct never use 0 again
 //             //Console.WriteLine(firstAttempt.ToString(fmt));
 //             Response firstResp = safe.Attempt(firstAttempt.ToString(fmt));
 //             if (firstResp.Type == ResponseType.Valid)
 //             {
 //                 ValidResponse checkCorrect = (ValidResponse)firstResp;
 //                 if (checkCorrect.CorrectDigits >= 1)    //zeros okay
 //                 {
 //                     for (int digit = 9; digit >= 0; digit--)        //increment through digits
 //                     {
 //                         for (long curDig = 000000000; curDig <= (9 * (long)Math.Pow(10, digit)); curDig += (1 * (long)Math.Pow(10, digit)))   //digit 9 use previous 8 digits + new digit x100000000
 //                         {
 //                             Console.WriteLine("Value of current digit: {0}", curDig);
 //
 //                             //change int i to string
 //                             //use it for saft attempt
 //                             //write that to console
 //                             Console.WriteLine(i);
 //                             i++;
 //                             
 //                             Response resp = safe.Attempt(curDig.ToString(fmt));
 //                             if (resp.Type == ResponseType.Valid)
 //                             {
 //                                 ValidResponse checkCorrect1 = (ValidResponse)resp;
 //                                 if (checkCorrect1.CorrectDigits >= 2)
 //                                 {
 //                                     safeKey += curDig;
 //                                     Console.WriteLine("Value of safeKey: {0}", safeKey);
 //                                     break;
 //                                 }
 //                             }
 //
 //
 //                         }
 //                     }
 //                 }
 //                 else        //no zeros
 //                 {
 //                     /*curdig starts at 0
 //                     * digit value is <= 9 * (10 ^ digit - 1)
 //                     * digit value increments by 1 * (10 ^ digit - 1) 
 //                     */
 //                     for (int digit = 9; digit >= 0; digit--)        //increment through digits
 //                     {
 //                         for (long curDig = 000000001; curDig <= (9 * (long)Math.Pow(10, digit)); curDig += (1 * (long)Math.Pow(10, digit)))   //digit 9 use previous 8 digits + new digit x100000000
 //                         {
 //                             Console.WriteLine("Value of current digit: {0}", curDig);
 //
 //                             //change int i to string
 //                             //use it for saft attempt
 //                             //write that to console
 //
 //
 //
 //                             Response resp = safe.Attempt(curDig.ToString(fmt));
 //                             if (resp.Type == ResponseType.Valid)
 //                             {
 //                                 ValidResponse checkCorrect2 = (ValidResponse)resp;
 //                                 if (checkCorrect2.CorrectDigits >= 1)
 //                                 {
 //                                     safeKey += curDig;
 //                                     Console.WriteLine("Value of safeKey: {0}", safeKey);
 //                                     break;
 //                                 }
 //                             }
 //                         }
 //                     }
 //                 }
 //             }
 //
 //
 //
 //         }
 //
 //     }





        public void finalAnswer()
        {
            //string fmt = "000000000";

            string result = string.Join("", safeKey);
            Response solved = safe.Attempt(result);

            if (safe.IsOpen)
            {
                Console.WriteLine();
                Console.WriteLine("The final safe key is {0}", safeKey);
                
                if (1 == 1)
                {
                    SuccessResponse gitErDone = (SuccessResponse)solved;
                    Console.WriteLine(gitErDone.Attempts);
                }
                Console.WriteLine("Safe was successfully opened.");
            }
            else
            {
 //             safeKey = 0;
 //             digitValid();
            }


        }


        //fill valid number array
        int[] numValid = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//need 1d array to store #valid
        int[] safeKey = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        bool[] digitFound = { false, false, false, false, false, false, false, false, false };
        //need 2d array to store value of digit in safe key


        public void numberCorrect()      //check each possible number on all digits and set flags if number is used
        {
            //string fmt = "000000000";
            long allDigit = 0;      //stores value of answer

            //should use 10 guess

   //         for (int digit = 9; digit >= 0; digit--)        //increment through digits
   //         {
   //             for (long curDig = 000000000; curDig <= (9 * (long)Math.Pow(10, digit)); curDig += (1 * (long)Math.Pow(10, digit)))
   //             {
   //                 Console.WriteLine("Value of current digit is {000000000}", curDig);
   //                 //Console.WriteLine("Value of alldigit is {000000000}", allDigit);
   //                 allDigit += (digit * curDig);
   //             }
   //
   //         }


            for (int k = 0; k < 10; k++)        //0-9         //decrement value, so now test 8xx,xxx,xxx
            {
                //Console.WriteLine("Current test value is {0}", k);
                //decrement through numbers that have valid responses
                //else write value such as 9xx,xxx,xxx and test if valid, going digit by digit, x9x,xxx,xxx , xx9,xxx,xxx do this until all flags have been filled.
                while (numValid[k] > 0)//if digit  has no valid numbers skip it when testing and use value from safekey e.g. 945,{#}x2,x33
                {
                    int[] testKey = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int arrayFill = 0; arrayFill > 0; arrayFill++)
                    {
                        testKey[arrayFill] = k;
                        Console.WriteLine(testKey[k]);
                    }


                    /*
                    //do all current digit except 1 is current digit -1
                    //move x-1 through digits e.g. 8999 -> 9899 -> 9989 -> 9998
                    for (int j = 0; j < 9; j++)
                    {
                        testKey[j] = k - 1;     //create an array for testKey
                                                //if #correct is lower than previous #correct store value in the previous digit/slot

                        //convert testKey array to string
                        string testResult = string.Join("", testKey);
                        Response resp = safe.Attempt(result);
                        if (resp.Type == ResponseType.Valid)
                        {
                            ValidResponse checkCorrect2 = (ValidResponse)resp;
                        }
                    }
                }
                */

                /*
                string result = string.Join("", allDigit);
                Response resp = safe.Attempt(allDigit.ToString(fmt));
                if (resp.Type == ResponseType.Valid)
                {
                    ValidResponse checkCorrectMax = (ValidResponse)resp;
                    if (checkCorrectMax.CorrectDigits >= 1)           //This value has some correct digits
                    {
                        switch (digit)       //Sets flags of correct values for each digit
                        {
                            case 0:
                                numValid[0] = checkCorrectMax.CorrectDigits;
                                break;
                            case 1:
                                numValid[1] = checkCorrectMax.CorrectDigits;
                                break;
                            case 2:
                                numValid[2] = checkCorrectMax.CorrectDigits;
                                break;
                            case 3:
                                numValid[3] = checkCorrectMax.CorrectDigits;
                                break;
                            case 4:
                                numValid[4] = checkCorrectMax.CorrectDigits;
                                break;
                            case 5:
                                numValid[5] = checkCorrectMax.CorrectDigits;
                                break;
                            case 6:
                                numValid[6] = checkCorrectMax.CorrectDigits;
                                break;
                            case 7:
                                numValid[7] = checkCorrectMax.CorrectDigits;
                                break;
                            case 8:
                                numValid[8] = checkCorrectMax.CorrectDigits;
                                break;
                            case 9:
                                numValid[9] = checkCorrectMax.CorrectDigits;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (digit)       //Sets flags of correct values for each digit
                        {
                            case 0:
                                numValid[0] = 0;
                                break;
                            case 1:
                                numValid[1] = 0;
                                break;
                            case 2:
                                numValid[2] = 0;
                                break;
                            case 3:
                                numValid[3] = 0;
                                break;
                            case 4:
                                numValid[4] = 0;
                                break;
                            case 5:
                                numValid[5] = 0;
                                break;
                            case 6:
                                numValid[6] = 0;
                                break;
                            case 7:
                                numValid[7] = 0;
                                break;
                            case 8:
                                numValid[8] = 0;
                                break;
                            case 9:
                                numValid[9] = 0;
                                break;
                            default:
                                break;
                        }
                    }
                    Console.WriteLine("numValid[9] = {0}", numValid[9]);
                    Console.WriteLine("numValid[8] = {0}", numValid[8]);
                    Console.WriteLine("numValid[7] = {0}", numValid[7]);
                    Console.WriteLine("numValid[6] = {0}", numValid[6]);
                    Console.WriteLine("numValid[5] = {0}", numValid[5]);
                    Console.WriteLine("numValid[4] = {0}", numValid[4]);
                    Console.WriteLine("numValid[3] = {0}", numValid[3]);
                    Console.WriteLine("numValid[2] = {0}", numValid[2]);
                    Console.WriteLine("numValid[1] = {0}", numValid[1]);
                    Console.WriteLine("numValid[0] = {0}", numValid[0]);
                    */
                }
            }
        }

    }
}


