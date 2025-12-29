import { useState } from 'react'
import './Home.css'
import CharList from '@components/CharList/CharList'
import SearchBar from '@components/SearchBar/SearchBar'
import { Link, useLoaderData, useNavigate } from 'react-router';
import type { FichaT20 } from '@/types/FichaT20';
import { api } from '@/services/api';

export default function Home() {
  const [filterChar, setFilterChar] = useState('');
  const getSearch = (search: string) => {
    setFilterChar(search);
  }

  const fichas = useLoaderData<FichaT20[]>();
  const navigate = useNavigate();

  const body = {'gerais': {'nome': 'Novo Personagem'}};

  function createFicha() {
    api.post('/ficha-t20', body).then(resp => { navigate('/ficha/' + resp.data.id) });
  }

  return (
    <>
      <h1 className='title'>LuckiFicha 🔥!</h1>
      <SearchBar propagateSearch={getSearch} />
      <CharList fichas={
        fichas.filter(char => char.gerais.nome.toLowerCase().includes(filterChar.toLowerCase()))
        .sort((a, b) => a.gerais.nome.localeCompare(b.gerais.nome))
        }
      />

      {/* <Link to="/ficha" style={{ textDecoration: 'none' }}> */}
        <button onClick={createFicha} className='btn-new-char'>+</button>
      {/* </Link> */}
    </>
  )
}
