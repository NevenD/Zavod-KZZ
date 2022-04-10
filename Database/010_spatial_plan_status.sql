SET IDENTITY_INSERT spatial_plan_status ON                                 
GO

INSERT INTO spatial_plan_status (Id, Name) VALUES
(1, 'Na snazi'),
(2, 'U izradi'),
(3, 'Van snage');
GO

SET IDENTITY_INSERT spatial_plan_status OFF  -- Statement revert granted permission
GO