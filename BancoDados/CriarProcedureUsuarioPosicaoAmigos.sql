
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE PR_ConsultarUsuarioAmigos
	@usuarioID bigint
AS
BEGIN	
	SET NOCOUNT ON;
	SELECT 
	ami.IDAmigo AS IDAmigo, usAmi.Usuario_Nome AS Usuario_Nome, pos.Posicao_Latitude AS Posicao_Latitude, pos.Posicao_Longitude AS Posicao_Longitude
		FROM [dbo].[Usuario] us 
		LEFT JOIN [dbo].[Amigo] ami ON us.ID = ami.IDUsuario 
		RIGHT JOIN [dbo].[Usuario] usAmi ON ami.IDAmigo = usAmi.ID 
		RIGHT JOIN [dbo].[Posicao] pos ON pos.IDUsuario = usAmi.ID 
		where us.ID = @usuarioID 
END
GO
