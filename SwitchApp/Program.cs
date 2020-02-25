using Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;
using SwitchApp.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SwitchApp
{
    class Program
    {
        const string conn = "Server=LAPTOP-2890B0QV;Database=SwitchDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        static void Main(string[] args)
        {
            //SetUser();
            //Linq();
            //Linq2();
            //ChangeTracker();
            //RemoveData();
            //Pk();
            //EagerLoading();
            //AddInstanciaRelacionada();
            //UpdateInstanciaRelacionada();
            //DeleteInstanciaRelacionada();
            //CommandSQL();
            //ProjecaoQuery();
            //ParametrizacaoQueries();
            //StorageProcedure();
            //StorageProcedureComParametros();
            StorageProcedureComParametrosDTO();

            Console.ReadKey();
        }

        static void SetUser()
        {
            Usuario usuario1;
            Usuario usuario2;
            Usuario usuario3;
            Usuario usuario4;
            Usuario usuario5;
            Usuario usuario6;

            Usuario CriarUsuario(string nome)
            {
                return new Usuario()
                {
                    Nome = "Usuario 1",
                    SobreNome = "SobreNomeUsuario",
                    Email = "usuario@teste.com.br",
                    Senha = "123",
                    Sexo = Switch.Domain.Enums.SexoEnum.Masculino,
                    DataNascimento = DateTime.Now,
                    UrlFoto = "teste"
                };
            }

            usuario1 = CriarUsuario("usuario1");
            usuario2 = CriarUsuario("usuario2");
            usuario3 = CriarUsuario("usuario3");
            usuario4 = CriarUsuario("usuario4");
            usuario5 = CriarUsuario("usuario5");
            usuario6 = CriarUsuario("usuario6");

            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    dbcontext.Usuarios.AddRange(usuario1, usuario2, usuario3, usuario4);
                    ////dbcontext.Usuarios.Add(usuario1);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Ok!");
            
        }

        static void Linq()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    //var user = dbcontext.Usuarios.ToList();

                    var user = dbcontext.Usuarios.Where(u => u.Nome == "Usuario 1");

                    //var usuarios = (from u in dbcontext.Usuarios
                    //                select u).ToList();

                    //var user1 = (from u in dbcontext.Usuarios
                    //             where u.Nome == "Usuario 1"
                    //             select u).ToList();

                    // first = primeiro item de uma relação
                    // ideais para quando existe dados duplicados no banco, ai vc traz o primeiro

                    // firstordefault = me devolve o primeiro elemento na base ou me retorna nulo

                    // single = procura se existe uma unica ocorrencia do parâmetro informado
                    // pode disparar um erro se encontrar registros duplicados

                    // last = é o oposto do first... pode ter impacto na performance

                    // find = pesquina na base caso saiba o Id 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Linq2()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    //dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    var usuarioNovo = CriarUsuario("usuarioNovo1");
                    dbcontext.Usuarios.Add(usuarioNovo);
                    dbcontext.SaveChanges();

                    // retorna uma estancia da entidade Usuario

                    //var usuarioRetorno = dbcontext.Usuarios.Where(u => u.Nome == "usuarioNovo1").First();
                    // ou
                    var usuarioRetorno = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuarioNovo1");

                    if (usuarioRetorno == null)
                        Console.WriteLine("Usuário não encontrado!");
                    else
                        Console.WriteLine("Nome do novo usuário é: " + usuarioRetorno.Nome);

                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void ChangeTracker()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    //dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    var usuarioNovo = CriarUsuario("usuarioNovo1");
                    Console.WriteLine("Criando novo usuario...");
                    Console.WriteLine("Verificando o ChangeTracker de usuaruio...");
                    dbcontext.Usuarios.Add(usuarioNovo);
                    ExibirChangeTracker(dbcontext.ChangeTracker);


                    //dbcontext.Usuarios.Add(usuarioNovo);
                    //dbcontext.SaveChanges();

                    //// retorna uma estancia da entidade Usuario

                    ////var usuarioRetorno = dbcontext.Usuarios.Where(u => u.Nome == "usuarioNovo1").First();
                    //// ou
                    //var usuarioRetorno = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuarioNovo1");

                    //if (usuarioRetorno == null)
                    //    Console.WriteLine("Usuário não encontrado!");
                    //else
                    //    Console.WriteLine("Nome do novo usuário é: " + usuarioRetorno.Nome);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void RemoveData()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    //dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    //var usuario123 = CriarUsuario("usuario123");
                    //var usuario124 = CriarUsuario("usuario123");

                    //dbcontext.Usuarios.AddRange(usuario123, usuario124);
                    //dbcontext.SaveChanges();

                    
                    var usuario = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuario123");

                    dbcontext.Usuarios.Remove(usuario);
                    dbcontext.SaveChanges();

                    var totalUsuarios = dbcontext.Usuarios.Count(u => u.Nome == "usuario123");
                    Console.WriteLine($"Total de usuarios é: {totalUsuarios}");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Pk()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    //var user = CriarUsuario("userFilipe");
                    //Console.WriteLine($"Id do novo usuario = {user.Id}");
                    //Console.ReadKey();

                    //dbcontext.Usuarios.Add(user);
                    //Console.WriteLine($"Id do novo usuario = {user.Id}");
                    //Console.ReadKey();

                    //dbcontext.SaveChanges();
                    //Console.WriteLine($"Id do novo usuario = {user.Id}");
                    //Console.ReadKey();

                    var user = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "userFilipe");
                    user.Senha = "abc123";

                    // realiza o update em todas as tabelas da entidade
                    dbcontext.Update<Usuario>(user); 

                    dbcontext.SaveChanges();
                    

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void EagerLoading()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    //dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    var instituicao = dbcontext.InstituicoesEnsino.FirstOrDefault();
                    var usuario = instituicao.Usuario;

                    // o include pede para que carregue os usuarios para cada instituicao de ensino
                    // funciona como o inner join
                    var instituicao1 = dbcontext.InstituicoesEnsino.Include(i => i.Usuario).FirstOrDefault();
                    var usuario1 = instituicao.Usuario;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void AddInstanciaRelacionada()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    //dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    var userMaria = CriarUsuario("Maria");

                    userMaria.InstituicoesEnsino.Add(new InstituicaoEnsino()
                    {
                         Nome = "Faculdade Pitagoras"                         
                    });

                    dbcontext.Usuarios.Add(userMaria);
                    dbcontext.SaveChanges();

                    Console.WriteLine($"Usuário {userMaria.Nome} cadastrado!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void UpdateInstanciaRelacionada()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    //dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    var userMaria = dbcontext.Usuarios.Include(i => i.InstituicoesEnsino).FirstOrDefault(u => u.Nome == "Maria");
                    //userMaria.InstituicoesEnsino.Add(new InstituicaoEnsino() { Nome = "Faculdade Fabrai" });
                    //userMaria.InstituicoesEnsino.Add(new InstituicaoEnsino() { Nome = "Faculdade Anhanguera" });

                    var instituicao = userMaria.InstituicoesEnsino.FirstOrDefault(i => i.Nome.Contains("Faculdade Fabrai"));
                    instituicao.Nome = "PUC MG";

                    // como é uma atualização em um usuario ja criado, não é necessário o dbcontext.usuarios.add();
                    dbcontext.SaveChanges();

                    Console.WriteLine($"Usuário '{userMaria.Nome}' atualizado!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void DeleteInstanciaRelacionada()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // carrega o logger da transação solicitada
                    //dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    // este usuario tem 3 instituicoes de ensino... vamos apagar somente uma.
                    var userMaria = dbcontext.Usuarios.Include(i => i.InstituicoesEnsino).FirstOrDefault(u => u.Nome == "Maria");

                    var instiuicao = userMaria.InstituicoesEnsino.FirstOrDefault(i => i.Nome == "PUC MG");

                    //não precisa chamar o dbcontext.instituicoes pois o user maria ja é representação do que existe neste dbcontext
                    userMaria.InstituicoesEnsino.Remove(instiuicao);

                    // como é uma atualização em um usuario ja criado, não é necessário o dbcontext.usuarios.add();
                    dbcontext.SaveChanges();

                    Console.WriteLine("Instituição removida!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CommandSQL()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    // se for declarar o comanando para trazer determinadas colunas, 
                    // o EF Core vai exigir que informe todos os nomes de colunas que exista na tabela
                    // nesse caso é melhor usar o 'select * from...'

                    //var command = "select Id, nome, sobrenome from usuarios;";

                    var command = "select * from usuarios;";
                    var usuario = dbcontext.Usuarios.FromSql(command).ToList();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ProjecaoQuery()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            //optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    var sqlCommand = "select nome, sobrenome from usuarios";
                    var connection = dbcontext.Database.GetDbConnection();

                    using(var command = connection.CreateCommand())
                    {
                        connection.Open();
                        command.CommandText = sqlCommand;
                        var listaUsuarios = new List<UsuarioDTO>();

                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // obtendo dados de cada linha
                                    listaUsuarios.Add(new UsuarioDTO() {
                                        Nome = dataReader["nome"].ToString(),
                                        SobreNome = dataReader["sobrenome"].ToString()
                                    });
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ParametrizacaoQueries()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            //optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    var filtroPesquisa = "Maria"; //"' or 1='1";
                    //var sqlCommand = $"select nome, sobrenome from usuarios where nome = '{filtroPesquisa}'";
                    var sqlCommand = $"select nome, sobrenome from usuarios where nome = @nomeUsuario";
                    var connection = dbcontext.Database.GetDbConnection();

                    using (var command = connection.CreateCommand())
                    {
                        connection.Open();
                        command.CommandText = sqlCommand;

                        SqlParameter param = new SqlParameter("@nomeUsuario", System.Data.SqlDbType.VarChar);
                        param.Value = filtroPesquisa;
                        command.Parameters.Add(param);
                             
                        var listaUsuarios = new List<UsuarioDTO>();

                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // obtendo dados de cada linha
                                    listaUsuarios.Add(new UsuarioDTO()
                                    {
                                        Nome = dataReader["nome"].ToString(),
                                        SobreNome = dataReader["sobrenome"].ToString()
                                    });
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void StorageProcedure()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            //optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    var connection = dbcontext.Database.GetDbConnection();

                    using (var command = connection.CreateCommand())
                    {
                        connection.Open();
                        command.CommandText = "exec sp_GetAllUsers";
                        var listaUsuarios = new List<UsuarioDTO>();

                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // obtendo dados de cada linha
                                    listaUsuarios.Add(new UsuarioDTO()
                                    {
                                        Nome = dataReader["nome"].ToString(),
                                        SobreNome = dataReader["sobrenome"].ToString()
                                    });
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void StorageProcedureComParametros()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));
            //optionsBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    var connection = dbcontext.Database.GetDbConnection();

                    using (var command = connection.CreateCommand())
                    {
                        connection.Open();
                        command.CommandText = "exec sp_GetUserById @usuarioId";
                        SqlParameter param = new SqlParameter("@usuarioId", System.Data.SqlDbType.Int);
                        param.Value = 5;

                        command.Parameters.Add(param);

                        var listaUsuarios = new List<UsuarioDTO>();

                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // obtendo dados de cada linha
                                    listaUsuarios.Add(new UsuarioDTO()
                                    {
                                        Nome = dataReader["nome"].ToString(),
                                        SobreNome = dataReader["sobrenome"].ToString()
                                    });
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void StorageProcedureComParametrosDTO()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseSqlServer(conn, m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    var connection = dbcontext.Database.GetDbConnection();

                    using (var command = connection.CreateCommand())
                    {
                        connection.Open();
                        command.CommandText = "exec sp_GetUsersByInstituicoesEnsino";

                        var listUsuarioInstiuicaoEnsino = new List<UsuarioInstituicaoEnsinoDTO>();

                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // obtendo dados de cada linha
                                    listUsuarioInstiuicaoEnsino.Add(new UsuarioInstituicaoEnsinoDTO()
                                    {
                                        NomeUsuario = dataReader["NomeUsuario"].ToString(),
                                        SobreNomeUsuario = dataReader["SobreNomeUsuario"].ToString(),
                                        NomeInstituicao = dataReader["NomeInstituicao"].ToString()
                                    });
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Usuario CriarUsuario(string nome)
        {
            return new Usuario()
            {
                Nome = nome,
                SobreNome = "SobreNomeUsuario",
                Email = "usuario@teste.com.br",
                Senha = "123",
                Sexo = Switch.Domain.Enums.SexoEnum.Masculino,
                DataNascimento = DateTime.Now,
                UrlFoto = @"c:\temp"
            };
        }

        public static void ExibirChangeTracker(ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                Console.WriteLine("Nome da Entidade: " + entry.Entity.GetType().FullName);
                Console.WriteLine("Status da Entidade: " + entry.State);
                Console.WriteLine("------------------");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

