# StoneChalleng

Olá! Esté o StoneChallenge, um serviço para criar o extrato da folha salarial dos funcionários.

## Como Rodar

Você pode executar o StoneChallenge de 3 formas:

### Docker Container
 
### 1) Dentro da raiz do projeto, execute:
```
docker-compose up
```
### 2) Dê pull na imagem docker:
```
docker pull httpsantos/stoneapi
docker run -p 8081:80 httpsantos/stoneapi
```
### 3) IDE 
Para esse passo, você precisará ter o Visual Studio instalado em sua máquina.
Antes de executar, precisamos buildar o projeto:
```
 Dentro do diretório do projeto, execute o comando:
 dotnet build
```
Em seguida, clique em Depurar > Iniciar Depuração.


## Como Utilizar
As requisições possíveis são:

**POST** /api/employee} - Cria um novo funcionário.

**GET** /api/Employee?funcionario={id} - Detalha os dados de um funcionário para o id correspondente.

**GET** /api/EmployeePaycheck?funcionario={id} - Detalha os dados do contracheque de um funcionário para o id correspondente.

### Exemplos de requisições para testar

### Criar um funcionário
```
--request POST
  {
    "nome": "fake",
    "sobreNome": "fake",
    "cpf": "000.000.000-00",
    "setor": "TI",
    "salarioBruto": 9999.99,
    "admissao": "2020-03-15",
    "planoSaude": false,
    "planoDental": false,
    "valeTransporte": false
  }
```

### Busca um funcionário
```
--request GET
  url http://localhost:8081/api/employee?funcionario=1
```

### Buscar contracheque
```
--request GET
  url http://localhost:8081/api/EmployeePaycheck?funcionario=1
```

### Testes 

Existem testes cobrindo as principais funcionalidades do StoneChallenge.
Para rodar os testes, você pode rodar individualmente pela sua IDE, ou
com o comando dentro do diretório da aplicação:
```
 dotnet test
```
