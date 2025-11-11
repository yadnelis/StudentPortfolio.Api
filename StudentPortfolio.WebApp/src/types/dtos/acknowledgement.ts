import { enums } from "../../utilities/enums";
import type { BaseResponse } from "./_baseResponse";
import type { Student } from "./student";

enums.acknowledgementType;

export interface Acknowledgement {
  id: string;
  studentId: number;
  type: keyof typeof enums.acknowledgementType;
  place: string;
  description: string;
  startDate: Date;
  endDate?: Date;
  otherType?: string;
  competitionPosition?: number;
  competitionName?: string;
  studentOrganizatonName?: string;
  student: Student;
}

export type getAcknowledgementResponse = BaseResponse<Acknowledgement>;
export type getAcknowledgementsResponse = BaseResponse<Acknowledgement[]>;
