/* File History
 * --------------------------------------------------------------------
 * Created by : Luciano Filho
 * Date       : 13/02/2021
 * Purpose    : Criação da ddl.sql do projeto
 * --------------------------------------------------------------------
 */

SET ANSI_NULLS ON /* comportamento dos operadores de comparação */
SET QUOTED_IDENTIFIER ON /* delimitam identificadores e cadeias de caracteres */
SET ANSI_PADDING ON /* Controla como a coluna armazena valores menores que o tamanho definido da coluna */



IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[usuario]') AND OBJECTPROPERTY(id, N'IsTable') = 1)
  DROP TABLE [usuario] ;
GO
CREATE TABLE [usuario] (
[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[nome] VARCHAR(255) not null ,
[login] VARCHAR(255),
[senha] VARCHAR(255),
[email] VARCHAR(255),
[fone] VARCHAR(255),
[cpf] VARCHAR(25),
[data_nascimento] DATE,
[nome_mae] VARCHAR(255),
[data_inclusao] DATETIME,
[data_alteracao] DATETIME,
[status] VARCHAR(25)
);

GO
select * from usuario
--