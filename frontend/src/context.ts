import { createContext } from "react";
import type { FichaT20 } from "./types/FichaT20";

export const FichaContext = createContext({  ficha: {} as FichaT20, setFicha: (ficha: FichaT20) => {}});