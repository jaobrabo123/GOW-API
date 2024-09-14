using System;
using System.Collections.Generic;

namespace GOW_API.Models
{
    public partial class Jogo
    {
        public Jogo()
        {
            Armas = new HashSet<Arma>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime Lancamento { get; set; }

        public virtual ICollection<Arma> Armas { get; set; }
    }
}
