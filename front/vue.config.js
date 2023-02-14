const { defineConfig } = require('@vue/cli-service');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = defineConfig({
  publicPath: '/',
  transpileDependencies: true,
  chainWebpack: config => {
    config.optimization.minimize(true);
    config.optimization.splitChunks({
      chunks: 'all',
      minSize: 1000 * 600
    })
  },
  css: {
    extract: true
  },
  configureWebpack: {
    optimization: {
      minimizer: [new UglifyJsPlugin()],
    }
  }
})
