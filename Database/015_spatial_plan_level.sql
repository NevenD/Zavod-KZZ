SET IDENTITY_INSERT spatial_plan_levels ON                                 
GO

INSERT INTO spatial_plan_levels (Id,ShortName,FullName) VALUES
(1, 'PPŽ', 'Prostorni plan županije'),
(2, 'PPUG', 'Prostorni plan ureðenja grada'),
(3, 'PPUO', 'Prostorni plan ureðenja opæine'),
(4, 'UPU', 'Urbanistièki plan ureðenja'),
(5, 'DPU', 'Detaljni plan ureðenja'),
(6, 'GUP', 'Generalni urbanistièki plan'),
(7, 'PUP', 'Provedbeni urbanistièki plan'),
(8, 'ISP', 'Izvješæe o stanju u prostoru');
GO

SET IDENTITY_INSERT spatial_plan_levels OFF  -- Statement revert granted permission
GO