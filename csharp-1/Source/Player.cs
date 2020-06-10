using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Codenation.Challenge
{
    public class Player
    {
        public long id;
        public string name;
        public DateTime birthDate;
        public int skillLevel;
        public decimal salary;

        public Player(long id, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.skillLevel = skillLevel;
            this.salary = salary;
        }
    }
}