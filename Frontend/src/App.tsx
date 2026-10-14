import { Link, Route, Routes } from "react-router-dom";
import CreateStudent from "./students/createStudentPage";
import { StudentListPage } from "./students/studentListPage";

function HomePage() {
  return <h1>Student Scoring System</h1>;
}

export default function App() {
  return (
    <>
      <nav>
        <Link to="/">Home</Link>{" "}
        <Link to="/students/createStudent">Create student</Link>
        <Link to="/students">All students</Link>
      </nav>

      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/students/createStudent" element={<CreateStudent />} />
        <Route path="/students" element={<StudentListPage />} />
      </Routes>
    </>
  );
}