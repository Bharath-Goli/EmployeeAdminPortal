
use EmployeeDB;
CREATE TABLE Employee (
    EmployeeID INT  PRIMARY KEY,
    EmployeeName varchar(50),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(15),
    Salary DECIMAL(10, 2),

);
INSERT INTO Employee (EmployeeID, EmployeeName, Email, PhoneNumber, Salary)
VALUES (1, 'Bharath Sai ESwar', 'bharathsaieswar@gmail.com', '834-1176-474', 20000.00);


select * from Employee;