import { apiRequest } from "../api";
import type { StudentNameId, GetStudentsRequest } from "../types";

export function getStudents(request: GetStudentsRequest) {
    const parameters = new URLSearchParams();

    if (request.search) {
    parameters.set("search", request.search);
  }

  return apiRequest<StudentNameId>(
    `/students?${parameters.toString()}`,
}