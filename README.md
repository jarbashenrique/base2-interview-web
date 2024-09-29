# MantisAutomation

Este projeto contém a automação de testes para o sistema de gestão de bugs Mantis. Utilizando o framework **Selenium WebDriver** com a linguagem **C#**, o projeto implementa testes automatizados para validar as funcionalidades do sistema.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework de Testes**: NUnit
- **Automação Web**: Selenium WebDriver
- **Navegador**: Google Chrome
- **Gerenciamento de Dependências**: NuGet
- **Ferramentas de Suporte**:
  - SeleniumExtras.WaitHelpers
  - Selenium ChromeDriver

## Pré-requisitos

Antes de rodar os testes, você deve ter instalado em sua máquina:

- **.NET 7.0 SDK** ou superior ([download](https://dotnet.microsoft.com/download))
- **Chrome Browser** ([download](https://www.google.com/chrome/))
- **ChromeDriver** compatível com a versão do Chrome instalada ([download](https://sites.google.com/chromium.org/driver/))

Para instalar as dependências do projeto, navegue até a pasta do projeto e execute:

```bash
dotnet restore
```

## Estrutura do Projeto

- **Drivers**: Contém a configuração do ChromeDriver utilizado pelo Selenium.
- **Pages**: Contém as Page Objects que representam as páginas do sistema Mantis.
- **Tests**: Contém os testes automatizados utilizando NUnit.

## Como Executar os Testes

1. Clone este repositório para a sua máquina local:
   ```bash
   git clone https://github.com/seuusuario/MantisAutomation.git
   ```

2. Navegue até a pasta do projeto:
   ```bash
   cd MantisAutomation
   ```

3. Restaure as dependências:
   ```bash
   dotnet restore
   ```

4. Execute os testes:
   ```bash
   dotnet test
   ```

Os testes serão executados no Google Chrome e você verá os resultados no terminal.

## Funcionalidades Testadas

### Testes de Login
### Testes de Reportar Problemas

## Contato

Em caso de dúvidas ou sugestões, entre em contato através do e-mail: **seuemail@exemplo.com**
