import * as path from 'path';
import { Tip } from "./tip";
const YAML = require("yamljs");
const aw = require('await-fs');

export class TipManager {
    async getTips(dir: string): Promise<Array<Tip>> {
        let files = await aw.readdir(dir)
        let tips = []

        for (var f of files) {
            var filePath = `${dir}/${f}`
            tips.push(YAML.parse(await aw.readFile(filePath, 'utf8')))
        }

        return tips;
    }
}