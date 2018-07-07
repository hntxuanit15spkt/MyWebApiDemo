
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/30/2018 17:33:31
-- Generated from EDMX file: E:\laptrinhkhac\thuc tap\MyWebApi\MyWebApi\School.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [School];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Course__TeacherI__1A14E395]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courses] DROP CONSTRAINT [FK__Course__TeacherI__1A14E395];
GO
IF OBJECT_ID(N'[dbo].[FK__Student__Standar__117F9D94]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK__Student__Standar__117F9D94];
GO
IF OBJECT_ID(N'[dbo].[FK__Teacher__Standar__173876EA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teachers] DROP CONSTRAINT [FK__Teacher__Standar__173876EA];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentStudentAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentAddresses] DROP CONSTRAINT [FK_StudentStudentAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Course];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Standards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Standards];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teachers];
GO
IF OBJECT_ID(N'[dbo].[StudentAddresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentAddresses];
GO
IF OBJECT_ID(N'[dbo].[StudentCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentCourse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [CourseId] bigint IDENTITY(1,1) NOT NULL,
    [CourseName] nvarchar(200)  NULL,
    [Location] nvarchar(200)  NULL,
    [TeacherId] bigint  NULL
);
GO

-- Creating table 'Standards'
CREATE TABLE [dbo].[Standards] (
    [StandardId] bigint IDENTITY(1,1) NOT NULL,
    [StandardName] nvarchar(200)  NULL,
    [Description] nvarchar(200)  NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [StudentId] bigint IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(200)  NULL,
    [LastName] nvarchar(200)  NULL,
    [StandardId] bigint  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Teachers'
CREATE TABLE [dbo].[Teachers] (
    [TeacherId] bigint IDENTITY(1,1) NOT NULL,
    [TeacherName] nvarchar(200)  NULL,
    [StandardId] bigint  NULL
);
GO

-- Creating table 'StudentAddresses'
CREATE TABLE [dbo].[StudentAddresses] (
    [StudentId] int  NOT NULL,
    [Address1] nvarchar(max)  NOT NULL,
    [Address2] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Student_StudentId] bigint  NOT NULL
);
GO

-- Creating table 'StudentCourse'
CREATE TABLE [dbo].[StudentCourse] (
    [Students_StudentId] bigint  NOT NULL,
    [Courses_CourseId] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CourseId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([CourseId] ASC);
GO

-- Creating primary key on [StandardId] in table 'Standards'
ALTER TABLE [dbo].[Standards]
ADD CONSTRAINT [PK_Standards]
    PRIMARY KEY CLUSTERED ([StandardId] ASC);
GO

-- Creating primary key on [StudentId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TeacherId] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([TeacherId] ASC);
GO

-- Creating primary key on [StudentId] in table 'StudentAddresses'
ALTER TABLE [dbo].[StudentAddresses]
ADD CONSTRAINT [PK_StudentAddresses]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [Students_StudentId], [Courses_CourseId] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [PK_StudentCourse]
    PRIMARY KEY CLUSTERED ([Students_StudentId], [Courses_CourseId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TeacherId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK__Course__TeacherI__1A14E395]
    FOREIGN KEY ([TeacherId])
    REFERENCES [dbo].[Teachers]
        ([TeacherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Course__TeacherI__1A14E395'
CREATE INDEX [IX_FK__Course__TeacherI__1A14E395]
ON [dbo].[Courses]
    ([TeacherId]);
GO

-- Creating foreign key on [StandardId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK__Student__Standar__117F9D94]
    FOREIGN KEY ([StandardId])
    REFERENCES [dbo].[Standards]
        ([StandardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Student__Standar__117F9D94'
CREATE INDEX [IX_FK__Student__Standar__117F9D94]
ON [dbo].[Students]
    ([StandardId]);
GO

-- Creating foreign key on [StandardId] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [FK__Teacher__Standar__173876EA]
    FOREIGN KEY ([StandardId])
    REFERENCES [dbo].[Standards]
        ([StandardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Teacher__Standar__173876EA'
CREATE INDEX [IX_FK__Teacher__Standar__173876EA]
ON [dbo].[Teachers]
    ([StandardId]);
GO

-- Creating foreign key on [Student_StudentId] in table 'StudentAddresses'
ALTER TABLE [dbo].[StudentAddresses]
ADD CONSTRAINT [FK_StudentStudentAddress]
    FOREIGN KEY ([Student_StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudentAddress'
CREATE INDEX [IX_FK_StudentStudentAddress]
ON [dbo].[StudentAddresses]
    ([Student_StudentId]);
GO

-- Creating foreign key on [Students_StudentId] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Student]
    FOREIGN KEY ([Students_StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Courses_CourseId] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Course]
    FOREIGN KEY ([Courses_CourseId])
    REFERENCES [dbo].[Courses]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourse_Course'
CREATE INDEX [IX_FK_StudentCourse_Course]
ON [dbo].[StudentCourse]
    ([Courses_CourseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------