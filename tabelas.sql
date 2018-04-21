CREATE TABLE [dbo].[Filmes] (
    [id_filme]   INT          NOT NULL,
    [nome_filme] VARCHAR (50) NOT NULL,
    [genero]     INT          NOT NULL,
    [duracao]    TIME (7)     NOT NULL,
    PRIMARY KEY CLUSTERED ([id_filme] ASC),
    CONSTRAINT [FK_Filmes_ToTable] FOREIGN KEY ([genero]) REFERENCES [dbo].[Genero] ([id_genero])
);

CREATE TABLE [dbo].[Genero] (
    [id_genero] INT          NOT NULL,
    [genero]    VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_genero] ASC)
);

CREATE TABLE [dbo].[Reserva_Lugares] (
    [id_reserva] INT       NOT NULL,
    [lugar]      NCHAR (3) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_reserva] ASC, [lugar] ASC)
);

CREATE TABLE [dbo].[Reservas] (
    [id_reserva]    INT      IDENTITY (1, 1) NOT NULL,
    [id_filme]      INT      NOT NULL,
    [id_sala]       INT      NOT NULL,
    [hora_inicio]   TIME (7) NOT NULL,
    [referencia]    INT      NOT NULL,
    [id_utilizador] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([id_reserva] ASC, [id_filme] ASC, [id_sala] ASC),
    CONSTRAINT [FK_Reservas_ToTable] FOREIGN KEY ([id_utilizador]) REFERENCES [dbo].[Utilizadores] ([id_utilizador])
);

CREATE TABLE [dbo].[Salas] (
    [id_sala]   INT          NOT NULL,
    [nome_sala] VARCHAR (50) NOT NULL,
    [lotacao]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([id_sala] ASC)
);

CREATE TABLE [dbo].[Utilizadores] (
    [id_utilizador] INT          NOT NULL,
    [nome]          VARCHAR (50) NOT NULL,
    [n_telefone]    NUMERIC (9)  NOT NULL,
    [email]         VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([id_utilizador] ASC)
);