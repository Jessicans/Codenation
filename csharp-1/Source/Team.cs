using System;
using System.Collections.Generic;
using System.Text;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CorUniformePrincipal { get; set; }
        public string CorUniformeSecundario { get; set; }
        //public long Capitao { get; set; }
        public long VisitorTeamId { get; set; }
        
    }
}
