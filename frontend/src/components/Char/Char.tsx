import './Char.css'

import noImg from '@assets/no-img.png'

interface Props {
  name: string;
  img: string | null;
  description: string;
}

export default function Char(props: Props) {
  return (
    <div className="char" onClick={() => window.location.href = 'https://www.youtube.com/watch?v=dQw4w9WgXcQ'}>
      <img className="char-image"
        src={props.img ?? noImg}
        alt={props.name}
      />
      <h2 className="char-name">{props.name}</h2>
      <p className="info">{props.description}</p>
    </div>
  )
}