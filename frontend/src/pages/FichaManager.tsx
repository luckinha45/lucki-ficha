import type { FichaT20 } from "@/types/FichaT20";
import { useState } from "react";
import { useLoaderData } from "react-router";


export default function FichaManager() {
  const [ficha, setFicha] = useState<FichaT20 | null>(null);

  const selectedFicha = useLoaderData<FichaT20>();
  if (ficha === null && selectedFicha) {
    setFicha(selectedFicha);
  }

  return (
  <div>
    
  </div>
  )
}
