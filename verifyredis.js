var redis = require("redis");
var bluebird = require("bluebird");

bluebird.promisifyAll(redis.RedisClient.prototype);

async function verify(dir, cacheConnection) {
    var categoriesKey = `techdata.${dir}.categories`
    let categories = JSON.parse(await cacheConnection.getAsync(categoriesKey))
    console.log(categories)
    categories.forEach( async c=>{
        var tipKey = `techdata.${dir}.category.${c.name}.${c.type}`
        console.log(tipKey)
        let tipData = await cacheConnection.getAsync(tipKey)
        console.log(tipData)
        console.log('---------------------------------')
    })
}

var cacheConnection = redis.createClient(6380, process.env.REDISCACHEHOSTNAME,
    { auth_pass: process.env.REDISCACHEKEY, tls: { servername: process.env.REDISCACHEHOSTNAME } });


verify('techtips', cacheConnection).then(() => {
    console.log('verify is done...')
    cacheConnection.quit()
})