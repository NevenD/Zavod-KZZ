SET IDENTITY_INSERT official_spatial_news ON                                 
GO

INSERT INTO official_spatial_news (Id, Name, ShortName) VALUES
(1, 'Službeni glasnik Grada Krapine','Sl.gl. Grada Krapine'),
(2, 'Službeni glasnik Krapinsko-zagorske županije', 'Sl. gl. KZŽ'),
(3, 'Službene novine Skupštine Opæine Donja Stubice', 'Sl. gl. Opæine Donja Stubica'),
(4, 'Službene novine Zajednice opæina Zagreb', 'Sl. novine Zaj. Opæine Zagreb'),
(5, 'Zaboèki glasnik', ''),
(6, 'Službeni vjesnik Zajednice opæina Hrvatsko Zagorje',''),
(7, 'Bistrièki glasnik: Službeni glasnik Opæine Marija Bistrica','Sl. gl. Opæine Marija Bistrica'),
(8, 'Službene novine Opæine Zlatar Bistrica','Sl.n. Opæine Marija Bistrica'),
(9, 'Nije poznat','');
GO

SET IDENTITY_INSERT official_spatial_news OFF  -- Statement revert granted permission
GO