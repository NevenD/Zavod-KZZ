SET IDENTITY_INSERT railroad_categories ON                                 
GO

INSERT INTO railroad_categories (Id,Name) VALUES
(1, 'Planirana'),
(2, 'Lokalna'),
(3, 'Regionalna'),
(4, 'Meðunarodna')
GO

SET IDENTITY_INSERT railroad_categories OFF  -- Statement revert granted permission
GO