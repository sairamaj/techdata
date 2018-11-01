const aw = require('await-fs');

var testfun = async function (){
    console.log('readdir')
    let files = await aw.readdir('techtips')
    console.log(files)
}

testfun()
