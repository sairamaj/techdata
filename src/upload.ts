import { TipManager } from "./tipmanager";
import {Tip} from "./tip";

import { RedisProxy } from "./redisProxy";
const path = require('path')

class Uploader{
    async uploadAsync(dir:string){
        console.log('in uploading...')
        let categories = await new TipManager(dir).getCategories()        
        
        let redisCategories = []
        for( var category of categories){
            var tipKey = `techdata.${dir}.category.${category.name}.${category.type}`
            console.log(tipKey)
            redisCategories.push({
                name : category.name,
                type: category.type
            })
            console.log(`redis.set ${category.name}`)
            RedisProxy.setAsync(tipKey, JSON.stringify(category.tips))
        }

        var categoriesKey = `techdata.${dir}.categories`
        RedisProxy.setAsync(categoriesKey, JSON.stringify(redisCategories))
    }
}

new Uploader().uploadAsync('techtips')
.then(result=>{
    console.log("success.")
    RedisProxy.close();
})
.catch(err=>{
    console.log('error:' + JSON.stringify(err))
    console.log(err.stack)
    RedisProxy.close();
});