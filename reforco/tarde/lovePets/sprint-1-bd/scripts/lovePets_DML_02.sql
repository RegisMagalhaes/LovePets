USE lovePets_tarde;
GO

INSERT INTO clinica(cnpj, razaoSocial, endereco)
VALUES			   ('99999999999999', 'lovePets', 'Al. Barão de Limeira, 538');
GO

INSERT INTO veterinario(idClinica, crmv, nomeVeterinario)
VALUES				   (1, '432551', 'Saulo'),
					   (1, '653655', 'Caique');
GO

INSERT INTO tipoPet(nomeTipoPet)
VALUES			   ('cachorro'),
				   ('gato');
GO

INSERT INTO dono(nomeDono)
VALUES			('Paulo'),
                ('Odirlei');
GO

INSERT INTO raca(idTipoPet, nomeRaca)
VALUES			(1, 'poodle'),
				(1, 'labrador'),
				(1, 'SRD'),
				(2, 'siamês');
GO

INSERT INTO pet(nomePet, idRaca, idDono, dataNascimento)
VALUES		   ('junior', 1, 1, '10/10/2018'),
			   ('loli', 4, 1, '18/05/2017'),
			   ('sammy', 1, 2, '16/06/2016');
GO

INSERT INTO atendimento(idPet, idVeterinario, descricao, dataAtendimento)
VALUES				   (1, 1, 'restam 10 dias de vida', '15/07/2021 16:00'),
					   (2, 2, 'o paciente está ok', '16/07/2021 17:00'),
					   (1, 2, 'o paciente está ok', '17/07/2021 10:00');
GO