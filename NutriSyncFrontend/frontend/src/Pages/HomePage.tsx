import HomeCards from "../Components/HomeCards";
import HomeCarousel from "../Components/HomeCarousel";
import HomeComponent from "../Components/HomeComponent"
const HomePage: React.FC = () => {

return( 
    <>
        <HomeComponent />
        <HomeCarousel />
        <HomeCards />
    </>
)
}

export default HomePage;