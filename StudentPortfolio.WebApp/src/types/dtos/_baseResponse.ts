export interface BaseResponse<T> {
  entity: T;
  resource: string;
  time: Date;
}
