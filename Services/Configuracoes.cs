using System.Text;

namespace WeatherForecastApiJwtSandbox.Services
{
    public class Configuracoes
    {
        private static string _ChavePrivada = "20d51a42-6850-4a89-8159-f449dafff2fc";

        public static byte[] GetChavePrivada ()
        {
            return Encoding.ASCII.GetBytes(_ChavePrivada);
        }
    }
}