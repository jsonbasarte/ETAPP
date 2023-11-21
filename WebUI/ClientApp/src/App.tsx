import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { useFormInput, useFetch } from './hooks'

function App() {
  const [count, setCount] = useState(0)
  const {  data, loading, error } = useFetch('https://jsonplaceholder.typicode.com/todos/1')

  const name = useFormInput('');
  const age = useFormInput('');

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(`Name: ${name.value}, Age: ${age.value}`)
  }

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>

      <form onSubmit={handleSubmit}>
        <div>
          <label>Name: </label>
          <input type="text" {...name} />
        </div>
        <div>
          <label>Age: </label>
          <input type="number" {...age} />
        </div>
        <button type="submit">Submit</button>
      </form>

      <pre><h2>{loading ? 'Fetching data...' : null}</h2>
      {error ?? 'No error'}
      {
        data ? <>
          <div>User Id: {data.userId}</div>
          <div>Title: {data.title}</div>
        </>
        : null
      }
      </pre>
    </>
  )
}

export default App
