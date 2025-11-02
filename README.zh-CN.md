# Revit MCP DotNet 项目

语言：中文 | [English](README.md)

该项目包含两个主要组件：一个 Revit MCP (Mcp) 服务器和一个用于与其通信的 Revit 插件。

## Revit MCP 项目

Revit MCP 项目 (`NET.Mcp.Server`) 是一个 .NET Core 应用程序，充当主应用程序和 Revit 应用程序之间的桥梁。它侦听命令并在 Revit 环境中执行它们。

### 配置

MCP 服务器通过位于 `src\NET.App.Revit\NET.Mcp.Server\` 中的 `mcpConfig.json` 文件进行配置。该文件定义了如何启动 MCP 服务器进程。

例如，要为 `trae` 环境配置它，您需要将项目路径设置为您本地计算机的路径。

**`mcpConfig.json` 示例：**

```json
{
  "mcpServers": {
    "revit": {
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "d:\GitHub\revit_mcp_dotnet-main\src\NET.App.Revit\NET.Mcp.Server",
        "--no-build"
      ],
      "env": {}
    }
  }
}
```

**注意：** 请确保 `--project` 路径指向您计算机上 `NET.Mcp.Server` 项目的正确位置。

### 运行服务器

要运行 MCP 服务器，您可以从终端执行 `mcpConfig.json` 中定义的命令。根据上面的示例，您将运行：

```bash
dotnet run --project d:\GitHub\revit_mcp_dotnet-main\src\NET.App.Revit\NET.Mcp.Server
```

这将启动服务器，然后服务器将等待 Revit 插件连接。

## Revit 插件项目

Revit 插件 (`NET.App.Revit`) 是 Autodesk Revit 的一个插件，它连接到 MCP 服务器并允许从外部控制 Revit。

### 在 Revit 中使用

1.  **构建项目**：构建 `NET.App.Revit.sln` 解决方案以生成插件 DLL。
2.  **在 Revit 中加载插件**：
    *   将生成的 `.addin` 文件和相关的 DLL 复制到 Revit 插件文件夹（例如 `%APPDATA%\Autodesk\Revit\Addins\2022`）。
    *   启动 Autodesk Revit。
3.  **运行插件**：
    *   加载后，您将在 Revit 的“附加模块”选项卡中找到新命令。
    *   使用“启动服务器”命令（或类似命令）来启动与正在运行的 MCP 服务器的连接。

### 版本兼容性

该插件目前已为 **Revit 2022** 配置和测试。

如果您需要在其他版本的 Revit（例如 2021、2023、2024）中使用它，您需要：
1.  更新 `.csproj` 文件中的 Revit API 引用。
2.  调整 `.addin` 文件以针对所需的 Revit 版本。
3.  重新构建项目。

## 示例说明

- MCP 服务器（.NET）：位于 `src/NET.App.Revit/NET.Mcp.Server`。包含一个本地启动示例 `mcpConfig.json`（含 Trae 配置示例）。
- Revit 插件（.NET）：位于 `src/NET.App.Revit/NET.App.Revit`。提供插件项目及在 Revit 中加载的使用说明。

以上示例均为 .NET 端实现。插件已在 Revit 2022 验证，其他版本需要手动配置 API 引用和 `.addin` 目标版本。

## 快速链接

- 英文详细指南：`src/NET.App.Revit/README.md`
- 中文详细指南：`src/NET.App.Revit/README.zh-CN.md`