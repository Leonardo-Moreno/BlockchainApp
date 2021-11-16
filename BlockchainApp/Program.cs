using Newtonsoft.Json;
using System;
using static BlockchainApp.BlockChain;

namespace BlockchainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain cadeia = new Blockchain();
            cadeia.AddBlock(new Block(DateTime.Now, null, "{Enviado:Leonardo,Recebido:Sarah,Valor:10}"));
            cadeia.AddBlock(new Block(DateTime.Now, null, "{Enviado:Sarah,Recebido:Marcos,Valor:100}"));
            cadeia.AddBlock(new Block(DateTime.Now, null, "{sender:Testador,receiver:Leo,amount:5}"));

            Console.WriteLine(JsonConvert.SerializeObject(cadeia, Formatting.Indented));

            Console.WriteLine($"Is Chain Valid: {cadeia.IsValid()}");

            Console.WriteLine($"Update valor to 99");
            cadeia.Chain[1].Data = "{Enviado:Sarah,Recebido:Marcos,Valor:100}";

            Console.WriteLine($"Is Chain Valid: {cadeia.IsValid()}");

            Console.WriteLine($"Update hash");
            cadeia.Chain[1].Hash = cadeia.Chain[1].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {cadeia.IsValid()}");

            Console.WriteLine($"Update the entire chain");
            cadeia.Chain[2].PreviousHash = cadeia.Chain[1].Hash;
            cadeia.Chain[2].Hash = cadeia.Chain[2].CalculateHash();
            cadeia.Chain[3].PreviousHash = cadeia.Chain[2].Hash;
            cadeia.Chain[3].Hash = cadeia.Chain[3].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {cadeia.IsValid()}");

            Console.ReadKey();

        }
    }
}
