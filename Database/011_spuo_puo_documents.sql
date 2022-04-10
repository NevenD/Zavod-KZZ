SET IDENTITY_INSERT spuo_puo_documents ON                                 
GO

INSERT INTO spuo_puo_documents (Id, Name,Description) VALUES
(1, 'PUO', 'Procjena utjecaja na okoliš'),
(2, 'SPUO', 'Strateška procjena utjecaja na okoliš'),
(3, 'PUO i SPUO', 'Sadrži oba dokumenta'),
(4, 'Nema', 'Ne sadrži ni jedan od navedenih dokumenata');
GO

SET IDENTITY_INSERT spuo_puo_documents OFF  -- Statement revert granted permission
GO