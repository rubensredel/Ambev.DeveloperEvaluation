# Developer Evaluation Project

`READ CAREFULLY`

## Instruções

Para executar o projeto, deve-se primeiramente compilar o projeto no docker

`docker compose build`

Após que, deve-se iniciar o container utilizando o comando

`docker compose up`

Todas as tabelas serão criadas automaticamente e todos os serviços estarão inicializados dentro de um container.

## Primeiros passos

Acessar a URL https://localhost:18081/swagger/index.html (SWAGGER) para ver os endpoints do projeto. Convém salientar que os endpoints que foram criados foram específicos para resolver a demanda em questão.

## Criação de usuário e autenticação

Para acessar as funcionalidades, deve-se criar um usuário através do endpoint POST /api/Users fornecendo todos os dados. Os dados de Status e Role poderão assumir o identificador 1.

Com o usuário criado na base, a autenticação é realizada através do endpoint POST /api/Auth utilizando o usuário (e-mail) e senha. Será gerado um token que deverá ser informado no Authorize do Swagger para que todos os comandos estejam funcionais.

## Criação de produtos

A próxima etapa envolve a criação de produtos para os pedidos de vendas. Os produtos apenas terão uma descrição, porém, gerará um UUID que será usado para confeccionar os pedidos de venda.

## Criação de Vendas

Com o Id do produto, é possível gerar os pedidos de venda e seus respectivos itens em questão através da controller /api/Sales. Nesses endpoints estão concentrados o CRUD e suas regras de negócios.

