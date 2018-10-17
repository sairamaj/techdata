import { TipManager } from "./tipmanager";
const path = require('path')

class Verifier{
    async verifyAsync(dir:string){
        console.log('in verifying...')
        let categories = await new TipManager(dir).getCategories()        
    }
}

new Verifier().verifyAsync('techtips')
.then(result=>{
    console.log("success.")
})
.catch(err=>{
    console.log('error:' + JSON.stringify(err))
    console.log(err.stack)
});