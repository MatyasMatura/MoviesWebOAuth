import { useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useForm } from "react-hook-form";
import { Alert} from "reactstrap";
import { useAuthContext } from "../providers/AuthProvider";
import { useNavigate } from "react-router-dom";
import axios from 'axios';

const AddMovie = () => {
    const { register, handleSubmit } = useForm()
    let navigate = useNavigate();
    const [error, setError] = useState(false);
    const [{ accessToken }] = useAuthContext();
    const AddItem = (value) => {
        console.log(value.year);
        value.year = Number(value.year);
        console.log(value);
        axios.post("api/movies/", value, {
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + accessToken
            }
        })
            .then((res) => {
                navigate("/");
            }).catch((error) => {
                setError(true);
                console.log(error);
                console.log(error.response);
            });
    }
    if (!accessToken) {
        return <Alert color="danger">You have to be Signed in</Alert>
    }
     else if (error) {
         return <Alert color="danger">There was an error.</Alert>
    } else
    return (            
            <div className="d-flex justify-content-center">
                <div className="panel bg-dark p-5 radius">
                    <Form onSubmit={handleSubmit((data) => { console.log(data); AddItem(data) })}>
                        <h1 className="text-center text-white">Add Movie</h1>
                        <Form.Group className="mb-3 text-white">
                            <Form.Label>Movie Name</Form.Label>
                            <Form.Control  {...register("name")} type="text" placeholder="Batman" />
                        </Form.Group>
                        <Form.Group className="mb-3 text-white">
                            <Form.Label>Description</Form.Label>
                            <Form.Control {...register("description")} as="textarea" rows={3} type="text" placeholder="About movie" />
                        </Form.Group>
                        <Form.Group className="mb-3 text-white">
                            <Form.Label>Release year</Form.Label>
                            <Form.Control {...register("year")} type="number" placeholder="2022" />
                        </Form.Group>
                        <Form.Group className="mb-3 text-white">
                            <Form.Label>Director</Form.Label>
                            <Form.Control {...register("director")} type="text" placeholder="Jack Doom" />
                        </Form.Group>
                        <Button variant="light" type="submit">Add Movie</Button>
                    </Form>
                </div>
            </div>                   
    );
}

export default AddMovie;