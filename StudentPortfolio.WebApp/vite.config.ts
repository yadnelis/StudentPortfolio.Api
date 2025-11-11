import tailwindcss from "@tailwindcss/vite";
import react from "@vitejs/plugin-react";
import { defineConfig } from "vite";

// https://vite.dev/config/
export default defineConfig({
  build: {
    outDir: "../StudentPortfolio.Api/wwwroot", // Builds to a directory named 'my-custom-output-directory' one level up
  },
  plugins: [react(), tailwindcss()],
});
