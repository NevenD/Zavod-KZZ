SET IDENTITY_INSERT spatial_plan_delivery ON                                 
GO

INSERT INTO spatial_plan_delivery (Id,DeliveryStatus) VALUES
(1, 'Dostavljen'),
(2, 'Dostavljen dio - bez CD-a'),
(3, 'Dostavljen dio - nedostaju kartografski prikazi'),
(4, 'Dostavljen dio - nedostaje dio'),
(5, 'Nije dostavljen'),
(6, 'Nepoznato');
GO

SET IDENTITY_INSERT spatial_plan_delivery OFF  -- Statement revert granted permission
GO