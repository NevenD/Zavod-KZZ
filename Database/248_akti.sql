SET IDENTITY_INSERT document_zara_status ON                                 
GO

INSERT INTO document_zara_status (Id, Name) VALUES
(1, 'Planirano'),
(2, 'U izradi'),
(3, 'Na snazi'),
(4, 'Van snage'),
(5, 'U procesu donošenja'),
(6, 'Nije poznato');
GO

SET IDENTITY_INSERT document_zara_status OFF  -- Statement revert granted permission
GO


SET IDENTITY_INSERT document_zara_types ON                                 
GO

INSERT INTO document_zara_types (Id, Name) VALUES
(1, 'Plan razvoja Krapinsko-zagorske županije'),
(2, 'Strategija razvoja'),
(3, 'Strategija razvoja ljudskih potencijala'),
(4, 'Master plan razvoja'),
(5, 'Strategija razvoja civilnog društva'),
(6, 'Županijski program djelovanja za mlade'),
(7, 'Socijalni plan Krapinsko-zagorske županije'),
(8, 'Akcijski plan energetske uèinkovitosti'),
(9, 'Ostalo');
GO

SET IDENTITY_INSERT document_zara_types OFF  -- Statement revert granted permission
GO