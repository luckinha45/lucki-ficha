import type { LoaderFunctionArgs } from "react-router";
import { api } from "./services/api";
import type { FichaT20 } from "./types/FichaT20";

export async function fichaLoader({ params }: LoaderFunctionArgs) {
  const fichaId = params.id;
  
  if (fichaId) {
    try {
      const resp = await api.get('/ficha-t20/' + fichaId);
      return resp.data as FichaT20;
    }
    catch (err) {
      console.error('Error fetching fichas:', err);
      return null;
    }
  }
}