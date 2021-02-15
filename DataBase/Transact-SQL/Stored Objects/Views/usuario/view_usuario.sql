
/* File History
--------------------------------------------------------------------
Created by : Luciano Filho
Date       : 13/02/2021
Purpose    : Cria��o da view de usu�rio
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



--
IF EXISTS (SELECT TOP 1 [id] FROM dbo.sysobjects WHERE id = object_id(N'[view_usuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
  DROP PROCEDURE [view_usuario];
GO

CREATE VIEW [view_usuario] AS
  SELECT * FROM usuario
GO
