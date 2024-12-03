using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusSports
{
    public class Connecao
    {
        public static string GetConString()
        {
            // Substitua "FocuSDB" pelo nome que você usou no App.config
            return ConfigurationManager.ConnectionStrings["FocuSDB"].ConnectionString;
        }

    }
}
