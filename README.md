💬 [MessagingApp] - Aplicativo de Chat em Tempo Real
Backend de um sistema de chat em tempo real desenvolvido para portfólio, focado em boas práticas, Arquitetura Limpa e comunicação com SignalR.

Sobre o Projeto
O objetivo deste projeto é construir a fundação de um aplicativo de mensageria robusto, lidando com o registro de usuários, autenticação, listagem de contatos e envio de mensagens em tempo real.

Funcionalidades Implementadas e Roadmap
[x] Arquitetura Limpa (Clean Architecture)
[x] Repository Pattern
[x] Repositórios e Serviços 100% Assíncronos (async/await)
[x] Implementação da Camada de Aplicação (Services, DTOs, Mapeamento Manual)
[x] Sistema de Autenticação e Autorização com ASP.NET Core Identity
[x] Registro de Usuários
[x] Login e Logout de Usuários
[x] Proteção de rotas com [Authorize]
[x] Sincronização de IDs entre a tabela do Identity (AspNetUsers) e a tabela de Domínio (Users)
[x] Lobby de Usuários
[x] Listagem de todos os usuários registrados
[x] Chat em Tempo Real com SignalR
[x] Hub de Chat (ChatHub) para comunicação bidirecional
[x] Envio de mensagens apenas para o remetente e destinatário
[x] Salvamento de todo o histórico de mensagens no banco de dados

.NET 8

ASP.NET Core MVC

ASP.NET Core SignalR

Entity Framework Core 8 (para ORM)

SQL Server (Banco de Dados, via LocalDB)

ASP.NET Core Identity (Autenticação e Autorização)

Arquitetura Limpa (Clean Architecture) de 4 camadas

Programação Assíncrona (async/await)

Injeção de Dependência (DI) nativa

Padrão Repositório (Repository Pattern)

DTOs (Data Transfer Objects)
