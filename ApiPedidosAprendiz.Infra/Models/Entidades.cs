using Newtonsoft.Json;

namespace ApiPedidosAprendiz.Infra.Models
{
    public class Entidades
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
      

        public string Cep { get; set; }

        public string Logradouro { get; set; }
     
        public string Complemento { get; set; }
    
        public string Localidade { get; set; }
  
        public string Uf { get; set; }
      
  
        public string Bairro { get; set; }



    }
}
