import './index.css'
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { createBrowserRouter } from 'react-router'
import { RouterProvider } from 'react-router'
import { api } from '@services/api';
import { fichaLoader } from './loaders.ts';


import Home from './pages/Home.tsx'
import FichaManager from '@/pages/FichaManager.tsx'

const router = createBrowserRouter([
  {
    path: '/',
    Component: Home,
    loader: async () => {
      try {
        const resp = await api.get('/ficha-t20');
        return resp.data;
      }
      catch (err) {
        console.error('Error fetching fichas:', err);
        return null;
      }
    },
  },
  {
    path: 'ficha/:id?',
    loader: fichaLoader,
    Component: FichaManager,
  }
])

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
