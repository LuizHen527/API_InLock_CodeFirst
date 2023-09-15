USE InLock_CodeFirst_Manha

SELECT * FROM Estudio

SELECT * FROM TipoUsuario

SELECT * FROM Usuario

SELECT * FROM Jogo

INSERT INTO Estudio
VALUES (NEWID(), 'Capcom')

INSERT INTO TipoUsuario
VALUES (NEWID(), 'Administrador'), (NEWID(), 'Comum')

INSERT INTO Usuario
VALUES (NEWID(), 'admin@admin.com', 'administrador', '3CF8002C-69D9-4154-B1C5-6DD407AE7BCF'), (NEWID(), 'comum@comum.com', 'comum', '1279FE40-D924-4696-A3F8-B99D2BC2C201')

INSERT INTO Jogo
VALUES (NEWID(), 'Resident Evil 4', 'LEON!!!', '2023-04-06', 1.99, '3F48CC5E-2272-4DC6-B90E-AA4BCD410870')