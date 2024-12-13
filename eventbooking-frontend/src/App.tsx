import PrimaryButton from "./components/ui/Buttons/PrimaryButton/PrimaryButton"
import SecondaryButton from "./components/ui/Buttons/SecondaryButton/SecondaryButton"

function App() {

  return (
    <>
        <PrimaryButton text='Login' variant='default' link='/login' />
        <SecondaryButton text='Book Now' variant='active' link='/book' />
    </>
  )
}

export default App
