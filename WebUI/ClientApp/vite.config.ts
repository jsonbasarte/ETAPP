import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'
import mkcert from "vite-plugin-mkcert";

export default defineConfig(({ command, mode }) => {
  const env = loadEnv(mode, process.cwd(), '')
  return {
    plugins: [react(), mkcert()],
    server: {
      port: 3001,
      https: true,
      strictPort: true,
      proxy: {
        "/api": {
          target: env.VITE_API_URL,
          changeOrigin: true,
          secure: false,
        },
        "/swagger": {
          target: env.VITE_API_URL,
          changeOrigin: true,
          secure: false,
        },
      }
    }
  }
})

