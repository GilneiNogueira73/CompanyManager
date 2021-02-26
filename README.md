# CompanyManager

Solução para controle dos funcionários da empresa Company.
Após clonar o repositório, é necessário acionar o Entity Framework para que as migrations iniciais sejam rodadas. Para isso digitar no Package Manager Console os comandos na seguinte ordem: 


   - update-database -context CompanyContext
   - update-database -context AuthenticationDbContext


Pronto! Com isso o banco de dados estará pronto para uso. Ao rodar o sistema, será solicitado email e senha para acesso:
Email: admin@companymanager.com
Senha: Abc#123456

Ao logar, o navegador registrará um cookie com a autenticação e não será necessário informar o login novamente até que este cookie expire :)

    *GET de Funcionários*:
Para consumir da Api as informações de todos os funcionários, basta utilizar a seguinte URI:
 http://localhost:57461/funcionario/Listafuncionarios
 
Já para identificar um funcionário em específico, basta passar como parametro o Id do funcionário para a URI:
http://localhost:57461/funcionario/Id
 
Informações que serão compartilhadas através da API:
        "id" - Guid
        "nome" - String
        "sobrenome" - String
        "email" - String
        "numeroDeChapa" - int
        "ddd1" - int
        "telefone1" - int
        "ddd2" - int
        "telefone2" - int
        "liderId" - Guid
        "senha" - String
        "login" - String
        "excluido" - bool
        
    *POST de Funcionários*:
Para inserir o cadastro de um funcionário, é necessário utilizar o endereço:
  http://localhost:57461/Funcionario/IncluiFuncionario
Deverão ser passados os seguintes parametros na requisição:
        "nome" - string
        "login" - string
        "email" - string
        "numeroDeChapa" - int
        "senha" - string
        "sobrenome" - string
        (Se houver)"liderId" - Guid 
        
- Definir um funcionário como líder:
Para informar ao sistema que um determinado funcionário agora é um líder, é necessário realizar um POST para a seguinte URI:
  http://localhost:57461/Funcionario/DefinirLider
É necessário informar como parametro a chave funcionarioId com o Id do funcionário que passará a ser líder. 
        
    *PUT de Funcionários*:
Para Editar o cadastro de um funcionário já existente no banco de dados, basta utilizar o endereço:
  http://localhost:57461/Funcionario/EditarFuncionario
Na requisição, deverão ser informados os dados a serem alterados, os quais poderão ser:
        "nome" - String
        "sobrenome" - String
        "email" - String
        "numeroDeChapa" - int
        "ddd1" - int
        "telefone1" - int
        "ddd2" - int
        "telefone2" - int
        "liderId" - Guid
        "senha" - String
        "login" - String
        
É DE SUMA IMPORTANCIA INFORMAR NA REQUISIÇÃO O id DO FUNCIONÁRIO.

- Exclusão de funcionário:
É possível realizar a exclusão _*lógica*_ de um funcionário através do endereço:
  http://localhost:57461/Funcionario/ExcluirFuncionario
  
É necessário passar como parametro o id do Funcionário.


*UTIL*
- Collection do Postman com as requisições: https://www.getpostman.com/collections/16b87cfb9e06b18ad505
- Na pasta Util há um bat com o comando para transformar a aplicação em um container, basta executar o arquivo RunDocker.bat ;)
