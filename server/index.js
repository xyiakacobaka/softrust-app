const express = require("express");
const cors = require("cors");
const redis = require("redis");
const svgCaptcha = require("svg-captcha");
const { v4: uuidv4 } = require("uuid");

const app = express();
const port = 3000;

app.use(express.json());

(async () => {
  client = redis.createClient();

  client.on("error", (error) => console.log("Что-то пошло не так", error));
  client.on("connect", () => console.log("Подключение выполнено"));

  await client.connect();
})();

app.use(cors());

app.get("/captcha", async (_, res) => {
  const id = uuidv4();

  const captcha = svgCaptcha.create({ size: 6, background: "#ffffcc" });

  try {
    await client.set(id, captcha.text, {
      EX: 300,
      NX: true,
    });

    res.status(200).send({ id, data: captcha.data });
  } catch (err) {
    console.error("Ошибка записи в Redis:", err);
    res.status(500).send("Ошибка записи в Redis");
  }
});

app.post("/validate-captcha", async (req, res) => {
  const { captchaId, userInput } = req.body;

  await client
    .get(captchaId)
    .then((savedCaptcha) => {
      if (!savedCaptcha) {
        return res
          .status(400)
          .json({ error: "Капча не найдена или сессия устарела" });
      }
      if (savedCaptcha.toLowerCase() === userInput.toLowerCase()) {
        res.status(200).json({ valid: true });
      } else {
        client.del(captchaId);
        res.status(200).json({ valid: false });
      }
    })
    .catch((err) => {
      console.error("Ошибка при получении капчи из Redis:", err);
      res.status(500).json({ error: "Ошибка сервера" });
    });
});

app.listen(port, () => {
  console.log(`Сервер запущен на http://localhost:${port}`);
});
