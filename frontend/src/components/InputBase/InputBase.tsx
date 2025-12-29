import { FichaContext } from "@/context";
import { useContext } from "react";
import "./InputBase.css";

interface Props {
  label: string;
  content: string;
  width?: string | "100%";
}

export default function InputBase(props: Props) {
  const fichaCtx = useContext(FichaContext);
  const key = props.content as keyof typeof fichaCtx.ficha.gerais;

  return <div className="inpt-base">
    <input
      style={{width: props.width}}
      value={fichaCtx.ficha.gerais[key] ?? ""}
      onChange={(e) => fichaCtx.setFicha({...fichaCtx.ficha, gerais: {...fichaCtx.ficha.gerais, [key]: e.target.value}})}
    />
    
    <label>{props.label}</label>
  </div>
}
