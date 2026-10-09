import { Link, Route, Routes } from "react-router-dom";

function HomePage() {
  return <h1>Student Scoring System</h1>;
}

function AboutPage() {
  return <h1>About Student Scoring System</h1>;
}

export default function App() {
  return (
    <>
      <nav>
        <Link to="/">Home</Link>{" "}
        <Link to="/about">About</Link>
      </nav>

      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/about" element={<AboutPage />} />
      </Routes>
    </>
  );
}