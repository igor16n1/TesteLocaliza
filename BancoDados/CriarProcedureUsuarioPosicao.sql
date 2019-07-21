SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE PR_ConsultarUsuario 	
AS
BEGIN	
	SET NOCOUNT ON;
	SELECT us.Usuario_Nome, us.ID, pos.Posicao_Latitude, Posicao_Longitude 
	FROM [dbo].[Usuario] us RIGHT JOIN [dbo].[Posicao] pos ON us.ID = pos.IDUsuario
END
GO
