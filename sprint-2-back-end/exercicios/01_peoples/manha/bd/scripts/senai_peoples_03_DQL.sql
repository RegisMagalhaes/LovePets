USE M_Peoples;

SELECT nome, sobrenome FROM Funcionarios;

-- Busca os funcionários pelo nome
SELECT idFuncionario, nome, sobrenome FROM Funcionarios 
WHERE nome = 'Catarina';

-- Busca os funcionários trazendo os nomes completos
SELECT CONCAT(nome, ' ', sobrenome) AS [nome completo]
FROM Funcionarios;

-- Ordena os funcionários através do nome 
-- de maneira crescente ou descrescente 
SELECT nome, sobrenome FROM Funcionarios
ORDER BY sobrenome ASC;