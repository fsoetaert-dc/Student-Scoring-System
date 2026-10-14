import { keepPreviousData, useQuery } from "@tanstack/react-query";
import { Link, useSearchParams } from "react-router-dom";
import { getStudents } from "./StudentsApi";
import type { FormEvent } from "react";

export function StudentListPage() {
  const [searchParams, setSearchParams] = useSearchParams();
  const search = searchParams.get("search")?.trim() ?? "";

  const studentsQuery = useQuery({
  queryKey: ["students"],
  queryFn: () => getStudents(search),
  placeholderData: keepPreviousData,
});

  function handleSearch(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
  const formData = new FormData(event.currentTarget);
  const value = formData.get("search")?.toString().trim() ?? "";

  const next = new URLSearchParams();
  if (value) next.set("search", value);

  setSearchParams(next);


  if (value) {
    next.set("search", value);
  }

  }

  if (studentsQuery.isPending) {
    return <p>Loading students...</p>;
  }

  if (studentsQuery.isError) {
    return <p>Could not load the students. Is the API running?</p>;
  }

  const result = studentsQuery.data;


return (
    <main>
      <h1>All Students</h1>
      <form key={search} onSubmit={handleSearch}>
        <label>
          Search by name
          <input type="search" name="search" defaultValue={search} />
        </label>
        <button type="submit">Search</button>
      </form>
      {result.length === 0 ? (
        <p>No students found.</p>
      ) : (
        <ul>
          {result.map((student) => (
            <li key={student.id}>
              <Link to={`/students/${student.id}`}>
                <strong>{student.name}</strong>
              </Link>
            </li>
          ))}
        </ul>
      )}
      
      {studentsQuery.isFetching && <p>Updating students...</p>}
    </main>
  );
}
