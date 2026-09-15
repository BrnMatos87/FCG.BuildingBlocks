# FCG.BuildingBlocks

Biblioteca .NET 8 compartilhada da solução FIAP Cloud Games. O pacote concentra somente contratos e tipos realmente comuns, sem dependência de banco de dados, mensageria, HTTP ou infraestrutura específica.

## Componentes

- `EntityBase`: base para entidades de domínio.
- `StatusType` e `PaymentStatus`: enums compartilhados.
- `UserCreatedEvent`: contrato com os dados de um usuário criado.
- `OrderPlacedEvent`: contrato de pedido criado.
- `PaymentProcessedEvent`: contrato com o resultado de um pagamento.

Os contratos são independentes do transporte. Na arquitetura atual:

| Contrato | Produtor | Destino | Transporte |
|---|---|---|---|
| `UserCreatedEvent` | FCG.Users | FCG.Notifications | HTTP POST |
| `OrderPlacedEvent` | FCG.Catalog | FCG.Payments | RabbitMQ |
| `PaymentProcessedEvent` | FCG.Payments | FCG.Catalog | RabbitMQ |
| `PaymentProcessedEvent` | FCG.Payments | FCG.Notifications | HTTP POST |

O reaproveitamento do mesmo DTO no HTTP não transforma a chamada em consumo de mensagem. Notifications não possui consumer nem trigger RabbitMQ.

## Estrutura

```text
FCG.BuildingBlocks/
|-- Domain/
|   `-- EntityBase.cs
|-- Enums/
|   |-- StatusType.cs
|   `-- PaymentStatus.cs
|-- Events/
|   |-- UserCreatedEvent.cs
|   |-- OrderPlacedEvent.cs
|   `-- PaymentProcessedEvent.cs
`-- FCG.BuildingBlocks.csproj
```

## Uso

```xml
<PackageReference Include="FCG.BuildingBlocks" Version="1.0.1" />
```

```csharp
using FCG.BuildingBlocks.Domain;
using FCG.BuildingBlocks.Enums;
using FCG.BuildingBlocks.Events;
```

## Build, testes e pacote

```powershell
dotnet restore
dotnet build
dotnet test
dotnet pack -c Release
```

Para publicar uma nova versão, incremente o pacote conforme versionamento semântico e use uma API key fora do repositório:

```powershell
dotnet nuget push .\bin\Release\FCG.BuildingBlocks.<versao>.nupkg `
  --source https://api.nuget.org/v3/index.json `
  --api-key <NUGET_API_KEY>
```

## Limites da biblioteca

Não devem ser adicionados ao BuildingBlocks:

- Entity Framework ou drivers de persistência;
- RabbitMQ ou MassTransit;
- clientes HTTP;
- Controllers ou lógica específica de um microsserviço;
- secrets, connection strings ou configurações de implantação.

## Fase 3

Os requisitos de Kong, Kubernetes, Prometheus, Grafana, MongoDB, Redis e orquestração pertencem aos serviços e ao `FCG.Orchestration`. Esta biblioteca fornece somente os contratos necessários para manter compatibilidade entre eles.
