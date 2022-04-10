SET IDENTITY_INSERT spatial_measures ON                                 
GO

INSERT INTO spatial_measures (Id, Name) VALUES
(1, '1:100.000'),
(2, '1:25.000'),
(3, '1:10.000'),
(4, '1:5.000'),
(5, '1:2.000'),
(6, '1:1.000'),
(7, '1:500'),
(8, 'Neodreðeno');
GO

SET IDENTITY_INSERT spatial_measures OFF  -- Statement revert granted permission
GO