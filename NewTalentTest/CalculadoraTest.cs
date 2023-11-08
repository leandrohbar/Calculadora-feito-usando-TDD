using NewTalent;
using System.ComponentModel.DataAnnotations;

namespace NewTalentTest
{
    public class CalculadoraTest
    {
        public Calculadora construirCalculadora()
        {
            string data = "2021-01-01";
            Calculadora calculadora = new Calculadora(data);
            
            return calculadora;
        }


        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(3, 3, 6)]
        public void Somar_RecebendoDoisNumeros_RetornarResultado(int val1, int val2, int resultado)
        {
            Calculadora calculadora = construirCalculadora();
            
            var resultadoCalculado = calculadora.Somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculado);
        }

        [Theory]
        [InlineData(4, 3, 1)]
        [InlineData(3, 3, 0)]
        public void Subtrair_RecebendoDoisNumeros_RetornarResultado(int val1, int val2, int resultado)
        {
            Calculadora calculadora = construirCalculadora();

            var resultadoCalculado = calculadora.Subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculado);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(3, 3, 9)]
        [InlineData(1, 1, 1)]
        [InlineData(3, 0, 0)]
        public void Multiplicar_RecebendoDoisNumeros_RetornarResultado(int val1, int val2, int resultado)
        {
            Calculadora calculadora = construirCalculadora();

            var resultadoCalculado = calculadora.Multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculado);
        }

        [Theory]
        [InlineData(8, 4, 2)]
        [InlineData(3, 3, 1)]
        public void Dividir_RecebendoDoisNumeros_RetornarResultado(int val1, int val2, int resultado)
        {
            Calculadora calculadora = construirCalculadora();

            var resultadoCalculado = calculadora.Dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculado);
        }

        [Fact]
        public void Dividir_FazerDivisaoPorZero_MostrarExcecao()
        {
            Calculadora calculadora = construirCalculadora();

            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(3, 0));
        }

        [Fact]
        public void Historico_SolicitarHistorico_VerificandoTamanhoDoHistorico()
        {
            Calculadora calculadora = construirCalculadora();

            // fazer operações para popular o histórico
            calculadora.Somar(2, 3);
            calculadora.Somar(3, 3);
            calculadora.Subtrair(3, 3);
            calculadora.Multiplicar(3, 3);
            calculadora.Dividir(3, 3);

            var historico = calculadora.Historico();

            // verificar se o histórico está vazio e se o tamanho é 3
            Assert.NotEmpty(historico);
            Assert.Equal(3, historico.Count);
        }
    }
}