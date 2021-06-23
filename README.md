## Blazor WebAssembly Subtitles manager
An application builts with Blazor Framework using the client-side hosting model with WebAssembly in the browser. 



### Features
The user can enter the specification of the movie by filling in the form, adding a poster in order to save the record in the database. Then the user add subtitles file with description.

- connecting a web application made in C # technology and using the Blazor framework with an SQL database;
- connection made using Dapper ORM technology
- the ability to create, edit, delete and display movie records and the corresponding subtitles, the 'movies' table has a 1: N relationship with the subtitles table;
- upload of movie posters, which are saved in the database after conversion to a string of base64 type;
- validation of forms on the backend, where in the case of incorrectly filled fields the correct message is displayed in the frontend;
- dictionary data (names of film types and languages) contained in the ENUM data structure;
- pagination of displayed records from the database (division of the list into subpages, possible to switch over);
- search engine among movie records in terms of two columns in the list of records downloaded from the database;
- the ability to sort the displayed results by clicking on the column name;
- subtitles text files are saved on the server after adding a string containing the current date and time to the file name in order to make individual files unique;
- vertical menu made with collapse (menu sub-elements expand and collapse when clicked with the cursor);
- layout designed on the basis of Bootstrap grid;


#### Screenshots
Current database schema
![image](https://user-images.githubusercontent.com/46069709/122454894-1b0b9300-cfac-11eb-84f5-30cad086d0e9.png)

Control panel
![image](https://user-images.githubusercontent.com/46069709/122455709-fd8af900-cfac-11eb-815d-738dbb44924a.png)

Example of form validation
![image](https://user-images.githubusercontent.com/46069709/122455123-5908b700-cfac-11eb-987b-282e20b8bef5.png)

Movie view
![image](https://user-images.githubusercontent.com/46069709/122455599-db917680-cfac-11eb-87bd-655af1295926.png)

Form modal
![image](https://user-images.githubusercontent.com/46069709/122456355-be10dc80-cfad-11eb-8ae2-4d5631f1565b.png)



### TODO:
- [ ] Views refactor
- [ ] Uploaded files veryfication
- [ ] Authorization, authentication ( 3 groups of users)
..* Moderators can edit and delete any entries
..* Typical users can add movies and subtitles and rate subtitles
- [ ] Rating of subtitles service 
- [x] Forms and models validation
- [x] Modal with adding subtitles form

