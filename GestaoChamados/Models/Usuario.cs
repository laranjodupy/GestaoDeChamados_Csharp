using GestaoChamados.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoChamados.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public Papel Papel { get; set; }
    }
}
