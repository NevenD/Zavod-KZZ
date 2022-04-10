SET IDENTITY_INSERT official_spatial_news ON                                 
GO

INSERT INTO official_spatial_news (Id, Name, ShortName) VALUES
(1, 'Slu�beni glasnik Grada Krapine','Sl.gl. Grada Krapine'),
(2, 'Slu�beni glasnik Krapinsko-zagorske �upanije', 'Sl. gl. KZ�'),
(3, 'Slu�bene novine Skup�tine Op�ine Donja Stubice', 'Sl. gl. Op�ine Donja Stubica'),
(4, 'Slu�bene novine Zajednice op�ina Zagreb', 'Sl. novine Zaj. Op�ine Zagreb'),
(5, 'Zabo�ki glasnik', ''),
(6, 'Slu�beni vjesnik Zajednice op�ina Hrvatsko Zagorje',''),
(7, 'Bistri�ki glasnik: Slu�beni glasnik Op�ine Marija Bistrica','Sl. gl. Op�ine Marija Bistrica'),
(8, 'Slu�bene novine Op�ine Zlatar Bistrica','Sl.n. Op�ine Marija Bistrica'),
(9, 'Nije poznat','');
GO

SET IDENTITY_INSERT official_spatial_news OFF  -- Statement revert granted permission
GO