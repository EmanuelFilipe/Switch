using Switch.Domain.Enums;
using System;
using System.Collections.Generic;

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

        public virtual Identificacao Identificacao { get; set; }
        public virtual StatusRelacionamento StatusRelacionamento { get; set; }
        public virtual ProcurandoPor ProcurandoPor { get; set; }
        public virtual ICollection<Postagem> Postagens { get; set; } //= new List<Postagem>();
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; } //= new List<UsuarioGrupo>();
        public virtual ICollection<LocalTrabalho> LocaisTrabalho { get; set; } //= new List<LocalTrabalho>();
        public virtual ICollection<InstituicaoEnsino> InstituicoesEnsino { get; set; } //= new List<InstituicaoEnsino>();
        public virtual ICollection<Amigo> Amigos { get; set; } //= new List<Amigo>();
        public virtual ICollection<Comentario> Comentarios { get; set; } //= new List<Comentario>();

        public Usuario()
        {
            Postagens = new List<Postagem>();
            UsuarioGrupos = new List<UsuarioGrupo>();
            LocaisTrabalho = new List<LocalTrabalho>();
            InstituicoesEnsino = new List<InstituicaoEnsino>();
            Amigos = new List<Amigo>();
        }
    }
}
