SET IDENTITY_INSERT regulation_types ON                                 
GO

INSERT INTO regulation_types (Id, Name) VALUES
(1, 'Pravilnik'),
(2, 'Odluka'),
(3, 'Zakon'),
(4, 'Rješenje'),
(5, 'Uredba'),
(6, 'Ostalo');

GO

SET IDENTITY_INSERT regulation_types OFF  -- Statement revert granted permission
GO