# SingularityProject
here i have used code first approach thats why i didnt upload db 
So at first need to change your connection string from webconfing as well as appconfig accroding to your sql server name
<connectionStrings>
    <add name="DefaultConnection" connectionString="Server=Your sql server Entity Name; Database=SingularityProjectDB; Integrated Security=true;" providerName="System.Data.SqlClient" />
</connectionStrings>

After that u have to do migration run below code

update-database

then build the solution and run

For admin Login 
username: admin
pass:123456

For User login 
username: user 
pass: 123456

you can create own user account having signup

