import { BrowserRouter, Routes, Route } from "react-router-dom";
import PostListPage from "./modules/posts/pages/PostListPage";
import LoginPage from "./modules/auth/pages/LoginPage";
import RegisterPage from "./modules/auth/pages/RegisterPage";
import Navbar from "./shared/NavBar";
import { AuthProvider } from "./core/AuthContext";

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
      <Navbar />
      <Routes>
        <Route path="/" element={<PostListPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/posts" element={<PostListPage />} />
      </Routes>
    </BrowserRouter>
    </AuthProvider>
  );
}

export default App;