SET IDENTITY_INSERT Gamezone.dbo.products ON;

-- TRUNCATE TABLE product_variants;
-- TRUNCATE TABLE products;

INSERT INTO products (id, create_date, description, name, release_date, update_date, image_url)
VALUES (1, CURRENT_TIMESTAMP, 'Nintendo 64 Game', 'The Legend of Zelda: Ocarina of Time', CAST('1998-11-23 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://coverproject.sfo2.cdn.digitaloceanspaces.com/nintendo_64/n64_zeldaoot_label_thumb.jpg'),
        (2, CURRENT_TIMESTAMP, 'PlayStation 1 Game', 'Tony Hawk''s Pro Skater 2', CAST('2000-9-20 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://coverproject.sfo2.cdn.digitaloceanspaces.com/playstation_1/ps1_tonyhawksproskater2_front_de_thumb.jpg'),
        (3, CURRENT_TIMESTAMP, 'PlayStation 3 Game', 'Grand Theft Auto 4', CAST('2008-4-29 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/81rSkcE4IYL._AC_UF1000,1000_QL80_.jpg'),
        (4, CURRENT_TIMESTAMP, 'SEGA Dreamcast Game', 'Soul Calibur', CAST('1999-9-8 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://coverproject.sfo2.cdn.digitaloceanspaces.com/dreamcast/dc_soulcalibur_front_thumb.jpg'),
        (5, CURRENT_TIMESTAMP, 'Nintendo Wii Game', 'Super Mario Galaxy', CAST('2007-11-12 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://static.wikia.nocookie.net/nintendo/images/0/00/Super_Mario_Galaxy_%28EU%29.jpg/revision/latest?cb=20090401224138&path-prefix=en'),
        (6, CURRENT_TIMESTAMP, 'Nintendo Wii Game', 'Super Mario Galaxy 2', CAST('2010-5-23 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://upload.wikimedia.org/wikipedia/en/6/65/Super_Mario_Galaxy_2_Box_Art.jpg'),
        (7, CURRENT_TIMESTAMP, 'Xbox One Game', 'Read Dead Redemption 2', CAST('2018-10-26 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/81bbAeAG6vS.jpg'),
        (8, CURRENT_TIMESTAMP, 'Xbox One Game', 'Grand Theft Auto 5', CAST('2014-11-18 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://xboxaddict.com/images/box_art/3243.jpg'),
        (9, CURRENT_TIMESTAMP, 'PC Game', 'Disco Elysium: The Final Cut', CAST('2021-3-30 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://gamefaqs.gamespot.com/a/box/4/5/4/793454_front.jpg'),
        (10, CURRENT_TIMESTAMP, 'Nintendo Switch Game', 'The Legend of Zelda: Breath of the Wild', CAST('2017-3-3 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg'),
        (11, CURRENT_TIMESTAMP, 'Nintendo 64 Game', 'Perfect Dark', CAST('2000-5-22 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://i.ebayimg.com/images/g/CegAAOSwn8FXSnIj/s-l500.jpg'),
        (12, CURRENT_TIMESTAMP, 'Nintendo Gamecube Game', 'Metroid Prime', CAST('2002-11-17 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://static.wikia.nocookie.net/metroid/images/b/ba/MetroidPrimebox.jpg/revision/latest?cb=20220716192249'),
        (13, CURRENT_TIMESTAMP, 'Nintendo Switch Game', 'Super Mario Odyssey', CAST('2017-10-27 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/71QevE1u3xL.jpg'),
        (14, CURRENT_TIMESTAMP, 'XBOX Game', 'Halo: Combat Evolved', CAST('2001-11-14 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://pbs.twimg.com/media/FcJiQ3dXEAEFT1B.jpg'),
        (15, CURRENT_TIMESTAMP, 'SEGA Dreamcast', 'NFL 2K1', CAST('2000-9-7 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/511HHH8C48L.jpg'),
        (16, CURRENT_TIMESTAMP, 'PC Game', 'Half-Life 2', CAST('2004-11-16 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://upload.wikimedia.org/wikipedia/en/thumb/2/25/Half-Life_2_cover.jpg/220px-Half-Life_2_cover.jpg'),
        (17, CURRENT_TIMESTAMP, 'Xbox 360 Game', 'BioSchock', CAST('2007-8-21 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://store-images.s-microsoft.com/image/apps.35693.67628702173327834.9631ebfc-9c57-41b2-b688-4acf5b3815ce.ad223159-35ee-40ef-983b-58be333febbc?q=90&w=177&h=177'),
        (18, CURRENT_TIMESTAMP, 'Nintendo 64 Game', 'GoldenEye 007', CAST('1997-8-25 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://upload.wikimedia.org/wikipedia/en/3/36/GoldenEye007box.jpg'),
        (19, CURRENT_TIMESTAMP, 'PlayStation 3 Game', 'Uncharted 2: Among Thieves', CAST('2009-10-13 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/61bfoo-Z9cL.jpg'),
        (20, CURRENT_TIMESTAMP, 'Nintendo Gamecube Game', 'Resident Evil 4', CAST('2005-1-11 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://upload.wikimedia.org/wikipedia/en/d/d9/Resi4-gc-cover.jpg'),
        (21, CURRENT_TIMESTAMP, 'PlayStation 3 Game', 'Batman: Arkham City', CAST('2011-10-18 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://1.bp.blogspot.com/-RaTxp5ajcNc/TfpQ50ApvCI/AAAAAAAAFkQ/AIjaHa9mdJQ/s1600/Arkham-City-PS3-Cover-Artwork_5.jpg'),
        (22, CURRENT_TIMESTAMP, 'PlayStation 1 Game', 'Tekken 3', CAST('1998-4-29 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://static.wikia.nocookie.net/gamia_gamepedia_en/images/9/99/Front-Cover-Tekken-3-EU-PS1.jpg/revision/latest?cb=20180806163905'),
        (23, CURRENT_TIMESTAMP, 'Xbox Series X Game', 'Elden Ring', CAST('2022-2-25 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/81AXuMBqy9L._AC_UF1000,1000_QL80_.jpg'),
        (24, CURRENT_TIMESTAMP, 'Xbox 360 Game', 'Mass Effect 2', CAST('2010-1-26 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://i.ebayimg.com/images/g/JJMAAOSwHZhhYTPc/s-l1600.jpg'),
        (25, CURRENT_TIMESTAMP, 'Nintendo Gamecube Game', 'The Legend of Zelda: Twilight Princess', CAST('2006-12-11 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/51I25VxTAfL.jpg'),
        (26, CURRENT_TIMESTAMP, 'Xbox 360 Game', 'The Elder Scrolls 5: Skyrim', CAST('2011-11-11 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/91nOykIoY3L.jpg'),
        (27, CURRENT_TIMESTAMP, 'Nintendo Gamecube Game', 'The Legend of Zelda: The Wind Waker', CAST('2003-3-24 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://wiki.dolphin-emu.org/images/9/98/Wind_waker_boxart.jpg'),
        (28, CURRENT_TIMESTAMP, 'PlayStation 1 Game', 'Gran Turismo', CAST('1998-4-30 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://i.ebayimg.com/images/g/05YAAOSwlxRaaLU5/s-l300.jpg'),
        (29, CURRENT_TIMESTAMP, 'PlayStation 2 Game', 'Metal Gear Solid 2: Sons of Liberty', CAST('2001-11-12 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://cdn.staticneo.com/boxshots/MjAwNS8=/metal_gear_solid_2_sons_of_liberty_frontcover_large_NICQvk5nPZUjp8Y.jpg'),
        (30, CURRENT_TIMESTAMP, 'Nintendo Switch Game', 'Persona 5 Royal', CAST('2022-10-21 00:00:00.000' AS DATETIME), CURRENT_TIMESTAMP, 'https://m.media-amazon.com/images/I/81qu57lDKpL.jpg');
   
SET IDENTITY_INSERT Gamezone.dbo.products OFF;

SET IDENTITY_INSERT Gamezone.dbo.product_variants ON;
      
INSERT INTO product_variants (id, condition_id, edition_id, price, product_id)
VALUES (1, 1, 1, 10.20, 1),
        (2, 1, 2, 15.10, 2),
        (3, 1, 3, 5.12, 3),
        (4, 2, 1, 40.22, 4),
        (5, 2, 2, 32.25, 5),
        (6, 2, 3, 12.11, 6),
        (7, 3, 1, 2.02, 7),
        (8, 3, 2, 11.11, 8),
        (9, 3, 3, 3.33, 9),
        (10, 1, 1, 31.31, 10),
        (11, 2, 1, 60, 11),
        (12, 3, 1, 21, 12),
        (13, 1, 2, 10.01, 13),
        (14, 2, 2, 9, 14),
        (15, 3, 2, 2, 15),
        (16, 1, 3, 45.21, 16),
        (17, 2, 3, 40.04, 17),
        (18, 3, 3, 12.43, 18),
        (19, 1, 2, 7.07, 19),
        (20, 1, 3, 4.31, 20),
        (21, 2, 1, 6.50, 21),
        (22, 2, 3, 17.90, 22),
        (23, 3, 1, 27, 23),
        (24, 3, 2, 30.08, 24),
        (25, 3, 2, 41.14, 25),
        (26, 3, 1, 18.89, 26),
        (27, 2, 3, 55, 27),
        (28, 2, 1, 5, 28),
        (29, 1, 3, 46.72, 29),
        (30, 1, 2, 60, 30);

SET IDENTITY_INSERT Gamezone.dbo.product_variants OFF;
