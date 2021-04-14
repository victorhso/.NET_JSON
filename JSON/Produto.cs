using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        [JsonIgnore] //Faz com que essa informação não seia exibida no arquivo JSON
        public DateTime DataCadastro { get; set; }
        [JsonIgnore]
        public decimal PrecoCusto { get; set; }
        [JsonIgnore]
        public string DescricaoEtiqueta { get; set; }

        public Produto(int Codigo, string Nome, decimal Preco)
        {
            this.Codigo = Codigo;
            this.Nome = Nome;
            this.PrecoVenda = Preco;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nome} - {PrecoVenda}";
        }
    }
}
