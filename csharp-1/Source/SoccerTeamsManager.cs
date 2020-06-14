using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        public List<Team> teams = new List<Team>();
        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, 
                            string mainShirtColor, string secondaryShirtColor)
        {
            Team team = new Team(id, name, createDate, mainShirtColor, secondaryShirtColor);

            if (teams.Any(t => t.id == id))
            {
                throw new UniqueIdentifierException();
            }
            else
            {
                teams.Add(team);
            }
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, 
                              int skillLevel, decimal salary)
        {
            Player player = new Player(id, name, birthDate, skillLevel, salary);

            if (teams.Any(t => t.id == teamId))
            {
                if (!teams.Any(t => t.id == teamId && t.Players.Any(p => p.id == id)))
                {
                    teams.First(t => t.id == teamId).Players.Add(player);
                }
                else
                {
                    throw new UniqueIdentifierException();
                }
            }
            else
            {
                throw new TeamNotFoundException();
            }
        }

        public void SetCaptain(long playerId)
        {
            if (teams.Any(t => t.Players.Any(p => p.id == playerId)))
            {
                teams.First(t => t.Players.Any(p => p.id == playerId)).captain = playerId;
            }
            else
            {
                throw new PlayerNotFoundException();
            }
        }

        public long GetTeamCaptain(long teamId)
        {
            if (teams.Any(t => t.id == teamId))
            {
                if (teams.Any(t => t.id == teamId && t.captain != 0))
                {
                    return (long)teams.First(t => t.id == teamId).captain;
                }
                else
                {
                    throw new CaptainNotFoundException();
                }
            }
            else
            {
                throw new TeamNotFoundException();
            }
        }

        public string GetPlayerName(long playerId)
        {
            if (teams.Any(t => t.Players.Any(p => p.id == playerId)))
            {
                return teams.First(t => t.Players.Any(p => p.id == playerId))
                       .Players.First(p => p.id == playerId).name;
            }
            else
            {
                throw new PlayerNotFoundException();
            }
        }

        public string GetTeamName(long teamId)
        {
            if (teams.Any(t => t.id == teamId))
            {
                return teams.First(t => t.id == teamId).name;
            }
            else
            {
                throw new TeamNotFoundException();
            }
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (teams.Any(t => t.id == teamId))
            {
                return teams.First(t => t.id == teamId).Players.OrderBy
                                  (p => p.id).Select(p => p.id).ToList();
            }
            else
            {
                throw new TeamNotFoundException();
            }
              
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (teams.Any(t => t.id == teamId))
            {
                return teams.First(t => t.id == teamId).Players.First
                       (p => p.skillLevel == teams.First(t => t.id == teamId)
                       .Players.Max(p2 => p2.skillLevel)).id;
            }
            else
            {
                throw new TeamNotFoundException();
            }
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (teams.Any(t => t.id == teamId))
            {
                Player olderTeamPlayer = teams.FirstOrDefault(t => t.id == teamId).Players.OrderBy
                                         (p => p.birthDate).ThenBy(p => p.id).FirstOrDefault();
                if (olderTeamPlayer != null)
                    return olderTeamPlayer.id;
                else
                    throw new PlayerNotFoundException();                
            }
            else
            {
                throw new TeamNotFoundException();
            }
        }

        public List<long> GetTeams()
        {
            return teams.OrderBy(t => t.id).Select(t => t.id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (teams.Any(t => t.id == teamId))
            {
                Player higherSalaryPlayer = teams.FirstOrDefault(t => t.id == teamId)
                                            .Players.OrderByDescending(p => p.salary)
                                            .ThenBy(p => p.id).FirstOrDefault();
                if (higherSalaryPlayer != null)
                    return higherSalaryPlayer.id;
                else
                    throw new PlayerNotFoundException();
            }
            else
            {
                throw new TeamNotFoundException();
            }
        }

        public decimal GetPlayerSalary(long playerId)
        {
            if (teams.Any(t => t.Players.Any(p => p.id == playerId)))
            {
                return teams.First(t => t.Players.Any(p => p.id == playerId))
                       .Players.First(p => p.id == playerId).salary;
            }
            else
            {
                throw new PlayerNotFoundException();
            }
        }

        public List<long> GetTopPlayers(int top)
        {
            var players = new List<Player>();
            foreach (Team t in teams)
            {
                players.AddRange(t.Players);
            }
            return players.OrderByDescending(p => p.skillLevel)
                   .ThenBy(p => p.id).Take(top).Select(p => p.id).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if ((teams.Any(t => t.id == teamId)) && teams.Any(t => t.id == visitorTeamId))
            {
                if ((teams.First(t1 => t1.id == teamId).mainShirtColor) == 
                    (teams.First(t2 => t2.id == visitorTeamId).mainShirtColor))
                    return teams.First(t2 => t2.id == visitorTeamId).secondaryShirtColor;
                else
                    return teams.First(t2 => t2.id == visitorTeamId).mainShirtColor;
            }
            else
            {
                throw new TeamNotFoundException();
            }
        }

    }
}