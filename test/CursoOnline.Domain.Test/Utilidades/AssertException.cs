using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Domain.Test.Utilidades
{
    public static class AssertException
    {
        public static void ValidarMensagem(this ArgumentException argumentException, string mensagemErro)
        {
            if (argumentException.Message == mensagemErro)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"A mensagem esperada é {mensagemErro}");
            }
        }
    }
}
