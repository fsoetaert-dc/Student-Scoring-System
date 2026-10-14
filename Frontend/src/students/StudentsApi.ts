import type { CreateStudentRequest, CreateStudentResponse, StudentName } from "./Types";

const apiUrl = import.meta.env.VITE_API_URL;

export function getStudents(search: string) {
    const params = new URLSearchParams();

    if (search) {
        params.set("search", search);
    }

    return apiRequest<StudentName[]>('/students?${params.toString()}');
}

export function createStudent(request: CreateStudentRequest) {
  return apiRequest<CreateStudentResponse>("/students", {
    method: "POST",
    body: JSON.stringify(request),
  });
}

export async function apiRequest<T>(
  path: string,
  options: RequestInit = {},
): Promise<T> {
  const response = await sendRequest(path, options);
  return response.json() as Promise<T>;
}

async function sendRequest(path: string, options: RequestInit) {
  const headers = new Headers(options.headers);

  headers.set("Accept", "application/json");

  if (options.body) {
    headers.set("Content-Type", "application/json");
  }

  const response = await fetch(`${apiUrl}${path}`, {
    ...options,
    headers,
  });

  if (!response.ok) {
    throw new ApiError(
      response.status,
      `Request failed with status ${response.status}`,
    );
  }

  return response;
}

export class ApiError extends Error {
  status: number;

  constructor(status: number, message: string) {
    super(message);
    this.status = status;
  }
}