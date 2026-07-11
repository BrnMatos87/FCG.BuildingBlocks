# FCG.BuildingBlocks

Biblioteca compartilhada da solução **FIAP Cloud Games (FCG)**.

Este projeto contém os componentes comuns utilizados pelos microsserviços da aplicação, evitando duplicação de código e garantindo padronização entre os serviços.

## Objetivo

O FCG.BuildingBlocks centraliza contratos e componentes reutilizáveis utilizados pelos microsserviços da plataforma.

Atualmente este pacote disponibiliza:

- Entidade base (`EntityBase`)
- Eventos de integração
- Enumerações compartilhadas

Este projeto é distribuído como um pacote **NuGet** e consumido pelos demais microsserviços da solução.

---

# Estrutura

```
FCG.BuildingBlocks
│
├── Domain
│   └── EntityBase.cs
│
├── Enums
│   ├── PaymentStatus.cs
│   └── StatusType.cs
│
└── Events
    ├── OrderPlacedEvent.cs
    ├── PaymentProcessedEvent.cs
    └── UserCreatedEvent.cs
```

---

# Tecnologias

- .NET 8
- C#
- NuGet Package

---

# Gerando o pacote

Restaurar dependências:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build -c Release
```

Gerar o pacote NuGet:

```bash
dotnet pack -c Release --no-build
```

O pacote será criado em:

```
bin/Release/
```

---

# Publicando no GitHub Packages

Após configurar o GitHub Packages:

```bash
dotnet nuget push .\bin\Release\FCG.BuildingBlocks.1.0.0.nupkg \
--source github \
--api-key <TOKEN>
```

---

# Consumindo o pacote

Adicionar a origem do GitHub Packages:

```bash
dotnet nuget add source "https://nuget.pkg.github.com/BrnMatos87/index.json" \
--name github \
--username BrnMatos87 \
--password <TOKEN> \
--store-password-in-clear-text
```

Instalar o pacote:

```bash
dotnet add package FCG.BuildingBlocks
```

Ou adicionar ao projeto:

```xml
<PackageReference Include="FCG.BuildingBlocks"
                  Version="1.0.0" />
```

---

# Componentes compartilhados

## Domain

Contém classes base utilizadas pelos domínios da aplicação.

### EntityBase

Classe base para entidades compartilhadas entre os microsserviços.

---

## Events

Eventos utilizados na comunicação assíncrona através do RabbitMQ.

### UserCreatedEvent

Publicado pelo microsserviço de Usuários após o cadastro de um novo usuário.

Consumido pelo Notifications.

---

### OrderPlacedEvent

Publicado pelo Catalog quando uma compra é iniciada.

Consumido pelo Payments.

---

### PaymentProcessedEvent

Publicado pelo Payments após o processamento do pagamento.

Consumido pelo:

- Catalog
- Notifications

---

## Enums

Enumerações compartilhadas entre os microsserviços para manter consistência nos contratos.

---

# Versionamento

O projeto segue versionamento semântico.

Exemplo:

```
1.0.0
```

Incrementos:

- Patch → Correções
- Minor → Novas funcionalidades compatíveis
- Major → Alterações incompatíveis

---

# Solução

Este projeto faz parte da arquitetura de microsserviços da **FIAP Cloud Games**.

Microsserviços consumidores:

- FCG.Users
- FCG.Catalog
- FCG.Payments
- FCG.GameLibrary
- FCG.Notifications

---

# Autor

Bruno Matos

Pós-Tech FIAP
Arquitetura de Sistemas .NET