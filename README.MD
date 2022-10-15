# Console Flash Cards
### Project Overview
Code is organized in two projects: Console App For the front end and 
Class library for the back end. I decided to take this approach to decouple both project so that I can change the front end
in the future.
#### Functionalities
- Users can create stack of flash cards
- Stack table and Cards table are linked by foreign key
- Stacks Name are Uniques
- It manages relationship with cascade delete

### Technologies Used:
- **_MSSQL_** For data storage
- **_ADO.Net_** For Database Connection
- **_Microsoft.Extension.DependencyInjection_** For Dependency injection
- **_Newtonsoft.Json_** For Object serialization and Deserialization