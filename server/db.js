const mysql = require("mysql2/promise");

const pool = mysql.createPool({
  host: "localhost",
  user: "root",
  password: "123",
  database: "softrust",
  waitForConnections: true,
  connectionLimit: 10,
  queueLimit: 0,
  charset: "utf8mb4",
});

async function createTables() {
  await pool.query(
    `
      CREATE TABLE IF NOT EXISTS Themes (
          ThemeID INT AUTO_INCREMENT PRIMARY KEY,
          Theme NVARCHAR(255) NOT NULL UNIQUE
      );
    `
  );
  await pool.query(
    `
      CREATE TABLE IF NOT EXISTS Contacts (
          ContactID INT AUTO_INCREMENT PRIMARY KEY, -- Уникальный идентификатор контакта
          UserName NVARCHAR(255) NOT NULL,        -- Имя пользователя
          Email NVARCHAR(255) NOT NULL,           -- Электронная почта
          PhoneNumber NVARCHAR(20) NOT NULL       -- Номер телефона
      );
    `
  );
  await pool.query(
    `
      CREATE TABLE IF NOT EXISTS Messages (
          MessageID INT AUTO_INCREMENT PRIMARY KEY, -- Уникальный идентификатор сообщения
          Message TEXT NOT NULL,         -- Текст сообщения
          ThemeID INT NOT NULL,                   -- Ссылка на тему сообщения
          ContactID INT NOT NULL,                 -- Ссылка на контакт
          FOREIGN KEY (ThemeID) REFERENCES Themes(ThemeID), -- Внешний ключ для связи с Themes
          FOREIGN KEY (ContactID) REFERENCES Contacts(ContactID) -- Внешний ключ для связи с Contacts
      );
    `
  );
  await pool.query(`
    SET NAMES utf8mb4`);
}

createTables();
module.exports = {
  createTables,
};
