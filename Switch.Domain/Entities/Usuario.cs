﻿using Switch.Domain.Enums;
using System;

namespace Switch.Domain.Entities
{
    public class Usuario
    {
        // como private somente uma outra classe neste arquivo ira alterar o Id, de forma externa nao vai ser possivel
        public int Id { get; private set; } 
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public string UrlFoto { get; set; }
        //public int MyProperty { get; set; }
        //public int MyProperty2 { get; set; }
    }
}
