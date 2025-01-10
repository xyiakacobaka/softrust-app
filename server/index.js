const express = require("express");
const axios = require("axios");
const svgCaptcha = require("svg-captcha");
const app = express();

app.use(express.json());

app.post("/verify-recaptcha", async (req, res) => {
  const { token } = req.body;
  const secretKey = "ваш-секретный-ключ";

  try {
    const response = await axios.post(
      `https://www.google.com/recaptcha/api/siteverify?secret=${secretKey}&response=${token}`
    );

    const { success, score } = response.data;

    if (success && score >= 0.5) {
      // Капча пройдена
      res.json({ success: true, message: "reCAPTCHA успешно пройдена!" });
    } else {
      // Капча не пройдена
      res.json({ success: false, message: "Ошибка reCAPTCHA." });
    }
  } catch (error) {
    res.status(500).json({ success: false, message: "Ошибка сервера." });
  }
});

app.get("/captcha", function (req, res) {
  var captcha = svgCaptcha.create();

  res.status(200).send(captcha.data);
});

app.listen(3000, () => {
  console.log("Сервер запущен на http://localhost:3000");
});
