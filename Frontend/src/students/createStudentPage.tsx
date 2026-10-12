import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import type { FormEvent } from "react";
import "../App.css";

type NewStudent = {
  name: string;
  dateOfBirth: string;
  address: {
    street: string;
    houseNumber: string;
    city: string;
    postalCode: string;
    country: string;
  };
};

export default function CreateStudentPage() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();

  const createMutation = useMutation({
    mutationFn: async (student: NewStudent) => {
      const response = await fetch("/students", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(student),
      });

      if (!response.ok) {
        throw new Error(`Could not create student (${response.status})`);
      }

      // Use this if your API returns no response body: (like Delete)
      return response;
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["students"] });
      navigate("/students");
    },
  });

  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const form = new FormData(event.currentTarget);

    const student: NewStudent = {
      name: String(form.get("name")),
      dateOfBirth: String(form.get("dateOfBirth")),
      address: {
        street: String(form.get("street")),
        houseNumber: String(form.get("houseNumber")),
        city: String(form.get("city")),
        postalCode: String(form.get("postalCode")),
        country: String(form.get("country")),
      },
    };

    createMutation.mutate(student);
  }

    return (
    <form onSubmit={handleSubmit} className="student-form">
      <label>
        Name
        <input name="name" maxLength={100} required />
      </label>

      <label>
        Date of birth
        <input name="dateOfBirth" type="date" required />
      </label>

      <fieldset>
        <legend>Address</legend>

        <label>
          Street
          <input name="street" maxLength={100} required />
        </label>

        <label>
          House number
          <input name="houseNumber" maxLength={100} required />
        </label>

        <label>
          City
          <input name="city" maxLength={100} required />
        </label>

        <label>
          Postal code
          <input name="postalCode" type="number" maxLength={100} required />
        </label>

        <label>
          Country
          <input name="country" maxLength={100} required />
        </label>
      </fieldset>

      <button type="submit">Create student</button>
    </form>
  );
}
