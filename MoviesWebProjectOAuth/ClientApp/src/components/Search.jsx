import { InputGroup, InputGroupAddon, Input, Button } from "reactstrap";
import { React, useState, useEffect } from "react";
import axios from "axios";
import MoviesList from "./MoviesList";
import './NavMenu.css';

const Search = () => {
    const [searchText, setSearchText] = useState("");
    const [textLength, setTextLength] = useState(0);
    const [searchResults, setSearchResults] = useState([]);
    const processSearch = (text) => {
        console.log(text);
        console.log(text.length);
        setTextLength(text.length);
        axios.get("api/movies?name=" + text + "&limit=5")
            .then(response => {
                console.log(response);
                setSearchResults(response.data);
            })
    }
    useEffect(() => {
        processSearch(searchText);
    }, [searchText]);
    console.log(textLength);
    return (
        <>
            <Input
                className="search"
                name="search"
                id="search"
                placeholder="Search movies"
                value={searchText}
                onChange={e => {
                    setSearchText(e.target.value);
                    processSearch(e.target.value);
                    console.log(searchText);
                }}
            />
            {textLength === 0 ? <></> : <MoviesList items={searchResults} setClicked={setSearchText} />}
        </>
    );
}

export default Search;