using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> resultado = new List<int>();
            int num1 = 0;
            int num2 = 1;
            int soma = num1 + num2;

            resultado.Add(num1);
            resultado.Add(num2);

            while (soma <= 350)
            {
                resultado.Add(soma);

                num1 = num2;
                num2 = soma;

                soma = num1 + num2;
            }
            return resultado;
        }

        public bool IsFibonacci(int numberToTest)
        {
            if (numberToTest == 0 || numberToTest == 1)
            {
                return true;
            }

            int num1 = 0;
            int num2 = 1;
            int soma = num1 + num2;

            while (soma <= numberToTest)
            {
                if (numberToTest == soma)
                {
                    return true;
                }

                num1 = num2;
                num2 = soma;

                soma = num1 + num2;
            }
            return false;
        }
    }
}