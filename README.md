# Fast Request Selector
----------
<b>Fast Request Selector</b> é um biblioteca C# .NET que oferece ao usuário fazer requisições HTTP simples e também customizadas e obter todos os elementos que precisar utilizando as <b>REGRAS CSS</b>.
Vamos ver um exemplo abaixo:

Vamos supor que quero obter as linguagens mais usadas do perfil oficial do GitHub.
![alt](https://raw.githubusercontent.com/kledsonzg/FastRequestSelector/refs/heads/main/img/Captura%20de%20tela%202025-01-19%20140345.png)
Veja o código HTML deste trecho que temos interesse em obter:
![alt](https://raw.githubusercontent.com/kledsonzg/FastRequestSelector/refs/heads/main/img/Captura%20de%20tela%202025-01-19%20142649.png)

Repare que toda tag com as linguagens de programação mais usadas possuem o atributo "itemprop" com o valor "programmingLanguage".
Se a gente obter todos os elementos baseados apenas nisso, iriamos obter outros elementos da página que não temos interesse pois mais abaixo no código HTML haverá mais ocorrências do uso deste atributo. Então para obter apenas os elementos que temos interesse, vamos também basear no elemento pai destes elementos (marcados com um círculo verde).


```// Utilizando a classe estática "Request".
using KledsonZG.FastRequest.Selector;

namespace Program;

public static void Main(string[] args)
{
    var elements = Request.GetElements("https://github.com/github", ".ml-0 [itemprop=\"programmingLanguage\"]");

    Console.WriteLine("GitHub Profile TopLanguages:");
    foreach(var element in elements)
    {
        Console.WriteLine(element.TextContent);
    }
}
```

### Resultado:
![alt](https://raw.githubusercontent.com/kledsonzg/FastRequestSelector/refs/heads/main/img/Captura%20de%20tela%202025-01-19%20142112.png)

##### Créditos:
- [Aspose HTML](https://docs.aspose.com/html/net/)
