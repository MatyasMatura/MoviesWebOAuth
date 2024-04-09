import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './components/Home';
import { AuthProvider } from "./providers/AuthProvider";
import SignInCallback from "./components/Auth/SignInCallback";
import SignOutCallback from "./components/Auth/SignOutCallback";
import SilentRenewCallback from "./components/Auth/SilentRenewCallback";
import Movie from "./components/MovieDetail";
import AddMovie from "./components/AddMovie";
import Dashboard from "./components/Dashboard";

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <AuthProvider>
                <Layout>
                    <Routes>
                        <Route path="/oidc-callback" element={<SignInCallback />} />
                        <Route path="/oidc-signout-callback" element={<SignOutCallback />} />
                        <Route path="/oidc-silent-renew" element={<SilentRenewCallback />} />
                        <Route index path='/' element={<Home />} />
                        <Route path="/sign-in" element={<Home />} />
                        <Route path="/sign-out" element={<Home />} />
                        <Route path="/detail/:id" element={<Movie />} />
                        <Route path="/create" element={<AddMovie />} />
                        <Route path="/dashboard" element={<Dashboard />} />
                    </Routes>
                </Layout>
            </AuthProvider>
        );
    }
}
