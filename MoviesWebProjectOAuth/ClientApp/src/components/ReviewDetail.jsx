import { useState, useEffect } from "react";
import { Alert, Spinner, Button } from "reactstrap";
import axios from "axios";
import { useParams } from "react-router-dom";

const ReviewDetail = ({id}) => {
    //const { id } = useParams();
    const [items, setItems] = useState([]);
    const [error, setError] = useState(false);
    const [limit, setLimit] = useState(5);
    const [isLoading, setIsLoading] = useState(false);
    useEffect(() => {
        console.log(id + "xd");
        setIsLoading(true);
        setError(false);
        axios.get(`api/movies/${id}/reviews?limit=` + limit)
            .then(response => {
                setItems(response.data);
                console.log(response.data);
            })
            .catch(error => {
                setItems([]);
                setError(true);
            })
            .then(() => {
                setIsLoading(false);
            })
    }, [id, limit]);

    if (isLoading) {
        return <Spinner />;
    }
    else if (error) {
        return <Alert color="danger">There was an error with loading this page.</Alert>
    }
    else if (items) {
        return (
            <>
                {
                    items.map(item => (
                        <div className="d-flex justify-content-center">
                            <div className="panel bg-dark p-3 my-2 radius">
                                <p className="text-white">{item.author} {item.liked ? <i style={{ color: "green" }} class="bi bi-hand-thumbs-up-fill"></i> : <i style={{ color: "red" }} class="bi bi-hand-thumbs-down-fill"></i>}</p>
                                <p className="text-white">"{item.content}"</p>
                            </div>
                        </div>
                    ))
                }
                {
                    (items.length % 5) === 0
                        ?
                        <>
                            {
                                (items.length != 0)
                                    ?
                                    <div className="d-flex justify-content-center">
                                        <Button onClick={() => setLimit(limit + 5)} className="text-center m-3 px-5" color="dark" type="submit">Load More </Button>
                                    </div>
                                    :
                                    <></>
                            }
                        </>                        
                        :
                        <></>
                }
            </>
        );
    }
    else {
        return (
            <Spinner />
        );
    }
}

export default ReviewDetail;