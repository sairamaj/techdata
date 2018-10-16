const $ = require('./helpers');
const path = require('path')


const uglifyJSPlugin = require('uglifyjs-webpack-plugin');
const copyWebpackPlugin = require('copy-webpack-plugin');

module.exports = {
  target: 'node',
  entry: {
    'upload': $.root('./src/upload.ts'),
  },
  output: {
    path: $.root('dist'),
    filename: '[name]/upload.js',
    libraryTarget: 'commonjs2'
  },
  module: {
    rules: [
      {
        test: /\.ts$/,
        use: 'awesome-typescript-loader?declaration=false',
        exclude: [/\.(spec|e2e)\.ts$/]
      }
    ]
  },
  resolve: {
    extensions: ['.ts', '.js', '.json'],
    alias: {
      'hiredis': path.resolve(__dirname, './aliases/hiredis.js')
    },
    modules: [
      'node_modules',
      'src'
    ]
  },
  plugins: [
    new uglifyJSPlugin({
      uglifyOptions: {
        ecma: 6
      }
    }),
    new copyWebpackPlugin([
    ])
  ],
  node: {
    __filename: false,
    __dirname: false,
  }
};
