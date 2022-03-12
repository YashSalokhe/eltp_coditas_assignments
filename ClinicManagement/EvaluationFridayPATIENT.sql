create database Clinic;
use Clinic;


create table Patient_info (
	
	PatientId int IDENTITY(1,1) PRIMARY KEY,
	PatientName varchar(50) NOT NULL,
	MobileNumber varchar(10) NOT NULL,
	PatientAddress varchar(100) NOT NULL,
	Age int,
);


create table PatientBill(
	billnumber int IDENTITY(1,1) PRIMARY KEY,
	PatientId int not null REFERENCES Patient_info(PatientId),
	fees int not null,
	currentdate date default cast(getdate() as date)
)

create table Records (
	RecordId int IDENTITY(1,1) PRIMARY KEY,
	PatientId int not null REFERENCES Patient_info(PatientId),
	PatientName varchar(50) NOT NULL,

	PatientWeight float NOT NULL,
	PatientHeight float NOT NULL,
	BloodPressure varchar(50),
	Cholestrol varchar(50),
	Sugar varchar(10),
	MedicineSubscribed varchar(1000),
	AppointmentDate Date,  /*yyyy-mm-dd*/
);


select *from Patient_info;
select *from Records;
select*from PatientBill;

insert into Records(PatientId,PatientName,PatientWeight ,PatientHeight ,BloodPressure,Cholestrol,Sugar,MedicineSubscribed,AppointmentDate) values(1,'Yash',60,175,'Normal','CDL','Yes','Adulsa','2022-05-12')

/*
drop table Records;
drop table Patient_MedInfo;
drop table PatientBill;
*/
