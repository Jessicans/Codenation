using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        List<Team> Teams = new List<Team>();
        List<Player> Players = new List<Player>();

        public SoccerTeamsManager()
        {

        }
        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
           
            Team team = new Team();//instanciei o objeto da classe Team
            team.Id = id;
            team.Name = name;
            team.DataCriacao = createDate;
            team.CorUniformePrincipal = mainShirtColor;
            team.CorUniformeSecundario = secondaryShirtColor;

            if (Teams.Any(t=>t.Id==team.Id))
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
            }
            else
            {
                Teams.Add(team);//adiciona time          
            }
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {

            Player player = new Player();
            Team team = new Team();

            player.Id = id;
            player.TeamId = teamId;
            player.Name = name;
            player.BirthDate = birthDate;
            player.SkillLevel = skillLevel;
            player.Salary = salary;

            if (!Players.Contains(player))
            {
                Players.Add(player);//adiciona jogador   
            }
            else
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
            }
            if (Teams.Contains(team))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }
        }

        public void SetCaptain(long playerId)
        {

            var jogador = Players.Find(p => p.Id == playerId);
            if (jogador == null)
            {
                throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
            }
            var jogadorc = Players.Find(t => t.Id == playerId);
            jogadorc.Capitao = jogadorc.Id == playerId;

        }
        public long GetTeamCaptain(long teamId)
        {
            var time = Teams.Find(t => t.Id == teamId);
            if (time == null)
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();

            foreach (Player player in Players)
            {
                if (player.Capitao)
                {
                    return player.Id;
                }
            }

            throw new Codenation.Challenge.Exceptions.CaptainNotFoundException();

        }

        public string GetPlayerName(long playerId)
        {
            foreach (Player jogador in Players)
            {
                if (jogador.Id == playerId)
                {
                    return jogador.Name;
                }
            }
            throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
        }

        public string GetTeamName(long teamId)
        {
            foreach (Team time in Teams)
            {

                if (time.Id == teamId)
                {
                    return time.Name;
                }
            }
            throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            var time = Teams.Find(t => t.Id == teamId);
            if (time == null)
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();

            List<long> ListaId = Players.OrderBy(p => p.Id)
              .Select(p => p.Id).ToList();

            return ListaId;
        }
        public long GetBestTeamPlayer(long teamId)
        {
            var time = Teams.Find(t => t.Id == teamId);
            if (time == null)
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();

            return Players.OrderByDescending(p => p.SkillLevel).ThenBy(p => p.Id).First().Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            var jogadorvelho = Players.Find(jv => jv.TeamId == teamId);
            if (jogadorvelho == null)
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();

            return Players.OrderBy(jv => jv.BirthDate).Select(jv => jv.Id).First();
        }

        public List<long> GetTeams()
        {
            List<long> ListaId = Teams.OrderBy(t => t.Id).Select(p => p.Id).ToList();
            if (ListaId == null)
            {
                return ListaId = null;
            }
            return ListaId;

        }
        public long GetHigherSalaryPlayer(long teamId)
        {
            var salariojogador = Players.Find(sj => sj.TeamId == teamId);
            if (salariojogador == null)
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();

            return Players.OrderByDescending(sj => sj.Salary).ThenBy(sj => sj.Id).Select(jv => jv.Id).First();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            foreach (Player jogador in Players)
            {
                if (jogador.Id == playerId)
                {
                    return jogador.Salary;
                }
            }
            throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
        }

        public List<long> GetTopPlayers(int top)
        {
            List<long> ListaTop = Players.OrderByDescending(j => j.SkillLevel)
                .ThenBy(j => j.Id).Take(top).Select(j => j.Id).ToList();

            if (ListaTop == null)
            {
                return ListaTop = null;
            }
            return ListaTop;
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            var timecasa = Teams.Find(t => t.Id == teamId);
            if (timecasa == null)
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();

            var visitacasa = Teams.Find(t => t.Id == visitorTeamId);
            if (visitacasa == null)
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();

            if (timecasa.CorUniformePrincipal == visitacasa.CorUniformePrincipal)
            {
                return visitacasa.CorUniformeSecundario;
            }
            else
            {
                return visitacasa.CorUniformePrincipal;
            }


        }
    }
}