import InputBase from "@/components/InputBase/InputBase";
import type { FichaT20 } from "@/types/FichaT20";
import { useState } from "react";
import { useLoaderData } from "react-router";
import { FichaContext } from "@/context";


export default function FichaManager() {
  const selectedFicha = useLoaderData<FichaT20>();
  const [ficha, setFicha] = useState<FichaT20>(selectedFicha);

  return (
  <FichaContext.Provider value={{ficha, setFicha}}>
  <div className="ficha-body">
    <div className="infos-base">
        <InputBase label="Nome" content='nome' />
        <InputBase label="Raça" content='raca' />
        <InputBase label="Divindade" content='divindade' />
        <InputBase label="Origem" content='origem' />
        <InputBase label="Classe" content='classe' />
        <InputBase label="Nivel" content='nivel' />
        <InputBase label="Experiência" content='experiencia' />
    </div>
  </div>
  </FichaContext.Provider>
  )
}
