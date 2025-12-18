import { type Uuid, NewUuid } from '../Uuid';


type SheetAttrs = {
    usrId: Uuid;
    name: string;
    level: number;
    className: string | null;
    race: string | null;
    img: string | null;
}

export class Sheet {
    readonly id: Uuid;
    usrId: Uuid;
    name: string;
    level: number;
    className: string | null;
    race: string | null;
    img: string | null;
    createdAt: Date;
    updatedAt: Date;

    constructor({usrId, name, level, className, race, img}: SheetAttrs) {
        this.id = NewUuid();
        this.usrId = usrId;
        this.name = name;
        this.level = level;
        this.className = className;
        this.race = race;
        this.img = img;
        this.createdAt = new Date();
        this.updatedAt = new Date();
    }
}