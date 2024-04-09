import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export const Layout = ({ children, ...rest }) => {
    return (
        <div>
            <NavMenu />
            <Container>
                {children}
            </Container>
        </div>
    );
}

export default Layout;