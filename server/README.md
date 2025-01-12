# EXPRESS JS + Redis

This server is needed for interaction between the frontend and the backend

## RUN_GUIDE

1. Install dependencies

   ```bash
   npm install
   ```

   1.5 (Optional) If you don't have the Redis CLI, you can [install](https://github.com/microsoftarchive/redis/releases/tag/win-3.0.504).msi file:

   or use Chocolatey

   ```choco
   choco install redis
   ```

2. Start the Redis Server

   ```bash
   redis-server --daemonize yes
   ```

   2.5. Make sure the server is running and running on ports 6379

   ```bash
   Get-Process -Id (Get-NetTCPConnection -LocalPort 6379).OwningProcess
   ```

   If everything is ok, you will see a table like this:

   | Handles | NPM(K) | PM(K) | WS(K) | CPU(s) | Id    | SI  | ProcessName  |
   | ------- | ------ | ----- | ----- | ------ | ----- | --- | ------------ |
   | 488     | 9      | 7932  | 9200  | 0.03   | 15840 | 3   | redis-server |

3. Start the Express Server

   ```bash
   node index.js
   ```

   If everything is ok, you will see a two string like this:

   ```bash
   Сервер запущен на http://localhost:3000
   Подключение выполнено
   ```

4. (Optional) If you want to start the server in development mode use this command

   ```bash
   npm i -g nodemon
   nodemon index.js
   ```
