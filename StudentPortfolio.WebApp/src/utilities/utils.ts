import type { ODataQueryOptions } from "../types/ODataQueryOptions";

interface QueryParams {
  [key: string]: any;
}

export function convertToURLQueryParams(
  params?: QueryParams & object
): string | undefined {
  if (!params) return;

  const searchParams = new URLSearchParams();

  for (const key in params) {
    if (Object.prototype.hasOwnProperty.call(params, key)) {
      const value = params[key];

      // Handle different types and potential undefined/null values
      if (value !== undefined && value !== null) {
        if (Array.isArray(value)) {
          value.forEach((item) => searchParams.append(key, String(item)));
        } else {
          searchParams.append(key, String(value));
        }
      }
    }
  }
  return searchParams.toString();
}

export function appendQueryString(url: string, params?: QueryParams & object) {
  const query = convertToURLQueryParams(params);
  return `${url}${query ? `?${query}` : ""}`;
}

export function appendODataQueryString(
  url: string,
  params?: ODataQueryOptions
) {
  const query = convertToURLQueryParams(params);
  return `${url}${query ? `?${query}` : ""}`;
}
