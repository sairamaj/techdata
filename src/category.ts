import { Tip } from "./tip";

export class Category {
    constructor(
        public name: string,
        public type: string,
        public tips: Tip[]) {}
}