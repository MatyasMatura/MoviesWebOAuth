import { useState, useEffect } from "react";
import { Alert, Spinner, Table, Col } from "reactstrap";
import axios from "axios";
import { useParams } from "react-router-dom";
import AddReview from "./AddReview";
import { useAuthContext } from "../providers/AuthProvider";
import ReviewDetail from "./ReviewDetail";

const MovieDetail = ({mId}) => {
    const { id } = useParams();
    const [item, setItem] = useState([]);
    const [change, setChange] = useState(false);
    const [error, setError] = useState(false);
    const [{ accessToken }] = useAuthContext();
    const [isLoading, setIsLoading] = useState(false);
    useEffect(() => {
        console.log(id);
        setIsLoading(true);
        setError(false);
        if (mId != null) {
            axios.get(`api/movies/${mId}`)
                .then(response => {
                    setItem(response.data);
                    setChange(false);
                })
                .catch(error => {
                    setItem([]);
                    setError(true);
                })
                .then(() => {
                    setIsLoading(false);
                })
        }
        else {
            axios.get(`api/movies/${id}`)
                .then(response => {
                    setItem(response.data);
                    setChange(false);
                })
                .catch(error => {
                    setItem([]);
                    setError(true);
                })
                .then(() => {
                    setIsLoading(false);
                })
        }
    }, [id, change]);

    if (isLoading) {
        return <Spinner />;
    }
    else if (error) {
        return <Alert color="danger">There was an error with loading this page.</Alert>
    }
    else if (item) {
        return (
            <>
                <div className="d-flex justify-content-center">
                    <div className="panel bg-dark p-5 radius detail">
                        <h1 class="text-center text-white">{item.name}</h1>
                        <p className="text-center text-white score">{item.score}%</p>
                        <p className="text-white">Year: {item.year}</p>
                        <p className="text-white">Director: {item.director}</p>
                        <p className="text-white">About: {item.description}</p>
                    </div>
                </div>
                {
                    accessToken
                        ?
                        <AddReview setChange={setChange} />
                        :
                        <></>
                }
                <h2 class="text-center m-0">Reviews</h2>
                <ReviewDetail id={id} />
            </>            
        );
    }
    else {
        return (
            <Spinner />
        );
    }
}

export default MovieDetail;