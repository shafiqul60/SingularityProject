# SingularityProject
here i have used code first approach 
So at first need to change your connection string accroding to your sql server name
<connectionStrings>
    <add name="DefaultConnection" connectionString="Server=Your sql server Entity Name; Database=SingularityProjectDB; Integrated Security=true;" providerName="System.Data.SqlClient" />
</connectionStrings>

After that u have to do migration run below code

update-database

then build the solution and run

