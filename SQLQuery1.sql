create database TrainingStudent3
go
use TrainingStudent3
create table CourseCategory(
	CategoryID int IDENTITY(1,1) primary key,
	CategoryName nvarchar(100),
)
go
create table Course(
	CourseID int IDENTITY(1,1) primary key,
	CourseName nvarchar(100),
	CategoryID int references CourseCategory(CategoryID),
)
go
create table Trainer(
	TrainerID int IDENTITY(1,1) primary key,
	TrainerName nvarchar(100),
	WorkPlace nvarchar(100),
	Phone int,
	Email nvarchar(100),
	
)
create table Trainee(
	TraineeID int IDENTITY(1,1) primary key,
	TraineeName nvarchar(100),
	Majors nvarchar(100),
	Phone int,
	Classroom nvarchar(100),
	Location nvarchar(100)	
)
go

create table Enrollment(
	EnrollmentID int IDENTITY (1,1) primary key,
	CourseID int references Course(CourseID),
	TraineeID int references Trainee(TraineeID),
	TrainerID int references Trainer(TrainerID)
)

go
create table Topic(
	TopicID int  IDENTITY(1,1) primary key,
	TopicName nvarchar(100),
	CourseID int references Course(CourseID),
	TrainerID int references Trainer(TrainerID),
	Description nvarchar(100)
)
go



