using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{

    public class Country
    {
        public List<string> estados = new List<string>()
        {
            "AC;Acre;164123,040",
            "AL;Alagoas;27778,506",
            "AP;Amapa;142828,521",
            "AM;Amazonas;1559159,148",
            "BA;Bahia;564773,177",
            "CE;Ceara;148920,472",
            "DF;Distrito Federal;5779,999",
            "ES;Espirito Santo;46095,583",
            "GO;Goias;340111,783",
            "MA;Maranhao;331937,450",
            "MT;Mato Grosso;903366,192",
            "MS;Mato Grosso do Sul;357145,532",
            "MG;Minas Gerais;586522.122",
            "PA;Para;1247954,666",
            "PB;Paraiba;56585,000",
            "PR;Parana;199307,922",
            "PE;Pernambuco;98311,616",
            "PI;Piaui;251577,738",
            "RJ;Rio de Janeiro;43780,172",
            "RN;Rio Grande do Norte;52811,047",
            "RS;Rio Grande do Sul;281730,223",
            "RO;Rondonia;237590,547",
            "RR;Roraima;224300,506",
            "SC;Santa Catarina;95736,165",
            "SP;Sao Paulo;248222,362",
            "SE;Sergipe;21915,116",
            "TO;Tocantins;277720,520",
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
            double stateArea = 0;

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
                            stateArea = double.Parse(RemoveWhiteSpace(tempState[i].Replace(',', ' ')));
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