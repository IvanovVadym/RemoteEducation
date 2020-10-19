use RemoteEducationIdentity;
go

select * from users


insert into users(
Created,
CreatedBy,
UserName,
Email,
Password,
FirstName,
LastName,
Role,
IsDeleted
)
values
('2020-10-19', 'admin', 'admin', 'ivanovvvadym@gmail.com', '123456', 'Admin', 'Super', 'Admin', 0)