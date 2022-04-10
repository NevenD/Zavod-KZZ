SET IDENTITY_INSERT spatial_plan_levels ON                                 
GO

INSERT INTO spatial_plan_levels (Id,ShortName,FullName) VALUES
(1, 'PP�', 'Prostorni plan �upanije'),
(2, 'PPUG', 'Prostorni plan ure�enja grada'),
(3, 'PPUO', 'Prostorni plan ure�enja op�ine'),
(4, 'UPU', 'Urbanisti�ki plan ure�enja'),
(5, 'DPU', 'Detaljni plan ure�enja'),
(6, 'GUP', 'Generalni urbanisti�ki plan'),
(7, 'PUP', 'Provedbeni urbanisti�ki plan'),
(8, 'ISP', 'Izvje��e o stanju u prostoru');
GO

SET IDENTITY_INSERT spatial_plan_levels OFF  -- Statement revert granted permission
GO