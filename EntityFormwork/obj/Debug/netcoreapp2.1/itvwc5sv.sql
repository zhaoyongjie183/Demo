  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `Blog` (
    `BlogId` int NOT NULL AUTO_INCREMENT,
    `Url` varchar(20) NOT NULL,
    `BlogTitle` varchar(50) NULL,
    PRIMARY KEY (`BlogId`)
);

CREATE TABLE `Post` (
    `PostId` int NOT NULL AUTO_INCREMENT,
    `Title` text NULL,
    `Content` text NULL,
    `BlogId` int NOT NULL,
    PRIMARY KEY (`PostId`),
    CONSTRAINT `FK_Post_Blog_BlogId` FOREIGN KEY (`BlogId`) REFERENCES `Blog` (`BlogId`) ON DELETE CASCADE
);

CREATE INDEX `IX_Post_BlogId` ON `Post` (`BlogId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190717151621_InitialCreate', '2.2.4-servicing-10062');

