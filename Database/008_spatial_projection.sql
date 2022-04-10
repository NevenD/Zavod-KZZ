SET IDENTITY_INSERT spatial_projections ON                                 
GO

INSERT INTO spatial_projections (Id, Name, EnglishName, DescriptionOverview, ShortName, EpsgCode, Description) VALUES
(1, 'HDKS1901/GK5', 'MGI 1901/Balkans zone 5', 'Podru�je: HR nDimenzije: 2D Projekcija: GK5 Koordinate: X, Y', 'GK5', 'EPSG:31275', 'Hrvatski dr�avni koordinatni sustav 1901 u Gauss-Kr�gerovoj projekciji, 5. zona za podru�je Hrvatske. Dvodimenzionalni referentni sustav sa sredi�njim meridijanom 15� isto�no od Greenwicha, �irinom zone preslikavanja od 3�, linearnim mjerilom uzdu� srednjeg meridijana 0,9999, pomakom koordinate u smjeru istoka od 500 000 m i brojem zone "5".'),
(2, 'HTRS96/TM', 'HTRS96/TM', 'Podru�je: HR Dimenzije: 2D Projekcija: TM Koordinate: E, N', 'HTRS96/TM', 'EPSG:3765', 'Hrvatski terestri�ki referentni sustav 1996 popre�ne Mercatorove projekcije (konformna popre�na cilindri�na projekcija) za potrebe katastra i detaljne kartografije za podru�je Hrvatske na osnovu ETRS89 datuma i GRS80 elipsoida. Dvodimenzionalni (E, N) referentni sustav u ravnini projekcije s jednom zonom preslikavanja, sredi�njim meridijanom 16,5� isto�no od Greenwicha, linearnim mjerilom preslikavanja uzdu� srednjeg meridijana 0,9999 i pomakom u smjeru istoka od 500 000 m.'),
(3, 'HTRS96/LCC', 'HTRS96/LCC', 'Podru�je: HR Dimenzije: 2D Projekcija: LCC Koordinate: E, N', 'HTRS96/LCC', 'EPSG:3766', 'Hrvatski terestri�ki referentni sustav 1996 uspravne Lambertove konformne konusne projekcije za potrebe pregledne kartografije za podru�je Hrvatske na osnovu ETRS89 datuma i GRS80 elipsoida. Dvodimenzionalni referentni sustav u ravnini projekcije sa standardnim paralelama 43�05 i 45�55.'),
(4, 'WGS84/UTM33N', 'WGS84/UTM33N', 'Podru�je: Globalni (dio Hrvatske) nDimenzije: 2D Projekcija: UTM Koordinate: E, N', 'WGS84/UTM33N', 'EPSG:32634', 'World Geodetic System 1984 za cijelu Zemlju (globalni) u Universal Transverse Mercator projekciji za zonu 33N (podru�je Hrvatske). Dvodimenzionalne koordinate u ravnini projekcije.'),
(5, 'Nije poznata', 'Unknown', 'Parametri nisu poznati', 'N/A', 'Nije poznat', 'Nepoznato');
GO

SET IDENTITY_INSERT spatial_projections OFF  -- Statement revert granted permission
GO