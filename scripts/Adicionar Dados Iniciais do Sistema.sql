
INSERT INTO Menu (Id, Titulo) VALUES(DBO.fnc_getNextGUID(), 'Sistema');
INSERT INTO NivelDeAcesso (Id, Nome, Detalhes) VALUES(DBO.fnc_getNextGUID(), 'Administrador do Sistema', 'Administra o Sistema PGLaw Web: Criação de usuários, menus e níveis de acesso.')

BEGIN 
    DECLARE @menuSistemaId As UNIQUEIDENTIFIER;
    SET @menuSistemaId = (SELECT Id FROM Menu WHERE Titulo = 'Sistema');
    INSERT INTO Menu (Id, Titulo, Url, MenuPaiId) VALUES(DBO.fnc_getNextGUID(), 'Menus', 'Menus', @menuSistemaId);
END

BEGIN 
    DECLARE @menuSistemaId As UNIQUEIDENTIFIER;
    SET @menuSistemaId = (SELECT Id FROM Menu WHERE Titulo = 'Sistema');
    INSERT INTO Menu (Id, Titulo, Url, MenuPaiId) VALUES(DBO.fnc_getNextGUID(), 'Menus', 'Menus', @menuSistemaId);
END



delete from menu
delete from NivelDeAcesso
delete from MenuNivelDeAcesso
delete from UsuarioNivelDeAcesso

SELECT * FROM MenuNivelDeAcesso

-- INSERT INTO Menu (Id, Titulo) VALUES(DBO.fnc_getNextGUID(), 'Sistema');
-- INSERT INTO Menu (Id, Titulo) VALUES(DBO.fnc_getNextGUID(), 'Sistema');