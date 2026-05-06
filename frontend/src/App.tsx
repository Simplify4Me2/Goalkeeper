import { Outlet } from "react-router";
import Header from "./components/Header";
import './App.css';

export default function App() {
  return (
    <div className="app-container">
      <Header />
      <main className="flex-1">
        <Outlet />
      </main>
    </div>
  );
}
