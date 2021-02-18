create table Users (
LoginUser varchar(20) 
	constraint PK_Users primary key,
PasswordUser varchar(15),
UserStatus varchar(5) 
	constraint C_Users check (UserStatus = 'ADMIN' or UserStatus = 'USER')
);

create table Rooms (
Room_ID int 
	constraint PK_Rooms primary key
);

create table Days_of_week (
Day_of_week varchar(10) 
	constraint C_Day_of_week check (Day_of_week in ('MONDAY', 'TUESDAY', 'WEDNESDAY', 'THURSDAY', 'FRIDAY'))
	constraint PK_Days_of_week primary key
);

create table Lessons (
Lesson_ID int 
	constraint C_LessonID check (Lesson_ID between 1 and 8)
	constraint PK_Lessons primary key,
Time_Begin varchar(5)
	constraint C_Time_Begin check (Time_Begin like '__:__'),
Time_End varchar(5)
	constraint C_Time_End check (Time_End like '__:__')
);

create table Teachers (
FIO varchar(50) 
	constraint PK_Teachers primary key
);

create table Subjects (
Name_subject varchar(50) 
	constraint PK_Subjects primary key
);

create table Specialization (
FIO varchar(50) not null 
	constraint FK_Specialization_Teachers foreign key references Teachers(FIO)
	on delete cascade on update cascade,
Name_subject varchar(50) not null
	constraint FK_Specialization_Subjects foreign key references Subjects(Name_subject)
	on delete cascade on update cascade,

constraint PK_Specialization primary key (FIO, Name_subject)
);

create table Classes_Loading (
Study_year int
	constraint C_Study_year check (Study_year between 1 and 11)
	constraint PK_Class_Loading primary key,
Year_loading int default 0
);

create table Study_Plan (
Study_year int not null
	constraint FK_Study_Plan_Classes_Loading foreign key references Classes_Loading(Study_year)
	on delete cascade on update cascade,
Name_subject varchar(50) not null
	constraint FK_Study_Plan_Subjects foreign key references Subjects(Name_subject)
	on delete cascade on update cascade,
Year_loading int default 0,

constraint PK_Study_Plan primary key (Study_year, Name_subject)
);

create table Classes (
Study_year int not null 
	constraint FK_Classes_Classes_Loading foreign key references Classes_Loading(Study_year)
	on delete cascade on update cascade,
Letter_class varchar(1) not null,
Number_of_pupils int default 0,

constraint PK_Classes primary key (Study_year, Letter_class)
);

create table Timetable (
Number_of_week int not null
	constraint C_Number_of_week check (Number_of_week = 0 or Number_of_week = 1),
Day_of_week varchar(10) not null
	constraint FK_Timetable_Days_of_week foreign key references Days_of_week(Day_of_week)
	on delete cascade on update cascade,
Room_ID int not null
	constraint FK_Timetable_Rooms foreign key references Rooms(Room_ID)
	on delete cascade on update cascade,
Lesson_ID int not null
	constraint FK_Timetable_Lessons foreign key references Lessons(Lesson_ID)
	on delete cascade on update cascade,
FIO_Teacher varchar(50) not null
	constraint FK_Timetable_Teachers foreign key references Teachers(FIO)
	on delete cascade on update cascade,
Name_subject varchar(50) not null
	constraint FK_Timetable_Subjects foreign key references Subjects(Name_subject)
	on delete cascade on update cascade,
Study_year int not null,
Letter_class varchar(1) not null,

constraint FK_Timetable_Classes foreign key (Study_year, Letter_class) references Classes(Study_year, Letter_class)
	on delete cascade on update cascade,
constraint PK_Timetable primary key (Number_of_week, Day_of_week, Room_ID, Lesson_ID)
);