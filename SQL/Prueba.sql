-- Active: 1717616082372@@bplq440d2rkgpqobldeb-mysql.services.clever-cloud.com@3306
CREATE TABLE Students(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125),
    BirthDate DATE,
    Address VARCHAR(125),
    Email VARCHAR(125)
);

CREATE TABLE Teachers(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125),
    Specialty VARCHAR(125),
    Phone VARCHAR(25),
    Email VARCHAR(125),
    YearsExperience INT
);

CREATE TABLE Courses(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125),
    Description TEXT,
    TeacherId INT,
    Schedule VARCHAR(125),
    Duration VARCHAR(50),
    Capacity INT
);

CREATE TABLE Enrollments(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Date DATE,
    StudentId INTEGER(10),
    CourseId INTEGER(10),
    Status ENUM("paid", "pending payment", "cancelled")
);

SELECT * FROM Students;

ALTER TABLE Courses ADD FOREIGN KEY (TeacherId) REFERENCES Teachers(Id);

ALTER TABLE Enrollments ADD FOREIGN KEY (StudentId) REFERENCES Students(Id);

ALTER TABLE Enrollments ADD FOREIGN KEY (CourseId) REFERENCES Courses(Id);

INSERT INTO Students(Names, BirthDate, Address, Email) VALUES
('John Doe', '1990-05-15', '123 Main St, City, State, Zip', 'johndoe@example.com'),
('Jane Smith', '1985-12-20', '456 Elm St, City, State, Zip', 'janesmith@example.com'),
('Michael Johnson', '1995-03-10', '789 Oak St, City, State, Zip', 'ichaeljohnson@example.com'),
('Emily Davis', '1988-07-02', '321 Pine St, City, State, Zip', 'emilydavis@example.com'),
('David Wilson', '1992-09-18', '654 Maple St, City, State, Zip', 'davidwilson@example.com'),
('Sophia Brown', '1987-04-25', '987 Cedar St, City, State, Zip', 'ophiabrown@example.com'),
('Olivia Miller', '1993-11-08', '246 Birch St, City, State, Zip', 'oliviamiller@example.com'),
('James Anderson', '1989-06-12', '579 Hickory St, City, State, Zip', 'jamesanderson@example.com'),
('Ava Taylor', '1991-08-30', '864 Walnut St, City, State, Zip', 'avataylor@example.com'),
('Benjamin Wilkinson', '1994-10-22', '147 Cherry St, City, State, Zip', 'benjaminwilkinson@example.com');

INSERT INTO Teachers(Names, Specialty, Phone, Email, YearsExperience) VALUES
('Dr. Emily Thompson', 'Mathematics', '+1 123-456-7890', 'dr.emilythompson@example.com', 15),
('Prof. Michael Johnson', 'Physics', '+1 987-654-3210', 'prof.michaeljohnson@example.com', 20),
('Dr. Jane Smith', 'Chemistry', '+1 555-555-5555', 'dr.janesmith@example.com', 18),
('Prof. David Wilson', 'Biology', '+1 444-444-4444', 'prof.davidwilson@example.com', 22),
('Dr. Sophia Brown', 'English', '+1 333-333-3333', 'dr.sophiabrown@example.com', 17),
('Prof. Olivia Miller', 'History', '+1 222-222-2222', 'prof.oliviamiller@example.com', 25),
('Dr. James Anderson', 'Geography', '+1 111-111-1111', 'dr.jamesanderson@example.com', 19);

INSERT INTO Courses(Name, Description, TeacherId, Schedule, Duration, Capacity) VALUES
('Mathematics 101', 'Introduction to algebra and calculus.', 1, 'MWF 9:00 AM - 10:15 AM', '1 semester', 30),
('Physics 101', 'Fundamentals of physics for science majors.', 2, 'TTh 11:00 AM - 12:15 PM', '1 semester', 25),
('Chemistry 101', 'General chemistry for non-science majors.', 3, 'MWF 1:00 PM - 2:15 PM', '1 semester', 28),
('Biology 101', 'Introduction to biology for science majors.', 4, 'TTh 2:30 PM - 3:45 PM', '1 semester', 32),
('English 101', 'Basic English grammar and composition.', 5, 'MWF 11:00 AM - 12:15 PM', '1 semester', 27),
('History 101', 'Introduction to world history.', 6, 'TTh 9:00 AM - 10:15 AM', '1 semester', 29),
('Geography 101', 'Introduction to geography for non-science majors.', 7, 'MWF 2:30 PM - 3:45 PM', '1 semester', 31);

INSERT INTO Enrollments(Date, StudentId, CourseId, Status) VALUES
('2022-01-01', 1, 1, 'paid'),
('2022-01-01', 2, 2, 'pending payment');