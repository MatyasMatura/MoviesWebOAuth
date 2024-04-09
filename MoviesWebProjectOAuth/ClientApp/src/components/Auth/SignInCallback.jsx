import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../../providers/AuthProvider";
import axios from "axios";

export const SignInCallback = props => {
    const [{ userManager }] = useAuthContext();
    let navigate = useNavigate();
    useEffect(() => {
        (async () => {
            const signResult = await userManager.signinRedirectCallback();
            console.log(signResult.profile);

            axios.post("api/user", {
                "userId": signResult.profile.sub,
                "name": signResult.profile.name,
                "email": signResult.profile.email
            }, {
                headers: {
                    "Content-Type": "application/json"
                }
            })
                .then(response => {
                    console.log(response)
                })
                .catch(error => {
                    console.log(error)
                })

            navigate("/");
        })();
    }, [userManager]);
    return null;
}

export default SignInCallback;