import './App.css';
import {createBrowserRouter, RouterProvider} from 'react-router-dom';
import HomePage from './Pages/HomePage';
import Layout from './Pages/Layout';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {

const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout />,
    errorElement: <Layout />,
    children:[
      {
        path: "/",
        element: <HomePage />
      }
    ]
  }
])

  return (
    <>
      <RouterProvider router={router} />
    </>
  )
}

export default App;
