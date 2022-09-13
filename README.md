# Desafio ITERA

## Executar o projeto
- Via terminal: No diretório do projeto executar os comandos: *dotnet build; dotnet run*

## Acessar a documentação
- Após executar o projeto, acessar um dos endereços abaixo:
    - https://localhost:5001/swagger/index.html
    - http://localhost:5000/swagger/index.html

## Utilizar as rotas 
- Existem 2 tipos de rotas, as que necessitam estar logado e ser administrador e as que não precisa logar.

- Não necessitam de login:
    - POST /api/Usuarios/login
    - GET /empresa/{_id}
    - GET /grupo
    - GET /grupo/{_id}
    - GET /grupo/custos/{_id}

- Necessitam de login:
    - DELETE /empresa/{_id}
    - POST /empresa
    - PUT /empresa/custos/{_id}
    - POST /grupo
    - PUT /grupo/{_id}

## Realizar login
- Foram cadastrados 2 usuários para teste, um com perfil administrativo e outro como visitante. 
- Os dados dos usuários estão no caminho Data/user.json.