export type CreateStudentRequest = {
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

export type CreateStudentResponse = {
  id: string;
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

export type UpdateStudentRequest = {
  id: string;
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
