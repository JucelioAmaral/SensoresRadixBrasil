
 # SensoresRadixBrasil
 
## Explicação sobre a solução

Sistema capaz de receber milhares de eventos por segundo de sensores espalhados pelo Brasil, nas regiões norte, nordeste, sudeste e sul. Dados dos eventos podem ser visualizados através de tabela e gráfico.

Um evento é defino por um JSON com o seguinte formato:

```json
{
   "timestamp": <Unix Timestamp ex: 1539112021301>,
   "tag": "<string separada por '.' ex: brasil.sudeste.sensor01 >",
   "valor" : "<string>"
}
```

Descrição:
 * O campo timestamp é quando o evento ocorreu em UNIX Timestamp.
 * Tag é o identificador do evento, sendo composto de pais.região.nome_sensor.
 * Valor é o dado coletado de um determinado sensor (podendo ser numérico ou string).


# Sistema de sensores do Brasil

Api feito em .Net Core 3.1 usando Entity framework para persistencia, acesso, consultas e relatórios ao banco de dados SQLServer, como SGBD.

## Pré requisitos
 
1. [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
2. [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/)

## Como baixar o código

git clone https://github.com/JucelioAmaral/SensoresRadixBrasil.git

## Como configurar?

1. Abrir a solution;
2. Configurar o arquivo "appsettings.json" com a connectionString, apontando para o banco SQL server;
3. Abrir o Console do Visual Studio;
4. Executar o comando: Add-Migration MigracaoInicial;
5. Executar o comando: Update-Database;
6. Executar a Api pelo Visual Studio.

## Como executar a api (Back end)?

1. Abrir a solution;
2. Clicar no botão em Start.

## Como executar o app (Front end)?

1 - Node.js (mais recente) instalados;
2 - Abrir o cmd pelo explorar onde estão os arquivas do front;
3 - Inserir o comando: npm install; 
4 - Executar o front: npm start; 
    OBS: Pelo terminal (powerShell) dentro do Visual Code, o comando acima não funciona.
	