/* File History
--------------------------------------------------------------------
Created by : Luciano Filho
Date       : 13/02/2021
Purpose    : procedimentos para manipulação dos dados de usuários
--------------------------------------------------------------------
Updated by :
Date       :
Purpose    :
--------------------------------------------------------------------
Updated by : 
Date       :
Purpose    :
--------------------------------------------------------------------
*/

IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[stp_usuario_pesquisar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [stp_usuario_pesquisar];
GO

CREATE PROCEDURE [stp_usuario_pesquisar]
@nome VARCHAR(255) = null,
@cpf VARCHAR(255) = null,
@login VARCHAR(255) = null,
@status VARCHAR(255) = null

WITH ENCRYPTION AS

DECLARE @pesquisa VARCHAR(255) = NULL

IF @nome <> NULL 
  SELECT * FROM view_usuario WHERE  nome like '%'+@nome+'%'

ELSE IF @cpf <> NULL 
  SELECT * FROM view_usuario WHERE cpf like '%'+@cpf+'%'

ELSE IF @login <> NULL 
  SELECT * FROM view_usuario WHERE login like '%'+@login+'%'

ELSE IF @status <> NULL 
  SELECT * FROM view_usuario WHERE status like '%'+@status+'%'

ELSE
  SELECT * FROM view_usuario 

GO

IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[stp_usuario_nova_senha]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [stp_usuario_nova_senha];
GO

CREATE PROCEDURE [stp_usuario_nova_senha]
@login VARCHAR(255),
@cpf VARCHAR(255),
@nova_senha VARCHAR(255)
WITH ENCRYPTION AS

  UPDATE usuario
  Set senha = @nova_senha
  WHERE [login] = @login and [cpf] = @cpf
   
GO 
--

-- exec [stp_usuario_excluir]  1 Teste
IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[stp_usuario_excluir]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [stp_usuario_excluir];
GO

CREATE PROCEDURE [stp_usuario_excluir]
@id INT
WITH ENCRYPTION AS

  DELETE FROM usuario where id = @id
GO
--
-- exec stp_usuario_incluir 'teste', 'teste', 'teste','teste', 'teste', 'testeteste','01/01/2021', 'teste', 'teste'
IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[stp_usuario_incluir]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [stp_usuario_incluir];
GO

CREATE PROCEDURE [stp_usuario_incluir]
@nome VARCHAR(255),
@login VARCHAR(255),
@senha VARCHAR(255),
@email VARCHAR(255),
@fone VARCHAR(255),
@cpf VARCHAR(25),
@data_nascimento DATE,
@nome_mae VARCHAR(255),
@status VARCHAR(25)
WITH ENCRYPTION AS

DECLARE @data_inclusao DATETIME = getdate()

INSERT INTO usuario (nome, login, senha, email, fone, cpf, data_nascimento, nome_mae, status, data_inclusao) 
             values (@nome, @login, @senha, @email, @fone, @cpf, @data_nascimento, @nome_mae, @status, @data_inclusao)
   
GO 
-- 
--exec [stp_usuario_alterar] 2, 'teste','teste','teste','teste','teste','teste','01/01/2021','teste','01/01/2021','te'
IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[stp_usuario_alterar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE stp_usuario_alterar;
GO

CREATE PROCEDURE stp_usuario_alterar
@id INT,
@nome VARCHAR(255),
@login VARCHAR(255),
@senha VARCHAR(255),
@email VARCHAR(255),
@fone VARCHAR(25),
@cpf VARCHAR(25),
@data_nascimento DATE,
@nome_mae VARCHAR(255),
@status VARCHAR(25)
WITH ENCRYPTION AS

DECLARE @data_alteracao DATETIME = GETDATE();

UPDATE  usuario SET 
[nome] = @nome,
[login] = @login, 
[senha] = @senha,
[email] = @email,
[fone] = @fone, 
[cpf] = @cpf,
[data_nascimento] = @data_nascimento,
[nome_mae] = @nome_mae,
[data_alteracao] = @data_alteracao,
[status] = @status
WHERE [id] = @id
   
GO
--
--SELECT * from view_usuario where login = 'ALINEFERRA' and senha = '221259' and (status <> 'bloqueado' and status <> 'inativo' or status is null)
IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[stp_usuario_validar_login]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [stp_usuario_validar_login];
GO

CREATE PROCEDURE [stp_usuario_validar_login]
@login VARCHAR(255),
@senha VARCHAR(255)
WITH ENCRYPTION AS

  SELECT * FROM view_usuario WHERE [login] = @login and [senha] = @senha and ([status] <> 'bloqueado' and [status] <> 'inativo' or [status] is null)
  
GO 
--

