import { useState } from 'react'
import './App.css'
import CharList from './components/CharList/CharList'
import SearchBar from './components/SearchBar/SearchBar'

function App() {
  const [filterChar, setFilterChar] = useState('');
  const getSearch = (search: string) => {
    setFilterChar(search);
  }
  return (
    <>
      <h1 className='title'>Cards Massa 🔥!</h1>
      <SearchBar propagateSearch={getSearch} />
      <CharList filter={filterChar} />
    </>
  )
}


export default App
