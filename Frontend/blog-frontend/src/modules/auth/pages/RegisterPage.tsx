import React, { useState } from "react";
import api from "../../../core/axiosConfig";
import { useNavigate } from "react-router-dom";

const RegisterPage: React.FC = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleRegister = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
       await api.post("/User/CreateUser", {
        name,
        email,
        password,
      });
      alert("Usuário criado com sucesso!");
      navigate("/login"); // redireciona para login após cadastro
    } catch (error) {
      alert("Erro ao criar usuário.");
      console.error(error);
    }
  };

  return (
    <div className="container mt-5">
      <h1 className="mb-4">Cadastrar Usuário</h1>
      <form onSubmit={handleRegister}>
        <div className="mb-3">
          <label className="form-label">Nome:</label>
          <input
            type="text"
            className="form-control"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Email:</label>
          <input
            type="email"
            className="form-control"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Senha:</label>
          <input
            type="password"
            className="form-control"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit" className="btn btn-success">
          Cadastrar
        </button>
        <button type="button" className="btn btn-secondary" onClick={() => navigate("/")}>
          Voltar
        </button>
      </form>
    </div>
  );
};

export default RegisterPage;