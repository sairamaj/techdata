import { TipManager } from "./tipmanager";
const path = require('path')

class Uploader{
    async uploadAsync(){
        console.log('in uploading...')
        var tips = await new TipManager().getTips(`techtips`)        
        console.log(tips.length)
    }
}

new Uploader().uploadAsync()