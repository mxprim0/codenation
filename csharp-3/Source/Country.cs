using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Country
    {
        public State[] Top10StatesByArea()
        {
            string[,] BrazilianStates = {

                {"AC","Acre","164123,040"},
                {"AL","Alagoas","27778,506"},
                {"AP","Amapá","142828,521"},
                {"AM","Amazonas","1559159,148"},
                {"BA","Bahia","564773,177"},
                {"CE","Ceará","148920,472"},
                {"DF","Distrito Federal","5779,999"},
                {"ES","Espírito Santo","46095,583"},
                {"GO","Goiás","340111,783"},
                {"MA","Maranhão","331937,450"},
                {"MT","Mato Grosso","903366,192"},
                {"MS","Mato Grosso do Sul","357145,532"},
                {"MG","Minas Gerais","586522.122"},
                {"PA","Pará","1247954,666"},
                {"PB","Paraíba","56585,000"},
                {"PR","Paraná","199307,922"},
                {"PE","Pernambuco","98311,616"},
                {"PI","Piauí","251577,738"},
                {"RJ","Rio de Janeiro","43780,172"},
                {"RN","Rio Grande do Norte","52811,047"},
                {"RS","Rio Grande do Sul","281730,223"},
                {"RO","Rondônia","237590,547"},
                {"RR","Roraima","224300,506"},
                {"SC","Santa Catarina","95736,165"},
                {"SP","São Paulo","248222,362"},
                {"SE","Sergipe","21915,116"},
                {"TO","Tocantins","277720,520"},

            };

            int states = (BrazilianStates.Length / BrazilianStates.GetLength(1));

            for (int a = 0; a < states; a++)
            {
                for (int b = a + 1; b < states; b++)
                {
                    if (Convert.ToDouble(BrazilianStates[b, BrazilianStates.Rank]) > 
                       (Convert.ToDouble(BrazilianStates[a, BrazilianStates.Rank])))
                    {
                        for (int c = 0; c <= BrazilianStates.Rank; c++)
                        {
                            string[,] aux = { { "", "", ""} };
                            aux[0, c] = BrazilianStates[a, c];
                            BrazilianStates[a, c] = BrazilianStates[b, c];
                            BrazilianStates[b, c] = aux[0, c];
                        }
                        Convert.ToString(BrazilianStates);

                    }
                }
            }
            State[] ArrayBrazilianStates =
            {
                new State(BrazilianStates[0, 1], BrazilianStates[0,0]),
                new State(BrazilianStates[1, 1], BrazilianStates[1,0]),
                new State(BrazilianStates[2, 1], BrazilianStates[2,0]),
                new State(BrazilianStates[3, 1], BrazilianStates[3,0]),
                new State(BrazilianStates[4, 1], BrazilianStates[4,0]),
                new State(BrazilianStates[5, 1], BrazilianStates[5,0]),
                new State(BrazilianStates[6, 1], BrazilianStates[6,0]),
                new State(BrazilianStates[7, 1], BrazilianStates[7,0]),
                new State(BrazilianStates[8, 1], BrazilianStates[8,0]),
                new State(BrazilianStates[9, 1], BrazilianStates[9,0]),
            };
            return ArrayBrazilianStates;

        }
    }
}
