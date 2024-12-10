import './search.css';
import { RiSearchLine } from '@remixicon/react';

const Search = () => {
  return (
    <form className='search-form'>
        <div className='form-inner-search'>
            <input type='text' placeholder='Find your passion' />
            <button className='search-btn'>
                <RiSearchLine size={20} color='#ffff' className='ri-search' />
            </button>
        </div>
    </form>
  )
}

export default Search;
