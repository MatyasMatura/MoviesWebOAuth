//import { useRequireAuth } from "./Auth/useRequireAuth";
import { useState, useEffect, useCallback } from "react";
import { useAuthContext } from "../providers/AuthProvider";
import { UncontrolledCollapse, Button, ListGroup, ListGroupItem, Alert, Spinner } from 'reactstrap';
import axios from "axios";
import ReviewDetail from "./ReviewDetail";


const Dashboard = () => {
    const [{ accessToken, profile }] = useAuthContext();
    const [movies, setMovies] = useState([]);
    const [users, setUsers] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(false);
    
    //useRequireAuth();
    const FetchData = () => {
        if (profile) {
            if (profile.playground_admin == "1") {
                console.log("You have to press like or dislike");
                axios.get("api/movies", {
                    headers: {
                        "Content-Type": "application/json",
                    }
                })
                    .then((response) => {
                        setMovies(response.data);
                    }).catch((error) => {
                        setError(true);
                        console.log(error);
                        console.log(error.response);
                    });

                axios.get("api/user/all", {
                    headers: {
                        "Content-Type": "application/json",
                        Authorization: "Bearer " + accessToken
                    }
                })
                    .then((response) => {
                        setUsers(response.data);
                        console.log(response.data);
                    }).catch((error) => {
                        setError(true);
                        console.log(error);
                        console.log(error.response);
                    });
            }
        }
    }
    const deleteMovie = (id) => {
        axios.delete("api/movies/" + id, {
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + accessToken
            }
        })
            .then(() => {
                alert("Deleted successfully")
                FetchData();
            }).catch((error) => {
                setError(true);
                console.log(error);
                console.log(error.response);
            });
    }
    useEffect(() => {
        FetchData();
        console.log(profile);
        if (profile) {
            console.log("xd");
        }
    }, [profile]);

    if (profile) {
        if (profile.playground_admin == "1") {
            return (
                <>
                    <h2>Users</h2>
                    <Button color="primary" id={"togglerUsers"} style={{ marginBottom: '1rem' }}>
                        Toggle
                    </Button>
                    <UncontrolledCollapse toggler={"togglerUsers"}>
                    <ListGroup>
                        {
                            users.map((user, index) =>
                            (
                                <ListGroupItem>
                                    {user.name}
                                    <Button color="primary" id={"togglerU" + index} style={{ marginBottom: '1rem' }}>
                                        Toggle
                                    </Button>
                                    <UncontrolledCollapse toggler={"togglerU" + index}>
                                        <ReviewDetail id={user.id} />
                                        <p>{index}</p>
                                    </UncontrolledCollapse>
                                </ListGroupItem>
                            )
                            )
                        }
                        </ListGroup>
                    </UncontrolledCollapse>
                    <h2>Movies</h2>
                    <Button color="primary" id={"togglerMovies"} style={{ marginBottom: '1rem' }}>
                        Toggle
                    </Button>
                    <UncontrolledCollapse toggler={"togglerMovies"}>
                        <ListGroup>
                            {
                                movies.map((item, index) =>
                                (
                                    <ListGroupItem>
                                        {item.name}
                                        <Button className="bi bi-trash-fill mx-2" onClick={() => deleteMovie(item.id)} color="danger"></Button>
                                    </ListGroupItem>
                                )
                                )
                            }
                        </ListGroup>
                    </UncontrolledCollapse>
                </>
            );
        }
    }
    return <Alert color="danger">There was an error with loading this page.</Alert>
}

export default Dashboard;