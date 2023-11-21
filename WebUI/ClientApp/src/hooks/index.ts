
// Tips for building custom hooks

// 1. Start by identifying logic across your scryRenderedComponentsWithType
// 2. Extract this logic into a function named use prefix.
// 3. Each custom hook should be responsible for a single piece of functionality

import { useState, useEffect } from "react";

export function useFetch(url: string) {
    const [data, setData] = useState<any>(null);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            setLoading(true)
            setError(null)

            try {
                const response: any = await fetch(url);

                if (!response.ok) {
                    throw new Error(`An error occurred: ${response.statusText}`);
                }

                const jsonData = await response.json()
                setData(jsonData)
            } catch (error: any) {
                setError(error.message)
            } finally {
                setLoading(false);
            }
        }

        fetchData();
    }, [url])

    return { data, loading, error }
}


export function useFormInput(initialValue) {
    const [value, setValue] = useState(initialValue);

    const handleChange = (e) => {
        setValue(e.target.value)
    }

    return {
        value,
        onChange: handleChange
    }
}