import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import { createBrowserRouter, RouterProvider, isRouteErrorResponse, useRouteError } from "react-router";
import App from "./App.tsx";
import { Dashboard } from "./features/Dashboard.tsx";
import { Fixtures } from "./features/Fixtures.tsx";
import { Teams } from "./features/Teams.tsx";
import { Players } from "./features/Players.tsx";

function NotFound() {
  const error = useRouteError();
  const message = isRouteErrorResponse(error) ? `${error.status} ${error.statusText}` : "Page not found";
  return (
    <div className="flex flex-col items-center justify-center flex-1 gap-4 p-8 text-center">
      <h1 className="text-4xl font-bold">{message}</h1>
      <a href="/" className="underline">Go home</a>
    </div>
  );
}

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    errorElement: <NotFound />,
    children: [
      { index: true, element: <Dashboard /> },
      { path: "fixtures", element: <Fixtures /> },
      { path: "teams", element: <Teams /> },
      { path: "players", element: <Players /> },
    ],
  },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
);
