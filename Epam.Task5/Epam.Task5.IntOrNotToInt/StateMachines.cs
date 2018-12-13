using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.IntOrNotToInt
{
    public static class StateMachines
    {
        public static bool IsInteger(string str)
        {
            int currentSymbol = 0;
            int mantissa = 0;
            int order = 0;
            int orderValue = 0;
            int state = 0;
            const int FaultState = 101;
            do
            {
                switch (state)
                {
                    case 0:
                        if (char.IsDigit(str[currentSymbol]) || str[currentSymbol] == '+')
                        {
                            if (currentSymbol == 0)
                            {
                                state = 1;
                            }
                            else
                            {
                                if (char.IsDigit(str[currentSymbol]))
                                {
                                    orderValue += str[currentSymbol] - 48;
                                } 

                                state = 3;
                            }
                        }
                        else
                        {
                            state = FaultState;
                        }

                        break;
                    case 1:
                        if (str[currentSymbol] == '.')
                        {
                            state = 2;
                        }
                        else if (!char.IsDigit(str[currentSymbol]))
                        {
                            state = FaultState;
                        }

                        break;
                    case 2:
                        {
                            if (str[currentSymbol] == 'E' || str[currentSymbol] == 'e')
                            {
                                state = 0;
                            }
                            else if (char.IsDigit(str[currentSymbol]))
                            {
                                mantissa++;
                            }
                            else
                            {
                                state = FaultState;
                            }
                        }

                        break;
                    case 3:
                        {
                           if (char.IsDigit(str[currentSymbol]))
                            {
                                order++;
                                orderValue += str[currentSymbol] - 48;
                            }
                            else
                            {
                                state = FaultState;
                            }
                        }

                        break;
                    case 101:
                        return false;
                }

                currentSymbol++;
            }
            while (currentSymbol < str.Length);
            if (mantissa < orderValue || mantissa == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
