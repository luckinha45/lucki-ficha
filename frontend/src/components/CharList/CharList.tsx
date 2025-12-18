import './CharList.css';
import Char from '../Char/Char';
import { useEffect, useState } from 'react';
import { api } from 'services/api';
import type { MdlSheet } from 'types/MdlSheet';

interface Props {
  filter: string;
}

export default function CharList(props: Props) {
  const [chars, setChars] = useState<MdlSheet[]>();

  useEffect(() => {
    api.get('/fichas').then(res => {
      setChars(res.data);
    });
  }, []);

  return <div className='flex-cards'>
    {chars == null || chars === undefined ? <p>Loading...</p> : chars
      .filter(char => char.Name.toLowerCase().includes(props.filter.toLowerCase()))
      .map((char, idx) => {
        return <Char
          key={char.Id}
          name={char.Name}
          img={char.ImgUrl}
        />
    })
    .sort((a, b) => a.props.name.localeCompare(b.props.name))
    }
  </div>
}
