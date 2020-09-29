using CursoOnline.Domain.Curso.Enum;
using CursoOnline.Domain.Curso;
using ExpectedObjects;
using System;
using Xunit;
using CursoOnline.Domain.Test.Utilidades;

namespace CursoOnline.Domain.Test.Cursos
{
    public class CursoTest
    {

        [Fact]
        public void CriarCurso_RetornaCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Curso de TI",
                CargaHorario = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)50,
            };

            var curso = new CursoOnline.Domain.Curso.Curso(cursoEsperado.Nome, cursoEsperado.CargaHorario, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeDoCursoVazioOuNulo_RetornArgumentException(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Curso de TI",
                CargaHorario = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)50
            };

            Assert.Throws<ArgumentException>(() => new CursoOnline.Domain.Curso.Curso(nomeInvalido, cursoEsperado.CargaHorario, cursoEsperado.PublicoAlvo, cursoEsperado.Valor));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void CargaHorariaMenorQue1_RetornaArgumentException(double cargaHorariaInvalida)
        {
            string mensagemErro = "Parametros inválidos!";

            var cursoEsperado = new
            {
                Nome = "Curso de TI",
                CargaHorario = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)50
            };

           Assert.Throws<ArgumentException>(()
                => new CursoOnline.Domain.Curso.Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ValidarMensagem(mensagemErro);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ValorDoCursoMenorQue1_RetornaArguemntException(double valorInvalido)
        {
            string mensagemErro = "Parametros inválidos!";

            var cursoEsperado = new
            {
                Nome = "Curso de TI",
                CargaHorario = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)50
            };

            Assert.Throws<ArgumentException>(() 
                => new CursoOnline.Domain.Curso.Curso(cursoEsperado.Nome, cursoEsperado.CargaHorario, cursoEsperado.PublicoAlvo, valorInvalido)).ValidarMensagem(mensagemErro);
        }

    }
}
