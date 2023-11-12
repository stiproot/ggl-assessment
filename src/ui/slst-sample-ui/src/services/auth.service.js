import { HttpClient } from "./http.client";

const BASE_URL = "http://localhost:5079";
const httpClient = new HttpClient(BASE_URL);

export async function login() {
  const url = "/auth/login";

  try {
    const response = await httpClient.post(url, {}, {});
    return response;
  } catch (error) {
    console.error(error);
    throw error;
  }
}
