## Desafio Prático
Optei por não desenvolver um **front-end** mas diponibilizei swagger para teste de consumos, segui padrões que costumo estudar e sempre estar aplicando.

Api em .Net contempla:

- Arquitetura DDD - Clean
- IoC
- Entity Framework
- AutoMapper
- Swagger

#### Executar a aplicação:
#### Rebuild ou caso esteja usando cli do dotnet, na raíz do projeto executar o comando para instalar as dependências
```
dotnet restore
```
#### Rodar projeto da Api ou executar o run no path da Api
```
dotnet run
```

## Caso precise inicializar um banco relacional Postgres e rodar a migrations, siga os passos
#### Foi disponibilizado um docker-compose(Docker é uma dependência) com o container do postgres, para iniciar o container com o banco rodar:

Rodar no path raíz do projeto
```
docker-compose up -d
```

#### Migrations está presente usando entity framework core(ef-core é uma dependência para execução do comando e também alterar a classe abaixo apenas para execução pelo terminal), rodar para atualizar o banco:

Alterar classe para exemplo abaixo(retirar também o construtor)
```
public MyContext CreateDbContext(string[] args)
{
    var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
    optionsBuilder.UseNpgsql("string de conexão");
    return new MyContext(optionsBuilder.Options);

}
```

Rodar no path Repository
```
dotnet ef database update
```

