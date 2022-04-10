SET IDENTITY_INSERT local_governments ON                                 
GO

INSERT INTO local_governments (Id, Name, CodeNumber,CommunityTypeID,IsAdministrativeCity) VALUES
(1, 'Bedekovèina', 00116,2,0),
(2, 'Budinšèina', 00418,1,0),
(3, 'Desiniæ', 00701,1,0),
(4, 'Donja Stubica', 00795,1,0),
(5, 'Ðurmanec', 01082,1,0),
(6, 'Gornja Stubica', 01252,1,0),
(7, 'Hrašæina', 01465,1,0),
(8, 'Hum na Sutli', 01520,1,0),
(9, 'Jesenje', 05525,1,0),
(10, 'Klanjec', 01872,1,0),
(11, 'Konjšèina', 02003,1,0),
(12, 'Kraljevec na Sutli', 02089,1,0),
(13, 'Krapina', 02119,2,0),
(14, 'Krapinske Toplice', 02127,1,0),
(15, 'Kumrovec', 05533,1,0),
(16, 'Lobor', 02364,1,0),
(17, 'Maèe', 02488,1,0),
(18, 'Marija Bistrica', 02569,1,0),
(19, 'Mihovljan', 02658,1,0),
(20, 'Novi Golubovec', 05541,1,0),
(21, 'Oroslavje', 03115,2,0),
(22, 'Petrovsko', 03298,1,0),
(23, 'Pregrada', 03522,1,0),
(24, 'Radoboj', 03646,1,0),
(25, 'Stubièke Toplice', 04227,1,0),
(26, 'Sveti Križ Zaèretje', 04308,1,0),
(27, 'Tuhelj', 04669,1,0),
(28, 'Veliko Trgovišæe', 04812,1,0),
(29, 'Zabok', 05193,2,0),
(30, 'Zagorska Sela', 05215,1,0),
(31, 'Zlatar', 05266,1,0),
(32, 'Zlatar Bistrica', 05274,1,0);
GO

SET IDENTITY_INSERT local_governments OFF  -- Statement revert granted permission
GO