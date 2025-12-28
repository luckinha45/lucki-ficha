import { FichaContext } from "@/context";
import { useContext } from "react";

interface Props {
  label: string;
  content: string;
  width?: string;
}

export default function InputBase(props: Props) {
  const fichaCtx = useContext(FichaContext);
  const width = props.width || "100%";
  const key = props.content as keyof typeof fichaCtx.ficha.gerais;

  console.log(fichaCtx.ficha.gerais);

  return <div className="inpt-base" style={{width: width}}>
    <label>{props.label}</label>
    <input value={fichaCtx.ficha.gerais[key] ?? ""} onChange={(e) => fichaCtx.setFicha({...fichaCtx.ficha, gerais: {...fichaCtx.ficha.gerais, [key]: e.target.value}})} />
  </div>
}
