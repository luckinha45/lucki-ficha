import './CharList.css';
import type { Uuid } from 'models/Uuid';
import Char from '../Char/Char';
import { SheetT20 } from 'models/Sheet/SheetT20';


// char list
const chars = [
  new SheetT20({
    usrId:'usr-uuid-example' as Uuid,
    name: 'Balthazar Eurix III 👊',
    level: 1,
    className: "Lutador",
    race: "Humano",
    img: 'https://i.pinimg.com/1200x/af/09/45/af09458de49657060b26e17eb15f619b.jpg'
  }),
  new SheetT20({
    usrId:'usr-uuid-example' as Uuid,
    name: 'Luna',
    level: 5,
    className: "Bárbaro",
    race: "Meio Orc",
    img: null
  }),
  new SheetT20({
    usrId:'usr2-uuid-example' as Uuid,
    name: 'Orion',
    level: 3,
    className: 'Caçador',
    race: "Elfo",
    img: 'https://i.pinimg.com/736x/33/e8/2f/33e82f4caacbf7f880a4802c0298167e.jpg'
  }),
  new SheetT20({
    usrId:'usr2-uuid-example' as Uuid,
    name: 'Selene',
    level: 13,
    className: 'Arcanista',
    race: "Elfo",
    img: null
  }),
  new SheetT20({
    usrId:'usr2-uuid-example' as Uuid,
    name: 'Drake',
    level: 7,
    className: 'Arcanista',
    race: 'Qareen',
    img: null
  }),
  new SheetT20({
    usrId:'usr3-uuid-example' as Uuid,
    name: 'Mira',
    level: 4,
    className: "Ladino",
    race: "Goblin",
    img: 'https://i.pinimg.com/1200x/f2/48/be/f248be4c27f4d7174abc817ff27fbde1.jpg',
  })
]

interface Props {
  filter: string;
}

export default function CharList(props: Props) {
  return <div className='flex-cards'>
    {chars
      .filter(char => char.name.toLowerCase().includes(props.filter.toLowerCase()))
      .map((char, idx) => {
        return <Char
          key={idx}
          name={char.name}
          img={char.img}
          description={char.className+' Lvl '+char.level}
        />
    })}
  </div>
}
