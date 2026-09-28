CREATE TABLE Manufacturer (
    ManufacturerId INTEGER PRIMARY KEY,
    ManufacturerName VARCHAR NOT NULL UNIQUE
);

CREATE TABLE Brand (
    BrandId INTEGER PRIMARY KEY,
    BrandName VARCHAR NOT NULL UNIQUE
);

CREATE TABLE MatrixType (
    MatrixTypeId INTEGER PRIMARY KEY,
    MatrixTypeName VARCHAR NOT NULL UNIQUE
);

CREATE TABLE ScreenResolution (
    ScreenResolutionId INTEGER PRIMARY KEY,
    ResolutionWidth INTEGER NOT NULL CHECK (ResolutionWidth > 0),
    ResolutionHeight INTEGER NOT NULL CHECK (ResolutionHeight > 0)
);

CREATE TABLE Position (
    PositionId INTEGER PRIMARY KEY,
    PositionName VARCHAR NOT NULL UNIQUE
);

CREATE TABLE OrderState (
    OrderStateId INTEGER PRIMARY KEY,
    StateName VARCHAR NOT NULL UNIQUE
);

CREATE TABLE PaymentMethod (
    PaymentMethodId INTEGER PRIMARY KEY,
    PaymentMethodName VARCHAR NOT NULL UNIQUE
);

CREATE TABLE SparePart (
    SparePartId INTEGER PRIMARY KEY,
    PartName VARCHAR NOT NULL,
    UnitPrice DECIMAL NOT NULL CHECK (UnitPrice >= 0)
);

CREATE TABLE Owner (
    OwnerId INTEGER PRIMARY KEY,
    LastName VARCHAR NOT NULL,
    FirstName VARCHAR NOT NULL
);

CREATE TABLE SmartphoneModel (
    SmartphoneModelId INTEGER PRIMARY KEY,
    ModelName VARCHAR NOT NULL,
    RamSizeGb INTEGER NOT NULL CHECK (RamSizeGb > 0),
    RomSizeGb INTEGER NOT NULL CHECK (RomSizeGb > 0),
    ManufactureYear INTEGER NOT NULL CHECK (ManufactureYear BETWEEN 1990 AND 2100),
    BrandId INTEGER NOT NULL,
    ManufacturerId INTEGER NOT NULL,
    MatrixTypeId INTEGER NOT NULL,
    ScreenResolutionId INTEGER NOT NULL,
    FOREIGN KEY (BrandId) REFERENCES Brand(BrandId),
    FOREIGN KEY (ManufacturerId) REFERENCES Manufacturer(ManufacturerId),
    FOREIGN KEY (MatrixTypeId) REFERENCES MatrixType(MatrixTypeId),
    FOREIGN KEY (ScreenResolutionId) REFERENCES ScreenResolution(ScreenResolutionId)
);

CREATE TABLE Employee (
    EmployeeId INTEGER PRIMARY KEY,
    LastName VARCHAR NOT NULL,
    FirstName VARCHAR NOT NULL,
    PositionId INTEGER NOT NULL,
    FOREIGN KEY (PositionId) REFERENCES Position(PositionId)
);

CREATE TABLE OwnerPhone (
    OwnerPhoneId INTEGER PRIMARY KEY,
    OwnerId INTEGER NOT NULL,
    PhoneNumber VARCHAR NOT NULL UNIQUE,
    FOREIGN KEY (OwnerId) REFERENCES Owner(OwnerId)
);

CREATE TABLE Device (
    DeviceId INTEGER PRIMARY KEY,
    SmartphoneModelId INTEGER NOT NULL,
    OwnerId INTEGER NOT NULL,
    FOREIGN KEY (SmartphoneModelId) REFERENCES SmartphoneModel(SmartphoneModelId),
    FOREIGN KEY (OwnerId) REFERENCES Owner(OwnerId)
);

CREATE TABLE DeviceImei (
    DeviceImeiId INTEGER PRIMARY KEY,
    DeviceId INTEGER NOT NULL,
    ImeiNumber VARCHAR NOT NULL UNIQUE,
    FOREIGN KEY (DeviceId) REFERENCES Device(DeviceId)
);

CREATE TABLE Receipt (
    ReceiptId INTEGER PRIMARY KEY,
    ReceiptNumber VARCHAR NOT NULL UNIQUE,
    DeviceId INTEGER NOT NULL,
    AcceptedByEmployeeId INTEGER NOT NULL,
    MalfunctionDescription VARCHAR NOT NULL,
    ReceivedDate DATE NOT NULL,
    FOREIGN KEY (DeviceId) REFERENCES Device(DeviceId),
    FOREIGN KEY (AcceptedByEmployeeId) REFERENCES Employee(EmployeeId)
);

CREATE TABLE Repair (
    RepairId INTEGER PRIMARY KEY,
    ReceiptId INTEGER NOT NULL UNIQUE,
    PerformedByEmployeeId INTEGER NOT NULL,
    MalfunctionDescription VARCHAR NOT NULL,
    OrderStateId INTEGER NOT NULL,
    AmountToPay DECIMAL NOT NULL CHECK (AmountToPay >= 0),
    FOREIGN KEY (ReceiptId) REFERENCES Receipt(ReceiptId),
    FOREIGN KEY (PerformedByEmployeeId) REFERENCES Employee(EmployeeId),
    FOREIGN KEY (OrderStateId) REFERENCES OrderState(OrderStateId)
);

CREATE TABLE Warranty (
    WarrantyId INTEGER PRIMARY KEY,
    RepairId INTEGER NOT NULL UNIQUE,
    WarrantyPeriodMonths INTEGER NOT NULL CHECK (WarrantyPeriodMonths > 0),
    FOREIGN KEY (RepairId) REFERENCES Repair(RepairId)
);

CREATE TABLE RepairSparePart (
    RepairSparePartId INTEGER PRIMARY KEY,
    RepairId INTEGER NOT NULL,
    SparePartId INTEGER NOT NULL,
    QuantityUsed INTEGER NOT NULL CHECK (QuantityUsed > 0),
    FOREIGN KEY (RepairId) REFERENCES Repair(RepairId),
    FOREIGN KEY (SparePartId) REFERENCES SparePart(SparePartId)
);

CREATE TABLE Payment (
    PaymentId INTEGER PRIMARY KEY,
    RepairId INTEGER NOT NULL,
    PaymentMethodId INTEGER NOT NULL,
    PaymentAmount DECIMAL NOT NULL CHECK (PaymentAmount >= 0),
    PaymentDate DATE NOT NULL,
    FOREIGN KEY (RepairId) REFERENCES Repair(RepairId),
    FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethod(PaymentMethodId)
);
