import './App.css';
import {createBrowserRouter, RouterProvider} from 'react-router-dom';
import HomePage from './Pages/HomePage';
import Layout from './Pages/Layout';
import Products from './Components/Products';
import 'bootstrap/dist/css/bootstrap.min.css';
import RegisterComponent from './Components/RegisterComponent';
import LoginComponent from './Components/LoginComponent';
import CalorieCounter from './Components/CalorieCounter';
import MyProfile from './Components/MyProfile';
import Workout from './Components/WorkoutComponent';

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
      },
      {
        path: "/products",
        element: <Products />
      },
      {
        path:"/register",
        element: <RegisterComponent />
      },
      {
        path: "/login",
        element: <LoginComponent />
      },
      {
        path: "/calories",
        element: <CalorieCounter />
      },
      {
        path: "/myprofile",
        element: <MyProfile />
      },
      {
        path: "/workout",
        element: <Workout />
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
