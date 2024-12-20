On initialization the program will send a fetch request to the VisualCrossing weather API and parse the JSON information into Weather objects, which are added to weatherList.
A connection to the MariaDB MySQL server will be made and then a database and table will be created if they don't already exist.

After these background processes complete the UI will be loaded. The Nav Menu contains bootstrap icons which must be imported from the internet.
The Home page contains a Calendar component that uses system time to determine the current date, which it will display when it first renders. The user can switch which month is displayed and select a day.
When a day is selected the Day page will appear as a popup with basic information about any events on that day and the weather. Weather data is only available for the next 15 days. The user will see one or two buttons in the Day popup. If there is an event on that day, they will see a button which will redirect them to the Event Viewer page with that day's event pre-selected. The other button the user will see is the Create New Event button which will redirect them to the New Event page with the date pre-filled with the date that was selected on the Calendar component. The user can fill out the rest of the information and push the button at the bottom of the form to add their newly created event to the database. 

These features allow users to record, organize and manage scheduled events.
