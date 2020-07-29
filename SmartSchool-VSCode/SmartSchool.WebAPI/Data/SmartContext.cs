using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) {}
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {   
            //quando estiver criando o banco de dados esse metodo vai ser executado
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new {AD.AlunoId, AD.DisciplinaId}); //dado AlunoDisciplina para o AlunoId está para o DisciplinaId
        }
    }
}