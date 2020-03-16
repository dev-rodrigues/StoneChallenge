# Routiner

Olá! Esté o StonePayment, um serviço para criar o extrato da folha salarial dos funcionários.

## Como Rodar

Você pode executar o StonePayment de 2 formas:

### Docker Container
 
Dê pull na imagem docker
```
sudo docker pull {IMAGEM}
```
Execute-a com o seguinte comando:
```
docker run -p 7000:7000 {IMAGEM}
```

### IDE 
Para esse passo, você precisará ter o Visual Studio instalado em sua máquina.
Antes de executar, precisamos buildar o projeto e suas dependências.
```
procedimento para buildar
```

## Como Utilizar
As requisições possíveis são:

**POST** http://localhost:{}/api/employee} - Cria um novo funcionário.

**GET** http://localhost:{}/api/Employee?employeeId={id} - Detalha os dados de um funcionário para o id correspondente.

**GET** http://localhost:{}/api/EmployeePaycheck?employeeId={id} - Detalha os dados do contracheque de um funcionário para o id correspondente.

### Exemplos de requisições para testar

Criar um funcionário
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

Busca um funcionário
```
--request GET
  url http://localhost:32769/api/Employee?employeeId={id}
```

Buscar contracheque
```
--request GET
  url http://localhost:32769/api/EmployeePaycheck?employeeId={id}
```

## Testes 

Existem testes cobrindo as principais funcionalidades do StonePayment.
Para rodar os testes, você pode rodar individualmente pela sua IDE, ou
com o comando dentro do diretório da aplicação:
```
 dotnet test
```
