# FatCat.SSHFake Coding Standards

This file defines the coding standards for the FatCat.SSHFake codebase.
All code you generate — in any context — must follow the rules for the relevant language below.
The goal is that AI-generated code is indistinguishable from code written by a senior member of this team.

## ⚠️ READ THIS FIRST — Before Any Work

**Before doing anything else in this repository — reading, planning, or writing code — read [`README.md`](README.md) in full.**
It is the single source of truth for what this product is and how it is built. Do not skip it, even for a "small" change.

The README tells you the things you must know before you touch a line of code:
- **Product:** FatCat.SSHFake — an early-stage spike toward a fake SSH server for testing SSH clients. Today it contains no SSH protocol handling: the `SSHFake` console app starts `SshTcpServer` (a FatCat.Toolkit `FatTcpServer` whose `SshClientConnection` reads the raw `TcpClient` stream) on TCP port 21456 and writes every received message to the console; the `TestingConsole` app connects to `localhost:21456` through the toolkit's `ITcpFactory` and sends a test message. Nothing here is published as a NuGet package. **There is no `README.md` yet** — until one is written, this summary and the code are the source of truth.
- **Tech stack:** **.NET 11 / C# 15** console applications built on the **FatCat.Toolkit** (Autofac `SystemScope` injection, `FatCat.Toolkit.Communication` TCP server/client, `ConsoleLog`). There is no UI, web server, database, or test project in this repo.
- **Architecture:** `SSHFake` is the server side (the fake SSH host); `TestingConsole` is a hand-run client used to exercise it. Both bootstrap the same way — `SystemScope.Initialize` over their own assembly plus the toolkit, then resolve a worker (`LearningWorker` / `ClientTestingWorker`) and run it.
- **Standing rules:** the server and the client share the port number 21456 as a separate `ServerPort` constant in each project — change both together.

If anything below in the coding standards appears to conflict with the README, the README describes *what* the system is; these rules describe *how* to write code for it — follow both. Where the README and the actual code disagree, **the code is authoritative** — trust the code and flag the stale README.

## Repository Layout

| Path | Project | Purpose |
|---|---|---|
| `src/SSHFake` | `FatCat.SSHFake` | Console app hosting the fake SSH server: `SshTcpServer`, `SshClientConnection`, `LearningWorker` |
| `src/TestingConsole` | `TestingConsole` | Console app acting as a TCP client against the fake server (`ClientTestingWorker`); not shipped |

All production namespaces start with `FatCat.SSHFake.*` (the `TestingConsole` harness currently uses its own `TestingConsole` namespace); test namespaces start with `Tests.FatCat.SSHFake.*`.

Everything must build and every test must pass before work is considered done:
```bash
dotnet build src/SSHFake.slnx
dotnet test src/SSHFake.slnx
```

---

## C# Rules

Apply these rules to all C# code. Do not apply them to PowerShell or any other language.

@.claude/rules/csharp/naming-and-structure.md
@.claude/rules/csharp/types-and-di.md
@.claude/rules/csharp/toolchain.md
@.claude/rules/csharp/async.md
@.claude/rules/csharp/errors-and-logging.md
@.claude/rules/csharp/testing.md
@.claude/rules/csharp/not-allowed.md

## PowerShell Rules

Apply these rules to all PowerShell scripts. Do not apply them to C# or any other language.

@.claude/rules/powershell/powershell.md
