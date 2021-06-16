// Faz a importação do axios
import axios from 'axios';

// Define a constate api para a chamada das requisições
const api = axios.create({
    // Define a URL base para as requisições à API
    baseURL : 'http://localhost:5000/api'
});

// Exporta a constante para uso em outros arquivos do projeto
export default api;