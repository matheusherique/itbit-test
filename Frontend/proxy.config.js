const proxy = [
    {
        "/api": {
          "target": "https://localhost:5001",
          "secure": true,
          "pathRewrite": {
          "^/api": ""
        },
          "changeOrigin": true
        }
      }
  ];
  module.exports = proxy;