import { useState, useEffect } from 'react';
import { useAuthContext } from "../providers/AuthProvider";
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Nav, Spinner, Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import Search from "./Search";

export const NavMenu = props => {
    const [{ profile, accessToken, isUserLoading, userManager }] = useAuthContext();
    const [isOpen, setIsOpen] = useState(false);
    const [isAdmin, setIsAdmin] = useState(false);
    const toggle = () => setIsOpen(!isOpen);

    useEffect(() => {
        if (profile) {
            if (profile.playground_admin == "1") {
                setIsAdmin(true);
            }
        }
    }, [profile]);

    return (
        <header>
            <Navbar color="dark" className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" dark>
                <Container>
                    <NavbarBrand className="title" tag={Link} to="/">MWPOA</NavbarBrand>
                    <NavbarBrand>
                        <Search/>
                    </NavbarBrand>
                    <NavbarToggler onClick={toggle} />
                    <Collapse isOpen={isOpen} navbar>
                        <Nav className="me-auto" navbar>
                            <NavItem>
                                <NavLink className="link" tag={Link} to="/">Home</NavLink>
                            </NavItem>
                            {
                                accessToken
                                    ?
                                    <NavItem>
                                        <NavLink className="link" tag={Link} to="/create">Add Movie</NavLink>
                                    </NavItem>
                                    :
                                    <></>
                            }
                            {
                                isAdmin
                                    ?
                                    <NavItem>
                                        <NavLink className="link" tag={Link} to="/dashboard">Dashboard</NavLink>
                                    </NavItem>
                                    :
                                    <></>
                            }
                        </Nav>
                        <Nav className="ml-auto" navbar>
                            <NavItem>
                                {
                                    isUserLoading
                                        ?
                                        <Spinner size="sm" />
                                        :
                                        <NavLink tag={Link} to="/">{accessToken ? profile.name : ""}</NavLink>
                                }
                            </NavItem>
                            <NavItem>
                                {
                                    accessToken
                                        ?
                                        <Button className="px-0 link" color="dark" onClick={() => { userManager.signoutRedirect() }}>Sign out</Button>
                                        :
                                        <Button className="px-0 link" color="dark" onClick={() => { userManager.signinRedirect() }}>Sign in</Button>
                                }
                            </NavItem>
                        </Nav>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    )
}
