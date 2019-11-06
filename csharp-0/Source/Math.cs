using System;
using System.Collections.Generic;
using Codenation.Challenge;
using Math = Codenation.Challenge.Math;

namespace Codenation.Challenge
{
    public class Math //classe math (matemática)
    {
        public List<int> Fibonacci()//metodo retorna lista de num inteiros de sequencia de fibonacci até 350
        {
            int t1 = 0;
            int t2 = 1;
            int t3 = t1 + t2;


            List<int> listaInt = new List<int>();//Cria uma lista vazia
            listaInt.Add(0);//0
            listaInt.Add(1);//1

            while (t3 < 350)
            {
                t3 = t1 + t2;
                t1 = t2; ;
                t2 = t3;
                
                listaInt.Add(t3);
            }
            return listaInt;
        }

        public bool IsFibonacci(int numberToTest)//metodo condicional
        {
            List<int> listaInt = Fibonacci();

            if (listaInt.Contains(numberToTest))
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




