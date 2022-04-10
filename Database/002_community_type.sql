SET IDENTITY_INSERT community_types ON                                 
GO

INSERT INTO community_types (Id, Name) VALUES
(1, 'Ruralno'),
(2, 'Urbano');
GO

SET IDENTITY_INSERT community_types OFF  -- Statement revert granted permission
GO