USE Chesed_DataBase;
GO

-- Tabla de Categorías
CREATE TABLE Category (
    Id INT IDENTITY(1,1) PRIMARY KEY,       -- Código de categoría, auto-incremental
    Name NVARCHAR(100) NOT NULL              -- Nombre de la categoría
);

-- Tabla de Usuarios (Volunteers)
CREATE TABLE Volunteer (
    Id INT IDENTITY(1,1) PRIMARY KEY,       -- Código del voluntario
    TZ INT NOT NULL,                         -- Número de identificación (ת.ז)
    FullName NVARCHAR(100) NOT NULL,         -- Nombre completo
    Number NVARCHAR(20),                     -- Teléfono
    Email NVARCHAR(100),                     -- Email
    Password NVARCHAR(100),                  -- Contraseña
    Address NVARCHAR(200),                   -- Dirección
    Latitude FLOAT,                          -- Latitud
    Longitude FLOAT,                         -- Longitud
    Job BIT NOT NULL,                        -- 0=Voluntario, 1=Director
    MaxDistance FLOAT,                        -- Distancia máxima
    DistanceType INT                          -- Tipo de distancia (ej: 0=Walk,1=Car)
);

-- Tabla de Calls (Solicitudes de voluntariado)
CREATE TABLE Call (
    Id INT IDENTITY(1,1) PRIMARY KEY,       -- Código de la llamada
    Description NVARCHAR(500),              -- Descripción
    CategoryId INT NOT NULL,                -- Código de categoría
    AddressCall NVARCHAR(200),              -- Dirección de la llamada
    Latitude FLOAT,                          -- Latitud
    Longitude FLOAT,                         -- Longitud
    DateAdded DATETIME NOT NULL DEFAULT GETDATE(),  -- Fecha de apertura
    VolunteerId INT NULL,                    -- Voluntario asignado (opcional)
    FOREIGN KEY (CategoryId) REFERENCES Category(Id),  -- Relación con categoría
    FOREIGN KEY (VolunteerId) REFERENCES Volunteer(Id) -- Relación con voluntario
);

