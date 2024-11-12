// See https://aka.ms/new-console-template for more information
string msgBoasVindas = "Bem vindo ao Screen Sound!";
//List<string> listaBandas = new List<string>{"Metallica", "Iron Maiden", "AC/DC", "Guns N' Roses", "Led Zeppelin"};

Dictionary<string , List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Metallica", new List<int>{10, 8, 9});
bandasRegistradas.Add("Iron Maiden", new List<int>{10, 8, 8});

void ExibirMensagem(){
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(msgBoasVindas);
}
void ExibirOpcoesMenu()
{
    ExibirMensagem();
    
    Console.WriteLine("\n");
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");

    string opcaoEscolhida = Console.ReadLine()!; // O ponto de exclamação é para garantir que o valor não é nulo
    int opcaoEscolhidaNumerica = Convert.ToInt32(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            registrarBanda();
            break;
        case 2:
            listarBandas();
            break;
        case 3:
            avaliarBanda();
            break;
        case 4:
            exibirMediaDaBanda();
            break;
        case -1:
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void registrarBanda(){
    Console.Clear();
    exibirTituloDaOpcao("Registrar uma banda");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.Write($"A banda {nomeDaBanda} foi registrada com sucesso: ");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void listarBandas(){
    Console.Clear();
    exibirTituloDaOpcao("Lista bandas registradas");
    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.WriteLine(banda);
    }
    Thread.Sleep(2000);
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
    Console.ReadKey();//
    Console.Clear();
    Console.Clear();
    ExibirOpcoesMenu();
}

void exibirTituloDaOpcao(string titulo){
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos+"\n");
}

void avaliarBanda(){
    //digite qualbanda deseja avaliar
    // se a banda existir no dicionario >> atribuir uma nota
    //senão, volta ao menu principal

    Console.Clear();
    exibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(nomeDaBanda)){
        Console.Write("Digite a nota da banda: ");
        int nota = Convert.ToInt32(Console.ReadLine());
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A banda {nomeDaBanda} foi avaliada com sucesso: ");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();
    }else{      
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

}

void exibirMediaDaBanda(){
    Console.Clear();
    exibirTituloDaOpcao("Exibir Média da Banda");
    Console.Write("Informe o nome da banda que deseja saber a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
        
    }else{
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}

ExibirOpcoesMenu();
