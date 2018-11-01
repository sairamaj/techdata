import * as path from 'path';
import { Tip } from "./tip";
import { Category } from './category';
const YAML = require("yamljs");
const aw = require('await-fs');
const fsp = require('fs-promise');

const debug = require('debug')('tipmanager')

export class TipManager {
    constructor(public dir: string){

    }
    async getCategories(): Promise<Array<Category>> {
        let files = await aw.readdir(this.dir)
        //let files = await fsp.readdir(this.dir)
        let categories = []

        for (var f of files) {
            let tips = await this.loadTips(f)

            var parts = f.split('.')
            var name = parts[0]
            var type = 'command'
            if( parts.length > 2){
                type = parts[1]
            }
    
            categories.push( new Category(name, type, tips) )
        }

        return categories;
    }

    async loadTips(fileName):Promise<Array<Tip>>{
        var filePath = `${this.dir}/${fileName}`
        var data = await aw.readFile(filePath, 'utf8')
        debug(`parsing ${filePath}`)
        try{
            return YAML.parse(data)
        }catch(err){
            debug(`data: ${data}`)
            throw err;
        }
        
    }
}