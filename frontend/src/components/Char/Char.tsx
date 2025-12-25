import { Link } from 'react-router';
import './Char.css'

import noImg from '@assets/no-img.png'

interface Props {
  id: string;
  name: string;
  img: string;
}

export default function Char(props: Props) {
  return (
    <Link to={`/ficha/${props.id}`}  style={{ textDecoration: 'none' }}>
      <div className="char">
        <img className="char-image"
          src={!props.img ? noImg : props.img}
          alt={props.name}
        />
        <h2 className="char-name">{props.name}</h2>
      </div>
    </Link>
  )
}