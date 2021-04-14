using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConverterObjetoJson();
            //ConverterJsonObjeto();
            SalvarObjetoArquivo();
            //LerObjetoJson();
        }

        //Convertendo objeto para formato JSON
        static void ConverterObjetoJson()
        {
            Topico topico = new Topico
            {
                Id = 1,
                Titulo = "Erro ao publicar projeto.",
                Conteudo = "Estou obtendo o erro X ao publicar meu projeto na hospedagem.",
                Usuario = "Victor",
                Tags = new string[3] { "ASP.NET", "C#", "Visual Studio" }
            };

            string json = JsonConvert.SerializeObject(topico);
            Console.Write(json);
        }

        //Convertendo JsSON para Objeto
        static void ConverterJsonObjeto()
        {
            string json = "{" +
                          " 'Id':1, " +
                          " 'Titulo':'Erro ao publicar projeto'," +
                          " 'Conteudo':'Estou obtendo o erro XYZ ao publicar meu projeto na hospedagem.'," +
                          " 'Usuario':'Victor'," +
                          " 'Tags': ['ASP.NET','C#','Visual Studio']" +
                          "}";
            Topico topico = JsonConvert.DeserializeObject<Topico>(json);
            Console.Write($"{topico.Id} \n {topico.Titulo} \n {topico.Usuario}");
        }

        //Salvando JSON em arquivo
        static void SalvarObjetoArquivo()
        {
            //List<Produto> produtos = new List<Produto>();
            List<Produto> produtos = CriarListaProdutos();

            StreamWriter sw = new StreamWriter("D:\\ProjetosJSON\\Produtos.json");
            JsonTextWriter jtw = new JsonTextWriter(sw);
            JsonSerializer serializer = new JsonSerializer();

            //Diminuindo tamanho do arquivo gerado pelos seus campos nulos.
            //serializer.NullValueHandling = NullValueHandling.Ignore;
            //Ignorando valores que são padrões
            //serializer.DefaultValueHandling = DefaultValueHandling.Ignore;

            //Retirando essa linha o tamanho é diminuido ainda mais.
            jtw.Formatting = Formatting.Indented;

            serializer.Serialize(jtw, produtos);
            sw.Close();
        }

        //Lendo arquivo JSON
        static void LerObjetoJson()
        {
            StreamReader sr = new StreamReader("D:\\ProjetosJSON\\Produtos.json");
            JsonTextReader jtr = new JsonTextReader(sr);
            JsonSerializer serializer = new JsonSerializer();

            List<Produto> produtos = serializer.Deserialize<List<Produto>>(jtr);

            foreach (var prod in produtos)
                Console.WriteLine(prod);

            sr.Close();
        }

        static List<Produto> CriarListaProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            for (int i = 0; i < 1000; i++)
            {
                produtos.Add(new Produto(i + 1, $"Produto {i + 1}", (i + 1) * 5)
                {
                    //Simulando com valores padrão
                    //DataCadastro = DateTime.Today.AddDays(-i),
                    //PrecoCusto = i * 3
                });
            }
            return produtos;
        }
    }
}
