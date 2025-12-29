import InputBase from "@/components/InputBase/InputBase";
import type { FichaT20 } from "@/types/FichaT20";
import { Link, useLoaderData } from "react-router";
import { FichaContext } from "@/context";
import { useState } from "react";
import { api } from "@/services/api";
import noImg from '@assets/no-img.png';
import "./FichaManager.css";


export default function FichaManager() {
  const selectedFicha = useLoaderData<FichaT20>();
  const [ficha, setFicha] = useState<FichaT20>(selectedFicha);

  function updateFicha() {
    if (ficha.gerais.nome.trim() === '') {
      alert('O nome do personagem não pode ser vazio!');
      return;
    }

    api.patch('/ficha-t20/' + ficha.id, ficha).then(() => alert('Ficha salva com sucesso!'));
  }

  return (
  <FichaContext.Provider value={{ficha, setFicha}}>
    <div className="ficha">
      <div className="ficha-header">
        <Link to="/" style={{ textDecoration: 'none' }}> <button>Voltar</button> </Link>
        <button onClick={ updateFicha }>Salvar Ficha</button>
      </div>
      <div className="ficha-body">
        <img className="char-img" src={ficha.gerais.imgUrl ? ficha.gerais.imgUrl : noImg} alt="Character Image" />
        <div className="infos-base">
          <InputBase label="Nome" content='nome' />
          <InputBase label="Raça" content='raca' />
          <InputBase label="Divindade" content='divindade' />
          <InputBase label="Origem" content='origem' />
          <InputBase label="Classe" content='classe' />
          <InputBase label="Nivel" content='nivel' width="30px" />
          <InputBase label="Experiência" content='experiencia' width="50px" />
        </div>
        <div className="pericias">PERICIAS</div>
      </div>
    </div>
  </FichaContext.Provider>
  )
}
