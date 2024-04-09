import { useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useForm } from "react-hook-form";
import { Alert } from "reactstrap";
import { useAuthContext } from "../providers/AuthProvider";
import { useParams } from "react-router-dom";
import axios from 'axios';

const AddReview = ({ setChange }) => {
    const { id } = useParams();
    const [{ accessToken, profile }] = useAuthContext();
    const { register, handleSubmit } = useForm({
        defaultValues: {
            content: "",
            author: profile.name,
            liked: null,
            movieId: id,
            userId: profile.sub
        }
    })
    const [error, setError] = useState(false);
    const [liked, setLiked] = useState(null);

    const [likeButton, setLikeButton] = useState("bi-hand-thumbs-up");
    const [dislikeButton, setDislikeButton] = useState("mx-2 bi-hand-thumbs-down");

    const [errorData, setErrorData] = useState("");
    const AddItem = (value) => {
        if (liked == null) {
            alert("You have to press like or dislike");
        }
        else {
            value.liked = liked;
            console.log(value);
        axios.post("api/reviews/", value, {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + accessToken
                }
            })
                .then((res) => {
                    setChange(true);
                }).catch((error) => {
                    setError(true);
                    setErrorData(error.response.data);
                    console.log(error);
                    console.log(error.response);
                });
        }
    }
    const LikeButton = () => {
        if (liked == true) {
            setLikeButton("bi-hand-thumbs-up");
            setLiked(null);
        }
        else {
            setLikeButton("bi-hand-thumbs-up-fill");
            setDislikeButton("mx-2 bi-hand-thumbs-down");
        }
    }
    const DisLikeButton = () => {
        if (liked == false) {
            setDislikeButton("mx-2 bi-hand-thumbs-down");
            setLiked(null);
        }
        else {
            setDislikeButton("mx-2 bi-hand-thumbs-down-fill");
            setLikeButton("bi-hand-thumbs-up");
        }
    }
    if (!accessToken) {
        return <Alert color="danger">You have to be Signed in</Alert>
    }
    else if (error) {
        return <Alert color="danger">{errorData}</Alert>
    } else
        return (
            <div className="d-flex justify-content-center mt-4">
                <div className="panel bg-dark radius p-3">
                    <Button onClick={() => { setLiked(true); LikeButton() }} className={likeButton} variant="dark" type="submit"> Like</Button>
                    <Button onClick={() => { setLiked(false); DisLikeButton() }} className={dislikeButton} variant="dark" type="submit"> Dislike</Button>
                    <Form onSubmit={handleSubmit((data) => { console.log(data); AddItem(data) })}>                        
                        <Form.Group className="mb-3 text-white">
                            <Form.Label>Write a review</Form.Label>
                            <Form.Control {...register("content")} as="textarea" rows={3} type="text" placeholder="What is on your mind" />
                        </Form.Group>
                        <div className="d-flex flex-row-reverse">
                            <Button className="ml-auto" variant="light" type="submit">Post review</Button>
                        </div>
                    </Form>
                </div>
            </div>
        );
}

export default AddReview;