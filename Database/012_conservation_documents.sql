SET IDENTITY_INSERT conservation_documents ON                                 
GO

INSERT INTO conservation_documents (Id,ValidationStatus) VALUES
(1, 'DA'),
(2, 'NE'),
(3, 'Nije poznata');
GO

SET IDENTITY_INSERT conservation_documents OFF  -- Statement revert granted permission
GO