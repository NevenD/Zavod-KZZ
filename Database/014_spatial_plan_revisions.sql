SET IDENTITY_INSERT spatial_plan_revisions ON                                 
GO

INSERT INTO spatial_plan_revisions (Id,RevisionStatus) VALUES
(1, 'Osnovni'),
(2, 'Izmjene'),
(3, 'Izvješæe');
GO

SET IDENTITY_INSERT spatial_plan_revisions OFF  -- Statement revert granted permission
GO