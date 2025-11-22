import Char from '../Char/Char'
import './CharList.css'

// char list
const chars = [
  {
    name: 'Balthazar Eurix III 👊',
    img: 'https://i.pinimg.com/1200x/af/09/45/af09458de49657060b26e17eb15f619b.jpg',
    description: "Humano Lutador Lv 1"
  },
  {
    name: 'Luna',
    img: null,
    description: "Meio Orc Bárbaro Lv 5"
  },
  {
    name: 'Orion',
    img: 'https://i.pinimg.com/736x/33/e8/2f/33e82f4caacbf7f880a4802c0298167e.jpg',
    description: "Elfo Caçador Lv 3"
  },
  {
    name: 'Selene',
    img: null,
    description: "Elfa Arcanista Lv 13"
  },
  {
    name: 'Drake',
    img: null,
    description: "Qareen Arcanista Lv 7"
  },
  {
    name: 'Mira',
    img: 'https://i.pinimg.com/1200x/f2/48/be/f248be4c27f4d7174abc817ff27fbde1.jpg',
    description: "Goblin Ladino Lv 4"
  }
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
          description={char.description}
        />
    })}
  </div>
}
