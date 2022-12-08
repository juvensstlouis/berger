import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import CreateChurchPage from "./pages/create-church";
import CreatePersonPage from "./pages/create-person";
import HomePage from "./pages/home";
import SignInPage from "./pages/sign-in";
import SignUpPage from "./pages/sign-up";
import ViewPeoplePage from "./pages/view-people";
import { isAuthenticated } from "./services/auth";

const Routes = () => (
  <BrowserRouter>
    <Switch>
      <Route path="/sign-in" component={SignInPage} />
      <Route path="/sign-up" component={SignUpPage} />
      <Route path="/create-church" component={CreateChurchPage} />
      <Route path="/create-person" component={CreatePersonPage} />
      <Route path="/view-people" component={ViewPeoplePage} />
      <Route path="/" component={HomePage} />
    </Switch>
  </BrowserRouter>
);

export const AuthenticatedPage = ({
  children,
  className,
}: {
  children: React.ReactNode;
  className: string;
}) => {
  return isAuthenticated() ? (
    <div className={"page " + className}>{children}</div>
  ) : (
    <Redirect to={{ pathname: "/sign-in" }} />
  );
};

export const UnauthenticatedPage = ({
  children,
  className,
}: {
  children: React.ReactNode;
  className: string;
}) => {
  return !isAuthenticated() ? (
    <div className={"page " + className}>{children}</div>
  ) : (
    <Redirect to={{ pathname: "/" }} />
  );
};

export default Routes;
