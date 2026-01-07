import { FichaContext } from "@/context";
import { useContext } from "react";
import "./InputAttr.css";

interface Props {
  label: string;
  content: string;
}

export default function InputAttr(props: Props) {
  const fichaCtx = useContext(FichaContext);
  const key = props.content as keyof typeof fichaCtx.ficha.atributos;

  return <div className="inpt-attr">
    <input
      value={fichaCtx.ficha.atributos[key] ?? ""}
      onChange={(e) => fichaCtx.setFicha({...fichaCtx.ficha, atributos: {...fichaCtx.ficha.atributos, [key]: e.target.value}})}
    />
    
    <label>{props.label}</label>
  </div>
}
