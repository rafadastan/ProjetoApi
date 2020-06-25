using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Configurations
{
    public class AppSettings
    {
        //propriedade para armazenar a palavra secreta
        //utilizada para gerar o TOKEN de segurança
        public string SecretKey { get; set; }
    }
}
