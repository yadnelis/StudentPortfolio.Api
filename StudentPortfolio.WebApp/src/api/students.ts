"use server";

import axios from "axios";
import type {
  GetStudentRequest,
  GetStudentsResponse,
} from "../types/dtos/student";
import { appendQueryString } from "../utilities/utils";

const controller =
  (import.meta.env.VITE_API_URL ?? "MISSING_API_URL") + "/Students";

export const getStudents = async (args?: GetStudentRequest) => {
  const url = appendQueryString(controller, args);
  var res = await axios.get<GetStudentsResponse>(url);
  return res.data;
};
