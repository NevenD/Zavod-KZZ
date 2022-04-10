SET IDENTITY_INSERT spatial_planners ON                                 
GO

INSERT INTO spatial_planners (Id, Name, Location, Address, Phone, Email) VALUES
(1, 'APE d.o.o.', 'Zagreb', 'Ozaljska 61/I', '01/309-7572', 'ape-info@ape.hr'),
(2, 'Arhitektonski atelier deset d.o.o.', 'Zagreb', 'Kneza Mislava 15', '098/177-2416', 'jasnamucko@gmail.com'),
(3, 'AMG Studio d.o.o.', 'Sveti Križ Zaèretje', 'Trg hrvatske kraljice Jelene 2', '049/227-738', ''),
(4, 'Urbanistièki zavod grada Zagreba d.o.o.', 'Zagreb', 'Braæe Domany 4', '01/384-3409', 'uzgz@uzgz.net'),
(5, 'Arhitektonski fakultet', 'Zagreb', 'Kaèiæeva 26', '01/463-9222', 'info@arhitekt.hr'),
(6, 'ZZPU KZŽ', 'Krapina', 'Magistratska 1', '049/382-145', 'zavod-prostor@kzz.hr'),
(7, 'ASK ATELIER d.o.o.', 'Zagreb', 'Trg Nikole Šubiæa Zrinskog 17', '01/487-3883', ''),
(8, 'Urbanistièki institut Hrvatske d.o.o.', 'Zagreb', 'Frane Petriæa 4', '01/480-4300', 'uih@zg.t-com.hr'),
(9, 'URBAN DESIGN d.o.o', 'Zagreb', 'Kneza Mislava 12', '01/457-6412', 'urban-design@email.t-com.hr'),
(10, 'URBING d.o.o.', 'Zagreb', 'Avenija V. Holjevca 20', '01/653-9692', 'urbing@urbing.hr'),
(11, 'URBANISTICA d.o.o.', 'Zagreb', 'Ðorðiæeva 5/II', '01/492-3456', ''),
(12, 'MVA mikeliæ vreš arhitekti d.o.o.', 'Zagreb', 'Martiæeva 38', '01/481-0786', 'info@mva.hr'),
(13, 'ZZPU (stari Zavod)', 'Zabok', '', '', ''),
(14, 'NESEK d.o.o.', 'Zagreb', 'Amruševa 8', '01/309-6108', ''),
(15, 'AG Planum d.o.o.', 'Zagreb', 'Mesnièka 9', '01/484-6286', 'info@agplanum.com'),
(16, 'URBIA d.o.o.', 'Èakovec', 'I.G. Kovaèiæa 10', '040/373-400', 'urbia@urbia.hr'),
(17, 'APZ - inženjering d. d. ', 'Zagreb', 'Grahorova 15', '01/390-3222', 'apz@apz.hr'),
(18, 'Arhitekti Ratkajec d.o.o.', 'Vrbovec', 'Vukotinoviæeva ul. 7', '091/798-1858', 'dubravko@arhitekti-ratkajec.hr'),
(19, 'ARHEO d.o.o.', 'Zagreb', 'Tomislavova 11', '01/663-6443', 'arheo@arheo.hr'),
(20, 'Nije poznat', '------', '------', '------', '------'),
(21, 'JURCON PROJEKT d.o.o.', 'Zagreb', 'Gotaloveèka 4a', '091/131-1104', 'bojan.lindaric@jurconprojekt.hr'),
(22, 'Arting d.o.o.', 'Bjelovar', 'J.J.StrossMyera 4', '043241226', 'arting@bj.t-com.hr');
GO

SET IDENTITY_INSERT spatial_planners OFF  -- Statement revert granted permission
GO