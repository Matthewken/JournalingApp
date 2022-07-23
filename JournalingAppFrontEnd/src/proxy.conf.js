const PROXY_CONFIG = [
  {
    context: ["/api/*"],
    target: process.env.API_SERVER || "https://localhost:7142",
    secure: false,
  },
];

module.exports = PROXY_CONFIG;
