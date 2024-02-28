const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const TerserPlugin = require('terser-webpack-plugin');
// const CssMinimizerPlugin = require('css-minimizer-webpack-plugin');

module.exports = (env = {}, argv = {}) => {
  const isProd = argv.mode === 'production';

  const config = {
    mode: argv.mode || 'development',
    context: path.join(__dirname, '.'),
    entry: { 'app': './wwwroot/js/index.js' },
    output: {
      filename: isProd ? '[name].min.js' : '[name].js',
      path: path.join(__dirname, './wwwroot/dist'),
      publicPath: '/dist/',
    },
    // devtool: 'source-map',
    plugins: [
      // new CopyWebpackPlugin({
      //   patterns: [
      //     { from: './wwwroot/images', to: 'images' }
      //   ]
      // }),
      new MiniCssExtractPlugin({
        filename: isProd ? '[name].min.css' : '[name].css',
      }),
    ],
    module: {
      rules: [
        {
          test: /\.m?js$/,
          exclude: /node_modules/,
          use: {
            loader: 'babel-loader',
            options: {
              presets: ['@babel/preset-env'],
            },
          },
        },
        {
          test: /\.css$/i,
          use: [MiniCssExtractPlugin.loader, 'css-loader', 'postcss-loader'],
        },
        {
          test: /\.(png|svg|jpg|jpeg|gif)$/i,
          type: 'asset/resource',
        },
        {
          test: /\.(woff|woff2|eot|ttf|otf)$/i,
          type: 'asset/resource',
        }
      ],
    },
    optimization: {
      minimize: isProd,
      minimizer: [
        new TerserPlugin({
          terserOptions: {
            compress: {
              drop_console: true,
            },
            mangle: true,
          },
          extractComments: false,
        }),
        // new CssMinimizerPlugin(),
      ],
    },
  };

  return config;
};
