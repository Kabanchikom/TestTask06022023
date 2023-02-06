const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
  transpileDependencies: true,
  chainWebpack: config => {
    config.optimization.minimize(true);
    config.optimization.splitChunks({
      chunks: 'all'
    });
  },
  css: {
    extract: true
  }
})
