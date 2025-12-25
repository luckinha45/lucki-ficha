import { useState } from 'react'
import './Home.css'
import CharList from '@components/CharList/CharList'
import SearchBar from '@components/SearchBar/SearchBar'
import { Link, useLoaderData } from 'react-router';
import type { FichaT20 } from '@/types/FichaT20';

export default function Home() {
  const [filterChar, setFilterChar] = useState('');
  const getSearch = (search: string) => {
    setFilterChar(search);
  }

  const fichas = useLoaderData<FichaT20[]>();

  return (
    <>
      <h1 className='title'>LuckiFicha 🔥!</h1>
      <SearchBar propagateSearch={getSearch} />
      <CharList fichas={
        fichas.filter(char => char.nome.toLowerCase().includes(filterChar.toLowerCase()))
        .sort((a, b) => a.nome.localeCompare(b.nome))
        }
      />

      <Link to="/ficha" style={{ textDecoration: 'none' }}>
        <button className='btn-new-char'>+</button>
      </Link>
    </>
  )
}
