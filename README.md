# Library

Este é o projeto de uma biblioteca, desenvolvido utilizando C# .NET.

Abaixo você encontrará como Clonar e Executar o Projeto. 👇

Segue o passo a passo:

## Passo 1: Instalar o .NET SDK

1. **Baixar o .NET SDK**
   - Acesse o site oficial do .NET: [Download .NET](https://dotnet.microsoft.com/download)
   - Baixe e instale a versão mais recente do .NET SDK (o SDK inclui o runtime e as ferramentas de desenvolvimento).

2. **Verificar a Instalação**
   - Abra o terminal (Prompt de Comando no Windows, Terminal no macOS/Linux).
   - Execute o seguinte comando para verificar se o .NET SDK foi instalado corretamente:
     ```bash
     dotnet --version
     ```
   - Você deve ver a versão do .NET SDK instalada.

## Passo 2: Clonar o Repositório do Projeto

1. **Obter o URL do Repositório**
   - Certifique-se de ter o URL do repositório Git onde o projeto está hospedado.

2. **Clonar o Repositório**
   - No terminal, navegue até o diretório onde você deseja clonar o projeto.
   - Execute o comando:
     ```bash
     git clone https://github.com/RicardoVictor/library-back.git
     ```

3. **Navegar para o Diretório do Projeto**
   - Após a clonagem, entre no diretório do projeto:
     ```bash
     cd library-back
     ```

## Passo 3: Restaurar Dependências do Projeto

1. **Restaurar Pacotes NuGet**
   - Execute o comando:
     ```bash
     dotnet restore
     ```
   - Isso restaurará todas as dependências do projeto listadas no arquivo `.csproj` ou `packages.config`.

## Passo 4: Executar o Projeto

1. **Executar o Projeto**
   - Execute o comando:
     ```bash
     dotnet run
     ```
   - Isso compilará e iniciará o projeto.

2. **Acessar o Projeto**
   - Se o projeto for um aplicativo web, abra o navegador e acesse o URL exibido no terminal. Normalmente é algo como `http://localhost:5000` ou `http://localhost:5001` para HTTPS.

## Passo 5: Compilar o Projeto

1. **Compilar o Projeto**
   - Se você precisar apenas compilar o projeto sem executá-lo, execute:
     ```bash
     dotnet build
     ```
   - Isso criará os binários do projeto na pasta `bin/`.

## Passo 6: Como Parar o Projeto

1. **Parar o Projeto**
   - No terminal onde o projeto está em execução, pressione `Ctrl + C` para parar o projeto.

## Problemas

Se você tiver problemas adicionais ou precisar de mais assistência, mande um email para [rvictorsoliveira@gmail.com](rvictorsoliveira@gmail.com).
