using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Codenation.Challenge
{
    public class Team
    {
        public List<Player> Players;
        public long id;
        public string name;
        public DateTime createData;
        public string mainShirtColor;
        public string secondaryShirtColor;
        public long captain;

        public Team(long id, string name, DateTime createData, 
                    string mainShirtColor, string secondaryShirtColor)
        {
            Players = new List<Player>();
            this.id = id;
            this.name = name;
            this.createData = createData;
            this.mainShirtColor = mainShirtColor;
            this.secondaryShirtColor = secondaryShirtColor;
        }
    }
}