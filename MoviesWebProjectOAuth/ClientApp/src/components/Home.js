import { Alert, Spinner, Card, CardBody, CardTitle, CardText, ListGroup, ListGroupItem, Row, Col } from 'reactstrap';
import { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import './NavMenu.css';

const Home = () => {
    const [items, setItems] = useState([]);
    const [worst, setWorst] = useState([]);
    const [error, setError] = useState(false);
    const [isLoading, setIsLoading] = useState(false);

    const fetchData = () => {
        setIsLoading(true);
        setError(false);
        axios.get("api/movies?scoreOrder=best&limit=10", {
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(response => {
                setItems(response.data);
            })
            .catch(error => {
                setItems([]);
                setError(true);
            })
            .then(() => {
                setIsLoading(false);
            })
        axios.get("api/movies?scoreOrder=worst&limit=10", {
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(response => {
                setWorst(response.data);
            })
            .catch(error => {
                setWorst([]);
                setError(true);
            })
            .then(() => {
                setIsLoading(false);
            })
    }
    useEffect(() => {
        fetchData();
    }, []);

    if (isLoading) {
        return <Spinner />;
    }
    else if (error) {
        return <Alert color="danger">There was an error with loading the drivers.</Alert>
    }
    else if (items) {
        return (
            <Row>
                <Col lg={{ size: '5' }} className="mb-3">
                    <Card color="dark" inverse className="radius" >
                        <CardBody>
                            <CardTitle tag="h2" className="text-center">
                                Best Movies
                            </CardTitle>
                            <CardText>
                                <ListGroup className="list-group-numbered">
                                    {items.map((item, index) => (
                                        <ListGroupItem color="dark" className="bg-dark text-white" key={index}>
                                            <Link to={"/detail/" + item.id} className="text-white link">
                                                {item.name} {item.score}%
                                            </Link>
                                        </ListGroupItem>
                                    ))}
                                </ListGroup>
                            </CardText>
                        </CardBody>
                    </Card>
                </Col>
                <Col lg={{ offset: 2, size: '5' }} className="mb-3">
                    <Card color="dark" inverse className="radius" >
                        <CardBody>
                            <CardTitle tag="h2" className="text-center">
                                Worst Movies
                            </CardTitle>
                            <CardText>
                                <ListGroup className="list-group-numbered">
                                    {worst.map((item, index) => (
                                        <ListGroupItem color="dark" className="bg-dark text-white" key={index}>
                                            <Link to={"/detail/" + item.id} className="text-white link">
                                                {item.name} {item.score}%
                                            </Link>                                           
                                        </ListGroupItem>
                                    ))}
                                </ListGroup>
                            </CardText>
                        </CardBody>
                    </Card>
                </Col>
            </Row>
        );
    }
    else {
        return (
            <Spinner />
        );
    }
}

export default Home;