# FCG.BuildingBlocks

Biblioteca compartilhada utilizada pelos microsserviços da solução **FIAP Cloud Games (FCG)**.

Este pacote concentra componentes reutilizáveis entre os microsserviços, promovendo padronização, reutilização de código e redução de dependências duplicadas.

O pacote está publicado no **NuGet.org** e pode ser consumido por qualquer aplicação .NET.

---

# Objetivo

O objetivo desta biblioteca é centralizar todos os componentes compartilhados da solução, permitindo que os microsserviços utilizem uma única implementação para objetos comuns.

Entre os principais benefícios estão:

- Reutilização de código
- Padronização entre microsserviços
- Redução de acoplamento
- Facilidade de manutenção
- Versionamento independente dos serviços

---

# Tecnologias

- .NET 8
- C#
- NuGet
- Domain Driven Design (DDD)
- Clean Architecture

---

# Estrutura do Projeto

```
FCG.BuildingBlocks
│
├── Domain
│   └── EntityBase.cs
│
├── Enums
│   ├── StatusType.cs
│   └── PaymentStatus.cs
│
├── Events
│   ├── UserCreatedEvent.cs
│   ├── OrderPlacedEvent.cs
│   └── PaymentProcessedEvent.cs
│
├── README.md
├── LICENSE
└── FCG.BuildingBlocks.csproj
```

---

# Componentes Disponíveis

Atualmente o pacote disponibiliza:

## Entidades Base

Componentes utilizados como base para entidades de domínio.

Exemplo:

- EntityBase

---

## Enums Compartilhados

Enums utilizados por diferentes microsserviços.

Exemplos:

- StatusType
- PaymentStatus

---

## Integration Events

Eventos compartilhados para comunicação assíncrona entre microsserviços.

Eventos disponíveis:

- UserCreatedEvent
- OrderPlacedEvent
- PaymentProcessedEvent

---

# Instalação

Instale utilizando o .NET CLI:

```bash
dotnet add package FCG.BuildingBlocks
```

Ou utilizando o Package Manager:

```powershell
Install-Package FCG.BuildingBlocks
```

Ou adicionando manualmente ao projeto:

```xml
<PackageReference Include="FCG.BuildingBlocks" Version="1.0.1" />
```

---

# Utilização

Após instalar o pacote, basta importar o namespace desejado.

Exemplo:

```csharp
using FCG.BuildingBlocks.Domain;
using FCG.BuildingBlocks.Enums;
using FCG.BuildingBlocks.Events;
```

---

# Versionamento

Este pacote segue versionamento semântico.

Exemplo:

```
1.0.0

Correções
↓

1.0.1

Novas funcionalidades compatíveis
↓

1.1.0

Mudanças incompatíveis
↓

2.0.0
```

Sempre que novas funcionalidades forem adicionadas ou corrigidas, uma nova versão será publicada no NuGet.org.

---

# Publicação

O pacote é publicado no NuGet.org.

Página oficial:

https://www.nuget.org/packages/FCG.BuildingBlocks

Publicação:

```bash
dotnet pack -c Release

dotnet nuget push .\bin\Release\FCG.BuildingBlocks.<versão>.nupkg \
    --source https://api.nuget.org/v3/index.json \
    --api-key SUA_API_KEY
```

---

# Consumo pelos Microsserviços

Atualmente este pacote é utilizado pelos seguintes serviços da solução:

- FCG.Users
- FCG.Catalog
- FCG.Payments
- FCG.GameLibrary
- FCG.Notifications

Todos os microsserviços utilizam o mesmo pacote compartilhado para manter consistência entre entidades, eventos e enums.

---

# Arquitetura

A solução utiliza uma arquitetura baseada em microsserviços.

```
                FCG.BuildingBlocks
                        │
        ┌───────────────┼────────────────┐
        │               │                │
        ▼               ▼                ▼

   FCG.Users      FCG.Catalog     FCG.Payments
        │               │                │
        └───────────────┼────────────────┘
                        │
                        ▼

               FCG.GameLibrary

                        │
                        ▼

             FCG.Notifications
```

Todos os microsserviços compartilham apenas este pacote comum, permanecendo independentes entre si.

---

# Boas Práticas

Esta biblioteca possui apenas componentes compartilhados.

Não devem ser adicionados:

- Entity Framework
- SQL Server
- RabbitMQ
- ASP.NET Core
- Controllers
- Repositórios
- Serviços específicos de um domínio

O objetivo é manter o pacote leve, reutilizável e independente.

---

# Licença

Este projeto utiliza a licença MIT.

Consulte o arquivo LICENSE para mais informações.

---

# Autor

Bruno Matos

Pós-graduação em Arquitetura de Software - FIAP
