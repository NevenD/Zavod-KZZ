SET IDENTITY_INSERT road_categories ON                                 
GO

INSERT INTO road_categories (Id,Name) VALUES
(1, 'Planirana'),
(2, 'Nerazvrstana'),
(3, 'Lokalna'),
(4, '�upanijska'),
(5, 'Dr�avna'),
(6, 'Brza'),
(7, 'Autocesta')
GO

SET IDENTITY_INSERT road_categories OFF  -- Statement revert granted permission
GO