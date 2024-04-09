import { ListGroup, ListGroupItem } from 'reactstrap';
import { Link } from "react-router-dom";
import './NavMenu.css';

const MoviesList = ({ items, setClicked }) => {
    if (items.length > 0) {
        return (
            <ListGroup className="dropdown-menu p-0 search">
                {items.map((item, index) =>
                (
                    <ListGroupItem onClick={() => setClicked("")} className="dropdown-item" key={index} tag={Link} to={"/detail/" + item.id} >{item.name}</ListGroupItem>
                ))}
            </ListGroup>
        );
    }
    else {
        return (
            <ListGroup className="dropdown-menu p-0 search">
                <ListGroupItem className="dropdown-item">Nothing found</ListGroupItem>
            </ListGroup>
        );
    }

}

export default MoviesList;