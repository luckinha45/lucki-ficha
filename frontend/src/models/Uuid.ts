export function NewUuid(): Uuid {
    return crypto.randomUUID() as Uuid;
}

export type Uuid = string & { [TYPE: symbol]: 'Uuid' };