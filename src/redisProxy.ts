var redis = require("redis");
var bluebird = require("bluebird");

bluebird.promisifyAll(redis.RedisClient.prototype);

export class RedisProxy {
  static CacheConnection
  static getConnection() {
    if (RedisProxy.CacheConnection !== undefined) {
      return RedisProxy.CacheConnection
    }

    console.log('creating cache connection.')
    RedisProxy.CacheConnection = redis.createClient(6380, process.env.REDISCACHEHOSTNAME,
      { auth_pass: process.env.REDISCACHEKEY, tls: { servername: process.env.REDISCACHEHOSTNAME } });

    return RedisProxy.CacheConnection;
  }

  static async getAsync(key: string): Promise<string> {
    return await RedisProxy.getConnection().getAsync(key)
  }

  static async setAsync(key: string, data: string): Promise<any> {
    return await RedisProxy.getConnection().setAsync(key, data)
  }

  static close(){
    RedisProxy.getConnection().quit()
  }
}