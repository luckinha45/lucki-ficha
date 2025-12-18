import type { Uuid } from "models/Uuid";
import { Sheet } from "./Sheet";

type SkillT20 = {
    name: string;
    mods: Array<{ type: string; value: number; active: boolean }>;
    isProficient: boolean;
    baseAttribute: AttrT20;
}

type AttrT20 = {
    name: 'forca' | 'destreza' | 'constituicao' | 'inteligencia' | 'sabedoria' | 'carisma';
    mods: Array<{ type: string; value: number }>;
}

type AttrSheetT20 = {
    usrId: Uuid;
    name: string;
    level: number;
    className: string | null;
    race: string | null;
    img: string | null;
}

export class SheetT20 extends Sheet {
    skills: Array<SkillT20>;
    attributes: Array<AttrT20>;

    constructor({usrId, name, level, className, race, img}: AttrSheetT20) {
        super({usrId, name, level, className, race, img});

        this.attributes = [
            { name: "forca", mods: [{ type: "base", value: 0 }] },
            { name: "destreza", mods: [{ type: "base", value: 0 }] },
            { name: "constituicao", mods: [{ type: "base", value: 0 }] },
            { name: "inteligencia", mods: [{ type: "base", value: 0 }] },
            { name: "sabedoria", mods: [{ type: "base", value: 0 }] },
            { name: "carisma", mods: [{ type: "base", value: 0 }] },
        ];


        this.skills = [
            { 
                name: "Atletismo",
                mods: [],
                isProficient: false,
                baseAttribute: this.attributes.find(attr => attr.name === 'forca')!,
            },
            {
                name: "Acrobacia",
                mods: [],
                isProficient: false,
                baseAttribute: this.attributes.find(attr => attr.name === 'destreza')!
            },
            {
                name: "Furtividade",
                mods: [],
                isProficient: false,
                baseAttribute: this.attributes.find(attr => attr.name === 'destreza')!,
            },
            {
                name: "Intimidação",
                mods: [],
                isProficient: false,
                baseAttribute: this.attributes.find(attr => attr.name === 'carisma')!,
            },
        ];
    }
}
