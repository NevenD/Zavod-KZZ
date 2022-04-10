SET IDENTITY_INSERT spuo_puo_documents ON                                 
GO

INSERT INTO spuo_puo_documents (Id, Name,Description) VALUES
(1, 'PUO', 'Procjena utjecaja na okoli�'),
(2, 'SPUO', 'Strate�ka procjena utjecaja na okoli�'),
(3, 'PUO i SPUO', 'Sadr�i oba dokumenta'),
(4, 'Nema', 'Ne sadr�i ni jedan od navedenih dokumenata');
GO

SET IDENTITY_INSERT spuo_puo_documents OFF  -- Statement revert granted permission
GO