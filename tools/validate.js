var fs = require("fs");
const YAML = require("yamljs");

function validate(dir){
    return fs.readdirSync(dir)
    .filter(f=> f.endsWith('yaml'))
    .forEach(f => {
        console.log(f)
        var fileName = `${dir}\\${f}`
        var data = fs.readFileSync(fileName,'utf-8');
        try{
            YAML.parse(data);
        }catch(err){
            console.error(err)
            process.exit(-2)
        }
    });
}

validate('techtips')
validate('techtasks//azure')
  

