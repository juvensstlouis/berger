import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import CreateChurch from "./pages/CreateChurch";
import Home from "./pages/Home";
import NotFound from "./pages/NotFound";
import SignIn from "./pages/SignIn";
import SignUp from "./pages/SignUp";

import { isAuthenticated } from "./services/auth";

const PrivateRoute = ({ component: Component, ...rest } : any) => (
  <Route
    {...rest}
    render={props =>
    isAuthenticated() ? (
        <Component {...props} />
      ) : (
        <Redirect to={{ pathname: "/sign-in", state: { from: props.location } }} />
      )
    }
  />
);

const Routes = () => (
  <BrowserRouter>
    <Switch>
      {isAuthenticated() ? <Redirect to={{ pathname: "/" }} /> :  <Route path="/sign-up" component={SignUp} /> }
      {isAuthenticated() ? <Redirect to={{ pathname: "/" }} /> :  <Route path="/sign-in" component={SignIn} /> }
      <PrivateRoute path="/" component={Home} />
      <PrivateRoute path="/create-church" component={CreateChurch} />
      <Route path="*" component={NotFound} />
    </Switch>
  </BrowserRouter>
);

export default Routes;