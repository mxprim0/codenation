using System;
using System.Collections.Generic;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            throw new NotImplementedException();
        }

        public void SetCaptain(long playerId)
        {
            throw new NotImplementedException();
        }

        public long GetTeamCaptain(long teamId)
        {
            throw new NotImplementedException();
        }

        public string GetPlayerName(long playerId)
        {
            throw new NotImplementedException();
        }

        public string GetTeamName(long teamId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            throw new NotImplementedException();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTeams()
        {
            throw new NotImplementedException();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTopPlayers(int top)
        {
            throw new NotImplementedException();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            throw new NotImplementedException();
        }

    }
}
