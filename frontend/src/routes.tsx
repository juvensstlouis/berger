import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import CreateChurch from "./pages/CreateChurch";
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
        <Redirect to={{ pathname: "/", state: { from: props.location } }} />
      )
    }
  />
);

const Routes = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={SignIn} />
      <Route path="/sign-up" component={SignUp} />
      <PrivateRoute path="/create-church" component={CreateChurch} />
      <Route path="*" component={NotFound} />
    </Switch>
  </BrowserRouter>
);

export default Routes;