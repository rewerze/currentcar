import { clsx, type ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}

export const buildApiUrl = (endpoint: string) => {
  const baseUrl =
    process.env.NODE_ENV !== "production"
      ? "http://localhost:3000"
      : window.location.origin;
  return `${baseUrl}/api${endpoint}`;
};
