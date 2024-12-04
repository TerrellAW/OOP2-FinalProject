On initialization the program will send a fetch request to the VisualCrossing weather API and parse the JSON information into Weather objects, which are added to weatherList.
A connection to the MariaDB MySQL server will be made and then a database and table will be created if they don't already exist.

After these background processes complete the UI will be loaded. The Nav Menu contains icons imported from bootstrap which must be imported from the internet.
The Home page contains a Calendar component that uses system time to determine the current date, which it will display when it first renders.
