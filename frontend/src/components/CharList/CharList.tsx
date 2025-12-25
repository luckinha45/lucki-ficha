import './CharList.css';
import Char from '../Char/Char';
import type { FichaT20 } from '@/types/FichaT20';

interface Props {
  fichas: FichaT20[];
}

export default function CharList(props: Props) {

  return <div className='flex-cards'>
    {
      props.fichas.map(char => { return <Char key={char.id} id={char.id} name={char.nome} img={char.imgUrl} /> })
    }
  </div>
}
