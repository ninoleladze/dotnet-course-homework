-- Domain: company employees carry out projects; an employee's position can
-- differ per project; tasks are issued to an employee with a deadline and
-- go through a sequence of statuses, each recorded with the date and the
-- employee who set it. Schema is normalized to 3NF: lookup tables remove
-- repeating text values, EmployeeProjects resolves the M:N employee/project
-- relationship (with a per-project position), and TaskStatusHistory records
-- each status change instead of overwriting a single status column.

CREATE TABLE Positions (
    PositionId INTEGER PRIMARY KEY,
    PositionName TEXT NOT NULL UNIQUE
);

CREATE TABLE ProjectStatuses (
    ProjectStatusId INTEGER PRIMARY KEY,
    StatusName TEXT NOT NULL UNIQUE
);

CREATE TABLE TaskStatuses (
    TaskStatusId INTEGER PRIMARY KEY,
    StatusName TEXT NOT NULL UNIQUE
);

CREATE TABLE Employees (
    EmployeeId INTEGER PRIMARY KEY,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Email TEXT NOT NULL UNIQUE,
    HireDate DATE NOT NULL CHECK (HireDate BETWEEN '2000-01-01' AND '2100-01-01')
);

CREATE TABLE Projects (
    ProjectId INTEGER PRIMARY KEY,
    ProjectName TEXT NOT NULL,
    CreationDate DATE NOT NULL CHECK (CreationDate BETWEEN '2000-01-01' AND '2100-01-01'),
    ClosureDate DATE CHECK (ClosureDate BETWEEN '2000-01-01' AND '2100-01-01'),
    ProjectStatusId INTEGER NOT NULL,
    FOREIGN KEY (ProjectStatusId) REFERENCES ProjectStatuses(ProjectStatusId)
);

CREATE TABLE EmployeeProjects (
    EmployeeProjectId INTEGER PRIMARY KEY,
    EmployeeId INTEGER NOT NULL,
    ProjectId INTEGER NOT NULL,
    PositionId INTEGER NOT NULL,
    AssignedDate DATE NOT NULL CHECK (AssignedDate BETWEEN '2000-01-01' AND '2100-01-01'),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId),
    FOREIGN KEY (PositionId) REFERENCES Positions(PositionId)
);

CREATE TABLE Tasks (
    TaskId INTEGER PRIMARY KEY,
    ProjectId INTEGER NOT NULL,
    EmployeeId INTEGER NOT NULL,
    TaskName TEXT NOT NULL,
    Deadline DATE NOT NULL CHECK (Deadline BETWEEN '2000-01-01' AND '2100-01-01'),
    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

CREATE TABLE TaskStatusHistory (
    TaskStatusHistoryId INTEGER PRIMARY KEY,
    TaskId INTEGER NOT NULL,
    TaskStatusId INTEGER NOT NULL,
    StatusDate DATE NOT NULL CHECK (StatusDate BETWEEN '2000-01-01' AND '2100-01-01'),
    SetByEmployeeId INTEGER NOT NULL,
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
    FOREIGN KEY (TaskStatusId) REFERENCES TaskStatuses(TaskStatusId),
    FOREIGN KEY (SetByEmployeeId) REFERENCES Employees(EmployeeId)
);
