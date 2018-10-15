var fs = require("fs");
var redis = require("redis");
var bluebird = require("bluebird");

bluebird.promisifyAll(redis.RedisClient.prototype);

async function upload(dir,cacheConnection){
    var categories = []
    fs.readdirSync(dir)
    .filter(f=> f.endsWith('yaml'))
    .forEach(async (f) => {
        var fileName = `${dir}\\${f}`
        var data = fs.readFileSync(fileName,'utf-8');
        var parts = f.split('.')
        var type = 'command'
        var name = parts[0]
        if( parts.length === 3){
            type = parts[1]
        }
        categories.push({ name: name, type: type})
        var tipKey = `techdata.${dir}.category.${name}.${type}`
        console.log('uplading.. ' + tipKey)
        await cacheConnection.setAsync(tipKey, data)
    });

    var categoriesKey = `techdata.${dir}.categories`
    await cacheConnection.setAsync(categoriesKey, JSON.stringify(categories))
    console.log(`uploaded ${categoriesKey}`)
}

var cacheConnection = redis.createClient(6380, process.env.REDISCACHEHOSTNAME, 
    {auth_pass: process.env.REDISCACHEKEY, tls: {servername: process.env.REDISCACHEHOSTNAME}});


upload('techtips',cacheConnection).then(()=>{
    console.log('upload is done...')
    cacheConnection.quit()
})