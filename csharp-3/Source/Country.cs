using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{

    public class Country
    {
        public List<string> estados = new List<string>()
        {
            "Acre; AC; 164123,040",
            "Alagoas; AL; 27778,506",
            "Amapa; AP; 142828,521",
            "Amazonas; AM; 1559159,148",
            "Bahia; BA; 564773,177",
            "Ceara; CE; 148920,472",
            "Distrito Federal, DF; 5779,999",
            "Espirito Santo; ES; 46095,583",
            "Goias; GO; 340111,783",
            "Maranhao; MA; 331937,450",
            "Mato Grosso; MT; 903366,192",
            "Mato Grosso do Sul; MS; 357145,532",
            "Minas Gerais; MG; 586522.122",
            "Para, PA; 1247954,666",
            "Paraiba, PB, 56585,000",
            "Parana, PR, 199307,922",
            "Pernambuco; PE; 98311,616",
            "Piaui; PI; 251577,738",
            "Rio de Janeiro, RJ, 43780,172",
            "Rio Grande do Norte; RN; 52811,047",
            "Rio Grande do Sul; RS; 281730,223",
            "Rondonia; RO; 237590,547",
            "Roraima; RR; 224300,506",
            "Santa Catarina; SC; 95736,165",
            "Sao Paulo; SP; 248222,362",
            "Sergipe; SE; 21915,116",
            "Tocantins, TO, 277720,520",
        };

        public State[] Top10StatesByArea()
        {
            var states = GetStates(estados);
            states = states.OrderByDescending(s => s.StateArea).Take(10).ToList();

            State[] brazilianStates = new State[10];

            for (int i = 0; i < states.Count; i++)
            {
                brazilianStates[i] = new State(states[i].StateName, states[i].StateAcronym);
            }
            return brazilianStates;
        }

        public List<ExtensionState> GetStates(List<string> list)
        {
            var extensionStateList = new List<ExtensionState>();
            string stateName = string.Empty;
            string stateAcronym = string.Empty;
            long stateArea = 0;

            foreach (var data in list)
            {
                var tempState = data.Split(';');
                for (int i = 0; i < tempState.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            stateAcronym = tempState[i];
                            break;

                        case 1:
                            stateName = tempState[i];
                            break;

                        case 2:
                            stateArea = long.Parse(RemoveWhiteSpace(tempState[i].Replace(',', ' ')));
                            break;
                        default:
                            break;
                    }
                }
                extensionStateList.Add(new ExtensionState(stateAcronym, stateName, stateArea));
            }
            return extensionStateList;

        }

        public string RemoveWhiteSpace(string stringObject)
        {
            string returnString = string.Empty;
            foreach (char ch in stringObject)
            {
                if (!Char.IsWhiteSpace(ch))
                    returnString += ch;
            }
            return returnString;
        }
    }
}


