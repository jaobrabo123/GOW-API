using System;
using System.Collections.Generic;

namespace GOW_API.Models
{
    public partial class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Jogoid { get; set; }
        public string? Descricao { get; set; }

        public virtual Jogo Jogo { get; set; } = null!;
    }
}
