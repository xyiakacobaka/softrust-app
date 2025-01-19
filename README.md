# Message form

This form is for sending messages. Messages are divided into topics, which can be added to the [data.json](./MessageFormAPI//MessageFormAPI.API/Data/themes.json) file

## Get starded

1. ### Start the Express Server

   1.1. Go to the server folder in the terminal

   ```bash
   cd server
   ```

   1.2. Install dependencies

   ```bash
   npm install
   ```

   1.3. Start the Redis Server

   ```bash
   redis-server --daemonize yes
   ```

   1.4 (Optional) If you don't have the Redis CLI, you can [install](https://github.com/microsoftarchive/redis/releases/tag/win-3.0.504).msi file

   or use Chocolatey

   ```choco
   choco install redis
   ```

   1.5. Make sure the server is running and running on ports 6379

   ```bash
   Get-Process -Id (Get-NetTCPConnection -LocalPort 6379).OwningProcess
   ```

   If everything is ok, you will see a table like this:

   | Handles | NPM(K) | PM(K) | WS(K) | CPU(s) | Id    | SI  | ProcessName  |
   | ------- | ------ | ----- | ----- | ------ | ----- | --- | ------------ |
   | 488     | 9      | 7932  | 9200  | 0.03   | 15840 | 3   | redis-server |

   1.6. Start the Express Server

   ```bash
   node index.js
   ```

   If everything is ok, you will see a two string like this:

   ```bash
   Сервер запущен на http://localhost:3000
   Подключение выполнено
   ```

2. ### Install PostgreSQL Server

   2.1. Install [pgAdmin 4](https://www.pgadmin.org/download/) for needed platform

   2.2 Change [ConnectionString](https://vscode.dev/github/xyiakacobaka/softrust-app/blob/main/MessageFormAPI/MessageFormAPI.API/appsettings.json#L10).

   - Username - Your username for database authentication
   - Password - Your password for user authentication

3. ### Start the Asp.Net Core Web Api

   3.1. Go to the server folder in the terminal

   ```bash
   cd MessageFormAPI
   ```

   3.2. Install dependencies

   ```
   dotnet restore
   ```

   3.3 Create PostgreSQL Database with initial data

   ```bash
   cd MessageFormAPI.API
   dotnet ef migrations add <MigrationName> --project MessageFormAPI.Infrastructure --startup-project MessageFormAPI.API
   ```

   3.4 Apply the generated migration

   ```bash
   dotnet ef database update --project MessageFormAPI.Infrastructure --startup-project MessageFormAPI.API
   ```

   3.5. Go to the API folder in the terminal

   ```bash
   cd MessageFormAPI.API
   ```

   3.6. Launch Swagger

   ```bash
   dotnet watch run
   ```

4. ### Start the Angular app

   3.1. Got to Angular app folder

   ```bash
   cd test-app
   ```

   3.1. Install dependencies

   ```bash
   npm install
   ```

   3.2. Start the app

   ```bash
   ng serve
   ```

## Technology stack:

- ### Frameworks:

  - ASP.NET Core
  - Express JS
  - Angular 19
  - EF Core

- ### Databases:

  - PostgreSQL (needed for storage messages)
  - Redis(needed for storage captcha text)
