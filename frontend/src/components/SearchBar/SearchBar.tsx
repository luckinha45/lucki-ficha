import { useState } from "react";
import './SearchBar.css'

interface Props {
  propagateSearch: (search: string) => void;
}

export default function SearchBar(props: Props) {
  const [search, setSearch] = useState('');

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.stopPropagation();
    setSearch(e.target.value);
    props.propagateSearch(e.target.value);
  }

  return <div className="div-search">
    <input className="inpt-search"
      type="text"
      value={search}
      onChange={(e) => handleInputChange(e) }
      placeholder="Pesquise Seu Herói..."
    />
  </div>
}


