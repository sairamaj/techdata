import { TipManager } from "./tipmanager";
const path = require('path')

class Verifier{
    async verifyAsync(dir:string){
        console.log(`verifying ${dir}`)
        let categories = await new TipManager(dir).getCategories()        
        //console.log(`${categories}`)
    }
}

new Verifier().verifyAsync(`techtips/yaml`)
.then(result=>{
    console.log("success.")
})
.catch(err=>{
    console.log('error:' + JSON.stringify(err))
    console.log(err.stack)
});